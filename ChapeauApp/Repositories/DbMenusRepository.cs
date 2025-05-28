using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using ChapeauApp.Enums;
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
        /*public List<Menu> MenusMaker(List<MenuItem> menuItems)
        {
            List<Menu> menus = new();
            List<int> checklist = new();//Contains all menuIds from the Menus that have been added to List<Menu> menus.
            foreach (MenuItem item in menuItems)
            {
                //If List<Menu> menus doesn't contain the given MenuId, make a new Menu and add the MenuItem to the new Menu.
                if (!checklist.Contains(item.Menu.MenuId)) 
                {
                    List<MenuItem> menuItemsCreator = new([item]);
                    Menu menu = new Menu(item.Menu.MenuId, item.Menu.MenuName, menuItemsCreator);
                    checklist.Add(item.Menu.MenuId);
                    menus.Add(menu);
                }
                //If List<Menu> menus does contain the given MenuId, retrieve the correct Menu and add the MenuItem to the Menu.
                else
                {
                    foreach(Menu menu in menus)
                    {
                        if (menu.MenuId == item.Menu.MenuId)
                        {
                            menu.MenuItems.Add(item);
                            break;
                        }
                    }
                }
            }
            return menus;
        }*/
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

        /*
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
            Menu menu = new();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT menuId, menuName FROM menus WHERE menuId = @MenuId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MenuId", menuId);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    menu = ReadMenu(reader); 
                }
            }
            return menu;
        }
        public Menu ReadMenu(SqlDataReader reader)
        {
            int menuId = (int)reader["menuId"];
            string menuName = (string)reader["menuName"];
            Menu menu = new(menuId, menuName);
            return menu;
        }*/
        public MenuItem ReadMenuItem(SqlDataReader reader)
        {
            int menuItemId = (int)reader["menuItemId"];
            int menuId = (int)reader["menuId"];
            MenuItemCard menuItemCard = GetMenuItemCard(menuId);
            string itemName = (string)reader["itemName"];
            decimal itemPrice = (decimal)reader["itemPrice"];
            if (itemPrice < 0)
                throw new Exception($"The itemPrice is negative for menuItemId {menuItemId} in the database!");
            if (itemPrice == null)
                throw new Exception($"The itemPrice has no value for menuItemId {menuItemId} in the database!");
            string itemType = (string)reader["itemType"];
            if (itemType == null)
                throw new Exception($"The itemType has no value for menuItemId {menuItemId} in the database!");
            MenuItemCategory itemCategory = GetMenuItemCategory(itemType);
            //string description = (string)reader["itemDescription"] != null ? (string)reader["itemDescription"] : "";
            string description = (reader["itemDescription"] as string) ?? "";

            /*if ((string)reader["itemDescription"] != null)
            {
                description = (string)reader["itemDescription"]!;
            }
            else { description = ""; }
            description ??= "";*/
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
            switch (menuName)
            {
                case null:
                case "all":
                case "All":
                    menuItemCard = MenuItemCard.All;
                    break;
                case "Dranken":
                    menuItemCard = MenuItemCard.Dranken;
                    break;
                case "Lunch":
                    menuItemCard = MenuItemCard.Lunch;
                    break;
                case "Diner":
                    menuItemCard = MenuItemCard.Diner;
                    break;
                default:
                    throw new Exception("Invalid menuName!");
            }
            return menuItemCard;
        }
        
        
        public MenuItemCategory GetMenuItemCategory(string itemType)
        {
            MenuItemCategory menuItemCategory = new();
            switch (itemType)
            {
                case null:
                case "all":
                case "All":
                    menuItemCategory = MenuItemCategory.All;
                    break;
                case "Voorgerecht":
                    menuItemCategory = MenuItemCategory.Voorgerecht;
                    break;
                case "Tussengerecht":
                    menuItemCategory = MenuItemCategory.Tussengerecht;
                    break;
                case "Hoofdgerecht":
                    menuItemCategory = MenuItemCategory.Hoofdgerecht;
                    break;
                case "Nagerecht":
                    menuItemCategory = MenuItemCategory.Nagerecht;
                    break;
                case "Koffie / Thee":
                    menuItemCategory = MenuItemCategory.KoffieThee;
                    break;
                case "Bieren van de tap":
                case "Bieren":
                case "bieren":
                case "bier":
                    menuItemCategory = MenuItemCategory.Bieren;
                    break;
                case "Wijnen":
                    menuItemCategory = MenuItemCategory.Wijnen;
                    break;
                case "Gedistilleerde drank":
                    menuItemCategory = MenuItemCategory.GedistilleerdeDrank;
                    break;
                default:
                    throw new Exception($"{itemType} is an invalid itemType/itemCategory!");
            }
            return menuItemCategory;
        }
    }
}
