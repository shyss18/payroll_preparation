using System;
using MediatR;

namespace PayrollPreparation.Application.AddEmployee.Commands
{
    public abstract class AddEmployeeCommand : IRequest<Guid>
    {
        public string Name { get; }

        public string Address { get; }

        protected AddEmployeeCommand(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}