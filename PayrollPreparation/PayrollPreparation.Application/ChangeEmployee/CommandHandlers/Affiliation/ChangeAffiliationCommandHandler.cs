using PayrollPreparation.Application.ChangeEmployee.Commands.Affiliation;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.Models;
using PayrollPreparation.Domain.Models.Affiliation;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.Affiliation
{
    public abstract class ChangeAffiliationCommandHandler<T> : ChangeEmployeeCommandHandler<T>
        where T : ChangeAffiliationCommand
    {
        protected ChangeAffiliationCommandHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
        }

        protected override void Change(Employee employee, T command)
        {
            employee.Affiliation = SetAffiliation(employee, command);
        }

        protected abstract IAffiliation SetAffiliation(Employee employee, T command);
    }
}