namespace ChapeauApp.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeType { get; set; }

        public EmployeeViewModel(string firstName, string lastName, string employeeType)
        {
            FirstName = firstName;
            LastName = lastName;
            EmployeeType = employeeType;
        }

        public EmployeeViewModel()
        {
        }
    }
}