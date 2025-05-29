using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderTime {  get; set; }
        //public DateOnly Date {  get; set; } //niet meer nodig?
        public OrderStatus OrderStatus { get; set; }
        public Table TableNumber { get; set; }
        //public Employee Employee { get; set; } //toevoegen voor sprint2

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



        //public Order(int orderId, DateTime orderTime, OrderItemStatus orderItemStatus, Table tableNumber, Employee employee, List<OrderItem> orderItems)
        //{
        //    OrderId = orderId;
        //    OrderTime = orderTime;
        //    OrderItemStatus = orderItemStatus;
        //    TableNumber = tableNumber;
        //    Employee = employee;
        //    OrderItems = orderItems;
        //}
    }
}
