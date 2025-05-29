using ChapeauApp.Controllers;
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
            _connectionString = configuration.GetConnectionString("ChapeauDb");
            //_employeeRepository = employeeRepository;
            _orderItemsRepository = orderItemsRepository;
        }

        private Order ReadOrder(SqlDataReader reader)
        {
            //retrieve data from fields from database
            int orderId = (int)reader["OrderId"];
            DateTime orderTime = (DateTime)reader["OrderTime"];
            OrderStatus orderStatus = (OrderStatus)(int)reader["OrderStatus"];

            //navragen of dit stukje goed is:
            int tableNumber = (int)reader["TableNumber"];
            Table table = new Table
            {
                TableNumber = tableNumber,
            };

            //sprint2
            //Employee employee = new Employee { EmployeeId = (int)reader["EmployeeId"] };
            //Employee? employee = _employeeRepository.GetEmployeeById(employeeId);


            List<OrderItem> orderItems = _orderItemsRepository.GetOrderItemsByOrderId(orderId);

            return new Order(orderId, orderTime, orderStatus, table, orderItems);
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT OrderId, OrderTime, OrderStatus, TableNumber FROM Orders";
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

        public Order? GetOrderByTableNumber(int tableNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT OrderId, OrderTime, OrderStatus, TableNumber FROM Orders WHERE TableNumber = @TableNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TableNumber", tableNumber);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return ReadOrder(reader);
                }

                return null;
            }
        }
    }
}
