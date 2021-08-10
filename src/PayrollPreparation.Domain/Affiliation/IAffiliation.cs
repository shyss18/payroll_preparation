using System;

namespace PayrollPreparation.Domain.Affiliation
{
    public interface IAffiliation
    {
        void AddServiceCharge(ServiceCharge serviceCharge);

        double CalculateServiceCharges(DateTime date);
    }
}