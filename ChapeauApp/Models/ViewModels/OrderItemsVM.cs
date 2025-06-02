using ChapeauApp.Enums;

namespace ChapeauApp.Models.ViewModels
{
    public class OrderItemsVM
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public MenuItem MenuItem { get; set; } //Name van menuitem gebruiken
        public OrderItemStatus Status { get; set; }

        //public bool IsDone { get; set; } ???
    }
}
