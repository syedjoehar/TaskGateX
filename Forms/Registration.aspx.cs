using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskGateX.Forms
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            string givenName = firstName.Text;
            string familyName = lastName.Text;
            string emailId = email.Text;
            string userPassword = password.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Users (FirstName, LastName, Email, Password) VALUES (@FirstName, @LastName, @Email, @Password)";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", givenName);
                    command.Parameters.AddWithValue("@LastName", familyName);
                    command.Parameters.AddWithValue("@Email", emailId);
                    command.Parameters.AddWithValue("@Password", userPassword);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Redirect("UserDetail.aspx");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }
        }
    }
}
