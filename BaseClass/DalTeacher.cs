using System;
using System.Data.SqlClient;

namespace ExamOnline.BaseClass
{
    public class DalTeacher
    {
        public static string StrSqlConn = System.Configuration.ConfigurationManager.AppSettings["DbConnectString"];

        public SqlDataReader GetSdr(string TeacherName)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand("select * from F_Teacher where TeacherName='" + TeacherName + "'", sqlcon);

            SqlDataReader sdr = sqlcmd.ExecuteReader();

            return sdr;
        }



        public SqlDataReader GetSdrInfo(int id)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand("select * from F_Student where StudentNum='" + id + "'", sqlcon);

            SqlDataReader sdr = sqlcmd.ExecuteReader();

            return sdr;
        }

        public int GetID(string strsql)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand(strsql, sqlcon);

            int resultId = Convert.ToInt32(sqlcmd.ExecuteScalar().ToString());

            return resultId;
        }

        public bool insertStudentInfo(string strsql)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand(strsql, sqlcon);

            if(sqlcmd.ExecuteNonQuery()>0)
                return true;
            return false;
        }
    }
}