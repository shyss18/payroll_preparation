namespace PayrollPreparation.Domain.PaymentMethod
{
    public interface IPaymentMethod
    {
        void Pay(double amount);
    }
}