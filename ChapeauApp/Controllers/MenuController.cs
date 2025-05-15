using Microsoft.AspNetCore.Mvc;

namespace ChapeauApp.Controllers
{
    public class MenuController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
