using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Application.Payday.Commands;
using PayrollPreparation.Domain.Models;
using PayrollPreparation.Domain.Models.PaymentClassification;
using PayrollPreparation.Domain.Models.PaymentMethod;
using PayrollPreparation.Domain.Models.PaymentSchedule;

namespace PayrollPreparation.Application.Payday.CommandHandlers
{
    public class PaydayCommandHandler : AsyncRequestHandler<PaydayCommand>
    {
        private readonly IPayrollDatasource _payrollDatasource;

        public PaydayCommandHandler(IPayrollDatasource payrollDatasource)
        {
            _payrollDatasource = payrollDatasource;
        }

        protected override Task Handle(PaydayCommand request, CancellationToken cancellationToken)
        {
            List<Employee> employees = _payrollDatasource.GetEmployees();

            foreach (var employee in employees)
            {
                IPaymentSchedule paymentSchedule = employee.PaymentSchedule;
                if (paymentSchedule.IsPaymentDate(request.Date))
                {
                    IPaymentClassification paymentClassification = employee.PaymentClassification;
                    IPaymentMethod paymentMethod = employee.PaymentMethod;

                    double amount = paymentClassification.CalculateAmount();
                    paymentMethod.Pay(amount);
                }
            }

            return Task.CompletedTask;
        }
    }
}