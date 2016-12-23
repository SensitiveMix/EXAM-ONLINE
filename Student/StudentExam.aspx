<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="StudentExam.aspx.cs" Inherits="ExamOnline.StudentExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 108px;
        }

        .auto-style2 {
            width: 71px;
        }

        .auto-style3 {
            width: 74px;
        }

        .tb2 {
            margin: 100px 0 100px 400px;
            text-align: center;
        }
    </style>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="stuentNum" runat="server" Text="学号："></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:Label ID="NumResult" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:Label ID="StudentName" runat="server" Text="姓名："></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="NameResult" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:Label ID="StudentSex" runat="server" Text="性别："></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="SexResult" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="tb2">
        <tr>
            <td>
                <asp:Label ID="Test_Choose" runat="server" Text="请选择考试科目："></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_Lession" runat="server">
                    <asp:ListItem>数据结构</asp:ListItem>
                    <asp:ListItem>算法分析与设计</asp:ListItem>
                    <asp:ListItem>数据库</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btn_Start" OnClick="btn_start" runat="server" Text="开始考试" />
            </td>
        </tr>
    </table>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

