namespace ChapeauApp.Models
{
    using ChapeauApp.Enums;
    public class Table
    {
        public Table()
        {
        }

        public int TableNumber { get; set; }
        public TableStatuses TableStatus { get; set; }

        public Table(int tableNumber, TableStatuses tableStatus)
        {
            TableNumber = tableNumber;
            TableStatus = tableStatus;
        }
    }
}
