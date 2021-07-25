using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PayrollPreparation.Application.AddEmployee.Commands;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.Models;
using PayrollPreparation.Domain.Models.PaymentClassification;
using PayrollPreparation.Domain.Models.PaymentMethod;
using PayrollPreparation.Domain.Models.PaymentSchedule;

namespace PayrollPreparation.Application.AddEmployee.CommandHandlers
{
    public class AddSalariedEmployeeCommandHandler : IRequestHandler<AddSalariedEmployeeCommand, Guid>
    {
        private readonly ILogger<AddSalariedEmployeeCommandHandler> _logger;
        private readonly IPayrollDatasource _payrollDatasource;

        public AddSalariedEmployeeCommandHandler(
            ILogger<AddSalariedEmployeeCommandHandler> logger,
            IPayrollDatasource payrollDatasource)
        {
            _logger = logger;
            _payrollDatasource = payrollDatasource;
        }

        public Task<Guid> Handle(AddSalariedEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = request.Name,
                Address = request.Address,
                PaymentClassification = new SalariedClassification(request.Salary),
                PaymentMethod = new HoldMethod(),
                PaymentSchedule = new MonthlySchedule()
            };

            Guid id = _payrollDatasource.AddEmployee(employee);
            
            return Task.FromResult(id);
        }
    }
}