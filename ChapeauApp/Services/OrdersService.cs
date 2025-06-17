using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;


namespace ChapeauApp.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;

        public OrdersService(IOrdersRepository ordersRepository, IOrderItemsRepository orderItemsRepository)
        {
            _ordersRepository = ordersRepository;
            _orderItemsRepository = orderItemsRepository;
        }

        public decimal CalculateTotalPriceAmount(List<OrderItem> orderItems)
        {
            decimal totalPriceAmount = 0;

            if (orderItems != null)
            {
                foreach (OrderItem orderItem in orderItems)
                {
                    if (orderItem.MenuItem != null)
                    {
                        totalPriceAmount += orderItem.Quantity * orderItem.MenuItem.ItemPrice;
                    }
                }
            }

            return totalPriceAmount;
        }

        public List<RunningOrdersViewModel> GetRunningOrdersBySection(string section)
        {
            List<RunningOrdersViewModel> runningOrdersVM = new List<RunningOrdersViewModel>();

            try
            {
                List<Order> orders = _ordersRepository.GetAllRunningOrders();

                MenuItemCategory[] barCategories = new MenuItemCategory[]
                {
                    MenuItemCategory.Bieren,
                    MenuItemCategory.Wijnen,
                    MenuItemCategory.KoffieThee,
                    MenuItemCategory.GedistilleerdeDrank
                };
                foreach (Order order in orders) 
                {
                    order.OrderItems = _orderItemsRepository.GetOrderItemsByOrderId(order.OrderId);                     

                    bool isInSection = false;

                    foreach (OrderItem item in order.OrderItems)
                    {
                            if (section == "Bar" && barCategories.Contains(item.MenuItem.ItemCategory))
                            {
                                isInSection = true;
                                break;
                            }
                            else if (section == "Kitchen" && !barCategories.Contains(item.MenuItem.ItemCategory))
                            {
                                isInSection = true;
                                break;
                            }

                        RunningOrdersViewModel runningOrdersViewModel = new RunningOrdersViewModel()
                        {
                            Order = order, //OrderId ophalen
                            Table = order.Table, //TableNumber ophalen
                            OrderTime = order.OrderTime
                            //Employee = order.Employee //Employee First- en LastName
                        };

                        runningOrdersVM.Add(runningOrdersViewModel);
                    }
                    //sorteer lopende orders van oud naar nieuw
                    runningOrdersVM.Sort((x, y) => DateTime.Compare(x.OrderTime, y.OrderTime));
                }
            }
            catch (Exception)
            {
                throw;
            }   
             return runningOrdersVM;             
        }
    }
}
