using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamOnline.Teacher
{
    public partial class TExaminationInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    string strsql = "select * from F_Test where TestCourse='" + Session["KCname"].ToString() + "'";
                    BaseClass.BaseClass.BindDG(gvExaminationInfo, "ID", strsql, "ExaminationInfo");
                }
            }
        }
        public string Getstatus(string zt)
        {
            if (zt == "0")
                return "否";
            else
                return "是";
        }
        protected void btnserch_Click(object sender, EventArgs e)
        {
            string strsql = "select * from F_Test where TestContent like '%" + txtstkey.Text.Trim() + "%'";
            BaseClass.BaseClass.BindDG(gvExaminationInfo, "ID", strsql, "ExaminationInfo");
        }
        protected void gvExaminationInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvExaminationInfo.DataKeys[e.RowIndex].Value;
            string sql = "delete from F_Test where ID=" + id;
            BaseClass.BaseClass.OperateData(sql);
            string strsql = "select * from F_Test where TestCourse='" + Session["KCname"].ToString() + "'";
            BaseClass.BaseClass.BindDG(gvExaminationInfo, "ID", strsql, "ExaminationInfo");
        }
        protected void gvExaminationInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExaminationInfo.PageIndex = e.NewPageIndex;
            string strsql = "select * from F_Test where TestCourse='" + Session["KCname"].ToString() + "'";
            BaseClass.BaseClass.BindDG(gvExaminationInfo, "ID", strsql, "ExaminationInfo");
        }
    }
}