<%@ Page Title="登入" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WebForm2.aspx.cs" Inherits="myWeb2.WebForm2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* 設置背景圖片，確保覆蓋 Site.Master 的*/
        body {
            background: url('./login.png') no-repeat center center fixed; /* 替換為您的背景圖片路徑 */
            background-size: cover;
        }
        .b1{width:80px;height:32px; border:none; border-radius:10px;background-color:#3498db; color:aliceblue;}
        .b1:hover{width:82px;height:34px; border:none; border-radius:10px;background-color:#21618c ; color:aliceblue;}
        .b2{width:72px;height:28px; border:none; border-radius:6px;background-color:#a569bd; color:aliceblue;}
        .b2:hover{width:74px;height:30px; border:none; border-radius:6px;background-color:#8e44ad ; color:aliceblue;}
        .zi_box_1 {
            border: 8px solid #eee; /* 框線顏色 */
            margin: 2em 0px;
            padding: 15px;
            position: relative;
            z-index: 0;
            border-radius:40px;
        }
        .zi_box_1:before {
            border-top: 8px solid #ffc98a; /* 強調色 */
            border-left: 8px solid #bc9678; /* 強調色 */
            content: '';
            display: block;
            position: absolute;
            top: -8px;
            left: -8px;
            width: 60px;
            height: 60px;
            z-index: 1;
            border-radius:40px 0px;
        }
    </style>
    <br><br><br>
    <div style="text-align: center; width:420px; margin: 0 auto;" class="zi_box_1">
        <br><img src="./logo1.png" style="width:150px;"/>
        <h2>登入</h2><br>
        <table align="center">
            <tr>
            <td style="text-align: right;">用戶名稱：<br></td>
            <td>
               <asp:TextBox ID="user" class="form-control" runat="server" Height="28px" Width="180"></asp:TextBox> <!-- class="form-control"：設置此控制項的 CSS 類別名稱 -->
            </td>
            </tr>
            <tr>
            <td colspan="2" style="height: 10px;"></td> <!-- 空白行 -->
            </tr>

            <tr>
            <td style="text-align: right;">密碼：<br></td>
            <td>
                <asp:TextBox TextMode="Password" ID="password" class="form-control" runat="server" Height="28px" Width="180"></asp:TextBox> <!-- class="form-control"：設置此控制項的 CSS 類別名稱 -->
            </td>
            </tr>
        </table>
        
        <br>
        <asp:Button ID="Button1" runat="server" Text="提交" class="b1" OnClick="InsertButton_Click"/>
        <br /><br />
        
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label> <!-- 放提示 -->
        <br /><br />
        還沒有帳號？&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="我要註冊" class="b2" OnClick="ToLoginButton_Click"/>
        <br><br>
    </div>
    <br><br><br><br><br>
</asp:Content>