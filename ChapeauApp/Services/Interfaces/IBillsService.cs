using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Services.Interfaces
{
    public interface IBillsService
    {
        //haalt de huidige rekening op voor een specifieke tafel
        GetBillByOrderAndTableNumberViewModel? GetBillByOrderAndTableNumberViewModel(int tableNumber);

        //haalt de afreken-viewmodel op voor de tip invoer
        SettleBillViewmodel? SettleBillViewmodel(int billId);
        Bill GetCurrentBill();//weghalen?
        void SaveTipAmount(int billId, decimal tipAmount);
        void SaveFeedbackText(int billId, string feedbackText);
        //void SavePaymentMethod (int billId, PaymentMethod paymentMethod); //billId en enum paymentMethod nodig
    }
}
