using PayrollPreparation.Application.ChangeEmployee.Commands.Basic;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.Basic
{
    public class ChangeEmployeeMailCommandHandler : ChangeEmployeeCommandHandler<ChangeEmployeeAddressCommand>
    {
        public ChangeEmployeeMailCommandHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
        }

        protected override void Change(Employee employee, ChangeEmployeeAddressCommand command)
        {
            employee.Address = command.Address;
        }
    }
}