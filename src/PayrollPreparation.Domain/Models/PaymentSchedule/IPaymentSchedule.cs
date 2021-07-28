using System;

namespace PayrollPreparation.Domain.Models.PaymentSchedule
{
    public interface IPaymentSchedule
    {
        bool IsPaymentDate(DateTime date);
    }
}