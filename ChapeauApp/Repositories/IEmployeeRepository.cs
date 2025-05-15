using ChapeauApp.Models;

namespace ChapeauApp.Repositories
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllEmployees();
        public Employee GetEmployeeById(int id);
        public void AddEmployee(Employee employee);
    }
}
