using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Repositories.Interfaces
{
    public interface IBillsRepository
    {
        Bill? GetBillByBillId(int billId);
        Bill? GetBillByTableNumber (int tableNumber);
        void UpdateTipAmount(int billId, decimal tipAmount); //saves tip amount in the database -> naam wijzigen naar SaveTipAmount!
        void SaveFeedbackText(int billId, string feedbackText);
        //int GetPaymentForBill (int billId); //moet int zijn want paymentId en billId zijn int
        //void SavePaymentMethod (int billId, PaymentMethod paymentMethod); //billId en enum paymentMethod is nodig
        //void BillCheckOut(Bill bill); //weghalen
    }
}