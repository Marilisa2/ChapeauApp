using ChapeauApp.Enums;

namespace ChapeauApp.Models.ViewModels
{
    public class TableViewModel
    {
        
        public int TableNumber { get; set; }
        public TableStatuses TableStatus { get; set; }
        public List<Order> OrderList { get; set; }

        public TableViewModel()
        {
        }
        public TableViewModel(Table table)
        {
            TableNumber = table.TableNumber;
            TableStatus = table.TableStatus;
            OrderList = table.OrderList;
        }        
    }
}
