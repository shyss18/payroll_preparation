using System;
using System.Threading;
using AutoFixture;
using Moq;
using Moq.AutoMock;
using PayrollPreparation.Application.AddTimeCard.CommandHandlers;
using PayrollPreparation.Application.AddTimeCard.Commands;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.Models;
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
            var employee = _fixture.Create<Employee>();
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