using System;
using MediatR;

namespace PayrollPreparation.Application.Payday.Commands
{
    public class PaydayCommand : IRequest
    {
        public DateTime Date { get; }

        public PaydayCommand(DateTime date)
        {
            Date = date;
        }
    }
}