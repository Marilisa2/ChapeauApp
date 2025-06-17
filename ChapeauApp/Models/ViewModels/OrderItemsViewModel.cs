using ChapeauApp.Enums;

namespace ChapeauApp.Models.ViewModels
{
    public class OrderItemsViewModel
    {
        public OrderItem OrderItem { get; set; }
        public int Quantity { get; set; }
        public MenuItem MenuItem { get; set; } //Name van menuitem gebruiken
        public OrderItemStatus Status { get; set; }

        //public bool IsDone { get; set; } ???
    }
}
