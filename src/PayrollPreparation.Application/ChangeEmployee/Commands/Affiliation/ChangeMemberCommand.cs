using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands.Affiliation
{
    public class ChangeMemberCommand : ChangeAffiliationCommand
    {
        public Guid MemberId { get; }

        public double Dues { get; }

        public ChangeMemberCommand(Guid employeeId, double dues, Guid memberId) : base(employeeId)
        {
            Dues = dues;
            MemberId = memberId;
        }
    }
}