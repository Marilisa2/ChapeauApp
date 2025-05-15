namespace ChapeauApp.Models
{
    public class Table
    {
        int TableNumber { get; set; }
        string TableStatus { get; set; }
        
        public Table()
        {
            
        }

        public Table(int tableNumber, string tableStatus)
        {
            TableNumber = tableNumber;
            TableStatus = tableStatus;
        }
    }
}
