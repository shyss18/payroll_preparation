using System.Collections.Generic;

namespace PayrollPreparation.Domain.Models.PaymentClassification
{
    public class HourlyClassification : IPaymentClassification
    {
        private readonly double _rate;
        private readonly List<TimeCard> _timeCards;

        public HourlyClassification(double rate)
        {
            _rate = rate;
            _timeCards = new List<TimeCard>();
        }

        public void AddTimeCard(TimeCard timeCard)
        {
            _timeCards.Add(timeCard);
        }
    }
}