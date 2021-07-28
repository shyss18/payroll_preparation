namespace PayrollPreparation.Domain.Models.PaymentClassification
{
    public class SalariedClassification : IPaymentClassification
    {
        private readonly decimal _salary;
        
        public SalariedClassification(decimal salary)
        {
            _salary = salary;
        }

        public double CalculateAmount()
        {
            return (double) _salary;
        }
    }
}