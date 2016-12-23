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
    public partial class Subject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminName"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            if (!IsPostBack)
            {
                DalAdmin dal = new DalAdmin();
                SqlDataReader sdr = dal.GetSdrInformation("select * from F_Lession");
                while (sdr.Read())
                {
                    ListBox1.Items.Add(sdr["Lession_Name"].ToString());
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtKCName.Text == "")
            {
                MessageBox.Show("请输入课程名称");
                return;
            }
            else
            {
                Random dom=new Random();
                var random = dom.Next(100);
                string systemTime = DateTime.Now.ToString();
                string strsql = "insert into F_Lession(Lession_ID,Lession_Name,Lession_DataTime) values('"+random+"','" + txtKCName.Text.Trim() + "','" + systemTime + "')";
                BaseClass.BaseClass.OperateData(strsql);
                txtKCName.Text = "";
                Response.Write("<script>alert('添加成功');location='Subject.aspx'</script>");
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedValue.ToString() == "")
            {
                MessageBox.Show("请选择删除项目后删除");
                return;
            }
            else
            {
                string strsql = "delete from F_Lession where Lession_Name='" + ListBox1.SelectedItem.Text + "'";
                BaseClass.BaseClass.OperateData(strsql);
                Response.Write("<script>alert('删除成功');location='Subject.aspx'</script>");
            }
        }
    }
}