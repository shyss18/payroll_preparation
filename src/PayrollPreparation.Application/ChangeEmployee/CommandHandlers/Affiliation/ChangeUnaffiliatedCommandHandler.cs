using PayrollPreparation.Application.ChangeEmployee.Commands.Affiliation;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain;
using PayrollPreparation.Domain.Affiliation;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.Affiliation
{
    public class ChangeUnaffiliatedCommandHandler : ChangeAffiliationCommandHandler<ChangeUnaffiliatedCommand>
    {
        private readonly IPayrollDatasource _payrollDatasource;

        public ChangeUnaffiliatedCommandHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
            _payrollDatasource = payrollDatasource;
        }

        protected override IAffiliation SetAffiliation(Employee employee, ChangeUnaffiliatedCommand command)
        {
            _payrollDatasource.RemoveUnionMember(command.EmployeeId);
            return new NoAffiliation();
        }
    }
}