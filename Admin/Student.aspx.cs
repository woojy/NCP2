using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB.Admin
{
    public partial class Student : System.Web.UI.Page
    {
        string connectionString = "Data Source=10.96.124.87,1433;Initial Catalog=metoo;Persist Security Info=True;User ID=sa;Password=metoo";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected override void OnPreRender(EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand sqlComm = new SqlCommand();
            SqlDataReader sd;
            String query = "select * from Student";
            try
            {
                conn.ConnectionString = connectionString;

                conn.Open();
                sqlComm.CommandText = query;
                sqlComm.Connection = conn;
                sd = sqlComm.ExecuteReader();

                while (sd.Read())
                {
                    stu11.Text = sd["Stu11"].ToString();
                    stu12.Text = sd["Stu12"].ToString();
                    stu13.Text = sd["Stu13"].ToString();
                    stu14.Text = sd["Stu14"].ToString();
                    stu15.Text = sd["Stu15"].ToString();
                    stu16.Text = sd["Stu16"].ToString();

                    stu21.Text = sd["Stu21"].ToString();
                    stu22.Text = sd["Stu22"].ToString();
                    stu23.Text = sd["Stu23"].ToString();
                    stu24.Text = sd["Stu24"].ToString();
                    stu25.Text = sd["Stu25"].ToString();
                    stu26.Text = sd["Stu26"].ToString();

                    stu31.Text = sd["Stu31"].ToString();
                    stu32.Text = sd["Stu32"].ToString();
                    stu33.Text = sd["Stu33"].ToString();
                    stu34.Text = sd["Stu34"].ToString();
                    stu35.Text = sd["Stu35"].ToString();
                    stu36.Text = sd["Stu36"].ToString();

                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                dbcheck.Text = ex.Message;
            }
        }
        protected void StuBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Student VALUES(@Stu11, @Stu12, @Stu13, @Stu14, @Stu15, @Stu16, " +
                                                                    "@Stu21, @Stu22, @Stu23, @Stu24, @Stu25, @Stu26," +
                                                                    "@Stu31, @Stu32, @Stu33, @Stu34, @Stu35, @Stu36);", conn)) //idx는 기본키
                    {
                        cmd.Parameters.AddWithValue("@Stu11", stu11.Text);
                        cmd.Parameters.AddWithValue("@Stu12", stu12.Text);
                        cmd.Parameters.AddWithValue("@Stu13", stu13.Text);
                        cmd.Parameters.AddWithValue("@Stu14", stu14.Text);
                        cmd.Parameters.AddWithValue("@Stu15", stu15.Text);
                        cmd.Parameters.AddWithValue("@Stu16", stu16.Text);

                        cmd.Parameters.AddWithValue("@Stu21", stu21.Text);
                        cmd.Parameters.AddWithValue("@Stu22", stu22.Text);
                        cmd.Parameters.AddWithValue("@Stu23", stu23.Text);
                        cmd.Parameters.AddWithValue("@Stu24", stu24.Text);
                        cmd.Parameters.AddWithValue("@Stu25", stu25.Text);
                        cmd.Parameters.AddWithValue("@Stu26", stu26.Text);

                        cmd.Parameters.AddWithValue("@Stu31", stu31.Text);
                        cmd.Parameters.AddWithValue("@Stu32", stu32.Text);
                        cmd.Parameters.AddWithValue("@Stu33", stu33.Text);
                        cmd.Parameters.AddWithValue("@Stu34", stu34.Text);
                        cmd.Parameters.AddWithValue("@Stu35", stu35.Text);
                        cmd.Parameters.AddWithValue("@Stu36", stu36.Text);
                        int row = cmd.ExecuteNonQuery();
                        dbcheck.Text = "연결완료!";
                    }
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                dbcheck.Text = ex.Message;
            }
        }
        protected void back_Click(object sender, EventArgs e) 
        {
            try
            {
                Response.Redirect("admin.aspx");
            }
            catch (SqlException ex)
            {
                dbcheck.Text = ex.Message;
            }
        }
    }
}