using ChapeauApp.Models.ViewModels;
using ChapeauApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChapeauApp.Controllers
{
    public class BarKitchenController : Controller
    {
        private readonly IOrdersService _ordersService;
        public BarKitchenController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RunningOrders(string section) 
        {
            List<RunningOrdersViewModel> runningOrders = _ordersService.GetRunningOrdersBySection(section);
            return View(runningOrders);
        }
    }
}
