using ChapeauApp.Models;

namespace ChapeauApp.Services.Interfaces
{
    public interface IOrderItemsService
    {
        List<OrderItem> GetOrderItemsByOrderId(int orderId);
        List<OrderItem> GetAllOrderItems();
        OrderItem? GetOrderItemById(int orderItemId);
        void UpdateOrderItem(OrderItem orderItem);
    }
}
