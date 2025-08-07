using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myWeb2
{
    public partial class WebForm2_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            // 檢查是否存在 Cookie
            if (Request.Cookies["UserInfo"] != null)
            {
                // 設置 Cookie 過期
                HttpCookie userCookie = new HttpCookie("UserInfo");
                userCookie.Expires = DateTime.Now.AddDays(-1); // 設置過期時間為過去
                Response.Cookies.Add(userCookie);
            }

            // 跳轉到登入頁面
            Response.Redirect("WebForm2.aspx");
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            // 跳轉到主頁面
            Response.Redirect("HomePage.aspx");
        }

    }
}