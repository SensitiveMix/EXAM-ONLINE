<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="StartExam.aspx.cs" Inherits="ExamOnline.StartExam" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <style>
        .auto-style1 {
            width: 108px;
            height: 42px;
        }

        .auto-style2 {
            width: 71px;
            height: 42px;
        }

        .auto-style3 {
            width: 74px;
            height: 42px;
        }

        .lb_table {
            margin: 0 0 0 300px;
        }

        .lb_Title {
            margin: 50px 0 0 0;
        }

        .lb_Time {
        }

        .auto-style4 {
            height: 42px;
        }
    </style>

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="stuentNum" runat="server" Text="学号："></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Label ID="NumResult" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:Label ID="StudentName" runat="server" Text="姓名："></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="NameResult" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:Label ID="StudentSex" runat="server" Text="性别："></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="SexResult" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:Button ID="btn_confirm" OnClick="BtnSubmit" runat="server" Text="交卷" />
            </td>
        </tr>
    </table>
    <table class="lb_table">
        <tr>
            <td class="auto-style4">
                <asp:Label CssClass="lb_Title" ID="lb_title" runat="server" Text="Label" Font-Bold="True" Font-Size="Larger" ForeColor="Black"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label CssClass="lb_Time" ID="lb_time" runat="server" Text="Label" Font-Size="Large" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" BorderStyle="None" Direction="LeftToRight" style="margin-left: 0px" Width="900px"></asp:Panel>
            </td>
        </tr>
    </table>


</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
