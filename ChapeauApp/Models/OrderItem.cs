using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public MenuItem MenuItem { get; set; }
        public Order Order { get; set; }
        public string? Comment { get; set; }//mag null zijn
      
        public OrderItemStatus OrderItemStatus { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int orderItemId, int quantity, MenuItem menuItem, Order order, OrderItemStatus orderItemStatus, string? comment)
        {
            OrderItemId = orderItemId;
            Quantity = quantity;
            MenuItem = menuItem;
            Order = order;
            OrderItemStatus = orderItemStatus;
            Comment = comment;
        }


    }
}
