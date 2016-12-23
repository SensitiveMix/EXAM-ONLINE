using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExamOnline.BaseClass;

namespace ExamOnline
{
    public partial class StartExam : System.Web.UI.Page
    {
        //记录考题正确答案
        public string Ans = null;

        //记录考题数量
        public int TNum;
        protected void Page_Load(object sender, EventArgs e)
        {

            DalStudent dlt = new DalStudent();

            var dt = dlt.GetStudentId(Session["StudentName"].ToString());

            var dtSex = dlt.GetStudentSex(Session["StudentName"].ToString());

            NumResult.Text = dt.ToString();

            SexResult.Text = dtSex;

            NameResult.Text = Session["StudentName"].ToString();

            lb_title.Text = Session["KM"].ToString().Trim() + "考试试题" + "<br><br><br><br>";

            lb_time.Text = "考试时间为10分钟，每小题两分，考试已经用时：" + "<br><br><br>";

            int i = 1;

            DalStudent dal = new DalStudent();

            var sdr = dal.GetCmd(Session["KM"].ToString()).ExecuteReader();

            //var sdr = dal.GetCmd("数据结构").ExecuteReader();

            while (sdr.Read())
            {
                Literal littxt = new Literal();

                Literal litti = new Literal();

                RadioButtonList cdk = new RadioButtonList();

                cdk.ID = "cdk" + i.ToString();

                cdk.TextAlign = TextAlign.Right;


                cdk.RepeatDirection = RepeatDirection.Vertical;

                littxt.Text = i.ToString() + "、" + Server.HtmlEncode(sdr["TestContent"].ToString()) + "<br><Blockquote>";

                litti.Text = "</Blockquote>";

                //添加选项A
                cdk.Items.Add("A." + Server.HtmlEncode(sdr["TestAns1"].ToString()));

                //添加选项B
                cdk.Items.Add("B." + Server.HtmlEncode(sdr["TestAns2"].ToString()));

                //添加选项C
                cdk.Items.Add("C." + Server.HtmlEncode(sdr["TestAns3"].ToString()));

                //添加选项D
                cdk.Items.Add("D." + Server.HtmlEncode(sdr["TestAns4"].ToString()));

                // cdk.Items.Add(new ListItem("A." + Server.HtmlEncode(sdr["TestAns1"].ToString())));

                cdk.Font.Size = 10;


                for (int j = 1; j <= 4; j++)
                {
                    cdk.Items[j - 1].Value = j.ToString();
                }

                Ans += sdr[6].ToString();

                if (Session["a"] == null)
                {
                    Session["Ans"] = Ans;
                }

                Panel1.Controls.Add(littxt);
                Panel1.Controls.Add(cdk);
                Panel1.Controls.Add(litti);

                i++;
                TNum++;
            }
            sdr.Close();
            Session["a"] = 1;

        }

        public void BtnSubmit(object sender, EventArgs e)
        {
            string msc = "";

            for (int i = 0; i < 10; i++)
            {
                RadioButtonList list = (RadioButtonList)Panel1.FindControl("cdk" + i.ToString());
                if (list != null)
                {
                    if (list.SelectedValue != null)

                        msc += list.SelectedValue.ToString();
                    else
                    {
                        msc += "0";
                    }
                }
            }

            Session["Sans"] = msc;

            //更新数据库

            DalStudent dal = new DalStudent();

            var stuentID = dal.GetStudentId(Session["StudentName"].ToString());

            dal.updateRightAnsTestInfo(Ans, stuentID);

            dal.updateStudentTestInfo(msc, stuentID);

            Response.Redirect("Student/result.aspx?Bint=" + TNum.ToString());
        }

    }




}