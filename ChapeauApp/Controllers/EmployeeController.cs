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

        public IActionResult Index()
        {


            try
            {
                
                
                List<Employee> employees = _employeeService.GetAllEmployees();
                Employee? LoggedInEmployee = HttpContext.Session.GetObject<Employee>("LoggedInEmployee");

                ViewData["LoggedInEmployee"] = LoggedInEmployee;
               
                return View(employees);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Employee");
            }
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
               Employee employee = _loginOrOffService.GetEmployeeByLoginCredentials(loginViewModel.EmployeeId,loginViewModel.Password);
                if (employee == null)
                {
                    ViewBag.ErrorMessage = "this username/password combination doesn't exist";
                    return View(loginViewModel);
                }
                else
                {

                    HttpContext.Session.SetObject("LoggedInEmployee", employee);


                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            try
            {
                _employeeService.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(employee);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                Employee employee = _employeeService.GetEmployeeById(id);
                return View(employee);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            try
            {
                _employeeService.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(employee);
            }
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            try
            {
                Employee employee = _employeeService.GetEmployeeById(id);
                return View(employee);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Remove(Employee employee)
        {
            try
            {
                _employeeService.DeleteEmployee(employee.EmployeeId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(employee);
            }
            
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }

}

