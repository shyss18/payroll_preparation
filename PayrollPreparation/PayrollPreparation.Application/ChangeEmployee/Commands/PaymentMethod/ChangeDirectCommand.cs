using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands.PaymentMethod
{
    public class ChangeDirectCommand : ChangePaymentMethodCommand
    {
        public string Bank { get; }

        public string Account { get; }
        
        public ChangeDirectCommand(Guid employeeId, string bank, string account) : base(employeeId)
        {
            Bank = bank;
            Account = account;
        }
    }
}