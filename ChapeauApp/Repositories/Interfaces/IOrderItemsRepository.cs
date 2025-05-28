using ChapeauApp.Models;

namespace ChapeauApp.Repositories.Interfaces
{
    public interface IOrderItemsRepository
    {
        List<OrderItem> GetAllOrderItems();
        List<OrderItem> GetByOrderId(int orderId);
        OrderItem? GetOrderItemById(int orderItemId);
        void UpdateOrderItem(OrderItem orderItem);
    }
}
