using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ExamOnline.BaseClass;

namespace ExamOnline.Admin
{
    public partial class AddStudentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtNum.Text == "" || txtPwd.Text == "")
            {
                MessageBox.Show("请将信息填写完整");
                return;
            }
            else
            {
                var para = "select count(*) from F_Student where StudentNum='" + txtNum.Text + "'";
                BaseClass.DalTeacher dal = new DalTeacher();

                int i = dal.GetID(para);
                if (i > 0)
                {
                    MessageBox.Show("此学号已经存在");
                    return;
                }
                else
                {
                    Random ran=new Random();

                    var random = ran.Next(10000);
                    var str = "insert into F_Student(ID,StudentNum,StudentName,StudentSex,StudentPwd) values('"+random+"','" +
                              txtNum.Text.Trim() + "','" + txtName.Text.Trim() + "','" + rblSex.SelectedValue.ToString() +
                              "','" + txtPwd.Text.Trim() + "')";
                    if (dal.insertStudentInfo(str))
                    {
                        MessageBox.Show("添加成功");
                        btnConcel_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                }
            }
        }
        protected void btnConcel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtNum.Text = "";
            txtPwd.Text = "";
        }
    }
}