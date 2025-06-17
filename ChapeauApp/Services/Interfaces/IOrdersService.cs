using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Services.Interfaces
{
    public interface IOrdersService
    {
        decimal CalculateTotalPriceAmount(List<OrderItem> orderItems);
        List<RunningOrdersViewModel> GetRunningOrdersBySection(string section);
    }
}
