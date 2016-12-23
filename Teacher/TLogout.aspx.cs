using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamOnline.Teacher
{
    public partial class TLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                Session["TeacherName"] = null;
                Response.Redirect("../Login.aspx");
            }
        }
    }
}