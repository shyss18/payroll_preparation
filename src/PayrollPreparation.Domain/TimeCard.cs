using System;

namespace PayrollPreparation.Domain
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