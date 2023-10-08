using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TaskGateX.Forms
{
    public partial class UserDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserData();
            }
        }

        private void BindUserData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            string query = "SELECT * FROM Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    userGridView.DataSource = dt;
                    userGridView.DataBind();
                }
            }
        }

        protected void userGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            userGridView.EditIndex = e.NewEditIndex;
            BindUserData();
        }

        protected void userDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            int userID = Convert.ToInt32(userDetailsView.DataKey.Value);
            string updatedFirstName = e.NewValues["FirstName"].ToString();
            string updatedLastName = e.NewValues["LastName"].ToString();
            string updatedEmail = e.NewValues["Email"].ToString();

            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@FirstName", updatedFirstName);
                    cmd.Parameters.AddWithValue("@LastName", updatedLastName);
                    cmd.Parameters.AddWithValue("@Email", updatedEmail);

                    cmd.ExecuteNonQuery();
                }
            }

            userGridView.EditIndex = -1;
            BindUserData();
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationForm.aspx");
        }

        protected void userGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;

                string updatedFirstName = e.NewValues["FirstName"].ToString();
                string updatedLastName = e.NewValues["LastName"].ToString();
                string updatedEmail = e.NewValues["Email"].ToString();

                int userID = Convert.ToInt32(e.NewValues["UserID"].ToString());

                string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email WHERE UserID = @UserID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", updatedFirstName);
                        cmd.Parameters.AddWithValue("@LastName", updatedLastName);
                        cmd.Parameters.AddWithValue("@Email", updatedEmail);
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            userGridView.EditIndex = -1;
                            BindUserData();
                        }
                        else
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void userGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            userGridView.EditIndex = -1;
            BindUserData();
        }

        protected void userGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                int userID = Convert.ToInt32(e.Values["UserID"].ToString());

                string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                string query = "DELETE FROM Users WHERE UserID = @UserID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            BindUserData();
                        }
                        else
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
