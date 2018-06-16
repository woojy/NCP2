using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB
{
    public partial class Index : System.Web.UI.Page
    {
        bool b = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*암호를 확인*/
            SqlConnection conn = new SqlConnection();
            SqlCommand sqlComm = new SqlCommand();
            SqlDataReader sd;
            String query = "select * from Encryption";
            try
            {
                string connectionString = "Data Source=10.96.124.87,1433;Initial Catalog=metoo;Persist Security Info=True;User ID=sa;Password=metoo";
                conn.ConnectionString = connectionString;

                conn.Open();
                sqlComm.CommandText = query;
                sqlComm.Connection = conn;
                sd = sqlComm.ExecuteReader();

                while (sd.Read())
                {
                    if ((start.Text).Equals(sd["Encryption"].ToString()))
                    {
                        Session["id"] = start.Text;//세션처리
                        b = true;
                        break;
                    }
                    else
                    {
                        b = false;
                    }
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                dbcheck.Text = ex.Message;

            }
        }
        protected void startBtn_Click(object sender, EventArgs e)
        {
            if (b==true)
            {
                Response.Redirect("user.aspx");       
            }
            else
            {
                if ((start.Text).Equals("metoo"))
                {
                    Session["id"] = start.Text;//세션처리
                    Response.Redirect("../Admin/Admin.aspx");
                }
                else
                {
                    check.Text = "암호키를 확인해주세요!";
                }
            }
            
        }
    }
}