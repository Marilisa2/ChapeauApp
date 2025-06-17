using ChapeauApp.Models;

namespace ChapeauApp.Services.Interfaces
{
    public interface IVatsService
    {
        public VatSummary CalculateVatTotalAmount(List<OrderItem> orderItems);
    }
}
