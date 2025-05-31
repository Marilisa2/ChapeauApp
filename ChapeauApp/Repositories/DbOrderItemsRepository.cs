using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace ChapeauApp.Repositories
{
    public class DbOrderItemsRepository : IOrderItemsRepository
    {
        private readonly string? _connectionString;

        public DbOrderItemsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Chapeau");
        }

        public List<OrderItem> GetAllOrderItems()
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT OrderItemId, Quantity, MenuItemId, OrderId, OrderItemStatus, Comment " +
                                "FROM OrderItems ORDER BY OrderItemId ASC";

                SqlCommand command = new SqlCommand(query, connection);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    OrderItem orderItem = ReadOrderItem(reader);
                    orderItems.Add(orderItem);
                }
                reader.Close();
            }
            return orderItems;
        }

        public List<OrderItem> GetByOrderId(int orderId)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT OrderItemId, Quantity, MenuItemId, OrderId, OrderItemStatus, Comment " +
                                "FROM OrderItems WHERE OrderId = @OrderId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
               
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
            return orderItems;
        }

        private OrderItem ReadOrderItem(SqlDataReader reader) 
        {
            int orderItemid = (int)reader["OrderItemId"];
            int quantity = (int)reader["Quantity"];
            int menuItemId = (int)reader["MenuItemId"];
            int orderId = (int)reader["OrderId"];
            OrderItemStatus orderItemStatus = (OrderItemStatus)reader["OrderItemStatus"];
            string? comment = (string)reader["Comment"];

            MenuItem menuItem = new MenuItem 
            {
                MenuItemId = menuItemId
            };

            Order order = new Order
            {
                OrderId = orderId
            };

            return new OrderItem(orderItemid, quantity, menuItem, order,orderItemStatus, comment);
        }

        public OrderItem? GetOrderItemById(int orderItemId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT OrderItemId, Quantity, MenuItemId, OrderId, OrderItemStatus, Comment " +
                                "FROM OrderItems WHERE OrderItemId = @OrderItemId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderItemId", orderItemId);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    OrderItem orderItem = ReadOrderItem(reader);
                    reader.Close();
                    return orderItem;

                }
                reader.Close();
                return null;
            }
            
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"UPDATE OrderItems SET OrderItemId = @OrderItemId, Quantity = @Quantity, " +
                                "MenuItemId = @MenuItemId, OrderId = @OrderId, OrderItemStatus = @OrderItemStatus, Comment = @Comment" +
                                "WHERE OrderItemId = @OrderItemId";
                
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderItemId", orderItem.OrderItemId);
                command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
                command.Parameters.AddWithValue("@MenuItemId", orderItem.MenuItem.MenuItemId);
                command.Parameters.AddWithValue("@OrderId", orderItem.Order.OrderId);
                command.Parameters.AddWithValue("@OrderItemStatus", orderItem.OrderItemStatus);
                command.Parameters.AddWithValue("@Comment", orderItem.Comment);

                connection.Open();
                int nrOfRowsAffected = command.ExecuteNonQuery();
                if (nrOfRowsAffected == 0)
                {
                    throw new Exception("No records Updated!");
                }
            }
        }

       
    }
}
