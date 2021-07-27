using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PayrollPreparation.Application.ChangeEmployee.Commands;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.Models;

namespace PayrollPreparation.Application.ChangeEmployee.CommandHandlers
{
    public abstract class ChangeEmployeeCommandHandler<T> : IRequestHandler<T, Guid> where T : ChangeEmployeeCommand
    {
        private readonly IPayrollDatasource _payrollDatasource;

        protected ChangeEmployeeCommandHandler(IPayrollDatasource payrollDatasource)
        {
            _payrollDatasource = payrollDatasource;
        }

        public Task<Guid> Handle(T request, CancellationToken cancellationToken)
        {
            Employee employee = _payrollDatasource.GetEmployee(request.EmployeeId);
            if (employee == null)
                throw new InvalidOperationException($"Employee with id '{request.EmployeeId}' has not found");

            Change(employee, request);

            Guid id = _payrollDatasource.UpdateEmployee(employee);

            return Task.FromResult(id);
        }

        protected abstract void Change(Employee employee, T command);
    }
}