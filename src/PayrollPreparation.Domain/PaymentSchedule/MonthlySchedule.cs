using System;

namespace PayrollPreparation.Domain.PaymentSchedule
{
    public class MonthlySchedule : IPaymentSchedule
    {
        public bool IsPaymentDate(DateTime date)
        {
            DateTime nextDay = date.AddDays(1);
            return date.Month == nextDay.Month;
        }
    }
}