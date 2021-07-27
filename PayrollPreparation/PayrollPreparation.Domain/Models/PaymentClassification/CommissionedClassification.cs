using System.Collections.Generic;

namespace PayrollPreparation.Domain.Models.PaymentClassification
{
    public class CommissionedClassification : IPaymentClassification
    {
        private readonly decimal _salary;
        private readonly double _rate;

        private readonly List<SalesReceipt> _sales;

        public CommissionedClassification(decimal salary, double rate)
        {
            _salary = salary;
            _rate = rate;

            _sales = new List<SalesReceipt>();
        }

        public void AddSalesReceipt(SalesReceipt salesReceipt)
        {
            _sales.Add(salesReceipt);
        }

        public double CalculateAmount()
        {
            throw new System.NotImplementedException();
        }
    }
}