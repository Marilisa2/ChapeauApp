using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;

namespace ChapeauApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByLoginCredentials(int EmployeeId, string password)
        {
            throw new NotImplementedException();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
