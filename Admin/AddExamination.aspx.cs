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
    public partial class AddExamination : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                DalAdmin dal = new DalAdmin();
                SqlDataReader sdr = dal.GetSdrInformation("select * from F_Lession");
                this.ddlkm.DataSource = sdr;
                this.ddlkm.DataTextField = "Lession_Name";
                this.ddlkm.DataValueField = "Lession_ID";
                this.ddlkm.DataBind();
                this.ddlkm.SelectedIndex = 0;
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
                Random ran = new Random();
                var random = ran.Next(1000);
                string isfb = "";
                if (cbFB.Checked == true)
                    isfb = "1";
                else
                    isfb = "0";
                string str = "insert into F_Test(ID,TestContent,TestAns1,TestAns2,TestAns3,TestAns4,RightAns,Pub,TestCourse) values('" + random + "','" + txtsubject.Text.Trim() + "','" + txtAnsA.Text.Trim() + "','" + txtAnsB.Text.Trim() + "','" + txtAnsC.Text.Trim() + "','" + txtAnsD.Text.Trim() + "','" + rblRightAns.SelectedValue.ToString() + "','" + isfb + "','" + ddlkm.SelectedItem.Text + "')";
                BaseClass.BaseClass.OperateData(str);
                btnconcel_Click(sender, e);
            }
        }
        protected void btnconcel_Click(object sender, EventArgs e)
        {
            txtsubject.Text = "";
            txtAnsD.Text = "";
            txtAnsC.Text = "";
            txtAnsB.Text = "";
            txtAnsA.Text = "";
        }
    }
}