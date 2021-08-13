using System;
using MediatR;
using PayrollPreparation.Domain;

namespace PayrollPreparation.Application.GetEmployee.Commands
{
    public class GetEmployeeCommand : IRequest<Employee>
    {
        public Guid Id { get; }

        public GetEmployeeCommand(Guid id)
        {
            Id = id;
        }
    }
}