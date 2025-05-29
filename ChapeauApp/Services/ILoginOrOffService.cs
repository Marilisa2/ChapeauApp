using ChapeauApp.Models;

namespace ChapeauApp.Services
{
    public interface ILoginOrOffService
    {
        Employee GetEmployeeByLoginCredentials(int EmployeeId, string password);
        void Logoff();
    }
}
