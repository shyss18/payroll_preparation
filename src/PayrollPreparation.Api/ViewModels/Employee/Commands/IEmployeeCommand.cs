using PayrollPreparation.Application.AddEmployee.Commands;

namespace PayrollPreparation.Api.ViewModels.Employee.Commands
{
    public interface IEmployeeCommand
    {
        AddEmployeeCommand ToCommand();
    }
}