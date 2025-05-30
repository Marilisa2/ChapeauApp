namespace ChapeauApp.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public Menu Menu { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemType { get; set; }
        public string ItemDescription { get; set; }
        public int ItemStock {  get; set; }
        public int VATAmount { get; set; }

        public MenuItem()
        {
        }

        public MenuItem(int menuItemId, Menu menu, string itemName, decimal itemPrice, string itemType, string itemDescription, int itemStock, int vATAmount)
        {
            MenuItemId = menuItemId;
            Menu = menu;
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemType = itemType;
            ItemDescription = itemDescription;
            ItemStock = itemStock;
            VATAmount = vATAmount;
        }
    }
}
