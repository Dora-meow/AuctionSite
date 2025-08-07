<%@ Page Title="競標商品紀錄" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WebForm5.aspx.cs" Inherits="myWeb2.WebForm5" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        img[class="1"]{color:white;}
        img[class="1"]:hover{
            border: 5px solid #bcd9d9; /* 框線顏色  #eee*/
            width: 140px; height: 140px;
            position: relative;
            z-index: 0;
        }
        a[class="2"] h4{color:black;}
        a[class="2"] h4:hover{color:darkcyan; font-size:20px;}
        .t1{height:28px; border-radius:5px; border: 3px #f5cba7  solid;}
        .t1:focus{height:28px; border-radius:5px; border:3px #eb984e solid;  outline:none}
        .zi_box_1{
            border-radius: 15px;
            margin: 5px 10px; 
            padding: 20px; 
            position: relative;
            z-index: 0;
        }
        .zi_box_1:before{
            border-radius: 15px;
            background: repeating-linear-gradient(-45deg, #ffc73e, #ffc73e 5px, #ffe8af 0, #ffe8af 10px); /* 條紋顏色 */
            content: '';
            position: absolute;
            top: 0px;
            bottom: 0px;
            left: 0px;
            right: 0px;
            z-index: -2;
        }
        .zi_box_1:after{
            border-radius: 15px;
            background: #fff; /* 背景色 */
            content: '';
            position: absolute;
            top: 10px; 
            bottom: 10px; 
            left: 10px;
            right: 10px;
            z-index: -1;
        }
    </style>
    

    <div align="center">
        <br>
        <h2>商品拍賣紀錄</h2>
        <br><br>
        <asp:ListView ID="productList" runat="server" GroupItemCount="2" >
                <EmptyDataTemplate>
                    <br><img src="./nodata2.png" style="width:280px;"/>
                    <p style="color: gray; text-align: center; font-size:large;">沒有任何紀錄</p>
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
                    <td style="width:17px"></td>
                    <td runat="server"> <!--  style="gap:10px; border:15px solid; border-top-right-radius:20px;" cellspacing="10px" border='0'-->
                        <br>
                        <p class="zi_box_1">
                        
                        <table >
                            <tr style="height:7px"></tr>
                            <tr>
                                <td style="text-align: center;"><!-- background-color:slategray;  -->
                                    <a  href="ProductDetails.aspx?productID=<%#:Eval("商品ID")%>" >
                                        <img src="<%#: ResolveUrl(Eval("圖片").ToString()) %>"
                                             class="1" width="130" height="130" style="border-radius:15px 15px; object-fit:cover;" /></a>
                                </td>
                                <td style="width:15px"></td>
                                <td style="text-align:left;">
                                    <a class="2" href="ProductDetails.aspx?productID=<%#:Eval("商品ID")%>" >
                                         <h4><%#:Eval("商品名稱")%></h4>
                                    </a>
                                    <span><b><%#: Eval("顯示樣式2") %></b>NT$<%#:Eval("價錢")%></span><br />
                                    <span><b>買家: </b><%#:Eval("用戶名稱")%></span><br />
                                </td>
                                <td style="width:20px"></td>
                                <td style="text-align:center;">
                                     <span style="text-align:center; color: <%#: Eval("樣式顏色") %>;">
                                         <%#: Eval("顯示樣式") %>
                                     </span>
                                </td>
                            </tr>
                            <tr style="height:7px"></tr>
                        </table>
                        </p>
                    </td>
                    <td style="width:17px"></td>
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


    <asp:Label ID="lblWelcome" runat="server" Text=""></asp:Label><br>

</asp:Content>

