using ChapeauApp.Enums;

namespace ChapeauApp.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeTypes EmployeeType { get; set; }

        public EmployeeViewModel(Employee employee)
        {
            EmployeeId=employee.EmployeeId;
            FirstName = employee.FirstName ;
            LastName = employee.LastName ;
            EmployeeType = employee.EmployeeType ;
        }

        public EmployeeViewModel()
        {
        }

    }
}
