using PayrollPreparation.Application.ChangeEmployee.Commands.PaymentClassification;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.Models;
using PayrollPreparation.Domain.Models.PaymentClassification;
using PayrollPreparation.Domain.Models.PaymentSchedule;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.PaymentClassification
{
    public abstract class ChangePaymentClassificationHandler<T> : ChangeEmployeeCommandHandler<T>
        where T : ChangePaymentClassificationCommand
    {
        protected ChangePaymentClassificationHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
        }

        protected override void Change(Employee employee, T command)
        {
            employee.PaymentClassification = SetPaymentClassification(command);
            employee.PaymentSchedule = SetPaymentSchedule();
        }

        protected abstract IPaymentClassification SetPaymentClassification(T command);

        protected abstract IPaymentSchedule SetPaymentSchedule();
    }
}