using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Services.Interfaces
{
    public interface IPaymentsService
    {
        void SavePaymentMethod(int paymentId, PaymentMethod paymentMethod);
        int GetPaymentIdForBill(int billId); //moet int zijn want paymentId en billId zijn int
    }
}
