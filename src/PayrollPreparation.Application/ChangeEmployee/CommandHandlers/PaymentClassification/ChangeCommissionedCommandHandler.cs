using PayrollPreparation.Application.ChangeEmployee.Commands.PaymentClassification;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.PaymentClassification;
using PayrollPreparation.Domain.PaymentSchedule;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.PaymentClassification
{
    public class ChangeCommissionedCommandHandler : ChangePaymentClassificationHandler<ChangeCommissionedCommand>
    {
        public ChangeCommissionedCommandHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
        }

        protected override IPaymentClassification SetPaymentClassification(ChangeCommissionedCommand command)
            => new CommissionedClassification(command.Salary, command.Rate);

        protected override IPaymentSchedule SetPaymentSchedule()
            => new BiweeklySchedule();
    }
}