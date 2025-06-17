using ChapeauApp.Enums;

namespace ChapeauApp.Models.ViewModels
{
    public class RunningOrdersViewModel
    {
        public Order Order { get; set; } //id 
        public Table Table{ get; set; } // tablenumber
        //public Employee Employee { get; set; }  //first-lastname
        public DateTime OrderTime { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderItemsViewModel> OrderItems { get; set; } = new List<OrderItemsViewModel>();
        public TimeSpan WaitingTime => DateTime.Now - OrderTime;
    }
}
