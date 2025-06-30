using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ChapeauApp.Services.Interfaces;
using ChapeauApp.Services;

namespace ChapeauApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;
        private readonly ITableService _tableService;
        private readonly IVatsService _vatsService;
        
        public OrdersController(IOrdersService ordersService, ITableService tableService, IVatsService vatsService)
        {
            _ordersService = ordersService;
            _tableService = tableService;            
            _vatsService = vatsService;
        }

        public IActionResult Index()
        {
            //List<Table> tables = _tablesRepository.GetAllTables();
            List<TableViewModel> tables = _tableService.GetAllTables();

            //orderviewmodel
            OrdersViewModel ordersViewModel = new OrdersViewModel
            {
                Tables = tables
            };

            return View(ordersViewModel);
        }

        // shows ordered items (orders)
        public IActionResult GetOrderByTableNumber(int tableNumber)
        {
            Order order = _ordersService.GetOrderByTableNumber(tableNumber);

            if (order == null)
            {
                return NotFound($"No order found for table: {tableNumber}");
            }

            return View(order);
            // calling the methode GetOrderByBillId(int bllId)
            //return GetOrderByBillId(order.Bill.BillId);
        }

        public IActionResult GetOrderByBillId(int billId)
        {
            Order order = _ordersService.GetOrderByBillId(billId);

            if (order == null)
            {
                return NotFound("Order not found for this bill.");
            }

            //orderServices to calculate totalpriceamount
            decimal totalPriceAmount = _ordersService.CalculateTotalPriceAmount(order.OrderItems);

            //vatservice to display low and high vat amount
            VatSummary vatTotals = _vatsService.CalculateVatTotalAmount(order.OrderItems);

            //orderviewmodel
            OrdersViewModel ordersViewModel = new OrdersViewModel
            {
                Table = order.Table,
                Order = order,
                TotalPriceAmount = totalPriceAmount,
                VatTotals = vatTotals
            };

            return View(ordersViewModel);
        }
    }
}