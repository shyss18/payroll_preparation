using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using Moq.AutoMock;
using PayrollPreparation.Application.AddEmployee.CommandHandlers;
using PayrollPreparation.Application.AddEmployee.Commands;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain;
using Xunit;

namespace PayrollPreparation.UnitTests.AddEmployeeUnitTests
{
    public class AddCommissionedEmployeeUnitTests
    {
        private readonly Fixture _fixture;
        private readonly AutoMocker _autoMocker;

        private readonly Mock<IPayrollDatasource> _mockPayrollDatasource;

        public AddCommissionedEmployeeUnitTests()
        {
            _fixture = new Fixture();
            _autoMocker = new AutoMocker();

            _mockPayrollDatasource = _autoMocker.GetMock<IPayrollDatasource>();
        }

        [Fact]
        public async Task Handle_CreateCommissionedEmployee()
        {
            //Arrange
            _mockPayrollDatasource
                .Setup(_ => _.AddEmployee(It.IsNotNull<Employee>()))
                .Returns(() => _fixture.Create<Guid>());

            var command = _fixture.Create<AddCommissionedEmployeeCommand>();
            var commandHandler = _autoMocker.CreateInstance<AddCommissionedEmployeeCommandHandler>();

            //Act
            await commandHandler.Handle(command, CancellationToken.None);

            //Assert
            _mockPayrollDatasource.Verify(_ => _.AddEmployee(It.IsNotNull<Employee>()), Times.Once);
        }
    }
}