using ChapeauApp.Models;

namespace ChapeauApp.Services.Interfaces
{
    public interface ILoginOrOffService
    {
        Employee GetEmployeeByLoginCredentials(int EmployeeId, string password);        
    }
}
