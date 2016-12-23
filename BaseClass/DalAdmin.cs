using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamOnline.BaseClass
{
    public class DalAdmin
    {
        public static string StrSqlConn = System.Configuration.ConfigurationManager.AppSettings["DbConnectString"];

        public SqlDataReader GetSdr(string AdminName)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand("select * from F_Admin where AdminName='" + AdminName + "'", sqlcon);

            SqlDataReader sdr = sqlcmd.ExecuteReader();

            return sdr;
        }

        public SqlDataReader GetSdrInfo(int id)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand("select * from F_Test where ID='" + id + "'", sqlcon);

            SqlDataReader sdr = sqlcmd.ExecuteReader();

            return sdr;
        }

        public SqlDataReader GetSdrInformation(string strsql)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand(strsql, sqlcon);

            SqlDataReader sdr = sqlcmd.ExecuteReader();

            return sdr;
        }

        public string GetKName(string strsql)
        {
            SqlConnection sqlcon=new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd=new SqlCommand(strsql,sqlcon);

            string Kname = sqlcmd.ExecuteScalar().ToString();

            sqlcon.Close();

            return Kname;
        }
    }
}
