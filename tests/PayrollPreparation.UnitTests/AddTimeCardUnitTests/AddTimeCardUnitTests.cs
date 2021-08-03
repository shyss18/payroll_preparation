using System;
using System.Threading;
using AutoFixture;
using Moq;
using Moq.AutoMock;
using PayrollPreparation.Application.AddTimeCard.CommandHandlers;
using PayrollPreparation.Application.AddTimeCard.Commands;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.Models;
using PayrollPreparation.Domain.Models.Affiliation;
using PayrollPreparation.Domain.Models.PaymentClassification;
using PayrollPreparation.Domain.Models.PaymentMethod;
using PayrollPreparation.Domain.Models.PaymentSchedule;
using Xunit;

namespace PayrollPreparation.UnitTests.AddTimeCardUnitTests
{
    public class AddTimeCardUnitTests
    {
        private readonly Fixture _fixture;
        private readonly AutoMocker _autoMocker;

        public AddTimeCardUnitTests()
        {
            _fixture = new Fixture();
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public void Handle_WhenEmployeeDidNotExist_ThenThrowInvalidOperationException()
        {
            //Arrange
            var commandHandler = _autoMocker.CreateInstance<AddTimeCardCommandHandler>();

            //Act, Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await commandHandler.Handle(_fixture.Create<AddTimeCardCommand>(), CancellationToken.None));
        }

        [Fact]
        public void Handle_WhenEmployeeExistAndPaymentClassificationDidNotExist_ThenThrowInvalidOperationException()
        {
            //Arrange
            var employee = _fixture
                .Build<Employee>()
                .With(x => x.PaymentMethod, new DirectMethod())
                .With(x => x.PaymentClassification, new SalariedClassification(_fixture.Create<decimal>()))
                .With(x => x.PaymentSchedule, new MonthlySchedule())
                .With(x => x.Affiliation, new NoAffiliation())
                .Create();

            employee.PaymentClassification = null;
            
            var command = _fixture.Create<AddTimeCardCommand>();
            var mockPayrollDatasource = _autoMocker.GetMock<IPayrollDatasource>();

            mockPayrollDatasource
                .Setup(_ => _.GetEmployee(It.IsAny<Guid>()))
                .Returns(() => employee);

            var commandHandler = _autoMocker.CreateInstance<AddTimeCardCommandHandler>();
            
            //Act, Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await commandHandler.Handle(command, CancellationToken.None));
        }
    }
}