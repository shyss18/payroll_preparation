using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands
{
    public class ChangeMemberCommand : ChangeEmployeeCommand
    {
        public DateTime Dues { get; }
        
        public ChangeMemberCommand(Guid employeeId, DateTime dues) : base(employeeId)
        {
            Dues = dues;
        }
    }
}