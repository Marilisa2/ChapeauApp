using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public MenuItem MenuItem { get; set; }
        public Order Order { get; set; }

        public OrderItemStatus Status { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int orderItemId, int quantity, MenuItem menuItem, Order order, OrderItemStatus status)
        {
            OrderItemId = orderItemId;
            Quantity = quantity;
            MenuItem = menuItem;
            Order = order;
            Status = status;
        }

      
    }
}
