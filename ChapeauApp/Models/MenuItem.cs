namespace ChapeauApp.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public Menu MenuId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemType { get; set; }
        public string ItemDescription { get; set; }
        public int ItemStock {  get; set; }
        public int VATAmount { get; set; }

        public MenuItem()
        {
        }

        public MenuItem(int menuItemId, Menu menuId, string itemName, decimal itemPrice, string itemType, string itemDescription, int itemStock, int vATAmount)
        {
            MenuItemId = menuItemId;
            MenuId = menuId;
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemType = itemType;
            ItemDescription = itemDescription;
            ItemStock = itemStock;
            VATAmount = vATAmount;
        }
    }
}
