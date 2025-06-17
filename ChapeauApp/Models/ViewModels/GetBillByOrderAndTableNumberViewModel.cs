namespace ChapeauApp.Models.ViewModels
{
    public class GetBillByOrderAndTableNumberViewModel
    {
        public Order Order { get; set; }
        public Bill Bill { get; set; }
        public Table Table { get; set; }
    }
}
