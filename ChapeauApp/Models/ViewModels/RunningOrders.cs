namespace ChapeauApp.Models.ViewModels
{
    public class RunningOrders
    {
        public int OrderId{ get; set; }
        public int TableNumber{ get; set; }
        public DateTime OrderTime { get; set; }
        public string WaitingTime { get; set; }
    }
}
