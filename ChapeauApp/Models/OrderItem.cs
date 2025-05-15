namespace ChapeauApp.Models
{
    public class OrderItem
    {
        int OrderItemId { get; set; }
        int Quantity { get; set; }
        int MenuItemId { get; set; }
        int OrderId { get; set; }
    }
}
