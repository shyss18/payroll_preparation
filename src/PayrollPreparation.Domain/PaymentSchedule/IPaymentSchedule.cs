using System;

namespace PayrollPreparation.Domain.PaymentSchedule
{
    public interface IPaymentSchedule
    {
        bool IsPaymentDate(DateTime date);
    }
}