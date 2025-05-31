using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Services.Interfaces;

namespace ChapeauApp.Services
{
    public class PaymentMethodsService : IPaymentMethodsService
    {
        List<PaymentMethod> IPaymentMethodsService.GetAvailablePaymentMethods()
        {
            return Enum.GetValues<PaymentMethod>().ToList();
        }
    }
}
