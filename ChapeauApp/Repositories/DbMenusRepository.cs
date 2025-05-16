using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace ChapeauApp.Repositories
{
    public class DbMenusRepository : IMenusRepository
    {
        private readonly string? _connectionString;
        public DbMenusRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Chapeau");
        }
        public MenuViewModel GetMenuViewModel() 
        {
            List<MenuItem> menuItems = GetAllMenuItems();
            MenuViewModel menusViewModel = new(menuItems);
            return menusViewModel;
        }
        public List<MenuItem> GetAllMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                string query = "SELECT * FROM menuItems";
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MenuItem menuItem = ReadMenuItem(reader);
                    menuItems.Add(menuItem);
                }
            }
            return menuItems;
        }

        public MenuItem ReadMenuItem(SqlDataReader reader)
        {
            int menuItemId = (int)reader["menuItemId"];
            int menuId =  (int)reader["menuId"];
            Menu menu = GetMenu(menuId);
            string itemName = (string)reader["itemName"];
            decimal itemPrice = (decimal)reader["itemPrice"];
            string itemType = (string)reader["itemType"];
            string description = (string)reader["itemDescription"];
            int stock = (int)reader["itemStock"];
            int vATAmount = (int)reader["vat_Amount"];
            MenuItem menuItem = new(menuItemId, menu, itemName, itemPrice, itemType, description, stock, vATAmount);
            return menuItem;
        }
        public Menu GetMenu(int menuId) 
        {
            Menu menu = new Menu();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM menus WHERE menuId = @MenuId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MenuId", menuId);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                ReadMenu(reader);
            }
            return menu;
        }
        public Menu ReadMenu(SqlDataReader reader)
        {
            int menuId = (int)reader["menuId"];
            string menuName = (string)reader["menuName"];
            Menu menu = new(menuId, menuName);
            return menu;
        }

    }
}
