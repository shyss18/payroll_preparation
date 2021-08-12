using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Application.DeleteEmployee.Commands;

namespace PayrollPreparation.Application.DeleteEmployee.CommandHandlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Guid>
    {
        private readonly IPayrollDatasource _payrollDatasource;
        private readonly ILogger<DeleteEmployeeCommandHandler> _logger;

        public DeleteEmployeeCommandHandler(
            IPayrollDatasource payrollDatasource,
            ILogger<DeleteEmployeeCommandHandler> logger)
        {
            _payrollDatasource = payrollDatasource;
            _logger = logger;
        }
        
        public Task<Guid> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            Guid id = _payrollDatasource.DeleteEmployee(request.Id);
            return Task.FromResult(id);
        }
    }
}