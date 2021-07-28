namespace PayrollPreparation.Domain.Models.PaymentMethod
{
    public class DirectMethod : IPaymentMethod
    {
        public void Pay(double amount)
        {
            throw new System.NotImplementedException();
        }
    }
}