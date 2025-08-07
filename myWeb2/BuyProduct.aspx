<%@ Page Title="出價" Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="BuyProduct.aspx.cs" Inherits="myWeb2.BuyProduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .b1{width:55px;height:28px; border:none; border-radius:10px;background-color:#6a92da; color:aliceblue;}
        .b1:hover{width:60px;height:33px; border:none; border-radius:10px;background-color:#5b7ebb ; color:aliceblue;}
        .b2{width:55px;height:28px; border:none; border-radius:10px;background-color:#ea7272; color:aliceblue;}
        .b2:hover{width:60px;height:33px; border:none; border-radius:10px;background-color:#da6a6a ; color:aliceblue;}
        .b3{width:80px;height:32px; border:none; border-radius:10px;background-color:#5d6d7e ; color:aliceblue;}
        .b3:hover{width:82px;height:34px; border:none; border-radius:10px;background-color:#2e4053 ; color:aliceblue;}
        </style>
    <div align="center">
        <h2>出價</h2><br><br><br>
        <table align="center">
            <tr>
            <td style="text-align: right;">價錢：</td>
            <td>
                <asp:TextBox ID="money" class="form-control" runat="server" Height="28px" Width="180"></asp:TextBox> <!-- class="form-control"：設置此控制項的 CSS 類別名稱 -->
            </td>
            </tr>
        </table>
        
        <br><br>
        <asp:Button ID="Button1" runat="server" Text="確定" class="b1" OnClick="InsertButton_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="取消" class="b2" OnClick="CancelButton_Click"/>
        <br /><br /><br />
        
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label> <!-- 放提示 -->
        <br><br>
        <asp:Button ID="Button2" runat="server" Text="回上一頁" class="b3" OnClick="CancelButton_Click"/>
        <br /><br />
      
    </div>
</asp:Content>
