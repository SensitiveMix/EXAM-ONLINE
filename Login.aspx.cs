using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ExamOnline.BaseClass;

namespace ExamOnline
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void login(object sender, EventArgs e)
        {
            var name = account.Value.Trim();
            var passward = pwd.Value.Trim();
            var dentity = DropDownList.SelectedValue.Trim();
            if (dentity == "请选择登录身份")
            {
                this.Response.Write("<script>alert('请选择身份登录：!');</script>");
            }
            switch (dentity)
            {
                case "学生":
                    Session["StudentName"] = name;
                    GetLogin(BaseClass.BaseClass.CheckStudent(name, passward), "学生");
                    break;

                case "教师":
                    Session["TeacherName"] = name;
                    GetLogin(BaseClass.BaseClass.CheckTeacher(name, passward), "教师");
                    break;

                case "管理员":
                    Session["AdminName"] = name;
                    GetLogin(BaseClass.BaseClass.CheckAdmin(name, passward), "管理员");
                    break;
            }

        }
        void GetLogin(bool value, string Role)
        {
            if (value == true)
            {
                switch (Role)
                {
                    case "学生":
                        MessageBox.Show("Login Success!");
                        Response.Redirect(string.Format("Student/StudentExamNormal.aspx"));
                        break;
                    case "教师":
                        MessageBox.Show("Login Success!");
                        Response.Redirect(string.Format("Teacher/TeacherManage.aspx"));
                        break;

                    case "管理员":
                        MessageBox.Show("Login Success!");
                        Response.Redirect(string.Format("Admin/AdminManage.aspx"));
                        break;
                }
            }
            else
            {
                this.Response.Write("<script>alert('Login Failed,Try again!');</script>");
            }
        }
    }
}