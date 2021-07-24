using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PayrollPreparation.Application.AddEmployee.Commands;

namespace PayrollPreparation.Application.AddEmployee.CommandHandlers
{
    public class AddCommissionedEmployeeCommandHandler : AsyncRequestHandler<AddCommissionedEmployeeCommand>
    {
        protected override Task Handle(AddCommissionedEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}