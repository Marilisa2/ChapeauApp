using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChapeauApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenusService _menusService;
        public MenuController(IMenusService menusService)
        {
            _menusService = menusService;
        }
        
        //cardName is menuName in the database.
        //itemCategory is itemType in the database but should have been courseName to avoid confusion.
        //Naming things really is some of the most difficult things in programming.
        public IActionResult Index(string? card, string? category)
        {
            try
            {
                //Hardcoded offline backup (outdated)
                /*MenuItemCard card1 = MenuItemCard.Lunch;
                MenuItemCard card2 = MenuItemCard.Diner;
                MenuItemCard card3 = MenuItemCard.Dranken;
                List<MenuItem> AllMenuItems = [
                    new(1, card3, "Coffee", (decimal)2.99, "Drink", "This is coffee", 12, 9),
                    new(2, card3, "Cola", (decimal)1.99, "Drink", "This is cola", 19, 9),
                    new(3, card1, "Chips", (decimal)2.99, "Drink", "This is chips", 0, 9),
                    new(4, card3, "Wine", (decimal)5.99, "Drink", "This is wine", 2, 21)];
                Menu menu = new(AllMenuItems);
                MenuViewModel menuViewModel = new (menu);*/
                MenuViewModel menuViewModel = _menusService.GetMenuViewModel(card, category);
                return View(menuViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"The menu could not be loaded: {ex.Message}";//This message should be updated to give the client a clear idea of what went wrong.
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
