namespace ChapeauApp.Models
{
    public class Bill
    {
        int Bill_Id { get; set; }
        int TotalAmountExclVAT { get; set; }
        int TipAmount {  get; set; }
        int TotalAmountInclVAT { get; set; }
        string FeedbackText { get; set; }
        int PaymentId { get; set; }
        int EmployeeId { get; set; }
    }
}
