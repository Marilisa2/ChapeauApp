using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Services.Interfaces
{
    public interface IOrdersService
    {
        Order GetOrderByTableNumber(int tableNumber);
        Order GetOrderByBillId(int billId);
        decimal CalculateTotalPriceAmount(List<OrderItem> orderItems);
        List<RunningOrdersViewModel> GetRunningOrdersBySection(string section);
    }
}
