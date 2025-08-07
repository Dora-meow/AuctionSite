using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

namespace myWeb2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public static string userId;//設為全域變數(不知道為什麼cookie裡的值會消失)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] != null)
            {
                string userName = Request.Cookies["UserInfo"]["UserName"];
                string userID = Request.Cookies["UserInfo"]["UserID"];
            }
            else
            {
                // 未登入，跳轉回登入頁面
                Response.Redirect("WebForm2.aspx");
            }
            /*Response.Write(Request.Cookies["UserInfo"]["UserID"] + "<br>");*/
            if (Convert.ToInt32(Request.Cookies["UserInfo"]["UserID"]) != 0)
            {
                //Response.Write(Convert.ToInt32(userId) + "<br>");
                userId = Request.Cookies["UserInfo"]["UserID"];
            }
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            //Response.Write(Convert.ToInt32(userId) + "<br>");

            string product = TextBox1.Text.Trim(); //物品名
            string cate = DropDownList1.SelectedValue; //分類
            string intro = TextBox2.Text.Trim(); //說明
            string money = TextBox3.Text.Trim();//起標價
            string selectedDateTime = txtDateTime.Text.Trim() + ":00"; //用戶提交的開始日期時間
            string selectedDateTime2 = txtDateTime2.Text.Trim() + ":00"; //用戶提交的結束日期時間



            //檢查資料是否有輸入完整
            if (string.IsNullOrEmpty(product) || string.IsNullOrEmpty(cate) || string.IsNullOrEmpty(intro))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "商品資訊請輸入完整";
                return;
            }
            if (!FileUpload1.HasFile)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "請選擇檔案！";
                return;
            }
            if (!FileUpload1.PostedFile.ContentType.Contains("image"))
            {
                lblMessage.Text = "請上傳圖片檔";
                return;
            }
            if (FileUpload1.PostedFile.ContentLength > 10485760) // 10 MB
            {
                lblMessage.Text = "檔案大小不能超過 10MB";
                return;
            }
            if (DateTime.Parse(selectedDateTime) > DateTime.Parse(selectedDateTime2)) // 10 MB
            {
                lblMessage.Text = "開始時間不能大於結束時間";
                return;
            }
            if (string.IsNullOrEmpty(money) || string.IsNullOrEmpty(selectedDateTime) || string.IsNullOrEmpty(selectedDateTime2))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "拍賣資訊請輸入完整";
                return;
            }


            try
            {
                //將檔案儲存到伺服器
                string uploadFolder = Server.MapPath("~/Image/"); // 儲存檔案的目錄
                if (!System.IO.Directory.Exists(uploadFolder))
                {
                    System.IO.Directory.CreateDirectory(uploadFolder); // 如果目錄不存在，則建立
                }

                string fileName = Guid.NewGuid() + "_" + FileUpload1.FileName; // 防止檔名衝突，生成唯一檔名
                string filePath = System.IO.Path.Combine(uploadFolder, fileName);
                FileUpload1.SaveAs(filePath); // 儲存檔案

                string relativePath = "~/Image/" + fileName; // 存到資料庫的路徑

                //連資料庫，丟資料
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
                string insertQuery = "INSERT INTO [商品] ([分類], [商品名稱], [說明], [圖片]) VALUES (@product, @cate, @intro, @imagePath)";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(insertQuery, connection);
                    command.Parameters.Add("@cate", OleDbType.VarChar).Value = cate;
                    command.Parameters.Add("@product", OleDbType.VarChar).Value = product;
                    command.Parameters.Add("@intro", OleDbType.VarChar).Value = intro;
                    command.Parameters.Add("@imagePath", OleDbType.VarChar).Value = relativePath;

                    int rowsAffected = command.ExecuteNonQuery();

                    // 取得剛插入的商品 ID
                    string getIdQuery = "SELECT @@IDENTITY";
                    OleDbCommand getIdCommand = new OleDbCommand(getIdQuery, connection);
                    int newProductId = Convert.ToInt32(getIdCommand.ExecuteScalar());

                    //存到"賣"的資料表
                    string insertQuery2 = @"INSERT INTO [賣] ([開始時間], [停止時間], [起標價], [價錢], [使用者ID], [商品ID]) 
                               VALUES (@startTime, @endTime, @money, @Nmoney, @userID, @pID)";
                    //string userID = Request.Cookies["UserInfo"]["UserID"];

                    OleDbCommand command2 = new OleDbCommand(insertQuery2, connection);
                    command2.Parameters.AddWithValue("@startTime", DateTime.Parse(selectedDateTime));//DateTime.Parse(selectedDateTime)
                    command2.Parameters.AddWithValue("@endTime", DateTime.Parse(selectedDateTime2));
                    command2.Parameters.AddWithValue("@money", Convert.ToInt32(money));
                    command2.Parameters.AddWithValue("@Nmoney", Convert.ToInt32(money));
                    command2.Parameters.AddWithValue("@userID", Convert.ToInt32(userId));//Request.Cookies["UserInfo"]["UserID"]
                    command2.Parameters.AddWithValue("@pID", newProductId);

                    //Response.Write(newProductId);
                    //Response.Write(Convert.ToInt32(money));
                    //Response.Write(Convert.ToInt32(Request.Cookies["UserInfo"]["UserID"]));

                    int rowsAffected2 = command2.ExecuteNonQuery();


                    if (rowsAffected > 0 && rowsAffected2 > 0)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "商品新增成功！ 已開始拍賣";

                        // 清空所有輸入框
                        TextBox1.Text = string.Empty;
                        TextBox2.Text = string.Empty;
                        TextBox3.Text = string.Empty;
                        txtDateTime.Text = string.Empty;
                        txtDateTime2.Text = string.Empty;
                        DropDownList1.SelectedIndex = 0;
                        
                        // 重置 FileUpload
                        FileUpload1.Attributes.Clear();
                    }
                    else
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "商品新增失敗，請再試一次。";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "發生錯誤：" + ex.Message;
            }

            //存到"賣"的資料表
            /*try
            {
                //將資料存入資料庫
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
                string insertQuery = @"INSERT INTO [賣] ([開始時間], [停止時間], [起標價], [使用者ID], [商品ID]) 
                               VALUES (@startTime, @endTime, @money, @userID, @pID)";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command = new OleDbCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@money", money);
                    command.Parameters.AddWithValue("@startTime", selectedDateTime);
                    command.Parameters.AddWithValue("@endTime", selectedDateTime2);
                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@pID", getIdQuery);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "商品新增成功！";
                    }
                    else
                    {
                        lblMessage.Text = "商品新增失敗，請再試一次。";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "發生錯誤：" + ex.Message;
            }*/
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string selectedDateTime = txtDateTime.Text;
            // 處理用戶提交的日期時間
            lblMessage.Text = "你選擇的日期和時間是：" + selectedDateTime;
        }
    }
}