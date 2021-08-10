using PayrollPreparation.Application.ChangeEmployee.Commands.PaymentClassification;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.PaymentClassification;
using PayrollPreparation.Domain.PaymentSchedule;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.PaymentClassification
{
    public class ChangeSalariedCommandHandler : ChangePaymentClassificationHandler<ChangeSalariedCommand>
    {
        public ChangeSalariedCommandHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
        }

        protected override IPaymentClassification SetPaymentClassification(ChangeSalariedCommand command)
            => new SalariedClassification(command.Salary);

        protected override IPaymentSchedule SetPaymentSchedule()
            => new MonthlySchedule();
    }
}