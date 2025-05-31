using ChapeauApp.Models;
using ChapeauApp.Repositories;
using ChapeauApp.Services.Interfaces;
using ChapeauApp.Repositories.Interfaces;

namespace ChapeauApp.Services
{
    public class OrderItemsService : IOrderItemsService
    {
        private readonly IOrderItemsRepository _OrderItemsRepository;

        public OrderItemsService(IOrderItemsRepository OrderItemsRepository)
        {
            _OrderItemsRepository = OrderItemsRepository;
        }

        public List<OrderItem> GetAllOrderItems()
        {
            return _OrderItemsRepository.GetAllOrderItems();
        }

        public List<OrderItem> GetByOrderId(int orderId)
        {
            return _OrderItemsRepository.GetByOrderId(orderId);
        }

        public OrderItem? GetOrderItemById(int orderItemId)
        {
            return _OrderItemsRepository.GetOrderItemById(orderItemId);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _OrderItemsRepository.UpdateOrderItem(orderItem);
        }
    }
}
