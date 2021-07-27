using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands.PaymentClassification
{
    public class ChangeSalariedCommand : ChangePaymentClassificationCommand
    {
        public decimal Salary { get; }
        
        public ChangeSalariedCommand(Guid employeeId, decimal salary) : base(employeeId)
        {
            Salary = salary;
        }
    }
}