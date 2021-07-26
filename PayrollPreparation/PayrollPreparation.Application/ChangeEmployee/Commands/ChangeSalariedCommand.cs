using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands
{
    public class ChangeSalariedCommand : ChangeEmployeeCommand
    {
        public decimal Salary { get; }
        
        public ChangeSalariedCommand(Guid employeeId, decimal salary) : base(employeeId)
        {
            Salary = salary;
        }
    }
}