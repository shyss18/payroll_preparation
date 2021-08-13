using PayrollPreparation.Application.AddEmployee.Commands;

namespace PayrollPreparation.Api.ViewModels.Employee.Commands
{
    public class SalariedEmployeeCommand : IEmployeeCommand
    {
        private readonly EmployeeViewModel _employeeViewModel;

        public SalariedEmployeeCommand(EmployeeViewModel employeeViewModel)
        {
            _employeeViewModel = employeeViewModel;
        }

        public AddEmployeeCommand ToCommand()
            => new AddSalariedEmployeeCommand(
                _employeeViewModel.Name,
                _employeeViewModel.Address,
                _employeeViewModel.Salary);
    }
}