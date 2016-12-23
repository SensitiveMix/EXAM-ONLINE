<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ExamOnline.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录界面</title>
    <style>
        .contact {
            padding-left: 950px;
            padding-right: 0px;
            padding-bottom: 30px;
            margin-top: -75px;
            color: #000066;
            font-family: 'Segoe UI';
        }

        .title {
            width: 300px;
            padding-top: 10px;
            padding-left: 20px;
            color: white;
            font-family: 'Segoe UI';
            font-size: small;
        }

        .dt {
            color: grey;
        }

        .form_login {
            text-align: center;
        }

        .sign {
            padding: 10px 0 0 0;
            text-decoration: none;
        }

        .Images {
            padding: 0 20px 0 320px;
            margin: -40px 0 0 0;
        }

        .label_title {
            font-family: 'Segoe UI';
            font-size: 30px;
            font-style: normal;
            margin: 50px 70px -20px 140px;
        }

        .label_body {
            font-family: 'Segoe UI';
            font-size: 15px;
            font-style: normal;
            margin: 40px 0 0 140px;
        }

        .label_two {
            font-family: 'Segoe UI';
            font-size: 15px;
            font-style: normal;
            margin: 20px 0 0 140px;
        }

        .label_three {
            font-family: 'Segoe UI';
            font-size: 15px;
            font-style: normal;
            margin: 20px 0 0 140px;
        }

        .ddl_login {
            padding: 0 0 0 -80px;
        }

        .lb_dentity {
            margin: 0 0 0 -30px;
        }

        .tbody {
            background-image: url(Images/back_01.gif);
            background-repeat: no-repeat;
            margin-top: 20px;
        }
    </style>
</head>
<body runat="server" class="tbody" background="Images/back_01.gif">
    <div style="height: 50px; width: 100%; margin-top: 20px;">
        <asp:Label CssClass="title" runat="server" Text="titile" Font-Size="40px"><b>在线考试系统</b></asp:Label>
        <%--<asp:Label CssClass="contact" ID="Contact" runat="server" Text="Contact"></asp:Label>--%>
        <embed name="honehoneclock" class="contact" width="160" height="70" align="middle" pluginspage="http://www.macromedia.com/go/getflashplayer" src="http://chabudai.sakura.ne.jp/blogparts/honehoneclock/honehone_clock_tr.swf" type="application/x-shockwave-flash" allowscriptaccess="always" bgcolor="#ffffff" quality="high" wmode="transparent"></object>
    </div>
    <hr class="dt" />
    <div runat="server" style="float: left; display: inline">
        <div class="label_title" style="color: #99ccff;"><b>Examination system&nbsp;&nbsp;!</b></div>
        <p class="label_body">The evaluation of a system&nbsp;, </p>
        <p class="label_two">where we will find their usual work&nbsp;,</p>
        <p class="label_three">happy coding everyday&nbsp;!</p>
        <%--<asp:Images runat="server" CssClass="Images" ImagesUrl="~/Images/QQQ.png" />--%>
    </div>
    <div style="height: 400px; display: inline; margin-left: 10px">
        <form runat="server" class="form_login" style="width: 330px; height: 350px; border: 1px solid #66cc99; margin: 20px 0px 60px 650px;">
            <div style="border-color: gray; border: 1px; height: 15px; font-family: 'Segoe UI'; margin: 20px 0 15px 0">
                <label style="width: 200px; height: 100px;"><b>Login</b></label>
            </div>
            <hr style="border: 0.7px solid #66cc99;" />
            <div style="margin-top: 20px">
                <input runat="server" id="account" style="background-color: whitesmoke; width: 200px; height: 30px; border: 1px solid #66cc99" placeholder="Account" />
            </div>
            <div style="margin-top: 20px">
                <input runat="server" id="pwd" type="password" style="background-color: whitesmoke; width: 200px; height: 30px; border: 1px solid #66cc99" placeholder="Password" />
            </div>
            <div style="margin-top: 20px">
                <asp:DropDownList CssClass="ddl_login" ID="DropDownList" runat="server" AutoPostBack="False">
                    <asp:ListItem>请选择登录身份</asp:ListItem>
                    <asp:ListItem>学生</asp:ListItem>
                    <asp:ListItem>教师</asp:ListItem>
                    <asp:ListItem>管理员</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%--<div style="margin:20px 0 0 0"><a runat="server" style="width:200px;height:30px;background-color:#9999ff;font-family:'Segoe UI';font-size:15px;">Sign In</a> </div>--%>
            <div style="margin: 20px 0 0 0">
                <asp:LinkButton OnClick="login" runat="server" ID="Label_onclick" CssClass="sign" Width="200px" Height="30px" BackColor="#9999ff" ForeColor="#ffffff" Font-Bold="true" Text="Sign In" />
            </div>
        </form>
    </div>
    <fonter>
        <hr/>
        <p align="center">@2016 南京邮电大学通达学院  by Mr.zhu</p>
    </fonter>

</body>

</html>

