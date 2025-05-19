using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections;
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
        public MenuViewModel GetMenuViewModel(string? cardName, string? itemCategory) 
        {

            List<MenuItem> menuItems;
            string query = GetQuery(cardName, itemCategory);
            menuItems = GetMenuItems(query, cardName, itemCategory);
            MenuViewModel menusViewModel = new(menuItems);
            return menusViewModel;
        }
        public string GetQuery(string? cardName, string? itemCategory)
        {
            string query;
            if (cardName == null && itemCategory == null)
            {
                query = "SELECT * FROM menuItems";
                return query;
            }
            else if (cardName != null && itemCategory == null)
            {
                query = "SELECT * FROM menuItems WHERE menuId IN (SELECT menuId FROM menus WHERE menuName = @MenuName)";
                return query;
            }
            else if (cardName == null && itemCategory != null)
            {
                query = "SELECT * FROM menuItems WHERE itemType = @Itemtype";
                return query;
            }
            else if (cardName != null && itemCategory != null)
            {
                query = "SELECT * FROM menuItems WHERE menuId IN (SELECT menuId FROM menus WHERE menuName = @MenuName) AND itemType = @ItemType";
                return query;
            }
            else
            {
                throw new Exception("Something went terribly wrong!");
            }
        }
        public List<MenuItem> GetMenuItems(string query, string card, string category)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (card != null )
                command.Parameters.AddWithValue("@MenuName", card);
                if (category != null)
                    command.Parameters.AddWithValue("@ItemType", category);
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
