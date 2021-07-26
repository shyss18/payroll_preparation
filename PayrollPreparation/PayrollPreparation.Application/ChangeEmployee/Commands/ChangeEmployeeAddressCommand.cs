using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands
{
    public class ChangeEmployeeAddressCommand : ChangeEmployeeCommand
    {
        public string Address { get; }

        public ChangeEmployeeAddressCommand(Guid employeeId, string address) : base(employeeId)
        {
            Address = address;
        }
    }
}