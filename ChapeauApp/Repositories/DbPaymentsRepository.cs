using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace ChapeauApp.Repositories
{
    public class DbPaymentsRepository : IPaymentsRepository
    {
        private readonly string? _connectionString;

        public DbPaymentsRepository(IConfiguration configuration) 
        {
            //get database connectionstring from appsettings
            _connectionString = configuration.GetConnectionString("Chapeau");
        }

        public void SavePaymentMethod(int paymentId, PaymentMethod paymentMethod)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Payments SET PaymentMethod = @PaymentMethod WHERE PaymentId = @PaymentId";

                SqlCommand command = new SqlCommand(@query, connection);
                command.Parameters.AddWithValue("PaymentMethod", (int)paymentMethod); //this enum is stored as an int in the database
                command.Parameters.AddWithValue("@PaymentId", paymentId);

                connection.Open();
                command.ExecuteNonQuery();//?
            }
        }

        //wijzigen?
        public int GetPaymentIdForBill(int billId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT PaymentId FROM Bills WHERE BillId = @BillId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BillId", billId);

                connection.Open();
                var result = command.ExecuteScalar();// 1 waarde

                if (result == null || result == DBNull.Value)
                {
                    throw new Exception($"No PaymentId found for BillId {billId}");
                }

                return Convert.ToInt32(result);
            }
        }

    }
}
