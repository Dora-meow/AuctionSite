<%@ Page Title="我要賣東西" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WebForm3.aspx.cs" Inherits="myWeb2.WebForm3" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .b1{width:80px;height:32px; border:none; border-radius:10px;background-color:#5d6d7e ; color:aliceblue;}
        .b1:hover{width:82px;height:34px; border:none; border-radius:10px;background-color:#2e4053 ; color:aliceblue;}
        .t1{height:28px; border-radius:5px; border: 1px #aeb6bf  solid;}
        .t1:focus{height:28px; border-radius:5px; border:3px #f1c40f solid;  outline:none}
        .t2{height:28px; border-radius:5px; border: 1px #aeb6bf  solid;}
        .t2:focus{height:28px; border-radius:5px; border:3px #3498db  solid;  outline:none}
    </style>

    <!--輸入拍賣時間的樣式-->
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery-ui-timepicker-addon/dist/jquery-ui-timepicker-addon.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/jquery-ui-timepicker-addon/dist/jquery-ui-timepicker-addon.min.css">
    <script>
        $(function () {
            $(".datetimepicker").datetimepicker({
                dateFormat: "yy-mm-dd",
                timeFormat: "HH:mm",
                minDate: 0 // 限制不能選擇過去的日期
            });
        });
    </script>

    <!--主選單-->
    <div align="center">
        <h2>拍賣物品</h2>
        <h4>- 請填寫以下資訊 -</h4>
        <br><br>
        <table style="text-align: center;">
            <colgroup>
                <col style="width:95px;  background-color:#f9e79f; color:#aa5721 ; ">
                <col style="width:270px; background-color:#f9e79f;">
                <col style="background-color:white">
                <col style="width:125px; background-color:#aed6f1">
                <col style="width:180px; background-color:#aed6f1">
            </colgroup>
            <tr>
                <td colspan="2" style="background-color: #f7dc6f; border-top-left-radius:30px; border-top-right-radius:30px"><h3>商品資訊</h3></td>
                <td style="width: 50px;"></td>
                <td colspan="3" style="background-color: #5dade2; border-top-left-radius:30px; border-top-right-radius:30px"><h3>拍賣</h3></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 8px; background-color:white;"></td> <!-- 空白行 -->
                <td style="height: 8px; background-color:white;"></td> <!-- 空白行 -->
                <td colspan="3" style="height: 8px; background-color:white;"></td> <!-- 空白行 -->
            </tr>
            <tr>
                <td colspan="2" style="height: 20px;"></td>
                <td style="height: 20px; background-color:white;"></td>
                <td colspan="2" style="height: 20px;"></td>
                <td rowspan="5" style="width: 60px; background-color:#aed6f1; border-bottom-right-radius:30px;"></td>
            </tr>
            <tr> 
                <td style="text-align: right;"><p>物品名稱：</p></td>
                <td style="text-align: left;"><p><asp:TextBox ID="TextBox1" runat="server" class="t1"></asp:TextBox></p></td>
                <td style="width: 50px;"></td>
                <td style="text-align: right;"><p>起標價：</p></td>
                <td style="text-align: left;"><p><asp:TextBox ID="TextBox3" runat="server" class="t2"></asp:TextBox></p></td>         
            </tr>
            <tr>
                <td style="text-align: right;"><p>分類：</p></td>
                <td style="text-align: left;"><p>
                        <asp:DropDownList ID="DropDownList1" runat="server" class="t1">
                            <asp:ListItem Value="">請選擇項目</asp:ListItem>
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
                </td>
                <td style="width: 50px;"></td>
                <td style="text-align: right;"><p>開始時間：</p></td>
                <td style="text-align: left;"><p>
                        <asp:TextBox ID="txtDateTime" runat="server" CssClass="datetimepicker t2" Height="28px" style=""></asp:TextBox>
                        <!--<asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_Click" />-->
                    </p>
                </td>
            <tr>
                <td style="text-align: right;" valign="top"><p>說明：</p></td>
                <td style="text-align: left;"><p><asp:TextBox TextMode="MultiLine" ID="TextBox2" runat="server" class="t1" style="width:230px; height:56px;" ></asp:TextBox></p></td>
                <td style="width: 50px;"></td>
                <td style="text-align: right;" valign="top"><p> 結束時間：</p></td>
                <td style="text-align: left;" valign="top"><p><asp:TextBox ID="txtDateTime2" runat="server" class="datetimepicker t2" Height="28px"></asp:TextBox></p></td>
            </tr>
            <tr >
                <td style="text-align: right; border-bottom-left-radius:30px;" Height="50px" valign="top"><p>圖片：</p></td>
                <td style="text-align: left; border-bottom-right-radius:30px" Height="50px" valign="top"><p><asp:FileUpload ID="FileUpload1" runat="server" style="width:230px;"/></p></td>
                <td style="width: 50px;" Height="50px"></td>
                <td style="border-bottom-left-radius:30px;"></td>
                <td></td>
            </tr>
        </table>

        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="確認" class="b1" OnClick="InsertButton_Click"/>
        <br /><br />
        
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label> <!-- 放提示 -->
        
    </div>
</asp:Content>