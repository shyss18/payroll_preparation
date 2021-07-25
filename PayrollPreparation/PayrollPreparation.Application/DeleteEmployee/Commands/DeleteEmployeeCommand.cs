using System;
using MediatR;

namespace PayrollPreparation.Application.DeleteEmployee.Commands
{
    public class DeleteEmployeeCommand : IRequest<Guid>
    {
        public Guid Id { get; }

        public DeleteEmployeeCommand(Guid id)
        {
            Id = id;
        }
    }
}