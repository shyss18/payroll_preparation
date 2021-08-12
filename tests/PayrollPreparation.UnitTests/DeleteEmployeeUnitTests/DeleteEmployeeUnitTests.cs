using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using Moq.AutoMock;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Application.DeleteEmployee.CommandHandlers;
using PayrollPreparation.Application.DeleteEmployee.Commands;
using Xunit;

namespace PayrollPreparation.UnitTests.DeleteEmployeeUnitTests
{
    public class DeleteEmployeeUnitTests
    {
        private readonly Fixture _fixture;
        private readonly AutoMocker _autoMocker;

        private readonly Mock<IPayrollDatasource> _mockPayrollDatasource;

        public DeleteEmployeeUnitTests()
        {
            _fixture = new Fixture();
            _autoMocker = new AutoMocker();

            _mockPayrollDatasource = _autoMocker.GetMock<IPayrollDatasource>();
        }

        [Fact]
        public async Task Handle_DeleteEmployee()
        {
            //Arrange
            _mockPayrollDatasource
                .Setup(_ => _.DeleteEmployee(It.IsNotNull<Guid>()))
                .Returns(() => _fixture.Create<Guid>());

            var command = _fixture.Create<DeleteEmployeeCommand>();
            var commandHandler = _autoMocker.CreateInstance<DeleteEmployeeCommandHandler>();

            //Act
            await commandHandler.Handle(command, CancellationToken.None);

            //Assert
            _mockPayrollDatasource.Verify(_ => _.DeleteEmployee(It.IsNotNull<Guid>()), Times.Once);
        }
    }
}