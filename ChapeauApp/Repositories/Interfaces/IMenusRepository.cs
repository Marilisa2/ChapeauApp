using Microsoft.Data.SqlClient;
using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Repositories.Interfaces
{
    public interface IMenusRepository
    {
        MenuViewModel GetMenusViewModel(string? query, string? card, string? category);
        MenuItem ReadMenuItem(SqlDataReader reader);
    }
}
