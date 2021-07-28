using System;

namespace PayrollPreparation.Domain.Models.PaymentClassification
{
    public interface IPaymentClassification
    {
        double CalculateAmount(DateTime paymentDate);
    }
}