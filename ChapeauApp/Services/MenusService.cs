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
            //This will be used later for the implemention of basing the card on the time of day and displaying the current time.
            //This doesn't work yet, because the hours are stored in AM/PM format. This means that when the time is 15:30, int hours will have a value of 3.
            /*DateTime timeNow = DateTime.Now;
            string day = timeNow.ToString("yyyy/MM/dd");
            string time = timeNow.ToString("hh:mm:ss");
            int hours = int.Parse(timeNow.ToString("hh"));
            if (cardName == null)
            { 
                if (hours > 17 && hours < 21)
                {
                    cardName = "diner";
                }
                else if(hours > 11 && hours < 16)
                {
                    cardName = "lunch";
                }
                else {
                    cardName = "all";
                }
            }
            else
            { cardName = cardName.ToLower(); }
            */

            if (cardName == null)
            { cardName = "all"; }
            else 
            { cardName = cardName.ToLower(); }
            
            if (itemCategory == null)
            { itemCategory = "all"; }
            else
            { itemCategory = itemCategory.ToLower(); }

            string query = "SELECT menuItemId, menuId, itemName, itemPrice, itemCategory, itemDescription, itemStock, vat_Amount FROM MenuItems";
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
