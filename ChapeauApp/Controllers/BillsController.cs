using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ChapeauApp.Services.Interfaces;

namespace ChapeauApp.Controllers
{
    public class BillsController : Controller
    {
        private readonly IBillsService _billsService;
        private readonly IOrdersService _ordersService;

        public BillsController(IBillsService billsService, IOrdersService ordersService)
        {
            _billsService = billsService;
            _ordersService = ordersService;
        }

        public IActionResult GetBillByTableNumber(int tableNumber)
        {
            GetBillByOrderAndTableNumberViewModel getBillByOrderAndTableNumberViewModel = _billsService.GetBillByOrderAndTableNumberViewModel(tableNumber);

            if (getBillByOrderAndTableNumberViewModel == null)
            {
                return NotFound($"No bill found for table {tableNumber}");
            }

            return View(getBillByOrderAndTableNumberViewModel);
        }

        [HttpGet]
        public IActionResult SettleBill(int billId)
        {
            SettleBillViewmodel settleBillViewmodel = _billsService.SettleBillViewmodel(billId);

            if (settleBillViewmodel == null)
            {
                return NotFound("Bill not found");
            }

            return View(settleBillViewmodel);
        }

        [HttpPost]
        public IActionResult SettleBill(SettleBillViewmodel settleBillViewmodel)
        {
            if (settleBillViewmodel.TipAmount < 0)
            {
                ModelState.AddModelError("TipAmount", "TipAmount must be postive"); //aanpassen!!!
                return View(settleBillViewmodel);
            }

            _billsService.SaveTipAmount(settleBillViewmodel.BillId, settleBillViewmodel.TipAmount ?? 0); 
            _billsService.SavePaymentMethod(settleBillViewmodel.BillId, settleBillViewmodel.PaymentMethod);
                        
            TempData["SuccessMessage"] = "Payment was successful!"; //vervangen naar  the order has been finished correctly
            return RedirectToAction("Index", "Orders"); //aanpassen teruggestuurd naar Tafeloverzicht
        }

        
    }
}