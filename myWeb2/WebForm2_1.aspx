<%@ Page Title="登出" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WebForm2_1.aspx.cs" Inherits="myWeb2.WebForm2_1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .b1{width:50px;height:28px; border:none; border-radius:10px;background-color:#1e8449; color:aliceblue;}
        .b1:hover{width:55px;height:33px; border:none; border-radius:10px;background-color:#1b7441 ; color:aliceblue;}
        .b2{width:50px;height:28px; border:none; border-radius:10px;background-color:#cb4335; color:aliceblue;}
        .b2:hover{width:55px;height:33px; border:none; border-radius:10px;background-color:#b53e32 ; color:aliceblue;}
    </style>
    <div align="center" style="height:250px">
        <br><br><br>
        <h2>是否登出</h2><br><br>
       
        <asp:Button ID="Button1" runat="server" Text="是" class="b1"  OnClick="LogoutButton_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="否" class="b2"  OnClick="Button_Click"/>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label> <!-- 放提示 -->
        <br /><br />
    </div>
</asp:Content>
