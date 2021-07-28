using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands.PaymentClassification
{
    public class ChangeCommissionedCommand : ChangePaymentClassificationCommand
    {
        public decimal Salary { get; }

        public double Rate { get; set; }

        public ChangeCommissionedCommand(Guid employeeId, decimal salary, double rate) : base(employeeId)
        {
            Salary = salary;
            Rate = rate;
        }
    }
}