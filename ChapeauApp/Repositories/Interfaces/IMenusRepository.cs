using Microsoft.Data.SqlClient;
using ChapeauApp.Models;

namespace ChapeauApp.Repositories.Interfaces
{
    public interface IMenusRepository
    {
        MenuItem ReadMenuItem(SqlDataReader reader);
        List<MenuItem> GetAllMenuItems();

    }
}
