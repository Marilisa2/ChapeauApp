using ChapeauApp.Models;
using ChapeauApp.Services.Interfaces;

namespace ChapeauApp.Services
{
    public class OrdersService : IOrdersService
    {
        public decimal CalculateTotalPriceAmount(List<OrderItem> orderItems)
        {
            decimal totalPriceAmount = 0;

            if(orderItems != null)
            {
                foreach(OrderItem orderItem in orderItems)
                {
                    if (orderItem.MenuItem != null)
                    {
                        totalPriceAmount += orderItem.Quantity * orderItem.MenuItem.ItemPrice;
                    }
                }
            }

            return totalPriceAmount;
        }
    }
}
