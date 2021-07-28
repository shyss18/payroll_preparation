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
        private readonly Dictionary<Guid, Employee> _unionMembers;

        public PayrollDatabase()
        {
            _employees = new HashSet<Employee>(new EmployeeComparer());
            _unionMembers = new Dictionary<Guid, Employee>();
        }

        public Guid AddEmployee(Employee employee)
        {
            if (_employees.Contains(employee))
                throw new InvalidOperationException();

            employee.Id = Guid.NewGuid();
            _employees.Add(employee);

            return employee.Id;
        }

        public Employee GetEmployee(Guid id)
        {
            return _employees.FirstOrDefault(emp => emp.Id == id);
        }

        public Guid DeleteEmployee(Guid id)
        {
            Employee employee = _employees.FirstOrDefault(emp => emp.Id == id);
            if (employee == null)
                throw new InvalidOperationException();

            _employees.Remove(employee);
            return employee.Id;
        }

        public Employee GetUnionMember(Guid memberId)
        {
            return _unionMembers[memberId];
        }

        public Guid UpdateEmployee(Employee employee)
        {
            Employee existingEmployee = _employees.FirstOrDefault(emp => emp.Id == employee.Id);
            if (existingEmployee == null)
                throw new InvalidOperationException();

            _employees.Remove(existingEmployee);
            _employees.Add(employee);

            return employee.Id;
        }

        public Guid AddUnionMember(Guid memberId, Employee employee)
        {
            if (_unionMembers.ContainsKey(memberId))
                throw new InvalidOperationException();

            _unionMembers.Add(memberId, employee);

            return memberId;
        }

        public void RemoveUnionMember(Guid memberId)
        {
            if (_unionMembers.ContainsKey(memberId))
                _unionMembers.Remove(memberId);

            throw new InvalidOperationException();
        }

        public List<Employee> GetEmployees()
            => _employees.ToList();
    }
}