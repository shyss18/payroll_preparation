using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PayrollPreparation.Application.AddEmployee.Commands;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain;
using PayrollPreparation.Domain.PaymentClassification;
using PayrollPreparation.Domain.PaymentMethod;
using PayrollPreparation.Domain.PaymentSchedule;

namespace PayrollPreparation.Application.AddEmployee.CommandHandlers
{
    public class AddHourlyEmployeeCommandHandler : IRequestHandler<AddHourlyEmployeeCommand, Guid>
    {
        private readonly IPayrollDatasource _payrollDatasource;
        private readonly ILogger<AddHourlyEmployeeCommandHandler> _logger;

        public AddHourlyEmployeeCommandHandler(
            IPayrollDatasource payrollDatasource,
            ILogger<AddHourlyEmployeeCommandHandler> logger)
        {
            _payrollDatasource = payrollDatasource;
            _logger = logger;
        }
        
        public Task<Guid> Handle(AddHourlyEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = request.Name,
                Address = request.Address,
                PaymentClassification = new HourlyClassification(request.Rate),
                PaymentMethod = new HoldMethod(),
                PaymentSchedule = new WeeklySchedule()
            };

            Guid id = _payrollDatasource.AddEmployee(employee);
            
            return Task.FromResult(id);
        }
    }
}