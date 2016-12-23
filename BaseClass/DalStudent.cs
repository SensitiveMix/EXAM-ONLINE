using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamOnline.BaseClass
{
    public class DalStudent
    {
        public static string StrSqlConn = System.Configuration.ConfigurationManager.AppSettings["DbConnectString"];

        public int GetStudentId(string name)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcom = new SqlCommand("select StudentNum from F_Student where StudentName='" + name + "'", sqlcon);

            int id = Convert.ToInt32(sqlcom.ExecuteScalar());

            return id;
        }

        public SqlCommand GetCmd(string course)
        {

            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcom = new SqlCommand("select top 3 * from F_Test where TestCourse='" + course + "' order by newid()", sqlcon);

            return sqlcom;
        }


        //update

        public void updateRightAnsTestInfo(string Ans, int StudnetID)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand("update F_Score set RightAns1='" + Ans + "' where StudentID='" + StudnetID + "' ", sqlcon);

            sqlcmd.ExecuteNonQuery();

            sqlcon.Close();
        }

        public void updateStudentTestInfo(string msc, int StuentID)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand("update F_Score set StudentAns='" + msc + "' where StudentID='" + StuentID + "'", sqlcon);

            sqlcmd.ExecuteNonQuery();

            sqlcon.Close();
        }
        public string GetStudentSex(string name)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcom = new SqlCommand("select StudentSex from F_Student where StudentName='" + name + "'", sqlcon);

            return sqlcom.ExecuteScalar().ToString();
        }

        public bool GetStudentLessionInfo(string studentName, string lessionName)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcom = new SqlCommand("select count(*) from F_Score where LessionName='" + lessionName + "' and StudentName='" + studentName + "'", sqlcon);



            int count = Convert.ToInt32(sqlcom.ExecuteScalar());

            sqlcon.Close();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateFinalScore(string score, string studentID)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand("update F_Score set Score='" + score + "' where StudentID='" + studentID + "'", sqlcon);

            sqlcmd.ExecuteNonQuery();

            sqlcon.Close();
        }

        public bool InsertLessionInfo(string LessionName, string studentName, int studentID)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            Random a = new Random();
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand("insert into F_Score(StudentName,LessionName,StudentID,ID) values('" + studentName + "','" + LessionName + "','" + studentID + "','" + a.Next(100) + "')", sqlcon);

            // sqlcmd.ExecuteNonQuery();

            int count = Convert.ToInt32(sqlcmd.ExecuteScalar());

            sqlcon.Close();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public SqlDataReader GetDataReader(string strsql)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand(strsql, sqlcon);

            var result = sqlcmd.ExecuteReader();

            return result;
        }

        public bool TestIsOrExist(string lessionName)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand("select count(*) from F_Test where TestCourse ='" + lessionName + "' ", sqlcon);

            int count = Convert.ToInt32(sqlcmd.ExecuteScalar());

            sqlcon.Close();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetCMD(string strsql)
        {
            SqlConnection sqlcon = new SqlConnection(StrSqlConn);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand(strsql, sqlcon);

            var result = Convert.ToInt32(sqlcmd.ExecuteScalar());

            if (result > 0)
                return true;
            return false;
        }
    }
}