using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ChapeauApp.Services.Interfaces;

namespace ChapeauApp.Controllers
{
    public class OrdersController : Controller
    {
        //database
        private readonly IOrdersRepository _ordersRepository;
        private readonly ITableRepository _tablesRepository;
        private readonly IOrdersService _ordersService;
        private readonly IVatsService _vatsService;

        public OrdersController(IOrdersRepository ordersRepository, ITableRepository tablesRepository, IOrdersService ordersService, IVatsService vatsService)
        {
            _ordersRepository = ordersRepository;
            _tablesRepository = tablesRepository;
            _ordersService = ordersService;
            _vatsService = vatsService;
        }

        public IActionResult Index()
        {
            List<Table> tables = _tablesRepository.GetAllTables();

            //orderviemodel
            OrdersViewModel ordersViewModel = new OrdersViewModel
            {
                Tables = tables
            };

            return View(ordersViewModel);
        }

        public IActionResult GetOrderByTableNumber(int tableNumber)
        {
            Order order = _ordersRepository.GetOrderByTableNumber(tableNumber);

            if (order == null)
            {
                return NotFound($"No order found for table: {tableNumber}");
            }

            //orderServices to calculate totalpriceamount
            decimal totalPriceAmount = _ordersService.CalculateTotalPriceAmount(order.OrderItems);

            //vatservice to display low and high vat amount
            VatSummary vatTotals = _vatsService.CalculateVatTotalAMount(order.OrderItems);

            //orderviewmodel
            OrdersViewModel ordersViewModel = new OrdersViewModel
            {
                Table = new Table { TableNumber = tableNumber },
                Order = order,
                TotalPricemount = totalPriceAmount,
                VatTotals = vatTotals
            };

            return View(ordersViewModel);
        }
    }
}