using PayrollPreparation.Application.ChangeEmployee.Commands.Basic;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.Basic
{
    public class ChangeEmployeeNameCommandHandler : ChangeEmployeeCommandHandler<ChangeEmployeeNameCommand>
    {
        public ChangeEmployeeNameCommandHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
        }

        protected override void Change(Employee employee, ChangeEmployeeNameCommand command)
        {
            employee.Name = command.Name;
        }
    }
}