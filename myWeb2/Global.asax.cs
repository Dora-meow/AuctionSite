using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;
using System.Data.OleDb;

using System.Net.Mail;//用gmail
using System.Threading;

/*
using System.Threading.Tasks;//用SendGrid
using SendGrid;
using SendGrid.Helpers.Mail;*/

namespace myWeb2
{
    public class Global : HttpApplication
    {
        private static Timer _emailTimer;
        void Application_Start(object sender, EventArgs e)
        {
            // 應用程式啟動時執行的程式碼
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // 每 10 秒執行一次檢查任務
            _emailTimer = new Timer(CheckAndSendEmails, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        }

        private void CheckAndSendEmails(object state)
        {
            EmailHelper.CheckAndSendEmails();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            // 停止 Timer
            _emailTimer?.Dispose();
        }

    }

    public static class EmailHelper //處理郵件發送
    {
        //private const string ApiKey = "QV21EHB5DBLG96NVJ8YETDQQ"; // 替換成我的 SendGrid API 金鑰
        private static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        /*public static async Task SendEmail(string recipientEmail, string subject, string body)
        {
            var client = new SendGridClient(ApiKey);
            var from = new EmailAddress("your-email@example.com", "Your Name");
            var to = new EmailAddress(recipientEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);

            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                throw new Exception($"Email failed to send. Status Code: {response.StatusCode}");
            }
        }*/
        public static void CheckAndSendEmails()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();

                    // 查詢需要發送的郵件記錄
                    string query = @"
                    SELECT [使用者].[email], [使用者].[姓名], [商品].[商品名稱], [商品].[說明], [商品].[商品ID], [買].[競標價], DateAdd ('d',1,NOW())
                    FROM [賣], [使用者], [商品], [買]
                    WHERE [賣].[停止時間] <= NOW() AND [賣].[價錢]=[買].[競標價] AND [賣].[價錢]<>[賣].[起標價] AND [賣].[商品ID]=[買].[商品ID] AND [買].[使用者ID]=[使用者].[使用者ID] AND [商品].[商品ID]=[賣].[商品ID] AND [買].[是否寄郵件]=0";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable emailsToSend = new DataTable();
                    adapter.Fill(emailsToSend);

                    // 發送郵件
                    foreach (DataRow row in emailsToSend.Rows)
                    {
                        string recipient = row["email"].ToString(); //收件人電子郵件地址
                        string name = row["姓名"].ToString();
                        string productName = row["商品名稱"].ToString();
                        string direction = row["說明"].ToString();
                        string productID = row["商品ID"].ToString();
                        string money = row["競標價"].ToString();

                        string subject = "競標結果"; //郵件標題
                        string body = "親愛的使用者 " + name + " 您好，" + "\n" + "恭喜您競標成功！" + "\n" + "競標的商品：" + productName + "\n" + "商品說明：" + direction + "\n" + "價錢：" + money + "\n\n\n" + "MEOW的拍賣網站敬上"; //郵件正文

                        bool isSent = SendEmail(recipient, subject, body); //發送郵件

                        if (isSent)
                        {
                            // 更新狀態為已發送
                            UpdateEmailStatus(connection, productID, money);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 記錄錯誤（實際應用中應保存到日誌）
                System.Diagnostics.Debug.WriteLine("錯誤：" + ex.Message);
            }
        }

        private static bool SendEmail(string recipient, string subject, string body) //return true 表示成功，false 表示失敗
        {
            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("0506pepe@gmail.com"), // 我的mail
                    Subject = subject,
                    Body = body
                };
                mail.To.Add(recipient);

                //用 SmtpClient 發送郵件
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587) // SMTP 主機
                {
                    Credentials = new System.Net.NetworkCredential("0506pepe@gmail.com", "xwbf gbyd tlsy slam"), // 我的mail和應用程式密碼密码
                    EnableSsl = true // 启用 SSL
                };
                /*SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); //SMTP 主機
                smtpClient.Credentials = new System.Net.NetworkCredential("0506pepe@gmail.com", "a20040506a"); //驗證用戶名與密碼
                smtpClient.Port = 465; // 或 587
                smtpClient.EnableSsl = true; //啟用 SSL*/

                smtpClient.Send(mail); //發送郵件
                return true;
            }
            catch (SmtpException smtpEx)
            {
                System.Diagnostics.Debug.WriteLine($"SMTP錯誤: {smtpEx.Message} | 狀態碼: {smtpEx.StatusCode}");
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("郵件發送失敗: " + ex.Message);
                return false;
            }
        }

        private static void UpdateEmailStatus(OleDbConnection connection, string productID, string money)
        {
            string updateQuery = "UPDATE [買] SET [是否寄郵件] = ? WHERE [商品ID] = ? AND [競標價] = ?";
            using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@status", 1);
                updateCommand.Parameters.AddWithValue("@id", productID);
                updateCommand.Parameters.AddWithValue("@m", money);
                updateCommand.ExecuteNonQuery();
            }
        }
    }

}