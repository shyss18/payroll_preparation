using System;
using PayrollPreparation.Domain.Models;

namespace PayrollPreparation.Application.Common.Contracts
{
    public interface IPayrollDatasource
    {
        Guid AddEmployee(Employee employee);

        Employee GetEmployee(Guid id);

        Guid DeleteEmployee(Guid id);

        Employee GetUnionMember(Guid id);
    }
}