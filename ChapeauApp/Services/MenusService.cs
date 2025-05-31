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

        //cardName is menuName in the database.
        //itemCategory is itemType in the database but should have been courseName to avoid confusion.
        //Naming things really is some of the most difficult things in programming.
        public MenuViewModel GetMenuViewModel(string? cardName, string? itemCategory)
        {
            try
            {
                string query = GetQuery(cardName, itemCategory);
                MenuViewModel menuViewModel = _menusrepository.GetMenusViewModel(query, cardName, itemCategory);
                return menuViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string GetQuery(string? cardName, string? itemCategory)
        {
            if (cardName == null)
                cardName = "All";
            cardName = cardName.ToLower();
            if (itemCategory == null)
                itemCategory = "All";
            itemCategory = itemCategory.ToLower();

            string query = "SELECT menuItemId, menuId, itemName, itemPrice, itemType, itemDescription, itemStock, vat_Amount FROM MenuItems";
            if (cardName != "all" || itemCategory != "all")
            {
                query += " WHERE";
            }
            if (cardName != "all") 
            { 
                query += " menuId IN (SELECT menuId FROM Menus WHERE menuName = @MenuName)"; 
            }
            if (cardName != "all" && itemCategory != "all")
            {
                query += " AND";
            }
            if (itemCategory != "all")
            {
                query += " itemType = @Itemtype";
            }
            return query;
        }
    }
}
