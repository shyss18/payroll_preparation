using System;

namespace PayrollPreparation.Domain.PaymentClassification
{
    public interface IPaymentClassification
    {
        double CalculateAmount(DateTime paymentDate);
    }
}