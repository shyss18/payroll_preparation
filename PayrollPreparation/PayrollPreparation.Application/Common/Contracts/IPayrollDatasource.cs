using System;
using PayrollPreparation.Domain.Models;

namespace PayrollPreparation.Application.Common.Contracts
{
    public interface IPayrollDatasource
    {
        Guid AddEmployee(Employee employee);

        Employee GetEmployee(Guid id);

        Guid DeleteEmployee(Guid id);

        Employee GetUnionMember(Guid memberId);

        Guid UpdateEmployee(Employee employee);

        Guid AddUnionMember(Guid memberId, Employee employee);

        void RemoveUnionMember(Guid memberId);
    }
}