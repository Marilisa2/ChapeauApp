using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ChapeauApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Chapeau");
        }

        private Employee ReadEmployee(SqlDataReader reader)
        {
            int id = (int)reader["employeeId"];
            string firstname = (string)reader["firstName"];
            string lastname = (string)reader["lastName"];
            string _employeeType = (string)reader["EmployeeType"];
            string password = (string)reader["password"];
            string salt = (string)reader["salt"];
            EmployeeTypes employeeType = (EmployeeTypes)Enum.Parse(typeof(EmployeeTypes), _employeeType, true);
            return new Employee(id, firstname, lastname, employeeType, password,salt);
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = "SELECT employeeId, firstName, lastName, employeeType,password,salt FROM Employees where employeeId=@id";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    employee = ReadEmployee(reader);
                }
                reader.Close();

            }
            return employee;
        }

        public Employee GetEmployeeByLoginCredentials(string lastName, string password)
        {
            Employee employee = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = "SELECT employeeId, firstName, lastName, employeeType, password,salt FROM Employees where lastName=@lastName and password=@password";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                   employee = ReadEmployee(reader);
                }
                reader.Close();

            }
            return employee;
        }

        
        public string GetSalt(string lastName)
        {
            Employee? employee = GetEmployeeByLastName(lastName);
            if (employee == null) 
            {
                return null;
            }
            return employee.Salt;
        }
        public Employee GetEmployeeByLastName(string lastName)
        {
            Employee employee = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = "SELECT employeeId, firstName, lastName, employeeType,password,salt FROM Employees where lastName=@lastName";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@lastName", lastName);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    employee = ReadEmployee(reader);
                }
                reader.Close();

            }
            return employee;
        }
    }
}
