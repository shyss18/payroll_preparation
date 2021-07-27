using System;

namespace PayrollPreparation.Domain.Models
{
    public class SalesReceipt
    {
        public DateTime Date { get; }

        public double Amount { get; }

        public SalesReceipt(DateTime date, double amount)
        {
            Date = date;
            Amount = amount;
        }
    }
}