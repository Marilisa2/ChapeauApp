using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderTime {  get; set; }
        //public DateOnly Date {  get; set; } //?
        public OrderStatus OrderStatus { get; set; }
        public Table TableNumber { get; set; }
        //public Employee Employee { get; set; } add later!
        //public Bill Bill { get; set; } //add later!

        public List<OrderItem> OrderItems { get; set; }
        
        public Order()
        {
        }

        public Order(int orderId, DateTime orderTime, OrderStatus orderStatus, Table tableNumber, List<OrderItem> orderItems)
        {
            OrderId = orderId;
            OrderTime = orderTime;
            OrderStatus = orderStatus;
            TableNumber = tableNumber;
            OrderItems = orderItems;
        }
    }
}
