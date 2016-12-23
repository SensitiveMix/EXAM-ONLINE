using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ExamOnline.BaseClass;

namespace ExamOnline.Student
{
    public partial class StudentExamNormal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DalStudent dlt = new DalStudent();

                var dt = dlt.GetStudentId(Session["StudentName"].ToString());

                var dtSex = dlt.GetStudentSex(Session["StudentName"].ToString());

                lblNum.Text = dt.ToString();

                lblName.Text = Session["StudentName"].ToString();
                lblsex.Text = dtSex.ToString();
                Session["name"] = lblName.Text;
                Session["sex"] = lblsex.Text;
                BindDropDownList();
            }
        }
        private void BindDropDownList()
        {
            DalStudent dal = new DalStudent();
            SqlDataReader sdr = dal.GetDataReader("select * from F_Lession");
            ddlKm.DataSource = sdr;
            ddlKm.DataTextField = "Lession_Name";
            ddlKm.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ckbCheck.Checked == true)
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Image1.ImageUrl = "~/Images/kemu_03.gif";
            }
            else
            {
                MessageBox.Show("请接受考试规则");
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            DalStudent dal = new DalStudent();
            string StuID = dal.GetStudentId(Session["StudentName"].ToString()).ToString();//考生的编号
            string StuKC = ddlKm.SelectedItem.Text;//选择的考试科目
            if (dal.GetCMD("select count(*) from F_Score where StudentID='" + StuID + "' and LessionName='" + StuKC + "'"))
            {
                MessageBox.Show("你已经参加过此科目的考试了");
            }
            else
            {

                if (dal.GetCMD("select count(*) from F_Test where TestCourse='" + StuKC + "'"))
                {
                    dal.InsertLessionInfo(StuKC, Session["StudentName"].ToString(), Convert.ToInt32(StuID));
                    Session["KM"] = StuKC;
                    Session["falg"] = 1;
                    Response.Redirect("StartExamNormal.aspx");
                    //Response.Write("<script>window.open('StartExamNormal.aspx','newwindow','status=1,scrollbars=1,resizable=1')</script>");
                    //Response.Write("<script>window.opener=null;window.close();</script>");
                }
                else
                {
                    MessageBox.Show("此科目没有考试题");
                    return;
                }
            }
        }
    }
}