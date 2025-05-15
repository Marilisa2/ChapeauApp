using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;

namespace ChapeauApp.Services
{
    public class LoginOrOffService : ILoginOrOffService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public LoginOrOffService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee GetEmployeeByLoginCredentials(int EmployeeId, string password)
        {
           return _employeeRepository.GetEmployeeByLoginCredentials(EmployeeId,password);
        }

        public void Logoff()
        {
            throw new NotImplementedException();
        }
    }
}
