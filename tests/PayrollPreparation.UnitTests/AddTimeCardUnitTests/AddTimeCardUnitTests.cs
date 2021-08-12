using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using PayrollPreparation.Application.AddTimeCard.CommandHandlers;
using PayrollPreparation.Application.AddTimeCard.Commands;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain;
using PayrollPreparation.Domain.Affiliation;
using PayrollPreparation.Domain.PaymentClassification;
using PayrollPreparation.Domain.PaymentMethod;
using PayrollPreparation.Domain.PaymentSchedule;
using Xunit;

namespace PayrollPreparation.UnitTests.AddTimeCardUnitTests
{
    public class AddTimeCardUnitTests
    {
        private readonly Fixture _fixture;
        private readonly AutoMocker _autoMocker;

        private readonly Mock<IPayrollDatasource> _mockPayrollDatasource;

        public AddTimeCardUnitTests()
        {
            _fixture = new Fixture();
            _autoMocker = new AutoMocker();

            _mockPayrollDatasource = _autoMocker.GetMock<IPayrollDatasource>();
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
            _mockPayrollDatasource
                .Setup(_ => _.GetEmployee(It.IsAny<Guid>()))
                .Returns(() => employee);

            var commandHandler = _autoMocker.CreateInstance<AddTimeCardCommandHandler>();
            
            //Act, Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await commandHandler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_WhenEmployeeExistAndPaymentClassificationExist_ThenAddTimeCard()
        {
            //Arrange
            var employee = _fixture
                .Build<Employee>()
                .With(x => x.PaymentMethod, new DirectMethod())
                .With(x => x.PaymentClassification, new HourlyClassification(_fixture.Create<double>()))
                .With(x => x.PaymentSchedule, new MonthlySchedule())
                .With(x => x.Affiliation, new NoAffiliation())
                .Create();
            
            _mockPayrollDatasource
                .Setup(_ => _.GetEmployee(It.IsNotNull<Guid>()))
                .Returns(() => employee);
            _mockPayrollDatasource
                .Setup(_ => _.UpdateEmployee(employee))
                .Returns(employee.Id);

            var command = _fixture.Create<AddTimeCardCommand>();
            var commandHandler = _autoMocker.CreateInstance<AddTimeCardCommandHandler>();

            //Act
            Guid employeeId = await commandHandler.Handle(command, CancellationToken.None);
            
            //Assert
            employeeId.Should().Be(employee.Id);
            _mockPayrollDatasource.Verify(_ => _.GetEmployee(It.IsNotNull<Guid>()), Times.Once);
            _mockPayrollDatasource.Verify(_ => _.UpdateEmployee(employee), Times.Once);
        }
    }
}