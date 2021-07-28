namespace PayrollPreparation.Domain.Models.PaymentMethod
{
    public interface IPaymentMethod
    {
        void Pay(double amount);
    }
}