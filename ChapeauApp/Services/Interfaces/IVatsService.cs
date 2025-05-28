using ChapeauApp.Models;

namespace ChapeauApp.Services.Interfaces
{
    public interface IVatsService
    {
        public VatSummary CalculateVatTotalAMount(List<OrderItem> orderItems);
    }
}
