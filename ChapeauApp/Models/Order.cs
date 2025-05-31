using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Time {  get; set; }
        public DateOnly Date {  get; set; }
        public string Status { get; set; }
        public Table Table { get; set; }
        public Employee Employee { get; set; }

        public  List<OrderItem> OrderItems { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public Order()
        {
        }

        public Order(int orderId, DateTime time, DateOnly date, string status, Table table, Employee employee, List<OrderItem> orderItems)
        {
            OrderId = orderId;
            Time = time;
            Date = date;
            Status = status;
            Table= table;
            Employee = employee;
            OrderItems = orderItems;
        }
    }
}
