using System;
using PayrollPreparation.Application.ChangeEmployee.Commands.Affiliation;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain;
using PayrollPreparation.Domain.Affiliation;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.Affiliation
{
    public class ChangeMemberCommandHandler : ChangeAffiliationCommandHandler<ChangeMemberCommand>
    {
        private readonly IPayrollDatasource _payrollDatasource;

        public ChangeMemberCommandHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
            _payrollDatasource = payrollDatasource;
        }

        protected override IAffiliation SetAffiliation(Employee employee, ChangeMemberCommand command)
        {
            _payrollDatasource.RemoveUnionMember(command.MemberId);
            _payrollDatasource.AddUnionMember(Guid.NewGuid(), employee);
            return new UnionAffiliation(command.Dues);
        }
    }
}