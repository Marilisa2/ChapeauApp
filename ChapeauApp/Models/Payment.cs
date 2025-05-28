namespace ChapeauApp.Models
{
    public class Payment
    {
        int PaymentId { get; set; }
        string PaymentMethod { get; set; }
        string Status { get; set; }
        int DivisionType { get; set; }
    }
}
