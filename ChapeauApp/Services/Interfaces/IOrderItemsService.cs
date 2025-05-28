using ChapeauApp.Models;

namespace ChapeauApp.Services.Interfaces
{
    public interface IOrderItemsService
    {
        List<OrderItem> GetAllOrderItems();
        List<OrderItem> GetByOrderId(int orderId);
        OrderItem? GetOrderItemById(int orderItemId);
        void UpdateOrderItem(OrderItem orderItem);
    }
}
