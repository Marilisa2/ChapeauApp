using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Services.Interfaces
{
    public interface ILoginOrOffService
    {
        Employee GetEmployeeByLoginCredentials(LoginViewModel loginViewModel);        
    }
}
