using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;

namespace ChapeauApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee AddEmployee(Employee employee)
        {
           return _employeeRepository.AddEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
           return _employeeRepository.GetEmployeeById(id);
        }

        public Employee UpdateEmployee(Employee employee)
        {
           return _employeeRepository.UpdateEmployee(employee);
        }
    }
}
