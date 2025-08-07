using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace myWeb2
{
    public partial class BuyProduct : System.Web.UI.Page
    {
        public static string userId;//設為全域變數(不知道為什麼cookie裡的值在按按鈕後會消失)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] == null)
            {
                // 未登入，跳轉回登入頁面
                Response.Redirect("WebForm2.aspx");
            }

            Response.Write(Convert.ToInt32(Request.Cookies["UserInfo"]["UserID"]));
            if (!IsPostBack)
            {
                userId = Request.Cookies["UserInfo"]["UserID"];
                Button2.Visible = false;
            }

            /*if (Request.Cookies["UserInfo"] != null)
            {
                //HttpContext.Current.Cache["UserID"] = Request.Cookies["UserInfo"]["UserID"];
                Response.Write(Convert.ToInt32(Session["UserID"])+"<br>");
            }*/
        }
        protected void InsertButton_Click(object sender, EventArgs e)
        {
            //Response.Write(Convert.ToInt32(userId) + "<br>");
            /*string userId = null;
            if (Request.Cookies["UserInfo"] != null && Request.Cookies["UserInfo"]["UserID"] != null)
            {
                userId = Request.Cookies["UserInfo"]["UserID"];
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "使用者未登入，請先登入後再進行操作。";
                return;
            }*/
            string money1 = money.Text.Trim();
            string productId = Request.QueryString["productID"];
            //int uId = Convert.ToInt32(Request.Cookies["UserInfo"]["UserID"]);

            // Check if the input is valid
            if (string.IsNullOrEmpty(money1))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "請輸入價錢";
                Button2.Visible = false;
                return;
            }
            if (!int.TryParse(money1, out int parsedMoney))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "請輸入有效的數字";
                Button2.Visible = false;
                return;
            }




            try
            {
                //連資料庫
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    //確認填的價錢是否合理
                    string getMoneyQuery = "SELECT [價錢] FROM [賣] WHERE [商品ID] = ?";
                    OleDbCommand command = new OleDbCommand(getMoneyQuery, connection);
                    command.Parameters.AddWithValue("@pId", Convert.ToInt32(productId)); // 商品 ID
                    int moneyNow = Convert.ToInt32(command.ExecuteScalar());
                    if (moneyNow >= Convert.ToInt32(money1))
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "填入的價格小於目前的競標價，請重新輸入";
                        Button2.Visible = false;
                        return;
                    }

                    //新增資料
                    string insertQuery = "INSERT INTO [買] ([競標價], [購買時間], [使用者ID], [商品ID]) VALUES (@money1, NOW(), @userId, @productId)";
                    command = new OleDbCommand(insertQuery, connection);

                    command.Parameters.Add("@money1", OleDbType.Integer).Value = money1;
                    //command.Parameters.AddWithValue("@time", DateTime.Parse());
                    command.Parameters.AddWithValue("@userID", Convert.ToInt32(userId));
                    command.Parameters.Add("@productId", OleDbType.Integer).Value = productId;
                    int rowsAffected = command.ExecuteNonQuery();

                    //把價錢更新到'賣'資料表
                    string updateQuery = "UPDATE [賣] SET [價錢]= ? WHERE [商品ID] = ?";
                    OleDbCommand command2 = new OleDbCommand(updateQuery, connection);
                    command2.Parameters.AddWithValue("@m", Convert.ToInt32(money1)); // 更新的價錢
                    command2.Parameters.AddWithValue("@pId", Convert.ToInt32(productId)); // 商品 ID
                    int rowsAffected1 = command2.ExecuteNonQuery();


                    if (rowsAffected > 0 && rowsAffected1 > 0)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "標價成功!";
                        Button2.Visible = true;
                        //Response.Redirect("ProductDetails.aspx?productID=" + Request.QueryString["productID"]);
                    }
                    else
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Insertion failed.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error message:" + ex.Message;
            }


        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //跳轉到產品介紹頁面
            Response.Redirect("ProductDetails.aspx?productID=" + Request.QueryString["productID"]);
        }
    }
}