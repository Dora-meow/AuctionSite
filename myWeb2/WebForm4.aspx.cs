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
    public partial class WebForm4 : System.Web.UI.Page
    {
        public static string userId;//設為全域變數(不知道為什麼cookie裡的值會消失)
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] != null)
            {
                string userName = HttpUtility.UrlDecode(Request.Cookies["UserInfo"]["UserName"]);
                userId = Request.Cookies["UserInfo"]["UserID"];
            }
            else
            {
                // 未登入，跳轉回登入頁面
                Response.Redirect("WebForm2.aspx");
            }

            //LoadData();
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            try
            {
                //連接資料庫
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "SELECT [商品].[商品ID], [商品].[商品名稱], [商品].[圖片], [買].[競標價], [買].[是否寄郵件], [買].[購買時間] FROM [賣], [商品], [買] WHERE [賣].[商品ID]=[商品].[商品ID] AND [賣].[商品ID]=[買].[商品ID] AND [買].[使用者ID]=?"; // 查詢資料表
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.Add("@userID", OleDbType.VarChar).Value = userId;

                    connection.Open(); //嘗試開啟資料庫連接
                    Response.Write("<p></p>"); //測試:顯示資料庫連接成功

                    // 初始化 DataAdapter
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                    // 創建 DataTable 並使用 DataAdapter 填充數據
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    //確保有數據返回
                    if (dt.Rows.Count > 0)
                    {
                        // 綁定資料到 ListView
                        productList.DataSource = dt;
                        productList.DataBind();
                    }
                    else
                    {
                        // 如果沒有資料,顯示提示訊息
                        //Response.Write("沒有任何下標紀錄。");

                        // 清空 ListView 的資料源
                        productList.DataSource = null;
                        productList.DataBind();

                    }


                }
            }
            catch (Exception ex)
            {
                lblWelcome.ForeColor = System.Drawing.Color.Red;
                lblWelcome.Text = "Error message:" + ex.Message;
            }
        }


    }
}