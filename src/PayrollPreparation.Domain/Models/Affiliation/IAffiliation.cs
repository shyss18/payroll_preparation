using System;

namespace PayrollPreparation.Domain.Models.Affiliation
{
    public interface IAffiliation
    {
        void AddServiceCharge(ServiceCharge serviceCharge);

        double CalculateServiceCharges(DateTime date);
    }
}