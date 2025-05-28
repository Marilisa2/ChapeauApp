using ChapeauApp.Models;

namespace ChapeauApp.Repositories.Interfaces
{
    //tijdelijke IEmployeeRepository tot teamgenoot klaar is
    public interface IEmployeeRepository
    {
        Employee? GetEmployeeById(int id);
    }
}
