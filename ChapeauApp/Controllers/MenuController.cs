using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChapeauApp.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                Menu menu1 = new (1, "dranken");
                Menu menu2 = new (2, "eten");
                List<MenuItem> AllMenuItems = [
                    new(1, menu1, "Coffee", (decimal)2.99, "Drink", "Dit is koffie", 12, 9),
                    new(2, menu1, "Cola", (decimal)1.99, "Drink", "Dit is cola", 19, 9),
                    new(3, menu2, "Chips", (decimal)2.99, "Drink", "Dit is chips", 0, 9),
                    new(4, menu1, "Wine", (decimal)5.99, "Drink", "Dit is wijn", 2, 21)];
                MenuViewModel menuViewModel = new (AllMenuItems);
                return View(menuViewModel);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
