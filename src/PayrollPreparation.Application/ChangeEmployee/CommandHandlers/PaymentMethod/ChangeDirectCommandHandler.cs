using PayrollPreparation.Application.ChangeEmployee.Commands.PaymentMethod;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.PaymentMethod;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.PaymentMethod
{
    public class ChangeDirectCommandHandler : ChangePaymentMethodCommandHandler<ChangeDirectCommand>
    {
        public ChangeDirectCommandHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
        }

        protected override IPaymentMethod SetPaymentMethod(ChangeDirectCommand command)
            => new DirectMethod();
    }
}