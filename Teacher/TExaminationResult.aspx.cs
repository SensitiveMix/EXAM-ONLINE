using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamOnline.Teacher
{
    public partial class TExaminationResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeacherName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
        }
        protected void btnserch_Click(object sender, EventArgs e)
        {
            string type = ddltype.SelectedItem.Text;
            if (type == "学号")
            {
                string resultstr = "select * from F_Score where StudentID like '%" + txtkey.Text.Trim() + "%' and LessionName='" + Session["KCname"].ToString() + "'";
                BaseClass.BaseClass.BindDG(gvExaminationresult, "ID", resultstr, "result");
                Session["num"] = "学号";
            }
            if (type == "姓名")
            {
                string resultstr = "select * from F_Score where StudentName like '%" + txtkey.Text.Trim() + "%' and LessionName='" + Session["KCname"].ToString() + "'";
                BaseClass.BaseClass.BindDG(gvExaminationresult, "ID", resultstr, "result");
                Session["num"] = "姓名";
            }
        }
        protected void gvExaminationInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvExaminationresult.DataKeys[e.RowIndex].Value;
            string strsql = "delete from F_Score where ID=" + id;
            BaseClass.BaseClass.OperateData(strsql);
            if (Session["num"].ToString() == "学号")
            {
                string resultstr = "select * from F_Score where StudentID like '%" + txtkey.Text.Trim() + "%' and LessionName='" + Session["KCname"].ToString() + "'";
                BaseClass.BaseClass.BindDG(gvExaminationresult, "ID", resultstr, "result");
            }
            else
            {
                string resultstr = "select * from F_Score where StudentName like '%" + txtkey.Text.Trim() + "%' and LessionName='" + Session["KCname"].ToString() + "'";
                BaseClass.BaseClass.BindDG(gvExaminationresult, "ID", resultstr, "result");
            }
        }
        protected void gvExaminationresult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Session["num"].ToString() == "学号")
            {
                gvExaminationresult.PageIndex = e.NewPageIndex;
                string resultstr = "select * from F_Score where StudentID like '%" + txtkey.Text.Trim() + "%' and LessionName='" + Session["KCname"].ToString() + "'";
                BaseClass.BaseClass.BindDG(gvExaminationresult, "ID", resultstr, "result");
            }
            else
            {
                gvExaminationresult.PageIndex = e.NewPageIndex;
                string resultstr = "select * from F_Score where StudentName like '%" + txtkey.Text.Trim() + "%' and LessionName='" + Session["KCname"].ToString() + "'";
                BaseClass.BaseClass.BindDG(gvExaminationresult, "ID", resultstr, "result");
            }
        }
    }
}