using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace ChapeauApp.Repositories
{
    //tijdelijke DbEmployeeRepository tot teamgenoot klaar is
    public class DbEmployeesRepository : IEmployeeRepository
    {
        private readonly string? _connectionString;

        public DbEmployeesRepository(IConfiguration configuration)
        {
            //get database connectionstring from appsettings
            _connectionString = configuration.GetConnectionString("ChapeauDb");
        }

        private Employee ReadEmployee(SqlDataReader reader)
        {
            //retrieve data from fields
            int employeeId = (int)reader["EmployeeId"];
            string firstName = (string)reader["FirstName"];
            string lastName = (string)reader["LastName"];
            string employeeType = (string)reader["EmployeeType"];
            string password = (string)reader["Password"];

            //return new Employee object
            return new Employee(employeeId, firstName, lastName, employeeType, password);
        }

        public Employee? GetEmployeeById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT EmployeeId, FirstName, LastName, EmployeeType, Password FROM Employees WHERE EmployeeId = @EmployeeId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeId", id);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return ReadEmployee(reader);

                }

                return null;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByLoginCredentials(int EmployeeId, string password)
        {
            throw new NotImplementedException();
        }
    }
}
