<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/Site.Master" CodeBehind="AdminManage.aspx.cs" Inherits="ExamOnline.Admin.AdminManage" %>


<asp:Content runat="server" ContentPlaceHolderID="HeadContent"></asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent"></asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <body style="margin: 0 auto" background="../Image/back_01.gif">
        <form id="form1">
            <div style="text-align: center; margin: 0 0 0 200px">
                <table bgcolor="#ffffff" border="0" bordercolor="#215dc6" cellpadding="0" cellspacing="0"
                    height="278" width="778">
                    <tr>
                        <td height="453" rowspan="2" width="165">&nbsp;<iframe src="left.htm" style="width: 165px; height: 453px" frameborder="0" scrolling="no"></iframe>
                        </td>
                        <td bgcolor="#333300" style="text-align: left; height: 26px;">
                            <span style="font-size: 9pt; color: #ffffff">&nbsp;用户ID：</span><asp:Label ID="lblwz" runat="server" Font-Size="9pt" ForeColor="White"></asp:Label>&nbsp;&nbsp;<span
                                style="color: #ffffff">用户姓名：<asp:Label ID="lblname" runat="server" Font-Size="9pt"></asp:Label></span>&nbsp;
                    <span style="color: #ffffff">用户身份：管理员 </span>
                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="9pt" ForeColor="White"
                                OnClick="LinkButton1_Click" Font-Underline="False">【安全退出】</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td height="155">
                            <iframe name="menu" frameborder="0" scrolling="auto" style="width: 596px; height: 422px" src="StudentInfo.aspx"></iframe>
                            &nbsp;</td>
                    </tr>
                </table>

            </div>
            &nbsp;
        </form>
    </body>
</asp:Content>

