using System;
using PayrollPreparation.Domain.Affiliation;
using PayrollPreparation.Domain.PaymentClassification;
using PayrollPreparation.Domain.PaymentMethod;
using PayrollPreparation.Domain.PaymentSchedule;

namespace PayrollPreparation.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public IPaymentMethod PaymentMethod { get; set; }

        public IPaymentClassification PaymentClassification { get; set; }

        public IPaymentSchedule PaymentSchedule { get; set; }

        public IAffiliation Affiliation { get; set; }
    }
}