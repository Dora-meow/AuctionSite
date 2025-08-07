using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace myWeb2
{
    public partial class ProductDetails : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] == null)
            {
                // 未登入，跳轉回登入頁面
                Response.Redirect("WebForm2.aspx");
            }

            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            try
            {
                // 取連接字串
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
                string query = "SELECT [商品].[分類], [商品].[商品名稱], [商品].[說明], [商品].[圖片], [賣].[價錢], [賣].[開始時間], [賣].[停止時間], [使用者].[用戶名稱]" +
                               "FROM [賣], [商品], [使用者] " +
                               "WHERE [商品].[商品ID]=? AND [賣].[商品ID]=[商品].[商品ID] AND [賣].[使用者ID]=[使用者].[使用者ID]"; // 查詢資料表

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open(); //嘗試開啟資料庫連接
                    Response.Write("<p><br><br></p>"); //測試:顯示資料庫連接成功
                    //Response.Write(Request.QueryString["productID"]);

                    // 初始化 DataAdapter 並設置查詢
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@商品ID", Request.QueryString["productID"]);
                    /*command.Parameters.AddWithValue：用來將值綁定到 SQL 查詢中的參數（如 @ProductID）
                      Request.QueryString["productID"]：Request.QueryString 是用來獲取 URL(網址) 中的查詢參數的集合。
                      ex: 網址：http://example.com/ProductDetails.aspx?productID=123 -> Request.QueryString["productID"] 會返回字符串 "123"
                    */
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                    // 創建 DataTable 並使用 DataAdapter 填充數據
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    //確保有數據返回
                    if (dt.Rows.Count > 0)
                    {
                        // 將資料綁定到 GridView 控制項
                        //GridViewl.DataSource = dt;
                        //GridViewl.DataBind();

                        // 綁定資料到 ListView
                        FormView1.DataSource = dt;
                        FormView1.DataBind();

                        // 獲取開始和停止時間
                        DateTime startTime = Convert.ToDateTime(dt.Rows[0]["開始時間"]);
                        DateTime endTime = Convert.ToDateTime(dt.Rows[0]["停止時間"]);
                        DateTime currentTime = DateTime.Now;

                        // 判斷當前時間是否在範圍內
                        if (currentTime < startTime || currentTime > endTime)
                        {
                            // 隱藏按鈕 Button1
                            Button1.Visible = false;
                        }
                        else
                        {
                            // 顯示按鈕 Button1
                            Button1.Visible = true;
                        }
                    }
                    else
                    {
                        // 如果沒有資料,顯示提示訊息
                        Response.Write("沒有資料可以顯示。");
                    }


                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error message:" + ex.Message;
            }
        }

        protected void Buy(object sender, EventArgs e)
        {
            //跳轉到購買頁面
            Response.Redirect("BuyProduct.aspx?productID=" + Request.QueryString["productID"]);
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            //跳轉到主頁面
            Response.Redirect("HomePage.aspx");
        }
    }
}