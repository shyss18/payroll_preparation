using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands.PaymentMethod
{
    public class ChangeMailCommand : ChangePaymentMethodCommand
    {
        public string Address { get; }
        
        public ChangeMailCommand(Guid employeeId, string address) : base(employeeId)
        {
            Address = address;
        }
    }
}