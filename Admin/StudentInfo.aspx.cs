using System;
using System.Web.UI.WebControls;

namespace ExamOnline.Admin
{
    public partial class StudentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                string strsql = "select * from F_Student order by StudentNum desc";
                BaseClass.BaseClass.BindDG(gvStuInfo, "ID", strsql, "stuinfo");
            }
        }
        protected void btnserch_Click(object sender, EventArgs e)
        {
            if (txtKey.Text == "")
            {
                string strsql = "select * from F_Student order by StudentNum desc";
                BaseClass.BaseClass.BindDG(gvStuInfo, "ID", strsql, "stuinfo");
            }
            else
            {
                string stype = ddlType.SelectedItem.Text;
                string strsql = "";
                switch (stype)
                {
                    case "学号":
                        strsql = "select * from F_Student where StudentNum like '%" + txtKey.Text.Trim() + "%'";
                        BaseClass.BaseClass.BindDG(gvStuInfo, "ID", strsql, "stuinfo"); ;
                        break;
                    case "姓名":
                        strsql = "select * from F_Student where StudentName like '%" + txtKey.Text.Trim() + "%'";
                        BaseClass.BaseClass.BindDG(gvStuInfo, "ID", strsql, "stuinfo");
                        break;
                }
            }
        }
        protected void gvStuInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvStuInfo.DataKeys[e.RowIndex].Value;
            string str = "delete from F_Student where StudentNum=" + id;
            BaseClass.BaseClass.OperateData(str);
            string strsql = "select * from F_Student order by StudentNum desc";
            BaseClass.BaseClass.BindDG(gvStuInfo, "ID", strsql, "stuinfo");
        }
        protected void gvStuInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStuInfo.PageIndex = e.NewPageIndex;
            string strsql = "select * from F_Student order by ID desc";
            BaseClass.BaseClass.BindDG(gvStuInfo, "ID", strsql, "stuinfo");
        }
    }
}