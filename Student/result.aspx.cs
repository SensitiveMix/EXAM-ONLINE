using ExamOnline.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamOnline
{
    public partial class result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lb_Time.Text = DateTime.Now.ToString();

            Subjectresult.Text = Session["KM"].ToString();

            DalStudent dlt = new DalStudent();

            var dt = dlt.GetStudentId(Session["StudentName"].ToString());

            NumResult.Text = dt.ToString();

            NameResult.Text = Session["StudentName"].ToString();

            //获取正确答案

            string RightAns = Session["Ans"].ToString();

            //获取考生答案

            string studentAns = Session["Sans"].ToString();

            var j = Convert.ToInt32(Request.QueryString["Bint"]);

            int score = 0;

            for (int i = 0; i < j; i++)
            {
                if (RightAns.Substring(i, 1).Equals(studentAns.Substring(i, 1)))
                {
                    score += 2;
                }
            }

            Scoreresult.Text = score.ToString();

            //更新数据库
            dlt.UpdateFinalScore(score.ToString(),dt.ToString());
        }
    }
}