using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollPreparation.Domain.PaymentClassification
{
    public class CommissionedClassification : IPaymentClassification
    {
        private decimal _salary;
        private readonly double _rate;

        private readonly List<SalesReceipt> _salesReceipts;

        public CommissionedClassification(decimal salary, double rate)
        {
            _salary = salary;
            _rate = rate;

            _salesReceipts = new List<SalesReceipt>();
        }

        public void AddSalesReceipt(SalesReceipt salesReceipt)
        {
            _salesReceipts.Add(salesReceipt);
        }

        public double CalculateAmount(DateTime paymentDate)
        {
            if (_salesReceipts.Any())
            {
                foreach (var salesReceipt in _salesReceipts)
                {
                    if (IsSalesReceiptInPaymentPeriod(salesReceipt.Date, paymentDate))
                    {
                        _salary += (decimal) (salesReceipt.Amount * _rate);
                    }
                }
            }

            return (double) _salary;
        }

        private bool IsSalesReceiptInPaymentPeriod(DateTime salesReceiptTime, DateTime paymentDate)
        {
            DateTime endPeriod = paymentDate;
            DateTime startPeriod = paymentDate.AddDays(-12);

            return salesReceiptTime <= endPeriod && salesReceiptTime >= startPeriod;
        }
    }
}