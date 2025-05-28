namespace ChapeauApp.Models.ViewModels
{
    public class TableViewModel
    {
        public TableViewModel()
        {
        }

        public int TableNumber { get; set; }
        public string TableStatus { get; set; }

        public TableViewModel(int tableNumber, string tableStatus)
        {
            TableNumber = tableNumber;
            TableStatus = tableStatus;
        }
    }
}