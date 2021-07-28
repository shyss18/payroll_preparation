using System;
using MediatR;

namespace PayrollPreparation.Application.AddTimeCard.Commands
{
    public class AddTimeCardCommand : IRequest
    {
        public DateTime Date { get; }

        public int Hours { get; }

        public Guid EmployeeId { get; }

        public AddTimeCardCommand(Guid employeeId, int hours, DateTime date)
        {
            Date = date;
            Hours = hours;
            EmployeeId = employeeId;
        }
    }
}