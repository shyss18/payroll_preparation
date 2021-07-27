using System;

namespace PayrollPreparation.Domain.Models.PaymentSchedule
{
    public class MonthlySchedule : IPaymentSchedule
    {
        public bool IsPaymentDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}