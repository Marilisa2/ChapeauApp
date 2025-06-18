using AspNetCoreGeneratedDocument;
using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;

namespace ChapeauApp.Services
{
    public class BillsService : IBillsService
    {
        private readonly IBillsRepository _billsRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IVatsService _vatsService;

        public BillsService(IBillsRepository billsRepository, IOrdersRepository ordersRepository, ITableRepository tableRepository, IVatsService vatsService)
        {
            _billsRepository = billsRepository;
            _ordersRepository = ordersRepository;
            _tableRepository = tableRepository;
            _vatsService = vatsService;
        }

        public GetBillByOrderAndTableNumberViewModel? GetBillByOrderAndTableNumberViewModel (int tableNumber)
        {
            Bill bill = _billsRepository.GetBillByTableNumber(tableNumber);
            Order order = _ordersRepository.GetOrderByTableNumber(tableNumber);
            Table table = _tableRepository.GetTableByTableNumber(tableNumber);

            if (bill == null || order == null || table == null)
            {
                return null;
            }

            return new GetBillByOrderAndTableNumberViewModel
            {
                Bill = bill,
                Order = order,
                Table = table
            };
        }

        public Bill GetCurrentBill()
        {
            throw new NotImplementedException();
        }//weghalen?

        //public void SavePaymentMethod(int paymentId, PaymentMethod paymentMethod)
        //{
        //    paymentId = _billsRepository.
        //}

        public void SaveTipAmount(int billId, decimal tipAmount)
        {
            _billsRepository.SaveTipAmount(billId, tipAmount);
        }

        public void SaveFeedbackText(int billId, string feedbackText)
        {
            _billsRepository.SaveFeedbackText(billId, feedbackText);
        }

        public SettleBillViewmodel? SettleBillViewmodel(int billId)
        {
            //haal Bill uit repository
            Bill? bill = _billsRepository.GetBillByBillId(billId);

            if (bill == null)
            {
                return null;
            }

            return new SettleBillViewmodel
            {
                BillId = bill.BillId,
                TotalPriceAmountExclTip = bill.TotalPriceAmountInclVAT,
                TipAmount = bill.TipAmount,
                FeedbackText = bill.FeedbackText,
            };
        }
    }
}
