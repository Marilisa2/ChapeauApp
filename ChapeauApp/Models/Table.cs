using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class Table
    {
        public int TableNumber { get; set; }
        public string TableStatus { get; set; }

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
