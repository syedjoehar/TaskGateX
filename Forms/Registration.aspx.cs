using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskGateX.Interfaces;
using TaskGateX.Service;

namespace TaskGateX.Forms
{
    public partial class Registration : System.Web.UI.Page
    {
        private IDatabaseService databaseService;
        string selectedDatabaseType = "MySQL";

        public Registration()
        {
            if (selectedDatabaseType == "MySQL")
            {
                string mySqlConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;
                databaseService = new MySqlDatabaseService(mySqlConnectionString);
            }
            else if (selectedDatabaseType == "SQLServer")
            {
                string sqlServerConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                databaseService = new SqlServerDatabaseService(sqlServerConnectionString);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            string givenName = firstName.Text;
            string familyName = lastName.Text;
            string emailId = email.Text;
            string userPassword = password.Text;

            if(databaseService.RegisterUser(givenName, familyName, emailId, userPassword)>0)
                Response.Redirect("UserDetail.aspx");
        }
    }
}
