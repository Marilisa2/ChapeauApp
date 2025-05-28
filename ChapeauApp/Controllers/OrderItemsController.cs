using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Repositories;
using ChapeauApp.Services;
using ChapeauApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChapeauApp.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly IOrderItemsService _orderItemsService;
        public OrderItemsController(IOrderItemsService orderItemsService)
        {
            _orderItemsService = orderItemsService;
        }

        public IActionResult Index()
        {
            var orderItems = _orderItemsService.GetAllOrderItems();  
            return View(orderItems);
        }

        [HttpPost]
        public IActionResult UpdateOrder(OrderItem orderItem)
        {
            try
            {
                _orderItemsService.UpdateOrderItem(orderItem);
             
                    TempData["SuccesMessage"] = "Item is succesfully updated";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Item could not be updated";
            }
            return RedirectToAction("RunningOrders");
        }
    }
}
