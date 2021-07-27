using System.Collections.Generic;

namespace PayrollPreparation.Domain.Models.Affiliation
{
    public class UnionAffiliation : IAffiliation
    {
        private readonly List<ServiceCharge> _serviceCharges;

        public UnionAffiliation()
        {
            _serviceCharges = new List<ServiceCharge>();
        }

        public void AddServiceCharge(ServiceCharge serviceCharge)
        {
            _serviceCharges.Add(serviceCharge);
        }
    }
}