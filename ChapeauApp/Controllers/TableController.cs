using Microsoft.AspNetCore.Mvc;

namespace ChapeauApp.Controllers
{
    public class TableController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
