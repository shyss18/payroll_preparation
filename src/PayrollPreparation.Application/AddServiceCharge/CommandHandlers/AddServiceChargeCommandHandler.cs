using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PayrollPreparation.Application.AddServiceCharge.Commands;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain;
using PayrollPreparation.Domain.Affiliation;

namespace PayrollPreparation.Application.AddServiceCharge.CommandHandlers
{
    public class AddServiceChargeCommandHandler : IRequestHandler<AddServiceChargeCommand, Guid>
    {
        private readonly IPayrollDatasource _payrollDatasource;

        public AddServiceChargeCommandHandler(IPayrollDatasource payrollDatasource)
        {
            _payrollDatasource = payrollDatasource;
        }

        public Task<Guid> Handle(AddServiceChargeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = _payrollDatasource.GetUnionMember(request.MemberId);

            if (employee != null)
            {
                IAffiliation employeeAffiliation = employee.Affiliation;
                employeeAffiliation.AddServiceCharge(new ServiceCharge(request.Date, request.Charge));
                return Task.FromResult(_payrollDatasource.UpdateEmployee(employee));
            }

            throw new InvalidOperationException("Employee has not found");
        }
    }
}