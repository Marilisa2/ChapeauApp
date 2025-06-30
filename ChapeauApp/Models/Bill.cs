namespace ChapeauApp.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public decimal TotalPriceAmountExclVAT { get; set; }
        public decimal TipAmount {  get; set; }
        public decimal TotalPriceAmountInclVAT { get; set; }
        public string FeedbackText { get; set; }
        public Payment PaymentId { get; set; }
        public List<Order> Orders { get; set; }
        public Employee Employee { get; set; }
        //public int EmployeeId { get; set; }

        public Bill()
        {
        }

        public Bill(int billId, decimal totalPriceAmountExclVAT, decimal tipAmount, decimal totalPriceAmountInclVAT, string feedbackText, Payment paymentId)
        {
            BillId = billId;
            TotalPriceAmountExclVAT = totalPriceAmountExclVAT;
            TipAmount = tipAmount;
            TotalPriceAmountInclVAT = totalPriceAmountInclVAT;
            FeedbackText = feedbackText;
            PaymentId = paymentId;
        }
    }
}
