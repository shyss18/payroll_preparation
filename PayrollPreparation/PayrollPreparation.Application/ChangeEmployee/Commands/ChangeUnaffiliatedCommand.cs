using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands
{
    public class ChangeUnaffiliatedCommand : ChangeEmployeeCommand
    {
        public ChangeUnaffiliatedCommand(Guid employeeId) : base(employeeId)
        {
        }
    }
}