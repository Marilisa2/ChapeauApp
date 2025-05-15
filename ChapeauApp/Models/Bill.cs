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
        
        public Bill()
        {
            
        }

        public Bill(int bill_Id, int totalAmountExclVAT, int tipAmount, int totalAmountInclVAT, string feedbackText, int paymentId, int employeeId)
        {
            Bill_Id = bill_Id;
            TotalAmountExclVAT = totalAmountExclVAT;
            TipAmount = tipAmount;
            TotalAmountInclVAT = totalAmountInclVAT;
            FeedbackText = feedbackText;
            PaymentId = paymentId;
            EmployeeId = employeeId;
        }
    }
}
