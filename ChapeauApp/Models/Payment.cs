namespace ChapeauApp.Models
{
    public class Payment
    {
        int PaymentId { get; set; }
        string PaymentMethod { get; set; }
        string Status { get; set; }
        int DivisionType { get; set; }
        
        public Payment()
        {
            
        }

        public Payment(int paymentId, string paymentMethod, string status, int divisionType)
        {
            PaymentId = paymentId;
            PaymentMethod = paymentMethod;
            Status = status;
            DivisionType = divisionType;
        }
    }
}
