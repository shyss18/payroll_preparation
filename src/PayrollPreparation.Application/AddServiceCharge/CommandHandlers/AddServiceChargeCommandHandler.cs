using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PayrollPreparation.Application.AddServiceCharge.Commands;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain;

namespace PayrollPreparation.Application.AddServiceCharge.CommandHandlers
{
    public class AddServiceChargeCommandHandler : AsyncRequestHandler<AddServiceChargeCommand>
    {
        private readonly IPayrollDatasource _payrollDatasource;

        public AddServiceChargeCommandHandler(IPayrollDatasource payrollDatasource)
        {
            _payrollDatasource = payrollDatasource;
        }
        
        protected override Task Handle(AddServiceChargeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = _payrollDatasource.GetUnionMember(request.MemberId);

            if (employee != null)
            {
                var employeeAffiliation = employee.Affiliation;
                employeeAffiliation.AddServiceCharge(new ServiceCharge(request.Date, request.Charge));
            }

            throw new InvalidOperationException("Employee has not found");
        }
    }
}