using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands.Affiliation
{
    public class ChangeMemberCommand : ChangeAffiliationCommand
    {
        public Guid MemberId { get; }

        public DateTime Dues { get; }

        public ChangeMemberCommand(Guid employeeId, DateTime dues, Guid memberId) : base(employeeId)
        {
            Dues = dues;
            MemberId = memberId;
        }
    }
}