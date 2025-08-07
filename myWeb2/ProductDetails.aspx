<%@ Page Title="商品資訊" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProductDetails.aspx.cs" Inherits="myWeb2.ProductDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .b1{width:100px;height:35px; border:none; border-radius:10px;background-color:#206af5; color:aliceblue;}
        .b1:hover{width:103px;height:37px; border:none; border-radius:10px;background-color:#cd5757 ; color:aliceblue;}
        .b3{width:80px;height:32px; border:none; border-radius:10px;background-color:#5d6d7e ; color:aliceblue;}
        .b3:hover{width:82px;height:34px; border:none; border-radius:10px;background-color:#2e4053 ; color:aliceblue;}
        .myp{border-radius:15px 15px; background-color:aquamarine; padding: 8px 10px;}/*padding:上下 左右*/
        .myspan{border-radius:15px 15px; background-color:aquamarine; padding: 8px 10px;}/*padding:上下 左右*/
    </style>
    <div align="center">
        <h2>商品資訊</h2><br>
        <asp:FormView ID="FormView1" runat="server">
            <ItemTemplate>
                <div>
                    <h3> &nbsp;&nbsp;<%#:Eval("商品名稱") %></h3>
                </div>
                <br />
                <table>
                    <tr>
                        <td>
                            <img src="<%#: ResolveUrl(Eval("圖片").ToString()) %>"  style="border-radius:15px 15px; height:400px;" alt="<%#:Eval("商品名稱") %>"/>
                        </td>
                        <td style="width:40px"></td>  
                        <td style="vertical-align: top; text-align:left;">
                            <br /><br />
                            <span class="myspan" style="background-color:#d4a2f1; color:#6a3d6f;"><b>分類：</b>&nbsp;<%#: Eval("分類") %></span><br /><br />
                            <p class="myp" style="background-color:#f5abab; color:#6f3d3d;"><b>產品說明：</b><br /><%#:Eval("說明") %></p><p style="height:0.1px"></p>
                            <span class="myspan" style="background-color:#f0e996; color:#6f6e3d;"><b>目前出價：</b>&nbsp;NT$<%#:Eval("價錢")%></span><br /><br />
                            <p class="myp" style="background-color:#96d7f0; color:#305e61;"><b>拍賣時間：<br /></b>&nbsp;<%#:Eval("開始時間") %>&nbsp;~&nbsp;<%#:Eval("停止時間") %></p><p style="height:0.1px"></p>
                            <span class="myspan" style="background-color:#96f099; color:#345328;"><b>賣家：</b>&nbsp;<%#:Eval("用戶名稱") %></span><br /></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
        
        <br><br>
        <asp:Button ID="Button1" runat="server" Text="我要下標 !" class="b1" OnClick="Buy"/>
        <br><br><br>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><!-- 放提示 -->
        <asp:Button ID="Button2" runat="server" Text="回首頁" class="b3" OnClick="Button_Click"/>
        <br /><br />
    </div>
</asp:Content>
