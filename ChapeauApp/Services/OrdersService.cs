using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;

namespace ChapeauApp.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

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

        public Order GetOrderByTableNumber(int tableNumber)
        {
            return _ordersRepository.GetOrderByTableNumber(tableNumber);
        }

        public Order GetOrderByBillId(int billId)
        {
            return _ordersRepository.GetOrderByBillId(billId); 
        }
    }
}
