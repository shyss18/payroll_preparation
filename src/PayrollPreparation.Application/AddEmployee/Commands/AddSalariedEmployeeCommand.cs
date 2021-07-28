namespace PayrollPreparation.Application.AddEmployee.Commands
{
    public class AddSalariedEmployeeCommand : AddEmployeeCommand
    {
        public decimal Salary { get; }

        public AddSalariedEmployeeCommand(
            string name,
            string address,
            decimal salary) : base(name, address)
        {
            Salary = salary;
        }
    }
}