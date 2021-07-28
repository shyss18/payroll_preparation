using PayrollPreparation.Application.ChangeEmployee.Commands.PaymentClassification;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.Models.PaymentClassification;
using PayrollPreparation.Domain.Models.PaymentSchedule;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.PaymentClassification
{
    public class ChangeHourlyCommandHandler : ChangePaymentClassificationHandler<ChangeHourlyCommand>
    {
        public ChangeHourlyCommandHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
        }

        protected override IPaymentClassification SetPaymentClassification(ChangeHourlyCommand command)
            => new HourlyClassification(command.Rate);

        protected override IPaymentSchedule SetPaymentSchedule()
            => new WeeklySchedule();
    }
}