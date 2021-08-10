using System;

namespace PayrollPreparation.Domain.PaymentClassification
{
    public class SalariedClassification : IPaymentClassification
    {
        private readonly decimal _salary;
        
        public SalariedClassification(decimal salary)
        {
            _salary = salary;
        }

        public double CalculateAmount(DateTime paymentDate)
        {
            return (double) _salary;
        }
    }
}