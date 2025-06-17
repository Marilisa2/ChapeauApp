using Microsoft.AspNetCore.Mvc;
using ChapeauApp.Models;
using ChapeauApp.Models.Extensions;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Services.Interfaces;


namespace ChapeauApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILoginOrOffService _loginOrOffService;

        public EmployeeController(IEmployeeService employeeService, ILoginOrOffService loginOrOffService)
        {
            _employeeService = employeeService;
            _loginOrOffService = loginOrOffService;
        }        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            try
            {
               Employee employee = _loginOrOffService.GetEmployeeByLoginCredentials(loginViewModel );
                if (employee == null)
                {
                    ViewBag.ErrorMessage = "this username/password combination doesn't exist";
                    return View(loginViewModel);
                }
                else
                {

                    HttpContext.Session.SetObject("LoggedInEmployee", employee);


                    return RedirectToAction("Index","Table");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Login");
            }
        }        
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }

}

