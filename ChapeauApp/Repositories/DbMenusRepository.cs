using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using ChapeauApp.Enums;
using System.Collections;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;

namespace ChapeauApp.Repositories
{
    public class DbMenusRepository : IMenusRepository
    {
        private readonly string? _connectionString;
        public DbMenusRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Chapeau");
        }
        
        //cardName is menuName in the database.
        //itemCategory is itemType in the database but should have been courseName to avoid confusion.
        //Naming things really is some of the most difficult things in programming.
        public MenuViewModel GetMenusViewModel(string? query, string? cardName, string? itemCategory)
        {
            List<MenuItem> menuItems = GetMenuItems(query, cardName, itemCategory);
            Menu menu = new(menuItems, MenuItemSwitch(cardName), GetMenuItemCategory(itemCategory));
            MenuViewModel viewModel = new(menu);
            return viewModel;
        }
        public List<MenuItem> GetMenuItems(string query, string card, string category)
        {
            //Sets the default value for the filters card and category
            if (card == null)
                card = "All";
            if (category == null)
                category = "All";

            List<MenuItem> menuItems = new List<MenuItem>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                
                //Only adds the parameters if they are needed
                if (card != "All")
                command.Parameters.AddWithValue("@MenuName", card);
                if (category != "All")
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
            int menuId = (int)reader["menuId"];
            MenuItemCard menuItemCard = GetMenuItemCard(menuId);
            string itemName = (string)reader["itemName"];
            decimal itemPrice = (decimal)reader["itemPrice"];
            if (itemPrice < 0)
                throw new Exception($"The itemPrice is negative for menuItemId {menuItemId} in the database!");
            string itemType = (string)reader["itemCategory"];
            if (itemType == null)
                throw new Exception($"The itemType has no value for menuItemId {menuItemId} in the database!");
            MenuItemCategory itemCategory = GetMenuItemCategory(itemType);
            string description = (reader["itemDescription"] as string) ?? "";
            int stock = (int)reader["itemStock"];
            int vATAmount = (int)reader["vat_Amount"];
            MenuItem menuItem = new(menuItemId, menuItemCard, itemName, itemPrice, itemCategory, description, stock, vATAmount);
            return menuItem;
        }
        public MenuItemCard GetMenuItemCard(int menuId)
        {
            MenuItemCard menuItemCard = new();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT menuId, menuName FROM Menus WHERE menuId = @MenuId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MenuId", menuId);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    menuItemCard = ReadMenuItemCard(reader);
                }
            }
            return menuItemCard;
        }
        public MenuItemCard ReadMenuItemCard(SqlDataReader reader)
        {
            string menuName = (string)reader["menuName"];
            MenuItemCard menuItemCard = MenuItemSwitch(menuName);
            return menuItemCard;
        }
        public MenuItemCard MenuItemSwitch(string menuName)
        {
            MenuItemCard menuItemCard = new();
            if (!string.IsNullOrEmpty(menuName) && menuName != null)
                menuName = menuName.ToLower();
            switch (menuName)
            {
                case null:
                case "all":
                    menuItemCard = MenuItemCard.All;
                    break;
                case "dranken":
                    menuItemCard = MenuItemCard.Dranken;
                    break;
                case "lunch":
                    menuItemCard = MenuItemCard.Lunch;
                    break;
                case "diner":
                    menuItemCard = MenuItemCard.Diner;
                    break;
                default:
                    throw new Exception($"{menuName} is an invalid menuName!");
            }
            return menuItemCard;
        }
        
        
        public MenuItemCategory GetMenuItemCategory(string itemType)
        {
            MenuItemCategory menuItemCategory = new();
            if (!string.IsNullOrEmpty(itemType) && itemType != null)
            itemType = itemType.ToLower();
            switch (itemType)
            {
                case null:
                case "all":
                    menuItemCategory = MenuItemCategory.All;
                    break;
                case "voorgerecht":
                    menuItemCategory = MenuItemCategory.Voorgerecht;
                    break;
                case "tussengerecht":
                    menuItemCategory = MenuItemCategory.Tussengerecht;
                    break;
                case "hoofdgerecht":
                    menuItemCategory = MenuItemCategory.Hoofdgerecht;
                    break;
                case "nagerecht":
                    menuItemCategory = MenuItemCategory.Nagerecht;
                    break;
                case "koffie / thee":
                case "koffiethee":
                    menuItemCategory = MenuItemCategory.KoffieThee;
                    break;
                case "bieren van de tap":
                case "bieren":
                case "bier":
                    menuItemCategory = MenuItemCategory.Bieren;
                    break;
                case "wijnen":
                    menuItemCategory = MenuItemCategory.Wijnen;
                    break;
                case "gedistilleerde drank":
                case "gedistilleerdedrank":
                    menuItemCategory = MenuItemCategory.GedistilleerdeDrank;
                    break;
                default:
                    throw new Exception($"{itemType} is an invalid itemType/itemCategory!");
            }
            return menuItemCategory;
        }
    }
}
