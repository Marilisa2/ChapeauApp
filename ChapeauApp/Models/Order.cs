using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderTime {  get; set; }
        //public DateOnly Date {  get; set; } //?
        public OrderItemStatus OrderItemStatus { get; set; }
        public Table TableNumber { get; set; }
        //public Employee Employee { get; set; } //Add later!

        public List<OrderItem> OrderItems { get; set; }
        
        public Order()
        {
        }

        public Order(int orderId, DateTime orderTime, OrderItemStatus orderItemStatus, Table tableNumber, List<OrderItem> orderItems)
        {
            OrderId = orderId;
            OrderTime = orderTime;
            OrderItemStatus = orderItemStatus;
            TableNumber = tableNumber;
            //Employee = employee;
            OrderItems = orderItems;
        }
    }
}
