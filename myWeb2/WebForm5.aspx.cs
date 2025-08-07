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
    public partial class WebForm5 : System.Web.UI.Page
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
                //連接資料庫
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = @"SELECT 
                                        [商品].[商品ID],
                                        [商品].[商品名稱], 
                                        [商品].[圖片], 
                                        [買].[是否寄郵件], 
                                        [買].[競標價], 
                                        [賣].[起標價], 
                                        [賣].[價錢], 
                                        [賣].[開始時間],
                                        [賣].[停止時間],
                                        [使用者].[用戶名稱]
                                    FROM
                                        (([賣]
                                        INNER JOIN [商品] ON [賣].[商品ID] = [商品].[商品ID])
                                        LEFT JOIN [買] ON [賣].[商品ID] = [買].[商品ID])
                                        LEFT JOIN [使用者] ON [買].[使用者ID] = [使用者].[使用者ID]
                                    WHERE
                                        [賣].[使用者ID] = ?  "; //用LEFT JOIN 右表沒有對應的配對資料也沒關西，欄位會顯示null   //JOIN 要用括號，先執行 [賣] 和 [商品] 之間的 INNER JOIN，確保只獲取有對應商品的銷售記錄，然後執行與 [買] 的 LEFT JOIN 保留商品記錄。最後將[買] 和[使用者] 做 LEFT JOIN，找的買家信息。
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.Add("@userID", OleDbType.VarChar).Value = userId;

                    connection.Open(); //嘗試開啟資料庫連接
                    Response.Write("<p></p>"); //測試:顯示資料庫連接成功

                    // 初始化 DataAdapter
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                    // 創建 DataTable 並使用 DataAdapter 填充數據
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // 動態添加自定義資料行
                    if (!dt.Columns.Contains("顯示樣式")) //商品狀態
                        dt.Columns.Add("顯示樣式", typeof(string));
                    if (!dt.Columns.Contains("樣式顏色"))
                        dt.Columns.Add("樣式顏色", typeof(string));
                    if (!dt.Columns.Contains("顯示樣式2")) //價錢
                        dt.Columns.Add("顯示樣式2", typeof(string));

                    //確保有數據返回
                    if (dt.Rows.Count > 0)
                    {
                        List<DataRow> rowsToDelete = new List<DataRow>(); // 用來記錄需要刪除的行

                        // 從 DataTable 檢查每一筆資料並執行條件判斷
                        foreach (DataRow row in dt.Rows)
                        {
                            DateTime startTime = row["開始時間"] != DBNull.Value
                                ? Convert.ToDateTime(row["開始時間"])
                                : DateTime.MinValue; // 如果為空，設定為最小日期

                            DateTime stopTime = row["停止時間"] != DBNull.Value
                                ? Convert.ToDateTime(row["停止時間"])
                                : DateTime.MaxValue; // 如果為空，設定為最小日期

                            decimal bidPrice = row["競標價"] != DBNull.Value
                                ? Convert.ToDecimal(row["競標價"])
                                : -1; // 預設值為 -1 表示無競標價

                            bool isMailSent = row["是否寄郵件"] != DBNull.Value
                                && Convert.ToBoolean(row["是否寄郵件"]);

                            decimal sellPrice = row["價錢"] != DBNull.Value
                                ? Convert.ToDecimal(row["價錢"])
                                : 0; // 預設值為 0

                            decimal startPrice = row["起標價"] != DBNull.Value
                                ? Convert.ToDecimal(row["起標價"])
                                : 0; // 預設值為 0

                            // 判斷顯示樣式
                            if (startTime > DateTime.Now)
                            {
                                row["顯示樣式"] = "未上架";
                                row["樣式顏色"] = "blue";
                                row["顯示樣式2"] = "出價: ";
                                row["用戶名稱"] = "無";
                            }
                            else if (bidPrice == -1 && stopTime < DateTime.Now)
                            {
                                row["顯示樣式"] = "拍賣失敗";
                                row["樣式顏色"] = "purple";
                                row["顯示樣式2"] = "出價: ";
                                row["用戶名稱"] = "無";
                            }
                            else if (bidPrice == -1 || bidPrice == startPrice)
                            {
                                row["顯示樣式"] = "目前無人競標";
                                row["樣式顏色"] = "#ff5e00";
                                row["顯示樣式2"] = "出價: ";
                                row["用戶名稱"] = "無";
                            }
                            else if (sellPrice == bidPrice && isMailSent == true)
                            {
                                row["顯示樣式"] = "拍賣成功";
                                row["樣式顏色"] = "green";
                                row["顯示樣式2"] = "最終價錢: ";
                            }
                            else if ((sellPrice == bidPrice && isMailSent == false))
                            {
                                row["顯示樣式"] = "競標中";
                                row["樣式顏色"] = "red";
                                row["顯示樣式2"] = "競標價: ";
                            }
                            else
                            {
                                // 不符合任何條件，記錄此行來刪除
                                rowsToDelete.Add(row);
                            }
                        }

                        // 刪除不符合條件的行
                        foreach (var row in rowsToDelete)
                        {
                            dt.Rows.Remove(row);
                        }

                        // 確保有資料後再綁定到 ListView
                        if (dt.Rows.Count > 0)
                        {
                            productList.DataSource = dt;
                            productList.DataBind();
                        }
                        else
                        {
                            // 清空 ListView 的資料源
                            productList.DataSource = null;
                            productList.DataBind();
                        }
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