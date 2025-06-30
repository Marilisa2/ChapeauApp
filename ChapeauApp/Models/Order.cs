using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        //public Table Table { get; set; }
        public Employee Employee { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
        }

        public Order(int orderId, DateTime orderTime, OrderStatus orderStatus, List<OrderItem> orderItems)
        {
            OrderId = orderId;
            OrderTime = orderTime;
            OrderStatus = orderStatus;
            //Table = table;
            OrderItems = orderItems;
        }
    }
}