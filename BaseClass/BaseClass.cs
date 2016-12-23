using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ExamOnline.BaseClass
{
    public class BaseClass
    {
        public static string strSqlConn = System.Configuration.ConfigurationManager.AppSettings["DbConnectString"];

        //绑定GridView控件
        public static void BindDG(GridView dg, string id, string sqlstr, string name)
        {
            SqlConnection sqlcon = new SqlConnection(strSqlConn);

            SqlDataAdapter sda = new SqlDataAdapter(sqlstr, sqlcon);

            DataSet dt = new DataSet();

            sda.Fill(dt, name);

            dg.DataSource = dt.Tables[name];
            dg.DataKeyNames = new string[] { id };
            dg.DataBind();
        }

        //建立一个T—SQL的查询方法
        public static void OperateData(string strSql)
        {
            SqlConnection sqlcon = new SqlConnection(strSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand(strSql, sqlcon);

            sqlcmd.ExecuteNonQuery();

            sqlcon.Close();
        }

        public static bool CheckStudent(string studentName, string studentPwd)
        {
            SqlConnection sqlcon = new SqlConnection(strSqlConn);

            sqlcon.Open();

            SqlCommand sqlcom = new SqlCommand("select count(*) from F_Student where StudentName='" + studentName + "' and StudentPwd='" + studentPwd + "' ", sqlcon);

            int count = Convert.ToInt32(sqlcom.ExecuteScalar());

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool CheckTeacher(string teacherName, string teacherPwd)
        {
            using (SqlConnection sqlcon = new SqlConnection(strSqlConn))
            {
                sqlcon.Open();

                SqlCommand sqlcom = new SqlCommand("select count(*) from F_Teacher where TeacherName='" + teacherName + "' and TeacherPwd='" + teacherPwd + "' ", sqlcon);

                int count = Convert.ToInt32(sqlcom.ExecuteScalar());

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool CheckAdmin(string adminName, string adminPwd)
        {
            using (SqlConnection sqlcon = new SqlConnection(strSqlConn))
            {
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand("select count(*) from F_Admin where AdminName='" + adminName + "' and AdminPwd='" + adminPwd + "' ", sqlcon);

                var a = sqlcom.ExecuteNonQuery();

                int count = Convert.ToInt32(sqlcom.ExecuteScalar());

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}