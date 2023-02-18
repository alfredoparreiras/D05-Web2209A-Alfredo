using Microsoft.Data.SqlClient;
using PassportApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportApp.Repository
{
    internal class PassportRepository
    {
        private readonly string connectionString;

        public PassportRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["PassportDBO"].ConnectionString;
        }

        private Passport ReadNextPassport(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string firstName = reader.GetString(1);
            string lastName = reader.GetString(2);
            DateTime dateOfBirth = reader.GetDateTime(3);
            string country = reader.GetString(4);
            DateTime dateCreated = reader.GetDateTime(5);
            DateTime dateUpdated = reader.GetDateTime(6);

            return new Passport(id, firstName, lastName, dateOfBirth, country, dateCreated, dateUpdated);

        }
        public Passport GetPassport(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, FirstName, LastName, DateOfBirth, Country, DateCreated, DateUpdated " +
                "FROM Passports " +
                "WHERE Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadNextPassport(reader);
            return null;
        }


        public List<Passport> GetPassports()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, FirstName, LastName, DateOfBirth, Country, DateCreated, DateUpdated " +
                "FROM Passports ";

            using SqlDataReader reader = command.ExecuteReader();
            List<Passport> passports = new List<Passport>();
            while (reader.Read())
                passports.Add(ReadNextPassport(reader));
            return passports;
        }

        public List<Passport> GetPassportsByName(string firstName, string lastName)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Id, FirstName, LastName, DateOfBirth, Country, DateCreated, DateUpdated " +
                "FROM Passports " +
                "WHERE FirstName = @firstName AND LastName = @lastName;";

            command.Parameters.Add("@firstName", SqlDbType.NChar).Value = firstName;
            command.Parameters.Add("@lastName", SqlDbType.NChar).Value = lastName;

            using SqlDataReader reader = command.ExecuteReader();
            List<Passport> passports = new List<Passport>();
            while (reader.Read())
                passports.Add(ReadNextPassport(reader));
            return passports; 
        }

        public Passport AddPassport(Passport passport)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO dbo.Passports " +
                                  "(FirstName, LastName, DateOfBirth, Country, DateCreated, DateUpdated) " +
                                  "OUTPUT INSERTED.Id " +
                                  "VALUES(@firstName, @lastName, @dateOfBirth, @country, @dateCreated, @dateUpdated);";

            command.Parameters.Add("@firstName", SqlDbType.NChar).Value = passport.FirstName;
            command.Parameters.Add("@lastName", SqlDbType.NChar).Value = passport.LastName;
            command.Parameters.Add("@dateOfBirth", SqlDbType.DateTime2).Value = passport.DateOfBirth;
            command.Parameters.Add("@country", SqlDbType.NChar).Value = passport.CountryOfResidence;
            command.Parameters.Add("@dateCreated", SqlDbType.DateTime2).Value = DateTime.Now;
            command.Parameters.Add("@dateUpdated", SqlDbType.DateTime2).Value = DateTime.Now;

            int id = (int)command.ExecuteScalar();
            return new Passport(id, passport);

        }

        public bool UpdatePassport(Passport passport)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE dbo.Passports " +
                                  "SET FirstName = @firstName,  LastName = @lastName, DateOfBirth = @dateOfBirth, Country = @country, DateUpdated = @dateUpdated " +
                                  "WHERE Id = @id;";

            command.Parameters.Add("@id", SqlDbType.Int).Value = passport.Id;
            command.Parameters.Add("@firstName", SqlDbType.NChar).Value = passport.FirstName;
            command.Parameters.Add("@lastName", SqlDbType.NChar).Value = passport.LastName;
            command.Parameters.Add("@dateOfBirth", SqlDbType.DateTime2).Value = passport.DateOfBirth;
            command.Parameters.Add("@country", SqlDbType.NChar).Value = passport.CountryOfResidence;
            command.Parameters.Add("@dateUpdated", SqlDbType.DateTime2).Value = DateTime.Now;

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;

        }

        public bool RemovePassport(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE dbo.Passports " +
                                  "WHERE Id = @id;";

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public List<Passport> GetPassportsByDate(DateTime minimum, DateTime maximum)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand(); 
            command.CommandText = "SELECT Id, FirstName, LastName, DateOfBirth, Country, DateCreated, DateUpdated " +
                                  "FROM dbo.Passports " +
                                  "WHERE DateOfBirth BETWEEN @minimum AND @maximum";

            command.Parameters.Add("@minimum", SqlDbType.DateTime2).Value = minimum;
            command.Parameters.Add("@maximum", SqlDbType.DateTime2).Value = maximum;

            using SqlDataReader reader = command.ExecuteReader();
            List<Passport> passports = new List<Passport>();
            while (reader.Read())
                passports.Add(ReadNextPassport(reader));

            return passports; 
        }
    }
}
