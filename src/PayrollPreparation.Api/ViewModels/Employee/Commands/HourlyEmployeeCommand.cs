using PayrollPreparation.Application.AddEmployee.Commands;

namespace PayrollPreparation.Api.ViewModels.Employee.Commands
{
    public class HourlyEmployeeCommand : IEmployeeCommand
    {
        private readonly EmployeeViewModel _employeeViewModel;

        public HourlyEmployeeCommand(EmployeeViewModel employeeViewModel)
        {
            _employeeViewModel = employeeViewModel;
        }
        
        public AddEmployeeCommand ToCommand()
            => new AddHourlyEmployeeCommand(_employeeViewModel.Name, _employeeViewModel.Address, _employeeViewModel.Rate);
    }
}