using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands
{
    public class ChangeHoldCommand : ChangeEmployeeCommand
    {
        public ChangeHoldCommand(Guid employeeId) : base(employeeId)
        {
        }
    }
}