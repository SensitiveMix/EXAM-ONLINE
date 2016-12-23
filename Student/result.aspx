<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="result.aspx.cs" Inherits="ExamOnline.result" %>


<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <style>
        .tb_Result {
            margin: 0 0 0 400px;
        }

        .bian {
            border: 1px solid #158BB7;
        }

        .ce {
            border-top-width: 1px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 1px;
            border-top-style: none;
            border-right-style: none;
            border-bottom-style: none;
            border-left-style: solid;
            border-top-color: #158BB7;
            border-right-color: #158BB7;
            border-bottom-color: #158BB7;
            border-left-color: #158BB7;
        }

        .fisrt, .fisrt1, .fisrt2, .fisrt3 {
            text-align: center;
        }
        .auto-style1 {
            height: 218px;
        }
    </style>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent"></asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <script>
        function showtime() {
            var now = new Date();
            years = now.getFullYear();
            month = now.getMonth() + 1;
            dates = now.getDate();
            hours = now.getHours();
            Minutes = now.getMinutes();
            Seconds = now.getSeconds();
            if (hours < 10)
                hours = "0" + hours;
            if (Minutes < 10)
                Minutes = "0" + Minutes;
            if (Seconds < 10)
                Seconds = "0" + Seconds;
            var titletext = years + "年" + month + "月" + dates + "日" + hours + ":" + Minutes + ":" + Seconds;
            setTimeout("showtime()", 1000);
            document.getElementById("MainContent_lbldate").innerText = titletext;
        }
    </script>
    <body>
        <table align="center" bgcolor="#ffffff" border="0" cellpadding="0" cellspacing="0"
            width="778" style="height: 582px" style="border: 1px solid white">
            <tr>
                <td bgcolor="#ecf9ff" height="31" style="text-align: right">
                    <asp:Label ID="lbldate" runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp;</td>
            </tr>
            <tr>
                <td height="36">
                    <img height="53" src="../Images/emame_03.gif"
                        width="778" /></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <table align="center" border="1" cellpadding="0" class="bian"
                        height="61" width="500" bordercolor="#158bb7">
                        <tr>
                            <td background="../Images/bg.gif" height="20">
                                <div align="center" class="STYLE2">
                                    <span style="color: #ffffff">考试科目</span>
                                </div>
                            </td>
                            <td background="../Images/bg.gif">
                                <div align="center" class="STYLE2">
                                    <span style="color: #ffffff">考生学号</span>
                                </div>
                            </td>
                            <td background="../Images/bg.gif" style="width: 145px">
                                <div align="center" class="STYLE2">
                                    <span style="color: #ffffff">考生姓名</span>
                                </div>
                            </td>
                            <td background="../Images/bg.gif" style="width: 127px">
                                <div align="center" class="STYLE2">
                                    <span style="color: #ffffff">考试成绩</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="36" style="width: 145px" align="center">
                                <asp:Label ID="Subjectresult" CssClass="fisrt" runat="server" Text="Label"></asp:Label>&nbsp;</td>
                            <td align="center">&nbsp;<asp:Label ID="NumResult" CssClass="fisrt1" runat="server" Text="Label"></asp:Label></td>
                            <td align="center" style="width: 145px">&nbsp;<asp:Label ID="NameResult" CssClass="fisrt2" runat="server" Text="Label"></asp:Label></td>
                            <td align="center" style="width: 127px">&nbsp;<asp:Label ID="Scoreresult" CssClass="fisrt3" runat="server" Font-Bold="False"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
