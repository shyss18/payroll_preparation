namespace PayrollPreparation.Application.AddEmployee.Commands
{
    public class AddCommissionedEmployeeCommand : AddEmployeeCommand
    {
        public decimal Salary { get; }

        public double Rate { get; }

        public AddCommissionedEmployeeCommand(
            string name,
            string address,
            decimal salary,
            double rate) : base(name, address)
        {
            Salary = salary;
            Rate = rate;
        }
    }
}