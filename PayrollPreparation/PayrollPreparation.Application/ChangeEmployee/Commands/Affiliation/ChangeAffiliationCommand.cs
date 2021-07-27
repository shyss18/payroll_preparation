using System;

namespace PayrollPreparation.Application.ChangeEmployee.Commands.Affiliation
{
    public abstract class ChangeAffiliationCommand : ChangeEmployeeCommand
    {
        protected ChangeAffiliationCommand(Guid employeeId) : base(employeeId)
        {
        }
    }
}