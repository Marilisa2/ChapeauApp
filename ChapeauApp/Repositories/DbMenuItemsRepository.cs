using ChapeauApp.Models;
using Microsoft.Data.SqlClient;

namespace ChapeauApp.Repositories
{
    public class DbMenuItemsRepository
    {
        private readonly string? _connectionString;

        public DbMenuItemsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ChapeauDb");
        }

        public List<MenuItem> GetAllMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT menuItemId, menuId, itemName, itemPrice, itemType, itemDescription, itemStock, vat_Amount FROM MenuItems ORDER BY MenuItemId ASC";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MenuItem menuItem = ReadMenuItem(reader);
                    menuItems.Add(menuItem);
                }

                reader.Close();
            }

            return menuItems;
        }
        private MenuItem ReadMenuItem(SqlDataReader reader)
        {
            return new MenuItem
            {
                MenuItemId = (int)reader["menuItemId"],
                Menu = new Menu { MenuId = (int)reader["menuId"] },
                ItemName = reader["itemName"].ToString(),
                ItemPrice = (decimal)reader["itemPrice"],
                ItemType = reader["itemType"].ToString(),
                ItemDescription = reader["itemDescription"] != DBNull.Value ? reader["itemDescription"].ToString() : null,
                ItemStock = (int)reader["itemStock"],
                VATAmount = (int)reader["vat_Amount"]
            };
        }
    }
}
