using ChapeauApp.Models;
//tijdelijk tot teamgenoot klaar is
namespace ChapeauApp.Repositories.Interfaces
{
    public interface IOrderItemsRepository
    {
        List<OrderItem> GetOrderItemsByOrderId(int orderId);
    }
}
