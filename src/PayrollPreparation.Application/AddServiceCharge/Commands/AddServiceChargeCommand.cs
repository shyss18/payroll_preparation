using System;
using MediatR;

namespace PayrollPreparation.Application.AddServiceCharge.Commands
{
    public class AddServiceChargeCommand : IRequest
    {
        public DateTime Date { get; }

        public double Charge { get; }

        public Guid MemberId { get; }

        public AddServiceChargeCommand(Guid memberId, DateTime date, double charge)
        {
            Date = date;
            Charge = charge;
            MemberId = memberId;
        }
    }
}