using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PayrollPreparation.Application.AddEmployee.Commands;

namespace PayrollPreparation.Application.AddEmployee.CommandHandlers
{
    public class AddSalariedEmployeeCommandHandler : AsyncRequestHandler<AddSalariedEmployeeCommand>
    {
        protected override Task Handle(AddSalariedEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}