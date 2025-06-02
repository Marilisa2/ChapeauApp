using ChapeauApp.Models;
using Microsoft.Data.SqlClient;

namespace ChapeauApp.Repositories
{
    //tijdelijk
    public class DbMenuItemsRepository
    {
        private readonly string? _connectionString;

        public DbMenuItemsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<MenuItem> GetAllMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT MenuItemId, MenuId, ItemName, ItemPrice, ItemType, Description, Stock, VATAmount FROM MenuItems ORDER BY MenuItemId ASC";

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
                MenuItemId = (int)reader["MenuItemId"],
                MenuId = (int)reader["MenuId"],
                ItemName = reader["ItemName"].ToString(),
                ItemPrice = (decimal)reader["ItemPrice"],
                ItemType = reader["ItemType"].ToString(),
                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                Stock = (int)reader["Stock"],
                VATAmount = (int)reader["VATAmount"]
            };
        }
    }
}
