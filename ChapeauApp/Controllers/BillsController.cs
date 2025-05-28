using ChapeauApp.Repositories;
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
        private readonly IBillsRepository _billsRepository;
        private readonly IPaymentMethodsService _paymentMethodsService;

        public BillsController(IBillsRepository billsRepository, IPaymentMethodsService paymentMethodsService)
        {
            _billsRepository = billsRepository;
            _paymentMethodsService = paymentMethodsService;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetByBillId(int billId)
        { 
            Bill bill = _billsRepository.GetByBillId(billId);

            if (bill == null)
            {
                return NotFound("No bill found");
            }

            //calling available payment methods from PaymentMethodsService
            List<PaymentMethod> availablepaymentMethods = _paymentMethodsService.GetAvailablePaymentMethods();

            //billsviewmodel
            BillsCheckOutViewModel billsCheckOutViewModel = new BillsCheckOutViewModel
            {
                Bill = bill,
                Payment = new Payment(),
                AvailablePaymentMethods = availablepaymentMethods
            };

            return View(billsCheckOutViewModel);
        }


    }
}
