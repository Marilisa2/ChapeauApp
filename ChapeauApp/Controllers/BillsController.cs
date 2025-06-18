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
        private readonly IPaymentsService _paymentsService;

        public BillsController(IBillsService billsService, IOrdersService ordersService, IPaymentsService paymentsService)
        {
            _billsService = billsService;
            _ordersService = ordersService;
            _paymentsService = paymentsService;
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
                ModelState.AddModelError("TipAmount", "Tip amount must be postive"); //aanpassen!!!
                return View(settleBillViewmodel);
            }

            _billsService.SaveTipAmount(settleBillViewmodel.BillId, settleBillViewmodel.TipAmount ?? 0); 
            //_billsService.SavePaymentMethod(settleBillViewmodel.BillId, settleBillViewmodel.PaymentMethod);

            //paymentId eerst ophalen
            int paymentId = _paymentsService.GetPaymentIdForBill(settleBillViewmodel.BillId);
            _paymentsService.SavePaymentMethod(paymentId, settleBillViewmodel.PaymentMethod);

            //FeedbackText
            _billsService.SaveFeedbackText(settleBillViewmodel.BillId, settleBillViewmodel.FeedbackText);
                        
            TempData["ConfirmationMessage"] = "The order has been finished correctly!";
            return RedirectToAction("Index", "Orders"); //aanpassen teruggestuurd naar Tafeloverzicht
            //return View(settleBillViewmodel);
        } 
    }
}