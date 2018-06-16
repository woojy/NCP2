using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB
{
    public partial class Clear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void candidateClear_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=10.96.124.87,1433;Initial Catalog=metoo;Persist Security Info=True;User ID=sa;Password=metoo";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    // 후보자 테이블
                    cmd.CommandText = "DELETE FROM Candidate";
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                db2.Text = "연동 성공";
            }
            catch (Exception e1)
            {
                db1.Text = e1.Message;
            }
        }
        protected void studentClear_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=10.96.124.87,1433;Initial Catalog=metoo;Persist Security Info=True;User ID=sa;Password=metoo";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    // 학생 테이블
                    cmd.CommandText = "DELETE FROM Student";
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                db1.Text = "연동 성공";
            }
            catch (Exception e1)
            {
                db2.Text = e1.Message;
            }
        }

        protected void keyClear_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=10.96.124.87,1433;Initial Catalog=metoo;Persist Security Info=True;User ID=sa;Password=metoo";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    //암호키 테이블
                    cmd.CommandText = "DELETE FROM Encryption";
                    cmd.ExecuteNonQuery();

                    //날짜 테이블
                    cmd.CommandText = "DELETE FROM checkTime";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                db3.Text = "연동 성공";
            }
            catch (Exception e1)
            {
                db3.Text = e1.Message;
            }
        }

        protected void resultClear_Click(object sender, EventArgs e)
        {

        }
        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }
    }
}