using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Web.ModelBinding;

namespace myWeb2
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] != null)
            {
                string userName = HttpUtility.UrlDecode(Request.Cookies["UserInfo"]["UserName"]);
                lblWelcome.Text = "歡迎，" + userName;
            }
            else
            {
                // 未登入，跳轉回登入頁面
                Response.Redirect("WebForm2.aspx");
            }

            LoadData();
            /*if (!IsPostBack)
            {
                LoadData();
            }*/
        }
        private void LoadData()
        {
            try
            {
                string cate = DropDownList1.SelectedValue;

                string query;
                // 取連接字串
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbCommand command;

                    if (cate.Equals("全"))
                    {
                        query = "SELECT [商品].[商品ID], [商品].[商品名稱], [商品].[分類], [商品].[圖片], [賣].[價錢] FROM [賣], [商品] WHERE [賣].[商品ID]=[商品].[商品ID] AND [賣].[停止時間]>NOW() AND [賣].[開始時間]<NOW()"; // 查詢資料表
                        command = new OleDbCommand(query, connection);
                        //Response.Write(cate);
                        //Response.Write(query);
                    }
                    else
                    {
                        //Response.Write("mmmmmm");
                        query = "SELECT [商品].[商品ID], [商品].[商品名稱], [商品].[分類], [商品].[圖片], [賣].[價錢] FROM [賣], [商品] WHERE [賣].[商品ID]=[商品].[商品ID] AND [賣].[停止時間]>NOW() AND [賣].[開始時間]<NOW() AND [商品].[分類] =?"; // 查詢資料表
                        /*query = "SELECT [商品].[商品ID], [商品].[商品名稱], [商品].[分類], [商品].[圖片], [賣].[價錢] " +
                        "FROM [賣] INNER JOIN [商品] ON [賣].[商品ID] = [商品].[商品ID] " +
                        "WHERE [賣].[停止時間] > NOW() AND [賣].[開始時間] < NOW() AND [商品].[分類] = ?";
                        */
                        //Response.Write(cate);
                        //Response.Write(query);
                        command = new OleDbCommand(query, connection);
                        command.Parameters.Add("@cate", OleDbType.VarChar).Value = cate.Trim();
                    }
                    connection.Open(); //嘗試開啟資料庫連接
                    Response.Write("<p><br></p>"); //測試:顯示資料庫連接成功

                    // 初始化 DataAdapter 並設置查詢
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
                        productList.DataSource = dt;
                        productList.DataBind();
                    }
                    else
                    {
                        // 如果沒有資料,顯示提示訊息
                        //Response.Write("沒有資料可以顯示。");

                        // 清空 GridView 和 ListView 的資料源
                        //GridViewl.DataSource = null;
                        //GridViewl.DataBind();

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

        /*public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            var _db = new WingtipToys.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }
            return query;
        }*/
    }
}