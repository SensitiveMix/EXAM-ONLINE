using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ExamOnline.Teacher
{
    public partial class TAddExamination : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            lblkmname.Text = Session["KCname"].ToString();
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
                Random dom=new Random();
                var random = dom.Next(100);
                string isfb = "";
                if (cbFB.Checked == true)
                    isfb = "1";
                else
                    isfb = "0";
                string str = "insert into F_Test(ID,TestContent,TestAns1,TestAns2,TestAns3,TestAns4,RightAns,Pub,TestCourse) values('"+random+"','"
                    + txtsubject.Text.Trim() + "','" + txtAnsA.Text.Trim() + "','" + txtAnsB.Text.Trim() + "','" + txtAnsC.Text.Trim() + "','" + txtAnsD.Text.Trim() + "','" 
                    + rblRightAns.SelectedValue.ToString() + "','" + isfb + "','" + Session["KCname"].ToString() + "')";
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