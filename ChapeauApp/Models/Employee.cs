namespace ChapeauApp.Models
{
    using ChapeauApp.Enums;
    
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeTypes EmployeeType { get; set; }
        public string HashedPassword { get; private set; }
        public string Salt{ get; set; }

        public Employee(int employeeId, string firstName, string lastName, EmployeeTypes employeeType, string password)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            EmployeeType = employeeType;
            HashedPassword = password;
            
        }

        public Employee(int employeeId, string firstName, string lastName, EmployeeTypes employeeType, string password, string salt) : this(employeeId, firstName, lastName, employeeType, password)
        {
            Salt = salt;
        }

        public Employee()
        {
        }

        
    }
}
