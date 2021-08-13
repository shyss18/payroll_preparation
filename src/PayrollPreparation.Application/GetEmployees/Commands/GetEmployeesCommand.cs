using System.Collections.ObjectModel;
using MediatR;
using PayrollPreparation.Domain;

namespace PayrollPreparation.Application.GetEmployees.Commands
{
    public class GetEmployeesCommand : IRequest<ReadOnlyCollection<Employee>>
    {
        
    }
}