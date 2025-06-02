using ChapeauApp.Enums;

namespace ChapeauApp.Models.ViewModels
{
    public class TableUpdateViewModel
    {
        public TableUpdateViewModel()
        {
        }

        public int TableNumber { get; set; }
        public TableStatuses NewStatus { get; set; }
        public TableStatuses OldStatus { get; set; } 
    }
}
