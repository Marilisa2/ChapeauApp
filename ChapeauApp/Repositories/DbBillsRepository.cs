using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.IO.Pipelines;

namespace ChapeauApp.Repositories
{
    public class DbBillsRepository : IBillsRepository
    {
        private readonly string? _connectionString;

        public DbBillsRepository(IConfiguration configuration)
        {
            //get database connectionstring from appsettings
            _connectionString = configuration.GetConnectionString("Chapeau");
        }

        //public void BillCheckOut(Bill bill)
        //{
        //    throw new NotImplementedException();
        //}

        private Bill ReadBill(SqlDataReader reader)
        {
            //retrieve data fields from database
            int billId = (int)reader["BillId"];
            decimal totalPriceAmountExclVAT = (decimal)reader["TotalPriceAmountExclVAT"];
            decimal tipAmount = (decimal)reader["TipAmount"];
            decimal totalPriceAmountInclVAT = (decimal)reader["TotalPriceAmountInclVAT"];
            string feedbackText = (string)reader["FeedbackText"];

            int paymentId = (int)reader["PaymentId"];
            Payment payment = new Payment
            {
                PaymentId = paymentId,
            };

            return new Bill(billId, totalPriceAmountExclVAT, tipAmount, totalPriceAmountInclVAT, feedbackText, payment);
        }
        public Bill? GetBillByTableNumber(int tableNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT b.BillId, b.TotalPriceAmountExclVAT, b.TipAmount, b.TotalPriceAmountInclVAT, b.FeedbackText, b.PaymentId " +
                                "FROM Bills b " + 
                                "JOIN Orders o ON b.BillId = o.BillId " + 
                                "WHERE o.TableNumber = @TableNumber ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TableNumber", tableNumber);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return ReadBill(reader);
                }

                return null;
            }
        }


        public Bill? GetBillByBillId(int billId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT BillId, TotalPriceAmountExclVAT, TipAmount, TotalPriceAmountInclVAT, FeedbackText, PaymentId FROM Bills " +
                                "WHERE BillId = @BillId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BillId", billId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return ReadBill(reader);
                }

                return null;
            }
        }

        //Saves entered tip amount in the database
        public void SaveTipAmount (int billId, decimal tipAmount)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Bills SET TipAmount = @TipAmount WHERE BillId = @BillId";

                SqlCommand command = new SqlCommand(@query, connection);
                command.Parameters.AddWithValue("TipAmount", tipAmount);
                command.Parameters.AddWithValue("@BillId", billId);

                connection.Open();
                command.ExecuteNonQuery();//?
            }

        }

        public void SaveFeedbackText(int billId, string feedbackText)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Bills SET FeedbackText = @FeedbackText WHERE BillId = @BillId";

                SqlCommand command = new SqlCommand(@query, connection);
                command.Parameters.AddWithValue("FeedbackText", feedbackText);
                command.Parameters.AddWithValue("@BillId", billId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        //public int GetPaymentIdByBillId(int billId)
        //{

        //}

        //public void SavePaymentMethod(int billId, PaymentMethod paymentMethod)
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        string query = "UPDATE Payments SET PaymentMethod = @PaymentMethod WHERE BillId = @BillId";

        //        SqlCommand command = new SqlCommand(@query, connection);
        //        command.Parameters.AddWithValue("TipAmount", tipAmount);
        //        command.Parameters.AddWithValue("@BillId", billId);

        //        connection.Open();
        //        command.ExecuteNonQuery();//?
        //    }

        //}

        //public void BillCheckOut(Bill bill)
        //{
        //    throw new NotImplementedException();
        //}//weghalen??


    }
}
