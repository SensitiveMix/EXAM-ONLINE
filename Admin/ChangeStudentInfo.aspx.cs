using System;
using System.Windows.Forms;
using ExamOnline.BaseClass;

namespace ExamOnline.Admin
{
    public partial class ChangeStudentInfo : System.Web.UI.Page
    {
        private static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.QueryString["stuid"]);
                BaseClass.DalTeacher dal = new DalTeacher();
                var sdr = dal.GetSdrInfo(id);
                sdr.Read();
                txtStuName.Text = sdr["StudentName"].ToString();
                txtStuNum.Text = sdr["StudentNum"].ToString();
                txtStuPwd.Text = sdr["StudentPwd"].ToString();
                rblSex.SelectedValue = sdr["StudentSex"].ToString();
                sdr.Close();
            }
        }
        protected void btnSava_Click(object sender, EventArgs e)
        {
            if (txtStuName.Text.Trim() == "" || txtStuPwd.Text.Trim() == "")
            {
                MessageBox.Show("请将信息填写完整");
                return;
            }
            else
            {
                string str = "update F_Student set StudentName='" + txtStuName.Text.Trim() + "',StudentPwd='" + txtStuPwd.Text.Trim() + "',StudentSex='" + rblSex.SelectedItem.Text + "' where StudentNum=" + id;
                BaseClass.BaseClass.OperateData(str);
                Response.Redirect("StudentInfo.aspx");
            }
        }
        protected void btnConcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentInfo.aspx");
        }
    }
}