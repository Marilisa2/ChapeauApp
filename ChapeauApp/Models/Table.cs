namespace ChapeauApp.Models
{
    using ChapeauApp.Enums;
    public class Table
    {
        public int TableNumber { get; set; }
        public TableStatuses TableStatus { get; set; }
        public List<Order> OrderList { get; set; }
        
        public Table()
        {
        }

        public Table(int tableNumber, TableStatuses tableStatus)
        {
            TableNumber = tableNumber;
            TableStatus = tableStatus;
        }
        public Table(int tableNumber, TableStatuses tableStatus, List<Order> orderList)
        {
            TableNumber = tableNumber;
            TableStatus = tableStatus;
            OrderList = orderList;
        }
    }
}
