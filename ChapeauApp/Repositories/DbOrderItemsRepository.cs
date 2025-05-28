using ChapeauApp.Controllers;
using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace ChapeauApp.Repositories
{
    //tijdelijk
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
            int menuItemId = (int)reader["MenuItemId"];
            int orderId = (int)reader["OrderId"];


            MenuItem menuItem = new MenuItem
            {
                MenuItemId = (int)reader["menuItemId"],
                MenuId = new Menu { MenuId = (int)reader["menuId"] },
                ItemName = (string)reader["itemName"],
                ItemPrice = reader["itemPrice"] == DBNull.Value ? 0m : (decimal)reader["itemPrice"],
                ItemType = reader["itemType"] == DBNull.Value ? string.Empty : (string)reader["itemType"],
                ItemDescription = reader["itemDescription"] == DBNull.Value ? string.Empty : (string)reader["itemType"],
                ItemStock = (int)reader["itemStock"],
                VATAmount = (int)reader["vat_Amount"]
            };

            return new OrderItem
            {
                OrderItemId = orderItemId,
                Quantity = quantity,
                MenuItemId = menuItemId,
                OrderId = orderId,
                MenuItem = menuItem
            };
        }

        public List<OrderItem> GetOrderItemsByOrderId(int orderId)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT oi.OrderItemId, oi.Quantity, oi.MenuItemId, oi.OrderId, oi.Comment, " + 
                                  "mi.menuItemId, mi.menuId, mi.itemName, mi.itemPrice, mi.itemType, mi.itemDescription, mi.itemStock, mi.vat_Amount " +  
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
    }
}
