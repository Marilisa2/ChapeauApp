using ChapeauApp.Models;
using ChapeauApp.Services.Interfaces;

namespace ChapeauApp.Services
{
    public class VatsService : IVatsService
    {
        private const int LowVatAmount = 9;
        private const int HighVatAmount = 21;

        public VatSummary CalculateVatTotalAmount(List<OrderItem> orderItems)
        {
            VatSummary vatSummary = new VatSummary();

            foreach (OrderItem orderItem in orderItems)
            {
                decimal totalPriceAmount = orderItem.Quantity * orderItem.MenuItem.ItemPrice;
                int vatPercentage = orderItem.MenuItem.VATAmount;

                decimal vatAmount = totalPriceAmount * vatPercentage / (100 + vatPercentage);

                if (vatPercentage == LowVatAmount)
                {
                    vatSummary.LowVatAmount += vatAmount;
                }
                else if (vatPercentage == HighVatAmount)
                {
                    vatSummary.HighVatAmount += vatAmount;
                }
            }

            return vatSummary;
        }
    }
}
