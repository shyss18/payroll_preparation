using System;
using System.Collections.Generic;

namespace PayrollPreparation.Domain.Models.PaymentClassification
{
    public class HourlyClassification : IPaymentClassification
    {
        private readonly double _rate;
        private readonly List<TimeCard> _timeCards;

        private const double OvertimeRate = 1.5;

        public HourlyClassification(double rate)
        {
            _rate = rate;
            _timeCards = new List<TimeCard>();
        }

        public void AddTimeCard(TimeCard timeCard)
        {
            _timeCards.Add(timeCard);
        }

        public double CalculateAmount(DateTime paymentDate)
        {
            double amount = 0.0;

            foreach (var timeCard in _timeCards)
            {
                if (IsTimeCardInPaymentPeriod(timeCard.Date, paymentDate))
                {
                    amount += timeCard.Hours > 8
                        ? GetOvertimePayment(timeCard.Hours)
                        : GetRegularPayment(timeCard.Hours);
                }
            }

            return amount;
        }

        private bool IsTimeCardInPaymentPeriod(DateTime timeCardDate, DateTime paymentDate)
        {
            DateTime startPeriod = paymentDate.AddDays(-5);
            DateTime endPeriod = paymentDate;

            return timeCardDate <= endPeriod || timeCardDate >= startPeriod;
        }

        private double GetOvertimePayment(double hours)
        {
            double overtimeHours = hours - 8;
            return hours * _rate + overtimeHours * OvertimeRate;
        }

        private double GetRegularPayment(double hours)
            => hours * _rate;
    }
}