using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace myWeb2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void InsertButton_Click(object sender, EventArgs e)
        {
            //Response.Write("Hello! student: " + username.Text);
            string username1 = username.Text.Trim();
            string phone1 = phone.Text.Trim();
            string email1 = email.Text.Trim();
            string user1 = user.Text.Trim();
            string password1 = password.Text.Trim();
            string passwordConfirm = password_confirm.Text.Trim();

            // Check if the input is valid

            if (string.IsNullOrEmpty(username1) || string.IsNullOrEmpty(phone1) || string.IsNullOrEmpty(email1) || string.IsNullOrEmpty(user1) || string.IsNullOrEmpty(password1))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "資料請輸入完整";
                return;
            }
            if (passwordConfirm.Equals(password1) == false)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "密碼不同，請檢查輸入";
                return;
            }

            //連資料庫
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            string insertQuery = "INSERT INTO [使用者] ([姓名], [電話], [Email], [用戶名稱], [密碼]) VALUES (@username1, @phone1, @email1, @user1, @password1)";
            string checkQuery = "SELECT COUNT(*) FROM [使用者] WHERE [用戶名稱] = @user1";//判斷輸入的用戶名稱是否存在

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    OleDbCommand checkCommand = new OleDbCommand(checkQuery, connection);
                    checkCommand.Parameters.Add("@user1", OleDbType.VarChar).Value = user1;
                    int userCount = (int)checkCommand.ExecuteScalar();
                    if (userCount > 0)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "該用戶名稱已存在，請更換其他名稱";
                        return;
                    }

                    OleDbCommand command = new OleDbCommand(insertQuery, connection);

                    command.Parameters.Add("@username1", OleDbType.VarChar).Value = username1;
                    command.Parameters.Add("@phone1", OleDbType.VarChar).Value = phone1;
                    command.Parameters.Add("@email1", OleDbType.VarChar).Value = email1;
                    command.Parameters.Add("@user1", OleDbType.VarChar).Value = user1;
                    command.Parameters.Add("@password1", OleDbType.VarChar).Value = password1;

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "註冊成功!";
                        // Jump to Select.aspx after successful insertion
                        Response.Redirect("WebForm2.aspx");
                    }
                    else
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Insertion failed.";
                    }
                }

                catch (Exception ex)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Error message:" + ex.Message;
                }

            }
        }

        protected void username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}