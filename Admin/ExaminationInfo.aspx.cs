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
    public partial class ExaminationInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                string strsql = "select * from F_Test order by ID desc";
                BaseClass.BaseClass.BindDG(gvExaminationInfo, "ID", strsql, "ExaminationInfo");
                DalAdmin dal = new DalAdmin();
                var sdr = dal.GetSdrInformation("select * from F_Lession");
                this.ddlEkm.DataSource = sdr;
                this.ddlEkm.DataTextField = "Lession_Name";
                this.ddlEkm.DataValueField = "Lession_ID";
                this.ddlEkm.DataBind();
                this.ddlEkm.SelectedIndex = 0;
            }
        }
        public string Getstatus(string zt)
        {
            if (zt == "0")
                return "否";
            else
                return "是";
        }
        protected void btnSerch_Click(object sender, EventArgs e)
        {
            string strsql = "select * from F_Test where TestCourse='" + ddlEkm.SelectedItem.Text + "'";
            BaseClass.BaseClass.BindDG(gvExaminationInfo, "ID", strsql, "Result");
            lbltype.Text = ddlEkm.SelectedItem.Text;
        }
        protected void gvExaminationInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvExaminationInfo.DataKeys[e.RowIndex].Value;
            string sql = "delete from F_Test where ID=" + id;
            BaseClass.BaseClass.OperateData(sql);
            string strsql = "select * from F_Test order by ID desc";
            BaseClass.BaseClass.BindDG(gvExaminationInfo, "ID", strsql, "ExaminationInfo");
        }
        protected void gvExaminationInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExaminationInfo.PageIndex = e.NewPageIndex;
            string strsql = "select * from F_Test order by ID desc";
            BaseClass.BaseClass.BindDG(gvExaminationInfo, "ID", strsql, "ExaminationInfo");
        }
    }
}