namespace ChapeauApp.Models
{
    public class Employee
    {
        int EmployeeId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmployeeType { get; set; }
        string Password { get; set; }

        public Employee()
        {
            
        }

        public Employee(int employeeId, string firstName, string lastName, string employeeType, string password)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            EmployeeType = employeeType;
            Password = password;
        }
    }
    
}
