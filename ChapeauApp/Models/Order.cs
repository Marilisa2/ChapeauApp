using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Time {  get; set; }
        public DateOnly Date {  get; set; }
        public string Status { get; set; }
        public Table TableNumber { get; set; }
        public Employee EmployeeId { get; set; }

        public  List<OrderItem> OrderItems { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public Order()
        {
        }

        public Order(int orderId, DateTime time, DateOnly date, string status, Table tableNumber, Employee employeeId, List<OrderItem> orderItems)
        {
            OrderId = orderId;
            Time = time;
            Date = date;
            Status = status;
            TableNumber = tableNumber;
            EmployeeId = employeeId;
            OrderItems = orderItems;
        }
    }
}
