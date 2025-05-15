namespace ChapeauApp.Models
{
    public class Order
    {
        int OrderId { get; set; }
        DateTime Time {  get; set; }
        DateOnly Date {  get; set; }
        string Status { get; set; }
        int TableNumber { get; set; }
        int EmployeeId { get; set; }

    }
}
