using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using PayrollPreparation.Application.AddServiceCharge.CommandHandlers;
using PayrollPreparation.Application.AddServiceCharge.Commands;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain;
using PayrollPreparation.Domain.Affiliation;
using PayrollPreparation.Domain.PaymentClassification;
using PayrollPreparation.Domain.PaymentMethod;
using PayrollPreparation.Domain.PaymentSchedule;
using Xunit;

namespace PayrollPreparation.UnitTests.AddServiceChargeUnitTests
{
    public class AddServiceChargeUnitTests
    {
        private readonly Fixture _fixture;
        private readonly AutoMocker _autoMocker;

        private readonly Mock<IPayrollDatasource> _mockPayrollDatasource;

        public AddServiceChargeUnitTests()
        {
            _fixture = new Fixture();
            _autoMocker = new AutoMocker();

            _mockPayrollDatasource = _autoMocker.GetMock<IPayrollDatasource>();
        }

        [Fact]
        public void Handle_WhenUnionMemberDidNotExist_ThenThrowInvalidOperationException()
        {
            //Arrange
            var commandHandler = _autoMocker.CreateInstance<AddServiceChargeCommandHandler>();

            //Act, Assert
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await commandHandler.Handle(_fixture.Create<AddServiceChargeCommand>(), CancellationToken.None));
        }

        [Fact]
        public async Task Handle_WhenUnionMemberExist_ThenAddServiceCharge()
        {
            //Arrange
            var employee = _fixture
                .Build<Employee>()
                .With(x => x.PaymentMethod, new DirectMethod())
                .With(x => x.PaymentClassification, new HourlyClassification(_fixture.Create<double>()))
                .With(x => x.PaymentSchedule, new MonthlySchedule())
                .With(x => x.Affiliation, new UnionAffiliation(_fixture.Create<double>()))
                .Create();

            _mockPayrollDatasource
                .Setup(_ => _.GetUnionMember(It.IsNotNull<Guid>()))
                .Returns(() => employee);
            _mockPayrollDatasource
                .Setup(_ => _.UpdateEmployee(employee))
                .Returns(employee.Id);

            var command = _fixture.Create<AddServiceChargeCommand>();
            var commandHandler = _autoMocker.CreateInstance<AddServiceChargeCommandHandler>();

            //Act
            Guid employeeId = await commandHandler.Handle(command, CancellationToken.None);

            //Assert
            employeeId.Should().Be(employee.Id);
            _mockPayrollDatasource.Verify(_ => _.GetUnionMember(It.IsNotNull<Guid>()), Times.Once);
            _mockPayrollDatasource.Verify(_ => _.UpdateEmployee(employee), Times.Once);
        }
    }
}