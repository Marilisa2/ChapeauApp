using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Services.Interfaces
{
    public interface IEmployeeService
    {
         List<EmployeeViewModel> GetAllEmployees();
         Employee GetEmployeeById(int id);
         Employee AddEmployee(EmployeeCUDViewModel employee);
         void UpdateEmployee(EmployeeCUDViewModel employee);
         void DeleteEmployee(int id);
        
    }
}
