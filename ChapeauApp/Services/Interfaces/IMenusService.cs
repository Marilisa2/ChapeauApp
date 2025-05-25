using ChapeauApp.Models.ViewModels;
using ChapeauApp.Models;
using Microsoft.Data.SqlClient;

namespace ChapeauApp.Services.Interfaces
{
    public interface IMenusService
    {
        MenusViewModel GetMenusViewModel(string? card, string? category);
    }
}
