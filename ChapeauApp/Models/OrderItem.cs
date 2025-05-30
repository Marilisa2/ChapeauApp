using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public MenuItem MenuItem { get; set; }
        public Order Order { get; set; }
        public string? Comment { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int orderItemId, int quantity, MenuItem menuItem, Order order, string? comment, OrderItemStatus orderItemStatus)
        {
            OrderItemId = orderItemId;
            Quantity = quantity;
            MenuItem = menuItem;
            Order = order;
            Comment = comment;
            OrderItemStatus = orderItemStatus;
        }
    }
}
