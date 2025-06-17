using ChapeauApp.Models;

namespace ChapeauApp.Repositories.Interfaces
{
    public interface IOrdersRepository
    {
        List<Order> GetAllOrders();
        List<Order> GetAllRunningOrders();
        Order? GetOrderByTableNumber(int tableNumber);
        Order? GetOrderByBillId(int billId);
    }
}
