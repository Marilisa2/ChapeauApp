using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public MenuItem MenuItem { get; set; }
        public string? Comment { get; set; }//mag null zijn
      
        public OrderItemStatus OrderItemStatus { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int orderItemId, int quantity, MenuItem menuItem, string? comment, OrderItemStatus orderItemStatus)
        {
            OrderItemId = orderItemId;
            Quantity = quantity;
            MenuItem = menuItem;
            Comment = comment;
            OrderItemStatus = orderItemStatus;
        }
    }
}
