using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Services.Interfaces
{
    public interface IEmployeeService
    {
         List<Employee> GetAllEmployees();
         Employee GetEmployeeById(int id);
         Employee AddEmployee(Employee employee);
         Employee UpdateEmployee(Employee employee);
         void DeleteEmployee(int id);
        
         Employee GetEmployeeById(int id);
        
        
    }
}
