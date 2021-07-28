using System;
using MediatR;

namespace PayrollPreparation.Application.ChangeEmployee.Commands
{
    public abstract class ChangeEmployeeCommand : IRequest<Guid>
    {
        public Guid EmployeeId { get; }

        protected ChangeEmployeeCommand(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}