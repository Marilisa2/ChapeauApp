namespace ChapeauApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderTime {  get; set; }
        //public DateOnly Date {  get; set; } //niet meer nodig?
        public string OrderStatus { get; set; } //wordt enum!
        public Table TableNumber { get; set; }
        //public Employee EmployeeId { get; set; } //toevoegen voor sprint2

        public List<OrderItem> OrderItems { get; set; }
        
        public Order()
        {
        }

        public Order(int orderId, DateTime orderTime, string orderStatus, Table tableNumber, List<OrderItem> orderItems)
        {
            OrderId = orderId;
            OrderTime = orderTime;
            OrderStatus = orderStatus;
            TableNumber = tableNumber;
            OrderItems = orderItems;
        }
    }
}
