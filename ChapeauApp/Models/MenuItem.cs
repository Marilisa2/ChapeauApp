namespace ChapeauApp.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public int MenuId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemType { get; set; }
        public string Description { get; set; }
        public int Stock {  get; set; }
        public int VATAmount { get; set; }
    }
}
