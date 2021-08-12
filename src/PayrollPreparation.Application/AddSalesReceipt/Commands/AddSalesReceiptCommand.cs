using System;
using MediatR;

namespace PayrollPreparation.Application.AddSalesReceipt.Commands
{
    public class AddSalesReceiptCommand : IRequest<Guid>
    {
        public Guid EmployeeId { get; }

        public DateTime Date { get; }

        public double Amount { get; }

        public AddSalesReceiptCommand(Guid employeeId, DateTime date, double amount)
        {
            EmployeeId = employeeId;
            Date = date;
            Amount = amount;
        }
    }
}