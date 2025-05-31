using Microsoft.AspNetCore.Mvc;
using ChapeauApp.Repositories;
using ChapeauApp.Models;
using ChapeauApp.Services;
using ChapeauApp.Models.ViewModels;

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

        public IActionResult Index()
        {


            try
            {
                
                // get all users from database
                List<Employee> users = _employeeService.GetAllEmployees();
                Employee? LoggedInEmployee = HttpContext.Session.GetObject<Employee>("LoggedInemployee");

                ViewData["LoggedInEmployee"] = LoggedInEmployee;
                // send all users to view


                return View(users);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Users");
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginModel)
        {
            try
            {
                User user = _usersRepository.GetByLoginCredentials(loginModel.UserName, loginModel.Password);
                if (user == null)
                {
                    ViewBag.ErrorMessage = "this username/password combination doesn't exist";
                    return View(loginModel);
                }
                else
                {

                    HttpContext.Session.SetObject("LoggedInUser", user);


                    return RedirectToAction("Index", "Users");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Users");
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            try
            {
                _usersRepository.Add(user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(user);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                User user = _usersRepository.GetById(id);
                return View(user);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Users");
            }
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            try
            {
                _usersRepository.Update(user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(user);
            }
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            try
            {
                User user = _usersRepository.GetById(id);
                return View(user);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Users");
            }
        }
        [HttpPost]
        public IActionResult Remove(User user)
        {
            try
            {
                _usersRepository.Delete(user.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(user);
            }
            ;
        }
    }

}
}
