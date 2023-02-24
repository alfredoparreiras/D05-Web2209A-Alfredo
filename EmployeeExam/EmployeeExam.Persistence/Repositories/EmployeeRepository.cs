using EmployeeExam.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;

namespace EmployeeExam.Persistence.Repositories
{
    public class EmployeeRepository
    {
        private readonly string connectionString;
        public EmployeeRepository()
        {
            // TODO
            connectionString = ConfigurationManager.ConnectionStrings["EmployeeExamDatabase"].ConnectionString;
        }

        public Employee GetEmployee(int id)
        {
            // TODO
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, FirstName, LastName, DateOfBirth, JobTitle,HourlyWage,HoursWorked,HoursPaid,PaymentReceived " +
                                  "FROM dbo.Employees " +
                                  "WHERE Id = @id;";

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadNextEmployee(reader);

            return null;
        }


        public List<Employee> GetEmployees()
        {
            // TODO
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, FirstName, LastName, DateOfBirth, JobTitle,HourlyWage,HoursWorked,HoursPaid,PaymentReceived " +
                                  "FROM dbo.Employees ";

            using SqlDataReader reader = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
                employees.Add(ReadNextEmployee(reader));

            return employees;
        }

        public Employee AddEmployee(Employee employee)
        {
            // TODO
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO dbo.Employees "
                + "(FirstName, LastName, DateOfBirth, JobTitle,HourlyWage,HoursWorked,HoursPaid,PaymentReceived,DateCreated, DateUpdated ) "
                + "OUTPUT INSERTED.Id "
                + "VALUES(@firstName, @lastName,@dateOfBirth, @jobTitle, @hourlyWage, @hoursWorked, @hoursPaid, @paymentReceived,@dateCreated, @dateUpdated)";

            command.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = employee.FirstName;
            command.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = employee.LastName;
            command.Parameters.Add("@dateOfBirth", SqlDbType.DateTime2).Value = employee.DateOfBirth;
            command.Parameters.Add("@jobTitle", SqlDbType.NVarChar).Value = employee.JobTitle;
            command.Parameters.Add("@hourlyWage", SqlDbType.Decimal).Value = employee.HourlyWage;
            command.Parameters.Add("@hoursWorked", SqlDbType.Decimal).Value = employee.HoursWorked;
            command.Parameters.Add("@hoursPaid", SqlDbType.Decimal).Value = employee.HoursPaid;
            command.Parameters.Add("@paymentReceived", SqlDbType.Decimal).Value = employee.PaymentReceived;

            command.Parameters.Add("@dateCreated", SqlDbType.DateTime2).Value = DateTime.UtcNow;
            command.Parameters.Add("@dateUpdated", SqlDbType.DateTime2).Value = DateTime.UtcNow;

            int id = (int)command.ExecuteScalar();
            return new Employee(id, employee);

        }

        public bool UpdateEmployee(Employee employee)
        {
            // TODO
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE dbo.Employees "
                + "SET FirstName = @firstName, LastName = @lastName, DateOfBirth = dateOfBirth, JobTitle = @jobTitle," +
                "HourlyWage = @hourlyWage,HoursWorked = @hoursWorked ,HoursPaid = @hoursPaid,PaymentReceived = @paymentReceived,DateUpdated = @dateUpdated "
                + "WHERE Id = @id";

            command.Parameters.Add("@id", SqlDbType.Int).Value = employee.Id;
            command.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = employee.FirstName;
            command.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = employee.LastName;
            command.Parameters.Add("@dateOfBirth", SqlDbType.DateTime2).Value = employee.DateOfBirth;
            command.Parameters.Add("@jobTitle", SqlDbType.NVarChar).Value = employee.JobTitle;
            command.Parameters.Add("@hourlyWage", SqlDbType.Decimal).Value = employee.HourlyWage;
            command.Parameters.Add("@hoursWorked", SqlDbType.Decimal).Value = employee.HoursWorked;
            command.Parameters.Add("@hoursPaid", SqlDbType.Decimal).Value = employee.HoursPaid;
            command.Parameters.Add("@paymentReceived", SqlDbType.Decimal).Value = employee.PaymentReceived;
            command.Parameters.Add("@dateUpdated", SqlDbType.DateTime2).Value = DateTime.UtcNow;

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool RemoveEmployee(Employee employee)
        {

            return RemoveEmployee(employee.Id);
        }

        public bool RemoveEmployee(int id)
        {
            // TODO
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE dbo.Employees WHERE Id = @id";


            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
      
        }
        private Employee ReadNextEmployee(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string firstName = reader.GetString(1);
            string lastName = reader.GetString(2);
            DateTime dateOfBirth = reader.GetDateTime(3);
            string jobTitle = reader.GetString(4);
            decimal hourlyWage = reader.GetDecimal(5);
            decimal hoursWorked = reader.GetDecimal(6);
            decimal hoursPaid = reader.GetDecimal(7);
            decimal paymentReceived = reader.GetDecimal(8);


            return new Employee(id, firstName, lastName, dateOfBirth, jobTitle, hourlyWage, hoursWorked, hoursPaid, paymentReceived);
        }
    }
}
