using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands.PaymentClassification
{
    public abstract class ChangePaymentClassificationCommand : ChangeEmployeeCommand
    {
        protected ChangePaymentClassificationCommand(Guid employeeId) : base(employeeId)
        {
        }
    }
}