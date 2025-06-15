using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Services.Interfaces
{
    public interface IEmployeeService
    {
         Employee GetEmployeeById(int id);
        
        
    }
}
