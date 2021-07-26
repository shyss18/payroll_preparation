using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands
{
    public class ChangeMailCommand : ChangeEmployeeCommand
    {
        public string Address { get; }
        
        public ChangeMailCommand(Guid employeeId, string address) : base(employeeId)
        {
            Address = address;
        }
    }
}