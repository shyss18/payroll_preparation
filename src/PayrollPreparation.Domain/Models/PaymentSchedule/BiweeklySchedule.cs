using System;

namespace PayrollPreparation.Domain.Models.PaymentSchedule
{
    public class BiweeklySchedule : IPaymentSchedule
    {
        public bool IsPaymentDate(DateTime date)
        {
            DateTime firstMonthDay = date.AddDays(-date.Day + 1);

            int fridayCount = 0;
            while (firstMonthDay <= date)
            {
                if (firstMonthDay.DayOfWeek == DayOfWeek.Friday)
                {
                    if (fridayCount % 2 == 0 && date.DayOfWeek == DayOfWeek.Friday)
                    {
                        return true;
                    }

                    fridayCount++;
                }

                firstMonthDay = firstMonthDay.AddDays(1);
            }

            return false;
        }
    }
}