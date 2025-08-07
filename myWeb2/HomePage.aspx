<%@ Page Title="首頁" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="HomePage.aspx.cs" Inherits="myWeb2.HomePage" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        img[class="1"]{color:white;}
        img[class="1"]:hover{
            border: 5px solid #bcd9d9; /* 框線顏色  #eee*/
            width: 140px; height: 140px;
            position: relative;
            z-index: 0;
        }
        a[class="2"]{color:black;}
        a[class="2"]:hover{color:darkcyan; font-size:large}
        .t1{height:28px; border-radius:5px; border: 3px #f5cba7  solid;}
        .t1:focus{height:28px; border-radius:5px; border:3px #eb984e solid;  outline:none}
        .zi_box_1 {
            margin: 2em 0px;
            padding: 1em 1.5em;
            background-color: #fff; /* 底色 */
            border: 4px solid #a4d2ff; /*框線顏色*/
            border-radius: 3em .8em 3em .7em/.9em 2em .8em 3em;
        }
    </style>
    

    <div align="center">
        <asp:Label ID="lblWelcome" runat="server" Text=""></asp:Label><br>
        
        <p align="left" style="font-size:15px" ><b>依分類搜尋：</b>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" align="left" class="t1">
            <asp:ListItem>全</asp:ListItem>
            <asp:ListItem Value="手機">手機/相機/耳機</asp:ListItem>

            <asp:ListItem>家電</asp:ListItem>
            <asp:ListItem Value="電腦">電腦/平板/設備</asp:ListItem>
            <asp:ListItem Value="飾品">飾品/手錶</asp:ListItem>
            <asp:ListItem>服裝</asp:ListItem>
            <asp:ListItem Value="內衣">內衣/襪子/睡衣</asp:ListItem>
            <asp:ListItem Value="鞋子">鞋子/包包</asp:ListItem>
            <asp:ListItem>化妝品</asp:ListItem>
            <asp:ListItem>清潔用品</asp:ListItem>
            <asp:ListItem>日用品</asp:ListItem>
            <asp:ListItem>食品</asp:ListItem>
            <asp:ListItem>廚房用品</asp:ListItem>
            <asp:ListItem>運動</asp:ListItem>
            <asp:ListItem>家具</asp:ListItem>
            <asp:ListItem Value="書籍">書籍/文具</asp:ListItem>
            <asp:ListItem>玩具</asp:ListItem>
            <asp:ListItem>其他</asp:ListItem>

        </asp:DropDownList>
        </p>


        <!-- 顯示資料的GridView 控制項-->
        <!--<asp:GridView ID="GridViewl" runat="server" AutoGenerateColumns="True"
            CssClass="table" GridLines="None" HeaderStyle-BackColor="#3c8dbc"
            HeaderStyle-ForeColor="White" RowStyle-BackColor="#f7f7f7" AlternatingRowStyle-BackColor="#eef2f7"
            BorderColor="#ddd" BorderWidth="1px" CellPadding="8" BorderStyle="Solid">
        </asp:GridView> -->

        <asp:ListView ID="productList" runat="server" GroupItemCount="4" >
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td><br><img src="./nodata.png" style="width:350px;"/></td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>

                <GroupTemplate> <!-- 每個群組的項目包裝起來-->
                    <tr id="itemPlaceholderContainer" runat="server"> 
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate> <!--每一格的樣式-->
                    <td style="width:20px"></td>
                    <td runat="server"> <!--  style="gap:10px; border:15px solid; border-top-right-radius:20px;" cellspacing="10px" border='0'-->
                        <p class="zi_box_1">
                        <table >
                            <tr style="height:10px"></tr>
                            <tr>
                                <td style="text-align: center;"><!-- background-color:slategray;  -->
                                    <a  href="ProductDetails.aspx?productID=<%#:Eval("商品ID")%>" >
                                        <img src="<%#: ResolveUrl(Eval("圖片").ToString()) %>"
                                             class="1" width="130" height="130" style="border-radius:15px 15px; object-fit:cover;" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;">
                                    <a class="2" href="ProductDetails.aspx?productID=<%#:Eval("商品ID")%>" >
                                        <span>
                                            <%#:Eval("商品名稱")%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>現在價錢: </b>NT$<%#:Eval("價錢")%></span><br /></td>
                            </tr>
                            <tr style="height:10px"></tr>
                        </table>
                        </p>
                    </td>
                    <td style="width:20px"></td>
                </ItemTemplate>
                <LayoutTemplate> <!--整個 ListView 的結構，將群組和項目嵌套到此結構中-->
                    <table> <!--商品格子隨畫面縮放-->
                        <tbody>
                            <tr>
                                <td style="width:10px"></td>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                                <td style="width:10px"></td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
    </div>




</asp:Content>