using System;

namespace PayrollPreparation.Domain.Models.PaymentSchedule
{
    public class BiweeklySchedule : IPaymentSchedule
    {
        public bool IsPaymentDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}