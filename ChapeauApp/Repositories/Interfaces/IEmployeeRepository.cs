using ChapeauApp.Models;

namespace ChapeauApp.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllEmployees();
        public Employee GetEmployeeById(int id);
        public Employee AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public void DeleteEmployee(int id);
        Employee GetEmployeeByLoginCredentials(int EmployeeId, string password);
    }
}
