using System;
using System.Collections.Generic;
using PayrollPreparation.Domain.Models.Affiliation;
using PayrollPreparation.Domain.Models.PaymentClassification;
using PayrollPreparation.Domain.Models.PaymentMethod;
using PayrollPreparation.Domain.Models.PaymentSchedule;

namespace PayrollPreparation.Domain.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        
        public IPaymentMethod PaymentMethod { get; set; }

        public IPaymentClassification PaymentClassification { get; set; }

        public IPaymentSchedule PaymentSchedule { get; set; }

        public List<IAffiliation> Affiliations { get; set; }
    }
}