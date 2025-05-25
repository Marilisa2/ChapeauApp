using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace ChapeauApp.Services
{
    public class MenusService : IMenusService
    {
        private readonly IMenusRepository _menusrepository;
        public MenusService(IMenusRepository lecturersRepository)
        {
            _menusrepository = lecturersRepository;
        }

        public MenusViewModel GetMenusViewModel(string? cardName, string? itemCategory)
        {
            string query = GetQuery(cardName, itemCategory);
            MenusViewModel menuViewModel = _menusrepository.GetMenusViewModel(query, cardName, itemCategory);
            return menuViewModel;
        }
        public string GetQuery(string? cardName, string? itemCategory)
        {
            string query;
            if (cardName == null && itemCategory == null)
            {
                cardName = "All";
                itemCategory = "All";
                query = "SELECT menuItemId, menuId, itemName, itemPrice, itemType, itemDescription, itemStock, vat_Amount FROM menuItems";
                return query;
            }
            else if (cardName != null && itemCategory == null)
            {
                query = "SELECT menuItemId, menuId, itemName, itemPrice, itemType, itemDescription, itemStock, vat_Amount FROM menuItems WHERE menuId IN (SELECT menuId FROM menus WHERE menuName = @MenuName)";
                return query;
            }
            else if (cardName == null && itemCategory != null)
            {
                query = "SELECT menuItemId, menuId, itemName, itemPrice, itemType, itemDescription, itemStock, vat_Amount FROM menuItems WHERE itemType = @Itemtype";
                return query;
            }
            else if (cardName != null && itemCategory != null)
            {
                query = "SELECT menuItemId, menuId, itemName, itemPrice, itemType, itemDescription, itemStock, vat_Amount " +
                        "FROM menuItems WHERE menuId IN (SELECT menuId FROM menus WHERE menuName = @MenuName) AND itemType = @ItemType";
                return query;
            }
            else
            {
                throw new Exception("Something went terribly wrong in the MenusService!");
            }
        }
    }
}
