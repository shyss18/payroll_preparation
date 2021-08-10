using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Application.Payday.Commands;
using PayrollPreparation.Domain;
using PayrollPreparation.Domain.Affiliation;
using PayrollPreparation.Domain.PaymentClassification;
using PayrollPreparation.Domain.PaymentMethod;
using PayrollPreparation.Domain.PaymentSchedule;

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
                    IAffiliation affiliation = employee.Affiliation;
                    
                    double netAmount = paymentClassification.CalculateAmount(request.Date);
                    double serviceCharge = affiliation.CalculateServiceCharges(request.Date);

                    double grossAmount = netAmount - serviceCharge; 
                    
                    paymentMethod.Pay(grossAmount);
                }
            }

            return Task.CompletedTask;
        }
    }
}