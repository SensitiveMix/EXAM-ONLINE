using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExamOnline.BaseClass;

namespace ExamOnline.Admin
{
    public partial class TeacherInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                string strsql = "select * from F_Teacher order by ID desc";
                BaseClass.BaseClass.BindDG(gvTeacher, "ID", strsql, "teacher");
            }
        }
        public string GetKmName(int num)
        {
            BaseClass.DalAdmin dal=new DalAdmin();
            string kname = dal.GetKName("select Lession_Name from F_Lession where Lession_ID=" + num);
            return kname;
        }
        protected void gvTeacher_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvTeacher.DataKeys[e.RowIndex].Value;
            string str = "delete from F_Teacher where ID=" + id;
            BaseClass.BaseClass.OperateData(str);
            string strsql = "select * from F_Teacher order by ID desc";
            BaseClass.BaseClass.BindDG(gvTeacher, "ID", strsql, "teacher");
        }
        protected void gvTeacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTeacher.PageIndex = e.NewPageIndex;
            string strsql = "select * from F_Teacher order by ID desc";
            BaseClass.BaseClass.BindDG(gvTeacher, "ID", strsql, "teacher");
        }
    }
}