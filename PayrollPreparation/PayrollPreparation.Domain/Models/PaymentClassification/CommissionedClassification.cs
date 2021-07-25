namespace PayrollPreparation.Domain.Models.PaymentClassification
{
    public class CommissionedClassification : IPaymentClassification
    {
        private readonly decimal _salary;
        private readonly double _rate;

        public CommissionedClassification(decimal salary, double rate)
        {
            _salary = salary;
            _rate = rate;
        }
    }
}