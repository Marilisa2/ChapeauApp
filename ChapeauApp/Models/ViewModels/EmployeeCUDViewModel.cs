using ChapeauApp.Enums;

namespace ChapeauApp.Models.ViewModels
{
    public class EmployeeCUDViewModel
    {
        public EmployeeCUDViewModel()
        {
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeTypes EmployeeType { get; set; }
        public string Password { get; set; }

        public EmployeeCUDViewModel(Employee employee)
        {
            EmployeeId = employee.EmployeeId;
            FirstName =employee.FirstName;
            LastName =employee.LastName ;
            EmployeeType =employee.EmployeeType ;
           
        }
    }
}
