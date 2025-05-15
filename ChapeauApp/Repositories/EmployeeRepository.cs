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
            _connectionString = configuration.GetConnectionString("SomerenDatabase");
        }

        public Employee AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = $"insert into Employees (firstname,lastname,employeeType,password)" +
                                $"values (@firstname,@lastname,@employeeType,@password);" +
                                "select scope_identity();";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@firstname", employee.FirstName);
                command.Parameters.AddWithValue("@lastname", employee.LastName);
                command.Parameters.AddWithValue("@employeeType", employee.EmployeeType);
                command.Parameters.AddWithValue("@password", employee.Password);
                employee.EmployeeId = Convert.ToInt32(command.ExecuteScalar());
                return employee;
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = $"delete from employees where Employee=@id";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = "SELECT EmployeeId, firstname, lastname, employeeType,password FROM Employees";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                   Employee employee = ReadEmployee(reader);
                    employees.Add(employee);
                }
                reader.Close();
            }
            return employees;
        }
        private Employee ReadEmployee(SqlDataReader reader)
        {
            int id = (int)reader["EmployeeId"];
            string firstname = (string)reader["firstname"];
            string lastname = (string)reader["lastname"];
            string employeeType = (string)reader["EmployeeType"];
            string password = (string)reader["password"];
            return new Employee(id, firstname, lastname, employeeType, password);
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = "SELECT EmployeeId, firstname, lastname, employeeType,password FROM Employees where UserId=@id";
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

        public Employee GetEmployeeByLoginCredentials(int EmployeeId, string password)
        {
            Employee employee = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = "SELECT EmployeeId, firstname, lastname,employeeType,password FROM Employees where EmployeeId=@id and password=@password";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@id", EmployeeId);
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

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = $"update Employees set firstname=@firstname, lastname=@lastname,employeeType=@employeeType, password=@password where EmployeeId=@id";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@id", employee.EmployeeId);               
                command.Parameters.AddWithValue("@firstname", employee.FirstName);
                command.Parameters.AddWithValue("@lastname", employee.LastName);
                command.Parameters.AddWithValue("@employeeType", employee.EmployeeType);
                command.Parameters.AddWithValue("@password", employee.Password);
                command.ExecuteNonQuery();

            }
        }
    }
}
