using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace ChapeauApp.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly string _connectionString;

        public TableRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SomerenDatabase");
        }
        public List<Table> GetAllTables()
        {
            List<Table> tables = new List<Table>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = "SELECT tableNumber,tableStatus FROM Tables";
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

        public Table GetTableById(int id)
        {
            Table table = new Table();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = "SELECT tableNumber,tableStatus FROM Tables";
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
        private Table ReadTable(SqlDataReader reader)
        {
            int tableNumber = (int)reader["tableNumber"];
            string _tableStatus = (string)reader["tableStatus"];
            TableStatuses tableStatus = (TableStatuses)Enum.Parse(typeof(TableStatuses), _tableStatus, true);
            return new Table(tableNumber,tableStatus);
        }

    }
}
