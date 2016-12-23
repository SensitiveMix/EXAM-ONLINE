using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ExamOnline.BaseClass;

namespace ExamOnline.Admin
{
    public partial class AddTeacherInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                BaseClass.DalAdmin dal = new DalAdmin();
                var sdr = dal.GetSdrInformation("select * from F_Lession");
                ddlTeacherKm.DataSource = sdr;
                ddlTeacherKm.DataTextField = "Lession_Name";
                ddlTeacherKm.DataValueField = "Lession_ID";
                ddlTeacherKm.DataBind();
                ddlTeacherKm.SelectedIndex = 0;
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTeacherName.Text == "" || txtTeacherNum.Text == "" || txtTeacherPwd.Text == "")
            {
                MessageBox.Show("请将信息填写完整");
                return;
            }
            else
            {
                var para = "select count(*) from F_Teacher where TeacherNum='" + txtTeacherNum.Text.Trim() + "'";
                BaseClass.DalTeacher dal = new DalTeacher();

                int t = dal.GetID(para);
                if (t > 0)
                {
                    MessageBox.Show("此教师编号已经存在");
                    return;
                }
                else
                {
                    Random ran = new Random();

                    var random = ran.Next(10000);
                    string str = "insert into F_Teacher(ID,TeacherNum,TeacherName,TeacherPwd,TeacherCourse) values('" + random + "','" + txtTeacherNum.Text.Trim() + "','" + txtTeacherName.Text.Trim() + "','" + txtTeacherPwd.Text.Trim() + "','" + ddlTeacherKm.SelectedValue.ToString() + "')";
                    BaseClass.BaseClass.OperateData(str);
                    MessageBox.Show("教师信息添加成功");
                    btnconcel_Click(sender, e);
                }
            }
        }
        protected void btnconcel_Click(object sender, EventArgs e)
        {
            txtTeacherPwd.Text = "";
            txtTeacherNum.Text = "";
            txtTeacherName.Text = "";
        }
    }
}