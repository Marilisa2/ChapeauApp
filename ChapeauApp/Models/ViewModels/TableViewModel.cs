using ChapeauApp.Enums;

namespace ChapeauApp.Models.ViewModels
{
    public class TableViewModel
    {
        public TableViewModel()
        {
        }

        public int TableNumber { get; set; }
        public TableStatuses TableStatus { get; set; }

        public TableViewModel(Table table)
        {
            TableNumber =table.TableNumber ;
            TableStatus =table.TableStatus ;
        }
    }
}
