using PayrollPreparation.Application.ChangeEmployee.Commands.PaymentMethod;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.Models.PaymentMethod;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.PaymentMethod
{
    public class ChangeHoldCommandHandler : ChangePaymentMethodCommandHandler<ChangeHoldCommand>
    {
        public ChangeHoldCommandHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
        }

        protected override IPaymentMethod SetPaymentMethod(ChangeHoldCommand command)
            => new HoldMethod();
    }
}