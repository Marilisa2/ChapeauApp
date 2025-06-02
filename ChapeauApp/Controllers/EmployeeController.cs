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
                
                
                List<EmployeeViewModel> employees = _employeeService.GetAllEmployees();
                Employee? LoggedInEmployee = HttpContext.Session.GetObject<Employee>("LoggedInEmployee");

                ViewData["LoggedInEmployee"] = LoggedInEmployee;
               
                return View(employees);
            }
            catch (Exception)
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeCUDViewModel employee)
        {
            try
            {
                _employeeService.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            catch (Exception)
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
                EmployeeCUDViewModel employeeViewModel = new EmployeeCUDViewModel(employee);
                return View(employeeViewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(EmployeeCUDViewModel employee)
        {
            try
            {
                _employeeService.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            catch (Exception)
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
                EmployeeCUDViewModel employeeViewModel = new EmployeeCUDViewModel(employee);
                return View(employeeViewModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Remove(EmployeeCUDViewModel employee)
        {
            try
            {
                _employeeService.DeleteEmployee(employee.EmployeeId);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(employee);
            }
            
        }
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }

}

