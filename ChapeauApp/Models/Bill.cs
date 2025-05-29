namespace ChapeauApp.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public decimal TotalAmountExclVAT { get; set; }
        public decimal TipAmount {  get; set; }
        public decimal TotalAmountInclVAT { get; set; }
        public string FeedbackText { get; set; }
        public Payment Payment { get; set; }
        //public int EmployeeId { get; set; }

        public Bill()
        {
        }

        public Bill(int billId, decimal totalAmountExclVAT, decimal tipAmount, decimal totalAmountInclVAT, string feedbackText, Payment payment)
        {
            BillId = billId;
            TotalAmountExclVAT = totalAmountExclVAT;
            TipAmount = tipAmount;
            TotalAmountInclVAT = totalAmountInclVAT;
            FeedbackText = feedbackText;
            Payment = payment;
        }
    }
}
