using System;

namespace PayrollPreparation.Domain.Models.PaymentSchedule
{
    public class WeeklySchedule : IPaymentSchedule
    {
        public bool IsPaymentDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}