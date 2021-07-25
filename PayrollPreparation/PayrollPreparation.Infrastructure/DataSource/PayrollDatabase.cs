using System;
using System.Collections.Generic;
using System.Linq;
using PayrollPreparation.Application.Common.Contracts;
using PayrollPreparation.Domain.Models;
using PayrollPreparation.Infrastructure.Common.Comparators;

namespace PayrollPreparation.Infrastructure.DataSource
{
    public class PayrollDatabase : IPayrollDatasource
    {
        private readonly HashSet<Employee> _employees;

        public PayrollDatabase()
        {
            _employees = new HashSet<Employee>(new EmployeeComparer());
        }

        public Guid AddEmployee(Employee employee)
        {
            if (_employees.Contains(employee)) return Guid.Empty;

            employee.Id = Guid.NewGuid();
            _employees.Add(employee);

            return employee.Id;
        }

        public Employee GetEmployee(Guid id)
        {
            return _employees.FirstOrDefault(emp => emp.Id == id);
        }
    }
}