using System;

namespace PayrollPreparation.Domain.Models
{
    public class TimeCard
    {
        public DateTime Date { get; }

        public double Hours { get; }

        public TimeCard(DateTime date, double hours)
        {
            Date = date;
            Hours = hours;
        }
    }
}