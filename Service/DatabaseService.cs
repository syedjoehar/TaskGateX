using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaskGateX.Interfaces;

namespace TaskGateX.Service
{
    public class MySqlDatabaseService : IDatabaseService
    {
        private readonly string connectionString;

        public MySqlDatabaseService(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int RegisterUser(string firstName, string lastName, string email,string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Users (FirstName, LastName, Email, Password) VALUES (@FirstName, @LastName, @Email, @Password)";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public DataTable GetUserData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM Users"; // Replace with your SQL query
                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        return ConvertDataReaderToDataTable(reader);
                        
                    }
                }
            }
        }

        public int UpdateUser(int userID, string firstName, string lastName, string email)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email WHERE UserID = @UserID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public int DeleteUser(int userID)
        {
            throw new NotImplementedException();
        }
        public DataTable ConvertDataReaderToDataTable(MySqlDataReader reader)
        {
            DataTable dataTable = new DataTable();

            // Create columns based on the data reader's schema
            for (int i = 0; i < reader.FieldCount; i++)
            {
                DataColumn column = new DataColumn(reader.GetName(i), reader.GetFieldType(i));
                dataTable.Columns.Add(column);
            }

            // Read data and populate the DataTable
            while (reader.Read())
            {
                DataRow row = dataTable.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = reader[i];
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }

    public class SqlServerDatabaseService : IDatabaseService
    {
        private readonly string connectionString;

        public SqlServerDatabaseService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetUserData()
        {
            string query = "SELECT * FROM Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public int UpdateUser(int userID, string firstName, string lastName, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public int RegisterUser(string firstName, string lastName, string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Users (FirstName, LastName, Email, Password) VALUES (@FirstName, @LastName, @Email, @Password)";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteUser(int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Users WHERE UserID = @UserID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }

}