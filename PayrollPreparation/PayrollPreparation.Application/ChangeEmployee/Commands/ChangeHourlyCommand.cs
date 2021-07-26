using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands
{
    public class ChangeHourlyCommand : ChangeEmployeeCommand
    {
        public double Rate { get; }

        public ChangeHourlyCommand(Guid employeeId, double rate) : base(employeeId)
        {
            Rate = rate;
        }
    }
}