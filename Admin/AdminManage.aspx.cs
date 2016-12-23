using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExamOnline.BaseClass;

namespace ExamOnline.Admin
{
    public partial class AdminManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                lblname.Text = Session["AdminName"].ToString();
                BaseClass.DalAdmin dt = new DalAdmin();

                var sdr = dt.GetSdr(lblname.Text);
                sdr.Read();
                lblwz.Text = sdr["AdminNum"].ToString();
                //int id = Convert.ToInt32(sdr["TeacherCourse"].ToString());
                sdr.Close();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("TLogout.aspx");
        }
    }
}