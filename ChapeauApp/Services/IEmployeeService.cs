using ChapeauApp.Models;

namespace ChapeauApp.Services
{
    public interface IEmployeeService
    {
         List<Employee> GetAllEmployees();
         Employee GetEmployeeById(int id);
         Employee AddEmployee(Employee employee);
         Employee UpdateEmployee(Employee employee);
         void DeleteEmployee(int id);
        
    }
}
