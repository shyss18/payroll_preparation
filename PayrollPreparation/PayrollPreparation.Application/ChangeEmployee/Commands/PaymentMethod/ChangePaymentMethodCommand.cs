using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands.PaymentMethod
{
    public abstract class ChangePaymentMethodCommand : ChangeEmployeeCommand
    {
        protected ChangePaymentMethodCommand(Guid employeeId) : base(employeeId)
        {
        }
    }
}