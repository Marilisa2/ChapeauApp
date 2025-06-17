using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;

namespace ChapeauApp.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentsService(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        public void SavePaymentMethod(int paymentId, PaymentMethod paymentMethod)
        {
            _paymentsRepository.SavePaymentMethod(paymentId, paymentMethod);
        }

        public int GetPaymentIdForBill(int billId)
        {
            return _paymentsRepository.GetPaymentIdForBill(billId);
        }
    }
}
