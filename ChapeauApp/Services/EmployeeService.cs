using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;

namespace ChapeauApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordService _passwordService;

        public EmployeeService(IEmployeeRepository employeeRepository, IPasswordService passwordService)
        {
            _employeeRepository = employeeRepository;
            _passwordService = passwordService;
        }

        public Employee AddEmployee(EmployeeCUDViewModel employee)
        {
            string salt = _passwordService.GenerateSalt();
            string interleavedPassword = _passwordService.InterleaveSalt(employee.Password, salt);
            Employee employee1 = new Employee(employee.EmployeeId, employee.FirstName, employee.LastName, employee.EmployeeType, _passwordService.HashPassword(interleavedPassword), salt);           
            return _employeeRepository.AddEmployee(employee1);

        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }

        public List<EmployeeViewModel> GetAllEmployees()
        {
            List<Employee> employees= _employeeRepository.GetAllEmployees();
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            foreach (Employee employee in employees) 
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel(employee);
                employeeViewModels.Add(employeeViewModel);

            }
            return employeeViewModels;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

       
    }
}
