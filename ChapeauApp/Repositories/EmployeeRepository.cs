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
                string querry = $"insert into employees (firstname,lastname,employeeType,password)" +
                                $"values (@firstname,@lastname,@employeeType,@password);" +
                                "select scope_identity();";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@firstname", employee.FirstName);
                command.Parameters.AddWithValue("@lastname", employee.LastName);
                command.Parameters.AddWithValue("@employeeType", employee.EmployeeType);
                command.Parameters.AddWithValue("@password", employee.HashedPassword);
                employee.EmployeeId = Convert.ToInt32(command.ExecuteScalar());
                return employee;
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = $"delete from employees where EmployeeId=@id";
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
                string querry = "SELECT employeeId, firstName, lastName, employeeType, password FROM employees";
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
            int id = (int)reader["employeeId"];
            string firstname = (string)reader["firstName"];
            string lastname = (string)reader["lastName"];
            string employeeType = (string)reader["EmployeeType"];
            string password = (string)reader["password"];
            return new Employee(id, firstname, lastname, employeeType, password);
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = "SELECT employeeId, firstName, lastName, employeeType,password FROM employees where employeeId=@id";
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
                string querry = "SELECT employeeId, firstName, lastName, employeeType, password FROM employees where employeeId=@id and password=@password";
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
                string querry = $"update employees set firstName=@firstname, lastName=@lastname,employeeType=@employeeType, password=@password where employeeId=@id";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@id", employee.EmployeeId);               
                command.Parameters.AddWithValue("@firstname", employee.FirstName);
                command.Parameters.AddWithValue("@lastname", employee.LastName);
                command.Parameters.AddWithValue("@employeeType", employee.EmployeeType);
                command.Parameters.AddWithValue("@password", employee.HashedPassword);
                command.ExecuteNonQuery();
            }
            
        }
        public string GetSalt(int id)
        {
            Employee employee=GetEmployeeById(id);
            return employee.Salt;
        }
    }
}
