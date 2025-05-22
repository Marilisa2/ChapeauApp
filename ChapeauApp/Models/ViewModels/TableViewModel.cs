namespace ChapeauApp.Models.ViewModels
{
    public class TableViewModel
    {
        public TableViewModel()
        {
        }

        public int TableNumber { get; set; }
        public string TableStatus { get; set; }

        public TableViewModel(Table table)
        {
            TableNumber =table.TableNumber ;
            TableStatus =table.TableStatus ;
        }
    }
}
