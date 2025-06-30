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
        private readonly IMenusRepository _menusRepository;

        public OrdersService(IOrdersRepository ordersRepository, IMenusRepository menusRepository)
        {
            _ordersRepository = ordersRepository;
            _menusRepository = menusRepository;
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
                foreach (Order order in orders) {

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

                        //RunningOrdersViewModel runningOrdersViewModel = new RunningOrdersViewModel()
                        //{
                        //    OrderId = order.OrderId,
                        //    TableNumber = order.Table.TableNumber,
                        //    OrderTime = order.OrderTime,
                        //    EmployeeName = order.Employee.FirstName,
                        //};

                        //runningOrdersVM.Add(runningOrdersViewModel);
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
