using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ExamOnline.Teacher
{
    public partial class TeacherChangePwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
        }
        protected void btnchange_Click(object sender, EventArgs e)
        {
            if (txtNewPwd.Text == "" || txtNewPwdA.Text == "" || txtOldPwd.Text == "")
            {
                MessageBox.Show("请将信息填写完整");
                return;
            }
            else
            {
                if (BaseClass.BaseClass.CheckTeacher(Session["TeacherName"].ToString(), txtOldPwd.Text.Trim()))
                {
                    if (txtNewPwd.Text.Trim() != txtNewPwdA.Text.Trim())
                    {
                        MessageBox.Show("两次密码不一致");
                        return;
                    }
                    else
                    {
                        string strsql = "update F_Teacher set TeacherPwd='" + txtNewPwdA.Text.Trim() + "' where TeacherName='" + Session["TeacherName"].ToString() + "'";
                        BaseClass.BaseClass.OperateData(strsql);
                        MessageBox.Show("密码修改成功");
                        txtNewPwd.Text = "";
                        txtNewPwdA.Text = "";
                        txtOldPwd.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("旧密码输入错误");
                    return;
                }
            }
        }
    }
}