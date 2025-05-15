namespace ChapeauApp.Models
{
    public class MenuItem_oud
    {
        public int MenuItemId { get; set; }      // Primary key
        public int MenuId { get; set; }          // Foreign key naar Menu (optioneel afhankelijk van je modelstructuur)

        public string ItemName { get; set; }     // Naam van het item (bv. "Cappuccino")
        public decimal ItemPrice { get; set; }   // Prijs (bv. 3.50)

        public string ItemType { get; set; }     // "Food" of "Drink"
        public string Description { get; set; }  // Beschrijving van het item
        public int Stock { get; set; }           // Aantal op voorraad

        public decimal VATLowAmount { get; set; }    // BTW percentage laag (bv. 0.09m)
        public decimal VATHighAmount { get; set; }   // BTW percentage hoog (bv. 0.21m)
        
        public MenuItem_oud(int menuItemId, int menuId, string itemName, decimal itemPrice, string itemType, string description, int stock, decimal vATLowAmount, decimal vATHighAmount)
        {
            MenuItemId = menuItemId;
            MenuId = menuId;
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemType = itemType;
            Description = description;
            Stock = stock;
            VATLowAmount = vATLowAmount;
            VATHighAmount = vATHighAmount;
        }

        public MenuItem_oud()
        {
        }
    }
}
