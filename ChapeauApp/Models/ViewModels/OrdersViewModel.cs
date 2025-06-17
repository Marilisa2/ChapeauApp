namespace ChapeauApp.Models.ViewModels
{
    public class OrdersViewModel
    {
        public Order Order { get; set; }
        public Table Table { get; set; }
        public List<Table> Tables { get; set; }
        public decimal TotalPricemount { get; set; }

        public VatSummary VatTotals { get; set; } = new VatSummary();
        Bill Bill { get; set; }

        public OrdersViewModel()
        {
            //prevents Null_error
            Tables = new List<Table>();
            Bill = new Bill();
        }

        public OrdersViewModel(Order order, Table table, List<Table> tables, decimal totalPricemount, Bill bill)
        {
            Order = order;
            Table = table;
            Tables = tables;
            TotalPricemount = totalPricemount;
            Bill = bill;
        }
    }
}