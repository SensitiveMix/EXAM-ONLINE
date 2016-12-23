using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamOnline.Admin
{
    public partial class ExaminationResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                string strsql = "select * from F_Score order by ID desc";
                BaseClass.BaseClass.BindDG(gvExaminationresult, "ID", strsql, "result");
            }
        }
        protected void gvExaminationInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvExaminationresult.DataKeys[e.RowIndex].Value;
            string strsql = "delete from F_Score where ID=" + id;
            BaseClass.BaseClass.OperateData(strsql);
            string strsql1 = "select * from F_Score order by ID desc";
            BaseClass.BaseClass.BindDG(gvExaminationresult, "ID", strsql1, "result");
        }
        protected void gvExaminationresult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExaminationresult.PageIndex = e.NewPageIndex;
            string strsql = "select * from F_Score order by ID desc";
            BaseClass.BaseClass.BindDG(gvExaminationresult, "ID", strsql, "result");
        }
    }
}