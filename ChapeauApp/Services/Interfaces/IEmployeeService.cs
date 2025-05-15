using ChapeauApp.Models;

namespace ChapeauApp.Services.Interfaces
{
    public interface IEmployeeService
    {
         List<Employee> GetAllEmployees();
         Employee GetEmployeeById(int id);
         Employee AddEmployee(Employee employee);
         void UpdateEmployee(Employee employee);
         void DeleteEmployee(int id);
        
    }
}
