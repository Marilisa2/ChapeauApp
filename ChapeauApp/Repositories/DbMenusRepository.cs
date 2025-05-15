using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace ChapeauApp.Repositories
{
    public class DbMenusRepository : IMenusRepository
    {
        public List<MenuItem> GetAllMenuItems()
        {
            throw new NotImplementedException();
        }

        public List<Menu> GetAllMenus()
        {
            throw new NotImplementedException();
        }

        public Menu ReadMenu(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public MenuItem ReadMenuItem(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
