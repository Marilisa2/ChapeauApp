using Microsoft.Data.SqlClient;
using ChapeauApp.Models;

namespace ChapeauApp.Repositories.Interfaces
{
    public interface IMenusRepository
    {
        Menu ReadMenu(SqlDataReader reader);
        List<Menu> GetAllMenus();
        MenuItem ReadMenuItem(SqlDataReader reader);
        List<MenuItem> GetAllMenuItems();

    }
}
