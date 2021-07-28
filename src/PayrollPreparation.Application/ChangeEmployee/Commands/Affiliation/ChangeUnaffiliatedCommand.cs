using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands.Affiliation
{
    public class ChangeUnaffiliatedCommand : ChangeAffiliationCommand
    {
        public Guid MemberId { get; }

        public ChangeUnaffiliatedCommand(Guid employeeId, Guid memberId) : base(employeeId)
        {
            MemberId = memberId;
        }
    }
}