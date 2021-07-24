using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PayrollPreparation.Application.AddEmployee.Commands;

namespace PayrollPreparation.Application.AddEmployee.CommandHandlers
{
    public class AddHourlyEmployeeCommandHandler : AsyncRequestHandler<AddHourlyEmployeeCommand>
    {
        protected override Task Handle(AddHourlyEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}