using System;
using PayrollPreparation.Api.ViewModels.Employee.Commands;

namespace PayrollPreparation.Api.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }

        public decimal Salary { get; }

        public double Rate { get; }

        public IEmployeeCommand Command { get; set; }
    }
}