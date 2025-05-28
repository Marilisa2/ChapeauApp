using ChapeauApp.Enums;

namespace ChapeauApp.Services.Interfaces
{
    public interface IPaymentMethodsService
    {
        //List of the paymentmethods is needed not payment
        List<PaymentMethod> GetAvailablePaymentMethods();
    }
}
