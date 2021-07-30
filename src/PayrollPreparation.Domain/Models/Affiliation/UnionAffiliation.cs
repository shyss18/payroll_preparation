using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollPreparation.Domain.Models.Affiliation
{
    public class UnionAffiliation : IAffiliation
    {
        private readonly double _dues;
        private readonly List<ServiceCharge> _serviceCharges;

        public UnionAffiliation(double dues)
        {
            _dues = dues;
            _serviceCharges = new List<ServiceCharge>();
        }

        public void AddServiceCharge(ServiceCharge serviceCharge)
        {
            _serviceCharges.Add(serviceCharge);
        }

        public double CalculateServiceCharges(DateTime date)
        {
            double additionDues = 0.0;

            if (_serviceCharges.Any())
            {
                foreach (var serviceCharge in _serviceCharges)
                {
                    if (IsServiceChargeInPaymentPeriod(serviceCharge.Date, date))
                        additionDues += serviceCharge.Amount;
                }
            }

            int count = FridaysCount(date);
            double totalDues = _dues * count;

            return totalDues + additionDues;
        }

        private bool IsServiceChargeInPaymentPeriod(DateTime serviceChargeDate, DateTime paymentDate)
        {
            DateTime startPeriod = paymentDate.AddDays(-paymentDate.Day + 1);
            DateTime endPeriod = paymentDate;

            return serviceChargeDate <= endPeriod && serviceChargeDate >= startPeriod;
        }

        private int FridaysCount(DateTime date)
        {
            int count = 0;

            DateTime startDate = date.AddDays(-date.Day + 1);

            while (startDate <= date)
            {
                if (startDate.DayOfWeek == DayOfWeek.Friday)
                {
                    count++;
                }

                startDate = startDate.AddDays(1);
            }

            return count;
        }
    }
}