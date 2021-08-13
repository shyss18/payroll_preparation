using PayrollPreparation.Application.AddEmployee.Commands;

namespace PayrollPreparation.Api.ViewModels.Employee.Commands
{
    public class CommissionedEmployeeCommand : IEmployeeCommand
    {
        private readonly EmployeeViewModel _employeeViewModel;

        public CommissionedEmployeeCommand(EmployeeViewModel employeeViewModel)
        {
            _employeeViewModel = employeeViewModel;
        }
        
        public AddEmployeeCommand ToCommand()
            => new AddCommissionedEmployeeCommand(
                _employeeViewModel.Name,
                _employeeViewModel.Address,
                _employeeViewModel.Salary,
                _employeeViewModel.Rate);
    }
}