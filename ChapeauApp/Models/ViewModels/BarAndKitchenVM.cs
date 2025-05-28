using ChapeauApp.Enums;

namespace ChapeauApp.Models.ViewModels
{
    public class BarAndKitchenVM
    {
        public int OrderId { get; set; }
        public int TableNumber { get; set; }
        public DateTime OrderTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderItemsVM> OrderItems { get; set; }
        public TimeSpan WaitingTime => DateTime.Now - OrderTime;
    }
}
