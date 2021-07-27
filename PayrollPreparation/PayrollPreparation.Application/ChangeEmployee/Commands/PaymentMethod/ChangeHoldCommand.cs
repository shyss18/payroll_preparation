using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands.PaymentMethod
{
    public class ChangeHoldCommand : ChangePaymentMethodCommand
    {
        public ChangeHoldCommand(Guid employeeId) : base(employeeId)
        {
        }
    }
}