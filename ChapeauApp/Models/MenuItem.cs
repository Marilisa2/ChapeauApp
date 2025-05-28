namespace ChapeauApp.Models
{
    public class MenuItem
    {
        int MenuItemId { get; set; }
        int MenuId { get; set; }
        string ItemName { get; set; }
        decimal ItemPrice { get; set; }
        string ItemType { get; set; }
        string Description { get; set; }
        int Stock {  get; set; }
        int VATAmount { get; set; }
    }
}
