using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExamOnline.BaseClass;

namespace ExamOnline.Student
{
    public partial class StartExamNormal : System.Web.UI.Page
    {
        public string Ans = null;
        public int TNum;
        protected void Page_Load(object sender, EventArgs e)
        {
            DalStudent dlt = new DalStudent();

            var dt = dlt.GetStudentId(Session["StudentName"].ToString());

            var dtSex = dlt.GetStudentSex(Session["StudentName"].ToString());

            lblStuName.Text = Session["StudentName"].ToString();
            lblEndtime.Text = "考试时间为10分钟，每小题2分，考试已用时：";
            lblStuNum.Text = dt.ToString();
            // lblStuName.Text = Session["name"].ToString();
            lblStuSex.Text = dtSex.ToString();
            lblStuKM.Text = "[" + Session["KM"].ToString() + "]" + "考试试题";
            int i = 1;
            var sdr = dlt.GetCmd(Session["KM"].ToString()).ExecuteReader();
            while (sdr.Read())
            {

                Literal littxt = new Literal();
                Literal litti = new Literal();
                RadioButtonList cbk = new RadioButtonList();
                cbk.ID = "cbk" + i.ToString();
                littxt.Text = i.ToString() + "、" + Server.HtmlEncode(sdr["TestContent"].ToString()) + "<br><Blockquote>";
                litti.Text = "</Blockquote>";
                cbk.Items.Add("A. " + Server.HtmlEncode(sdr["TestAns1"].ToString()));
                cbk.Items.Add("B. " + Server.HtmlEncode(sdr["TestAns2"].ToString()));
                cbk.Items.Add("C. " + Server.HtmlEncode(sdr["TestAns3"].ToString()));
                cbk.Items.Add("D. " + Server.HtmlEncode(sdr["TestAns4"].ToString()));
                cbk.Font.Size = 11;
                for (int j = 1; j <= 4; j++)
                {
                    cbk.Items[j - 1].Value = j.ToString();
                }
                Ans += sdr[6].ToString();
                if (Session["a"] == null)
                {
                    Session["Ans"] = Ans;
                }
                Panel1.Controls.Add(littxt);
                Panel1.Controls.Add(cbk);
                Panel1.Controls.Add(litti);
                i++;
                TNum++;
            }
            sdr.Close();
            Session["a"] = 1;
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string msc = "";
            for (int i = 1; i <= TNum; i++)
            {
                RadioButtonList list = (RadioButtonList)Panel1.FindControl("cbk" + i.ToString());
                if (list != null)
                {
                    if (list.SelectedValue.ToString() != "")
                    {

                        msc += list.SelectedValue.ToString();
                    }
                    else
                    {
                        msc += "0";
                    }
                }
            }
            Session["Sans"] = msc;//考生答案
            DalStudent dal = new DalStudent();

            var stuentID = dal.GetStudentId(Session["StudentName"].ToString());

            dal.updateRightAnsTestInfo(Ans, stuentID);

            dal.updateStudentTestInfo(msc, stuentID);
            Response.Redirect("result.aspx?Bint=" + TNum.ToString());
        }
    }
}