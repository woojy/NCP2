using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB
{
    public partial class Key : System.Web.UI.Page
    {
        String nowdate = "";
        String encryption = "";

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void keyBtn_Click(object sender, EventArgs e)
        {

            /*날짜DB 넣어줌*/
            string connectionString = "Data Source=10.96.124.87,1433;Initial Catalog=metoo;Persist Security Info=True;User ID=sa;Password=metoo";
            try
            {
                /*오늘날짜 생성*/
                nowdate = DateTime.Now.ToString("yyyyMMdd");
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO checkTime VALUES(@checkTime);", conn)) //idx는 기본키
                    {
                        cmd.Parameters.AddWithValue("@checkTime", nowdate);

                        int row = cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                /*날짜 DB 넣을때 암호도 넣어줌*/
                try
                {
                    /*암호생성*/
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[20];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    var finalString = new String(stringChars);

                    key.Text = finalString;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Encryption VALUES(@Encryption);", conn)) //idx는 기본키
                        {
                            cmd.Parameters.AddWithValue("@Encryption", key.Text);

                            int row = cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                catch (SqlException ex1)
                {
                }
            }
            catch (SqlException ex2)
            {
                /*오늘날짜와 같은 경우*/
                /*암호키 보여줌*/
                SqlConnection conn = new SqlConnection();
                SqlCommand sqlComm = new SqlCommand();
                SqlDataReader sd;
                String query = "select * from Encryption";
                try
                {
                    conn.ConnectionString = connectionString;

                    conn.Open();
                    sqlComm.CommandText = query;
                    sqlComm.Connection = conn;
                    sd = sqlComm.ExecuteReader();

                    while (sd.Read())
                    {
                        encryption = sd["Encryption"].ToString();
                    }
                    conn.Close();

                    dbcheck1.Text = "이미 암호키가 존재합니다.<br>암호키: "+encryption;
                }
                catch (SqlException ex3)
                {
                }
            }

        }
    }
}