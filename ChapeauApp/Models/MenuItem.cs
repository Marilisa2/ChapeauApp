using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public MenuItemCard MenuCard { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public MenuItemCategory ItemCategory { get; set; }
        public string Description { get; set; }
        public int Stock {  get; set; }
        public int VATAmount { get; set; }
        
        public MenuItem()
        {
            
        }

        public MenuItem(int menuItemId, MenuItemCard menuCard, string itemName, decimal itemPrice, MenuItemCategory itemCategory, string description, int stock, int vATAmount)
        {
            MenuItemId = menuItemId;
            MenuCard = menuCard;
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemCategory = itemCategory;
            Description = description;
            Stock = stock;
            VATAmount = vATAmount;
        }
    }
}
