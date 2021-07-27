using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands.PaymentClassification
{
    public class ChangeHourlyCommand : ChangePaymentClassificationCommand
    {
        public double Rate { get; }

        public ChangeHourlyCommand(Guid employeeId, double rate) : base(employeeId)
        {
            Rate = rate;
        }
    }
}