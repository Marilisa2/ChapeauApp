using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;

namespace ChapeauApp.Services
{
    public class LoginOrOffService : ILoginOrOffService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordService _passwordService;

        public LoginOrOffService(IEmployeeRepository employeeRepository, IPasswordService passwordService)
        {
            _employeeRepository = employeeRepository;
            _passwordService = passwordService;
        }

        public Employee GetEmployeeByLoginCredentials(LoginViewModel loginViewModel)
        {                   
                string interleavedPassword = _passwordService.InterleaveSalt(loginViewModel.Password, _employeeRepository.GetSalt(loginViewModel.LastName));
                return _employeeRepository.GetEmployeeByLoginCredentials(loginViewModel.LastName, _passwordService.HashPassword(interleavedPassword));            
        }     
    }
}
