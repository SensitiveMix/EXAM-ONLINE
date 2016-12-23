using System;
using ExamOnline.BaseClass;

namespace ExamOnline
{
    public partial class StudentExam : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            DalStudent dlt = new DalStudent();

            var dt = dlt.GetStudentId(Session["StudentName"].ToString());

            var dtSex = dlt.GetStudentSex(Session["StudentName"].ToString());

            NumResult.Text = dt.ToString();

            SexResult.Text = dtSex;

            NameResult.Text = Session["StudentName"].ToString();

        }

        public void btn_start(object sender, EventArgs e)
        {
            var LessionName = ddl_Lession.SelectedValue.Trim();

            DalStudent dt = new DalStudent();

            var dtn = dt.GetStudentId(Session["StudentName"].ToString());

            var result = dt.GetStudentLessionInfo(Session["StudentName"].ToString(), LessionName);

            if (result.Equals(true))
            {
                Response.Write("<script>alert('你已经参加本门课程的考试')</script>");
            }
            else
            {
                if (dt.TestIsOrExist(LessionName))
                {


                    Session["KM"] = LessionName;
                    dt.InsertLessionInfo(LessionName, Session["StudentName"].ToString(), dtn);
                    Response.Write("<script>window.location.href='StartExamNormal.aspx'</script>");
                }
                else
                {
                    Response.Write("<script>alert('该科目没有试题')</script>");
                }
            }
        }
    }
}