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
    public class AddCommissionedEmployeeCommandHandler : IRequestHandler<AddCommissionedEmployeeCommand, Guid>
    {
        private readonly IPayrollDatasource _payrollDatasource;
        private readonly ILogger<AddCommissionedEmployeeCommandHandler> _logger;

        public AddCommissionedEmployeeCommandHandler(
            IPayrollDatasource payrollDatasource,
            ILogger<AddCommissionedEmployeeCommandHandler> logger)
        {
            _payrollDatasource = payrollDatasource;
            _logger = logger;
        }

        public Task<Guid> Handle(AddCommissionedEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = request.Name,
                Address = request.Address,
                PaymentClassification = new CommissionedClassification(request.Salary, request.Rate),
                PaymentMethod = new HoldMethod(),
                PaymentSchedule = new BiweeklySchedule()
            };

            Guid id = _payrollDatasource.AddEmployee(employee);

            return Task.FromResult(id);
        }
    }
}