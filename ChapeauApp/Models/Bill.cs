namespace ChapeauApp.Models
{
    public class Bill
    {
        int Bill_Id { get; set; }
        int TotalAmountExclVAT { get; set; }
        int TipAmount {  get; set; }
        int TotalAmountInclVAT { get; set; }
        string FeedbackText { get; set; }
        Payment Payment { get; set; }
        Employee Employee { get; set; }
        
        public Bill()
        {
            
        }

        public Bill(int bill_Id, int totalAmountExclVAT, int tipAmount, int totalAmountInclVAT, string feedbackText, Payment payment, Employee employee)
        {
            Bill_Id = bill_Id;
            TotalAmountExclVAT = totalAmountExclVAT;
            TipAmount = tipAmount;
            TotalAmountInclVAT = totalAmountInclVAT;
            FeedbackText = feedbackText;
            Payment = payment;
            Employee = employee;
        }
    }
}
