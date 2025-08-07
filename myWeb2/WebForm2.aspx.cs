using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace myWeb2
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] != null)
            {
                // 登入，跳轉到登出頁面
                Response.Redirect("WebForm2_1.aspx");
            }
            // 隱藏 Footer
            Control footer = Master.FindControl("Footer");
            if (footer != null)
            {
                //Response.Write("<p>hi</p>");
                footer.Visible = false;
            }
        }

        protected void ToLoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
        protected void InsertButton_Click(object sender, EventArgs e)
        {
            string user2 = user.Text.Trim();
            string password2 = password.Text.Trim();

            try
            {
                // 取連接字串
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
                string query = "SELECT [用戶名稱], [使用者ID], [email] FROM [使用者] WHERE [用戶名稱] = ? AND [密碼] = ?";                //string password = "SELECT [密碼] FROM [使用者]"; // 查詢 Member 資料表的 Name 和 Num 欄位

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open(); //嘗試開啟資料庫連接
                    Response.Write("<p>資料庫連接成功。</p>"); //調試:顯示資料庫連接成功

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // 添加參數
                        command.Parameters.AddWithValue("?", user2);
                        command.Parameters.AddWithValue("?", password2);

                        // 執行查詢
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // 如果有匹配記錄
                                reader.Read(); // 移動到第一筆記錄

                                string matchedUser = reader["用戶名稱"].ToString();
                                string email = reader["email"].ToString();

                                // 驗證成功的回應
                                lblMessage.ForeColor = System.Drawing.Color.Green;
                                lblMessage.Text = $"歡迎，{matchedUser}！您的 Email 是：{email}";

                                //處存登入資料
                                HttpCookie userCookie = new HttpCookie("UserInfo");
                                userCookie["UserName"] = HttpUtility.UrlEncode(matchedUser);
                                userCookie["UserID"] = reader["使用者ID"].ToString();
                                userCookie["email"] = email;
                                userCookie.Expires = DateTime.Now.AddHours(1); // 設置有效期
                                userCookie.Path = "/"; // 確保適用於整個網站
                                //userCookie.HttpOnly = false; // 設置是否允許客戶端訪問
                                //userCookie.Secure = false; // 禁用 HTTPS 限制（僅測試用）
                                //userCookie.SameSite = SameSiteMode.None; // 適用跨站點請求
                                // 設定有效期（如 7 天）
                                //userCookie.Expires = DateTime.Now.AddDays(7);
                                Response.Cookies.Add(userCookie);
                                // 可以在這裡跳轉到另一個頁面
                                Response.Redirect("HomePage.aspx");
                            }
                            else
                            {
                                // 如果沒有匹配記錄
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                                lblMessage.Text = "用戶名稱或密碼不正確，請重新輸入。";
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error message:" + ex.Message;
            }
        }
    }
}