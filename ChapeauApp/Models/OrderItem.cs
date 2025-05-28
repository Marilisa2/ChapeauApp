using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int OrderId { get; set; }

        public OrderItemStatus Status { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int orderItemId, int quantity, int menuItemId, MenuItem menuItem, int orderId, OrderItemStatus status)
        {
            OrderItemId = orderItemId;
            Quantity = quantity;
            MenuItemId = menuItemId;
            MenuItem = menuItem;
            OrderId = orderId;
            Status = status;
        }

      
    }
}
