using ChapeauApp.Enums;

namespace ChapeauApp.Repositories.Interfaces
{
    public interface IPaymentsRepository
    {
        void SavePaymentMethod(int paymentId, PaymentMethod paymentMethod);
        int GetPaymentIdForBill(int billId); //moet int zijn want paymentId en billId zijn int
    }
}
