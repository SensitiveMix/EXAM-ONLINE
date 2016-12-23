using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExamOnline.BaseClass;

namespace ExamOnline.Teacher
{
    public partial class TeacherManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                lblname.Text = Session["TeacherName"].ToString();
                BaseClass.DalTeacher dt = new DalTeacher();

                var sdr = dt.GetSdr(lblname.Text);
                sdr.Read();
                lblwz.Text = sdr["TeacherNum"].ToString();
                //int id = Convert.ToInt32(sdr["TeacherCourse"].ToString());
                lblkc.Text = sdr["TeacherCourse"].ToString();
                sdr.Close();               
                Session["KCname"] = lblkc.Text;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("TLogout.aspx");
        }
    }
}