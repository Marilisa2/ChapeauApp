using ChapeauApp.Models;

namespace ChapeauApp.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {       
        public Employee GetEmployeeById(int id);       
        Employee GetEmployeeByLoginCredentials(string lastName, string password);
        public string GetSalt(string lastName);
    }
}
