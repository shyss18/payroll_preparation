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
    public class AddTimeCardCommandHandler : IRequestHandler<AddTimeCardCommand, Guid>
    {
        private readonly IPayrollDatasource _payrollDatasource;

        public AddTimeCardCommandHandler(IPayrollDatasource payrollDatasource)
        {
            _payrollDatasource = payrollDatasource;
        }

        public Task<Guid> Handle(AddTimeCardCommand request, CancellationToken cancellationToken)
        {
            Employee employee = _payrollDatasource.GetEmployee(request.EmployeeId);

            if (employee != null)
            {
                var employeeClassification = employee.PaymentClassification as HourlyClassification;
                if (employeeClassification == null)
                    throw new InvalidOperationException(
                        "Can't add time card to Employee without hourly classification");

                employeeClassification.AddTimeCard(new TimeCard(request.Date, request.Hours));
                return Task.FromResult(_payrollDatasource.UpdateEmployee(employee));
            }

            throw new InvalidOperationException("Employee has not found");
        }
    }
}