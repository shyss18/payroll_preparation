namespace PayrollPreparation.Domain.Models.PaymentClassification
{
    public class HourlyClassification : IPaymentClassification
    {
        private readonly double _rate;

        public HourlyClassification(double rate)
        {
            _rate = rate;
        }
    }
}