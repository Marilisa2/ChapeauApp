using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace ChapeauApp.Repositories
{
    public class DbTablesRepository : ITableRepository
    {
        private readonly string? _connectionString;

        public DbTablesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ChapeauDb");
        }

        private Table ReadTable(SqlDataReader reader)
        {
            //retrieve data from fields from database
            int tableNumber = (int)reader["TableNumber"];
            string tableStatus = (string)reader["TableStatus"];

            //return new Table Object
            return new Table
            {
                TableNumber = tableNumber,
                TableStatus = tableStatus,
            };
        }

        public List<Table> GetAllTables()
        {
            List<Table> tables = new List<Table>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT TableNumber, TableStatus FROM Tables";
                SqlCommand command = new SqlCommand(query, connection);

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
            throw new NotImplementedException();
        }

        public Table UpdateTableStatus(Table table)
        {
            throw new NotImplementedException();
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
    }
}