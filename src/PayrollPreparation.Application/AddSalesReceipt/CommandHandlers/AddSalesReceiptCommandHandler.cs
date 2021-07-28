using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PayrollPreparation.Application.AddSalesReceipt.Commands;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.Models;
using PayrollPreparation.Domain.Models.PaymentClassification;

namespace PayrollPreparation.Application.AddSalesReceipt.CommandHandlers
{
    public class AddSalesReceiptCommandHandler : AsyncRequestHandler<AddSalesReceiptCommand>
    {
        private readonly IPayrollDatasource _payrollDatasource;

        public AddSalesReceiptCommandHandler(IPayrollDatasource payrollDatasource)
        {
            _payrollDatasource = payrollDatasource;
        }

        protected override Task Handle(AddSalesReceiptCommand request, CancellationToken cancellationToken)
        {
            Employee employee = _payrollDatasource.GetEmployee(request.EmployeeId);

            if (employee != null)
            {
                var employeeClassification = employee.PaymentClassification as CommissionedClassification;
                if (employeeClassification == null)
                    throw new InvalidOperationException(
                        "Can't add sales receipt to Employee without commissioned classification");

                employeeClassification.AddSalesReceipt(new SalesReceipt(request.Date, request.Amount));
            }

            throw new InvalidOperationException("Employee has not found");
        }
    }
}