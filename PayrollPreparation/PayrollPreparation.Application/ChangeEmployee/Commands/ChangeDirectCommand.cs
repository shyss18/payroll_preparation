using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands
{
    public class ChangeDirectCommand : ChangeEmployeeCommand
    {
        public string Bank { get; }

        public string Account { get; }
        
        public ChangeDirectCommand(Guid employeeId, string bank, string account) : base(employeeId)
        {
            Bank = bank;
            Account = account;
        }
    }
}