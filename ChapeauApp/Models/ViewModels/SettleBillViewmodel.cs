using ChapeauApp.Enums;

namespace ChapeauApp.Models.ViewModels
{
    //The total amount can be entered or a tip value can be entered.
    public class SettleBillViewmodel
    {
        public int BillId { get; set; }
        public decimal TotalPriceAmountExclTip { get; set; }
        public decimal? TipAmount { get; set; } //allows null
        public decimal TotalPriceAmountInclTip 
        {
            get
            { 
                return TotalPriceAmountExclTip + (TipAmount ?? 0); // ?? 0 => Use the value of TipAmount if it exists, otherwise use 0.
            }
        }
        public PaymentMethod PaymentMethod { get; set; }
        public string? FeedbackText { get; set; }

        //public VatSummary VatTotalAmount { get; set; } = new VatSummary();
    }
}
