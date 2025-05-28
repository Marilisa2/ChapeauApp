//using ChapeauApp.Models;
//using ChapeauApp.Repositories;
//using ChapeauApp.Repositories.Interfaces;

//namespace ChapeauApp.Repositories
//{
//    public class DummyOrdersRepository : IOrdersRepository
//    {
//        List<Order> orders =
//        [
//            new Order(
//                1,
//                DateTime.Now,
//                "Open",
//                new Table {TableNumber = 2, TableStatus = "Open"},
//                new Employee {EmployeeId = 3, FirstName = "Luna", LastName = "Roe", EmployeeType = "waiter", Password = "welkom2"},
//                new List<OrderItem>
//            {
//                new OrderItem{
//                    OrderItemId=3,
//                    Quantity = 2,

//                    MenuItem = new MenuItem
//                    {
//                        MenuItemId = 1,
//                        MenuId = new Menu(1, "Hoofdgerechten"),
//                        ItemName = "Pizza",
//                        ItemPrice = 10,
//                        ItemType = "Main",
//                        Description = "Heerlijke Italiaanse pizza met kaas en tomatensaus",
//                        Stock = 15,
//                        VATAmount = 9,

//                    }
//                }
//            })
//        ];

//        public List<Order> GetAllOrders()
//        {
//            return orders;
//        }

//        public Order? GetOrderByTableNumber(int tableNumber)//Table tablNumber als parameter?
//        {
//            return orders.FirstOrDefault(x => x.TableNumber.TableNumber == tableNumber);
//        }
//    }
//}
