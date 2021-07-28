using System;

namespace PayrollPreparation.Domain.Models.PaymentSchedule
{
    public class WeeklySchedule : IPaymentSchedule
    {
        public bool IsPaymentDate(DateTime date)
            => date.DayOfWeek == DayOfWeek.Friday;
    }
}