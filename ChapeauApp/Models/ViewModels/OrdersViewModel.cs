namespace ChapeauApp.Models.ViewModels
{
    public class OrdersViewModel
    {
        public Order Order { get; set; }
        public Table Table { get; set; }

        public List<TableViewModel> Tables { get; set; }

        public decimal TotalPriceAmount { get; set; }
        public VatSummary VatTotals { get; set; } = new VatSummary();
        public Bill Bill { get; set; }

        public OrdersViewModel()
        {
            //prevents Null_error
            Tables = new List<TableViewModel>();
            Bill = new Bill();
        }

        public OrdersViewModel(Order order, Table table, List<TableViewModel> tables, decimal totalPriceAmount, Bill bill)
        {
            Order = order;
            Table = table;
            Tables = tables;
            TotalPriceAmount = totalPriceAmount;
            Bill = bill;
        }
    }
}