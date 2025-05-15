namespace ChapeauApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeType { get; set; }
        public string Password { get; private set; }

        public Employee(int employeeId, string firstName, string lastName, string employeeType, string password)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            EmployeeType = employeeType;
            Password = password;
        }

        public Employee()
        {
        }
    }
}
