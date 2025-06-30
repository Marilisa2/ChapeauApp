using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace ChapeauApp.Repositories
{
    public class DbTableRepository : ITableRepository
    {
        private readonly string _connectionString;

        public DbTableRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Chapeau");
        }
        public List<Table> GetAllTables()
        {
            List<Table> tables = new List<Table>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = "SELECT TableNumber, TableStatus FROM Tables";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Table table = ReadTable(reader);
                    tables.Add(table);
                }

                reader.Close();
            }
            return tables;
        }
        private Table ReadTable(SqlDataReader reader)
        {
            //retrieve data from fields from database
            int tableNumber = (int)reader["TableNumber"];
            string _tableStatus = (string)reader["TableStatus"];
            TableStatuses tableStatus = (TableStatuses)Enum.Parse(typeof(TableStatuses), _tableStatus, true);
            List<Order> orders = GetAllOrders(tableNumber);
            return new Table(tableNumber, tableStatus, orders);
        }

        public List<Order> GetAllOrders(int tableNumber)
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

        private Order ReadOrder(SqlDataReader reader)
        {
            int orderId = (int)reader["OrderId"];
            DateTime orderTime = (DateTime)reader["OrderTime"];
            OrderStatus orderStatus = (OrderStatus)reader["OrderStatus"];
            int tableInt = (int)reader["TableNumber"];
            Table table = GetTableById(tableInt);
            int billInt = (int)reader["BillId"];
            //Employee employee = (Employee)reader["EmployeeId"];
            List<OrderItem> orderItems = GetAllOrderItems();
            return new Order(orderId, orderTime, orderStatus, table, orderItems);
        }

        private List<OrderItem> GetAllOrderItems()
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT OrderItemId, Quantity, MenuItemId, OrderId, Comment, OrderItemStatus FROM OrderItems WHERE OrderId = @orderId";
            }
            return orderItems;
        }

        public Table GetTableById(int id)
        {
            Table table = new Table();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = "SELECT TableNumber, TableStatus FROM Tables";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

               if (reader.Read())
               {
                     table = ReadTable(reader);
                   
               }
                reader.Close();
            }
            return table;
        }

        public Table? GetTableByTableNumber(int tableNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT TableNumber, TableStatus FROM Tables WHERE TableNumber = @TableNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TableNumber", tableNumber);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return ReadTable(reader);
                }

                return null;
            }
        }

        public Table UpdateTableStatus(Table table)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = $"update Tables set tableStatus=@tableStatus where tableNumber=@tableNumber";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@tableNumber", table.TableNumber);
                command.Parameters.AddWithValue("@tableStatus", table.TableStatus);          
                command.ExecuteNonQuery();
            }
            return table;
        }

        //Y versie
        //private Table ReadTable(SqlDataReader reader)
        //{
        //    //retrieve data from fields from database
        //    int tableNumber = (int)reader["TableNumber"];
        //    string tableStatus = (string)reader["TableStatus"];

        //    //return new Table Object
        //    return new Table
        //    {
        //        TableNumber = tableNumber,
        //        TableStatus = tableStatus,
        //    };
        //}
    }
}
