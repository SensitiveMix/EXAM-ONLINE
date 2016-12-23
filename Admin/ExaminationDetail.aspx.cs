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
    public partial class ExaminationDetail : System.Web.UI.Page
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
                id = Convert.ToInt32(Request.QueryString["Eid"]);
                DalAdmin dal = new DalAdmin();
                SqlDataReader sdr = dal.GetSdrInformation("select * from F_Test where ID=" + id);
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
                string str = "update F_Test set TestContent='" + txtsubject.Text.Trim() + "',TestAns1='" + txtAnsA.Text.Trim() + "',TestAns2='" + txtAnsB.Text.Trim() + "',TestAns3='" + txtAnsC.Text.Trim() + "',TestAns4='" + txtAnsD.Text + "',RightAns='" + rblRightAns.SelectedValue.ToString() + "',Pub='" + isfb + "' where ID=" + id;
                BaseClass.BaseClass.OperateData(str);
                Response.Redirect("ExaminationInfo.aspx");
            }
        }
        protected void btnconcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExaminationInfo.aspx");
        }
    }
}