<%@ Page Title="註冊" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WebForm1.aspx.cs" Inherits="myWeb2.WebForm1" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .b1{width:80px;height:32px; border:none; border-radius:10px;background-color:#e67070; color:aliceblue;}
        .b1:hover{width:82px;height:34px; border:none; border-radius:10px;background-color:#cd5757 ; color:aliceblue;}
    </style>

        <h2 align="center">註冊</h2>
        <h4 align="center">- 建立新的帳戶 -</h4>
        <br><br>
               
    <table align="center">
        <tr>
        <td style="text-align: right;">姓名：<br></td>
        <td>
            <asp:TextBox ID="username" class="form-control" runat="server" Height="28px" Width="180"></asp:TextBox> <!-- class="form-control"：設置此控制項的 CSS 類別名稱 -->
        </td>
        </tr>
        <tr>
        <td colspan="2" style="height: 10px;"></td> <!-- 空白行 -->
        </tr>

        <tr>
        <td style="text-align: right;">電話：<br></td>
        <td>
            <asp:TextBox ID="phone" class="form-control" runat="server" Height="28px" Width="180"></asp:TextBox> <!-- class="form-control"：設置此控制項的 CSS 類別名稱 -->
        </td>
        </tr>
        <tr>
        <td colspan="2" style="height: 10px;"></td> <!-- 空白行 -->
        </tr>

        <tr>
        <td style="text-align: right; height: 42px;">Email：<br></td>
        <td style="height: 42px">
            <asp:TextBox ID="email" class="form-control" runat="server" TextMode="email" Height="28px" Width="180"></asp:TextBox> <!-- class="form-control"：設置此控制項的 CSS 類別名稱 -->
        </td>
        </tr>
        <tr>
        <td colspan="2" style="height: 10px;"></td> <!-- 空白行 -->
        </tr>

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
        <tr>
        <td colspan="2" style="height: 10px;"></td> <!-- 空白行 -->
        </tr>

        <tr>
            <td>再次輸入密碼：</td>
            <td>
                <asp:TextBox  id="password_confirm" class="form-control" runat="server" TextMode="Password" Height="28px" Width="180"></asp:TextBox> <!-- class="form-control"：設置此控制項的 CSS 類別名稱 -->
            </td>
        </tr>
    </table>
    <br>
    

        <br />
        <p align="center">
        <asp:Button ID="Button1" runat="server" Text="提交" class="b1" OnClick="InsertButton_Click" />
        <br /><br />
        
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label> </p><!-- 放提示 -->
        
        
        
</asp:Content>
