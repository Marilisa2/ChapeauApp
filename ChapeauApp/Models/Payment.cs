using ChapeauApp.Enums;

namespace ChapeauApp.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public int PaymentSplitCount { get; set; }

        public Payment()
        {
        }

        public Payment(int paymentId, PaymentMethod paymentMethod, string paymentStatus, int paymentSplitCount)
        {
            PaymentId = paymentId;
            PaymentMethod = paymentMethod;
            PaymentStatus = paymentStatus;
            PaymentSplitCount = paymentSplitCount;
        }
    }
}
