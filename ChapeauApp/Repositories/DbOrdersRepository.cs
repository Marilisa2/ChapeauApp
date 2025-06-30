using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace ChapeauApp.Repositories
{
    public class DbOrdersRepository : IOrdersRepository
    {
        private readonly string? _connectionString;
        //private readonly IEmployeeRepository _employeeRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;

        public DbOrdersRepository(IConfiguration configuration, IOrderItemsRepository orderItemsRepository)
        {
            //get database connectionstring from appsettings
            _connectionString = configuration.GetConnectionString("Chapeau");
            //_employeeRepository = employeeRepository;
            _orderItemsRepository = orderItemsRepository;
        }
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT OrderId, OrderTime, OrderStatus, TableNumber, BillId FROM Orders";
                SqlCommand command = new SqlCommand(query, connection);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Order order = ReadOrder(reader);
                    orders.Add(order);
                }
                reader.Close();
            }
            return orders;
        }
        private Order ReadOrder(SqlDataReader reader)
        {
            int orderId = (int)reader["OrderId"];
            DateTime orderTime = (DateTime)reader["OrderTime"];
            OrderStatus orderStatus = (OrderStatus)reader["OrderStatus"];
            int tableInt = (int)reader["TableNumber"];
            int billInt = (int)reader["BillId"];
            //Employee employee = (Employee)reader["EmployeeId"];
            List<OrderItem> orderItems = GetAllOrderItems(orderId);
            return new Order(orderId, orderTime, orderStatus, orderItems);
        }

        public List<Order> GetOrdersByTableNumber(int tableNumber)
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT OrderId, OrderTime, OrderStatus, BillId, EmployeeId FROM Orders WHERE TableNumber = @tableNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tableNumber", tableNumber);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Order order = ReadOrder(reader);
                    orders.Add(order);
                }

                reader.Close();
            }
            return orders;
        }

        public Order? GetOrderByBillId(int billId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT OrderId, OrderTime, OrderStatus, TableNumber, BillId FROM Orders WHERE BillId = @BillId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BillId", billId);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return ReadOrder(reader);
                }

                return null;
            }
        }

        private List<OrderItem> GetAllOrderItems(int orderId)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT OrderItemId, Quantity, MenuItemId, OrderId, Comment, OrderItemStatus FROM OrderItems WHERE OrderId = @orderId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderId", orderId);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OrderItem orderItem = ReadOrderItem(reader);
                    orderItems.Add(orderItem);
                }
            }
            return orderItems;
        }
        private List<OrderItem> GetOrderItemsById(int orderId)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT OrderItemId, Quantity, MenuItemId, OrderId, Comment, OrderItemStatus FROM OrderItems WHERE OrderId = @orderId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@orderId", orderId);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OrderItem orderItem = ReadOrderItem(reader);
                    orderItems.Add(orderItem);
                }
            }
            return orderItems;
        }
        private OrderItem ReadOrderItem(SqlDataReader reader)
        {
            return new OrderItem();
        }

        public Order? GetOrderByTableNumber(int tableNumber)
        {
            throw new NotImplementedException();
        }
        public List<Order> GetAllRunningOrders()
        {
            throw new NotImplementedException();
        }

    }
}
