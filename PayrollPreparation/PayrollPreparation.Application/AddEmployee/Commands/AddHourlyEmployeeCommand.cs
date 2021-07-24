namespace PayrollPreparation.Application.AddEmployee.Commands
{
    public class AddHourlyEmployeeCommand : AddEmployeeCommand
    {
        public double Rate { get; }

        public AddHourlyEmployeeCommand(
            string name,
            string address,
            double rate) : base(name, address)
        {
            Rate = rate;
        }
    }
}