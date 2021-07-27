using PayrollPreparation.Application.ChangeEmployee.Commands.PaymentMethod;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.Models;
using PayrollPreparation.Domain.Models.PaymentMethod;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers.PaymentMethod
{
    public abstract class ChangePaymentMethodCommandHandler<T> : ChangeEmployeeCommandHandler<T>
        where T : ChangePaymentMethodCommand
    {
        protected ChangePaymentMethodCommandHandler(IPayrollDatasource payrollDatasource) : base(payrollDatasource)
        {
        }
        
        protected override void Change(Employee employee, T command)
        {
            employee.PaymentMethod = SetPaymentMethod(command);
        }

        protected abstract IPaymentMethod SetPaymentMethod(T command);
    }
}