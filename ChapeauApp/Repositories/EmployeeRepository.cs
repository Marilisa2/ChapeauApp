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

        public Employee AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = $"insert into Employees (firstname,lastname,employeeType,password,salt)" +
                                $"values (@firstname,@lastname,@employeeType,@password,@salt);" +
                                "select scope_identity();";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@firstname", employee.FirstName);
                command.Parameters.AddWithValue("@lastname", employee.LastName);
                command.Parameters.AddWithValue("@employeeType", employee.EmployeeType);
                command.Parameters.AddWithValue("@password", employee.HashedPassword);
                command.Parameters.AddWithValue("@salt", employee.Salt);
                employee.EmployeeId = Convert.ToInt32(command.ExecuteScalar());
                return employee;
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = $"delete from Employees where EmployeeId=@id";
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
                string querry = "SELECT employeeId, firstName, lastName, employeeType, password,salt FROM Employees";
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

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string querry = $"update Employees set firstName=@firstname, lastName=@lastname,employeeType=@employeeType, password=@password, salt=@salt where employeeId=@id";
                SqlCommand command = new SqlCommand(querry, connection);

                command.Connection.Open();
                command.Parameters.AddWithValue("@id", employee.EmployeeId);               
                command.Parameters.AddWithValue("@firstname", employee.FirstName);
                command.Parameters.AddWithValue("@lastname", employee.LastName);
                command.Parameters.AddWithValue("@employeeType", employee.EmployeeType);
                command.Parameters.AddWithValue("@password", employee.HashedPassword);
                command.Parameters.AddWithValue("@salt",employee.Salt);
                command.ExecuteNonQuery();
            }
            
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
