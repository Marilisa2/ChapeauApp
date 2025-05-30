using ChapeauApp.Models;

namespace ChapeauApp.Repositories.Interfaces
{
    public interface IOrderItemsRepository
    {
        List<OrderItem> GetOrderItemsByOrderId(int orderId);
        List<OrderItem> GetAllOrderItems();
        OrderItem? GetOrderItemById(int orderItemId);
        void UpdateOrderItem(OrderItem orderItem);
    }
}
