using PayrollPreparation.Application.ChangeEmployee.Commands.PaymentMethod;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.PaymentMethod;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.PaymentMethod
{
    public class ChangeMailCommandHandler : ChangePaymentMethodCommandHandler<ChangeMailCommand>
    {
        public ChangeMailCommandHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
        }

        protected override IPaymentMethod SetPaymentMethod(ChangeMailCommand command)
            => new MailMethod();
    }
}