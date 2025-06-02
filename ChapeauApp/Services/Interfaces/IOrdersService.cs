using ChapeauApp.Models;

namespace ChapeauApp.Services.Interfaces
{
    public interface IOrdersService
    {
        decimal CalculateTotalPriceAmount(List<OrderItem> orderItems);
    }
}
