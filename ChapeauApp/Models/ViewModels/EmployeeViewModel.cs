namespace ChapeauApp.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeType { get; set; }

        public EmployeeViewModel(Employee employee)
        {
            FirstName = employee.FirstName ;
            LastName = employee.LastName ;
            EmployeeType = employee.EmployeeType ;
        }

        public EmployeeViewModel()
        {
        }

    }
}
