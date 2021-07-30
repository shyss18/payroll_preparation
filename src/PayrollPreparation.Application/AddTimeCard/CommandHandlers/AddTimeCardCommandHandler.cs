using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PayrollPreparation.Application.AddTimeCard.Commands;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain;
using PayrollPreparation.Domain.PaymentClassification;

namespace PayrollPreparation.Application.AddTimeCard.CommandHandlers
{
    public class AddTimeCardCommandHandler : IRequestHandler<AddTimeCardCommand>
    {
        private readonly IPayrollDatasource _payrollDatasource;

        public AddTimeCardCommandHandler(IPayrollDatasource payrollDatasource)
        {
            _payrollDatasource = payrollDatasource;
        }

        public Task<Unit> Handle(AddTimeCardCommand request, CancellationToken cancellationToken)
        {
            Employee employee = _payrollDatasource.GetEmployee(request.EmployeeId);

            if (employee != null)
            {
                var employeeClassification = employee.PaymentClassification as HourlyClassification;
                if (employeeClassification == null)
                    throw new InvalidOperationException(
                        "Can't add time card to Employee without hourly classification");

                employeeClassification.AddTimeCard(new TimeCard(request.Date, request.Hours));
            }

            throw new InvalidOperationException("Employee has not found");
        }
    }
}