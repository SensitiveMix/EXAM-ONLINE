using System;
using System.Windows.Forms;
using ExamOnline.BaseClass;

namespace ExamOnline.Teacher
{
    public partial class TExaminationDetail : System.Web.UI.Page
    {
        private static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.QueryString["Eid"]);
                BaseClass.DalTeacher dal = new DalTeacher();
                var sdr = dal.GetSdrInfo(id);
                sdr.Read();
                txtsubject.Text = sdr["TestContent"].ToString();
                txtAnsA.Text = sdr["TestAns1"].ToString();
                txtAnsB.Text = sdr["TestAns2"].ToString();
                txtAnsC.Text = sdr["TestAns3"].ToString();
                txtAnsD.Text = sdr["TestAns4"].ToString();
                rblRightAns.SelectedValue = sdr["RightAns"].ToString();
                string fb = sdr["Pub"].ToString();
                if (fb == "1")
                    cbFB.Checked = true;
                else
                    cbFB.Checked = false;
                lblkm.Text = sdr["TestCourse"].ToString();
                sdr.Close();
            }
        }
        protected void btnconfirm_Click(object sender, EventArgs e)
        {
            if (txtsubject.Text == "" || txtAnsA.Text == "" || txtAnsB.Text == "" || txtAnsC.Text == "" || txtAnsD.Text == "")
            {
                MessageBox.Show("请将信息填写完整");
                return;
            }
            else
            {
                string isfb = "";
                if (cbFB.Checked == true)
                    isfb = "1";
                else
                    isfb = "0";
                string str = "update F_Test set TestContent='" + txtsubject.Text.Trim() + "',TestAns1='" + txtAnsA.Text.Trim() + "',TestAns2='" + txtAnsB.Text.Trim() + "',TestAns3='" + txtAnsC.Text.Trim() + "',TestAns4='" + txtAnsD.Text + "',RightAns='" + rblRightAns.SelectedValue.ToString() + "',pub='" + isfb + "' where ID=" + id;
                BaseClass.BaseClass.OperateData(str);
                Response.Redirect("TExaminationInfo.aspx");
            }
        }
        protected void btnconcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TExaminationInfo.aspx");
        }
    }
}