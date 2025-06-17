using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace ChapeauApp.Repositories
{
    public class DbOrderItemsRepository : IOrderItemsRepository
    {
        private readonly string? _connectionString;

        public DbOrderItemsRepository(IConfiguration configuration)
        {
            //get database connectionstring from appsettings
            _connectionString = configuration.GetConnectionString("ChapeauDb");
        }

        private OrderItem ReadOrderItem(SqlDataReader reader)
        {
            int orderItemId = (int)reader["OrderItemId"];
            int quantity = (int)reader["Quantity"];
            MenuItem menuItemId = new MenuItem { MenuItemId = (int)reader["MenuItemId"] };
            Order order = new Order { OrderId = (int)reader["OrderId"] };
            string? comment = (string)reader["Comment"];
            OrderItemStatus orderItemStatus = (OrderItemStatus)(int)reader["OrderItemStatus"];

                  

            MenuItem menuItem = new MenuItem
            {
                MenuItemId = (int)reader["menuItemId"],
                //MenuCard = (MenuItemCard)(int)reader["menuCard"]
                MenuCard = reader["menuCard"] == DBNull.Value ? MenuItemCard.All : (MenuItemCard)(int)reader["menuCard"],
                ItemName = (string)reader["itemName"],
                ItemPrice = reader["itemPrice"] == DBNull.Value ? 0m : (decimal)reader["itemPrice"],
                //ItemCategory = (MenuItemCategory)(int)reader["itemCategory"],
                ItemCategory = reader["itemCategory"] == DBNull.Value ? MenuItemCategory.All : (MenuItemCategory)(int)reader["itemCategory"],
                Description = reader["itemDescription"] == DBNull.Value ? string.Empty : (string)reader["itemDescription"],
                Stock = (int)reader["itemStock"],
                VATAmount = (int)reader["vat_Amount"]
            };

            return new OrderItem
            {
                OrderItemId = orderItemId,
                Quantity = quantity,
                MenuItem = menuItem,
                Order = order,
                Comment = comment,
                OrderItemStatus = orderItemStatus
            };
        }

        public List<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT oi.OrderItemId, oi.Quantity, oi.MenuItemId, oi.OrderId, oi.Comment, oi.OrderItemStatus, " +
                                  "mi.menuItemId, mi.itemName, mi.itemPrice, mi.itemDescription, mi.itemStock, mi.vat_Amount, mi.itemCategory, mi.menuCard " +
                                  "FROM OrderItems oi " +
                                  "JOIN MenuItems mi ON oi.MenuItemId = mi.menuItemId " +
                                  "WHERE oi.OrderId = @OrderId ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue(@"OrderId", orderId);
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

        public OrderItem? GetOrderItemById(int orderItemId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT OrderItemId, Quantity, MenuItemId, OrderId, Comment, OrderItemStatus  " +
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
                                "MenuItemId = @MenuItemId, OrderId = @OrderId, Comment = @Comment, OrderItemStatus = @OrderItemStatus " +
                                "WHERE OrderItemId = @OrderItemId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderItemId", orderItem.OrderItemId);
                command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
                command.Parameters.AddWithValue("@MenuItemId", orderItem.MenuItem.MenuItemId);
                command.Parameters.AddWithValue("@OrderId", orderItem.Order.OrderId);
                command.Parameters.AddWithValue("@Comment", orderItem.Comment);
                command.Parameters.AddWithValue("@OrderItemStatus", orderItem.OrderItemStatus);

                connection.Open();
                int nrOfRowsAffected = command.ExecuteNonQuery();
                if (nrOfRowsAffected == 0)
                {
                    throw new Exception("No records Updated!");
                }
            }
        }

        public List<OrderItem> GetAllOrderItems()
        {
            throw new NotImplementedException();
        }
    }
}