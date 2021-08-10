using System;

namespace PayrollPreparation.Domain.Affiliation
{
    public class NoAffiliation : IAffiliation
    {
        public void AddServiceCharge(ServiceCharge serviceCharge)
        { }

        public double CalculateServiceCharges(DateTime date) => 0.0;
    }
}