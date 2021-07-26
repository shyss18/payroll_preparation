using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands
{
    public class ChangeEmployeeNameCommand : ChangeEmployeeCommand
    {
        public string Name { get; }

        public ChangeEmployeeNameCommand(Guid employeeId, string name) : base(employeeId)
        {
            Name = name;
        }
    }
}