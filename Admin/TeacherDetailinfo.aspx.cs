using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ExamOnline.BaseClass;

namespace ExamOnline.Admin
{
    public partial class TeacherDetailinfo : System.Web.UI.Page
    {
        private static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                id = Convert.ToInt32(Request.QueryString["Tid"]);
                DalAdmin dal = new DalAdmin();
                var sdr = dal.GetSdrInformation("select * from F_Teacher where TeacherNum=" + id);
                sdr.Read();
                txtTName.Text = sdr["TeacherName"].ToString();
                txtTNum.Text = sdr["TeacherNum"].ToString();
                txtTPwd.Text = sdr["TeacherPwd"].ToString();
                int kmid = Convert.ToInt32(sdr["TeacherCourse"].ToString());
                sdr.Close();
                string KmName = dal.GetKName("select Lession_Name from F_Lession where Lession_ID=" + kmid); ;
                sdr = dal.GetSdrInformation("select * from F_Lession");
                ddlTKm.DataSource = sdr;
                ddlTKm.DataTextField = "Lession_Name";
                ddlTKm.DataValueField = "Lession_ID";
                ddlTKm.DataBind();
                ddlTKm.SelectedValue = kmid.ToString();
            }
        }
        protected void btnSava_Click(object sender, EventArgs e)
        {
            if (txtTName.Text == "" || txtTPwd.Text == "")
            {
                MessageBox.Show("请将信息填写完整");
                return;
            }
            else
            {
                string strsql = "update F_Teacher set TeacherName='" + txtTName.Text.Trim() + "',TeacherPwd='" + txtTPwd.Text.Trim() + "',TeacherCourse='" + ddlTKm.SelectedValue.ToString() + "' where TeacherNum=" + id;
                BaseClass.BaseClass.OperateData(strsql);
                Response.Redirect("TeacherInfo.aspx");
            }
        }
        protected void btnConcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherInfo.aspx");
        }
    }
}