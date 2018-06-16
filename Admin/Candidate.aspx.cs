using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB
{
    public partial class Candidate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand sqlComm = new SqlCommand();
            SqlDataReader sd;
            string connectionString = "Data Source=10.96.124.87,1433;Initial Catalog=metoo;Persist Security Info=True;User ID=sa;Password=metoo";
            String query = "select * from Candidate";
            try
            {
                conn.ConnectionString = connectionString;

                conn.Open();

                sqlComm.CommandText = query;
                sqlComm.Connection = conn;
                sd = sqlComm.ExecuteReader();

                List<string> name = new List<string>();
                List<string> imageName = new List<string>();
                List<string> major = new List<string>();
                List<string> commitment = new List<string>();

                while (sd.Read())
                {
                    name.Add(sd["name"].ToString());
                    imageName.Add(sd["imageName"].ToString());
                    major.Add(sd["major"].ToString());
                    commitment.Add(sd["commitment"].ToString());
                }

                if (name.Count > 0)
                {
                    Label[] n = new Label[name.Count];
                    Image[] im = new Image[name.Count];
                    Label[] m = new Label[name.Count];
                    Label[] com = new Label[name.Count];

                    for (int i = 0; i < name.Count; i++)
                    {

                        //후보이미지
                        im[i] = new Image();
                        im[i].ImageUrl = "\\Models\\images\\" + imageName[i];
                        //후보자 명
                        n[i] = new Label();
                        n[i].Text = name[i] + "<br>";
                        //후보전공
                        m[i] = new Label();
                        m[i].Text = major[i] + "<br>";
                        //후보 공약
                        com[i] = new Label();
                        com[i].Text = commitment[i] + "<br>";

                        info.Controls.Add(im[i]);
                        info.Controls.Add(n[i]);
                        info.Controls.Add(m[i]);
                        info.Controls.Add(com[i]);
                    }
                }
                conn.Close();


                dbcheck.Text = "연동 성공";
            }
            catch (SqlException ex3)
            {
                dbcheck.Text = ex3.Message;
            }
        }
        void SaveFile(HttpPostedFile file)
        {
            string savePath = "C:\\Users\\Mirim\\source\\repos\\DB\\DB\\Models\\images\\";
            string fileName = img1.FileName;
            string pathToCheck = savePath + fileName;
            string tempfileName = "";

            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 1;
                while (System.IO.File.Exists(pathToCheck))
                {
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }
                fileName = tempfileName;
            }
            savePath += fileName;
            img1.SaveAs(savePath);

            string connectionString = "Data Source=10.96.124.87,1433;Initial Catalog=metoo;Persist Security Info=True;User ID=sa;Password=metoo";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Candidate VALUES(@name,@imageName,@major,@commitment);", conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name1.Text);
                        cmd.Parameters.AddWithValue("@imageName", fileName);
                        cmd.Parameters.AddWithValue("@major", major1.Text);
                        cmd.Parameters.AddWithValue("@commitment", commitment1.Text);

                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();

                    //이미지 띄우기
                    realimg.ImageUrl = "\\Models\\images\\" + fileName;
                    dbcheck.Text = "연결완료!";
                    imgcheck.Text = "파일 업로드에 성공하셨습니다.";
                }
                name1.Text = string.Empty;
                major1.SelectedIndex = 0;
                commitment1.Text = string.Empty;
            }
            catch (SqlException ex)
            {
                dbcheck.Text = ex.Message;
            }

        }
        protected void candidateBtn_Click(object sender, EventArgs e)
        {
            if (img1.HasFile)
            {
                SaveFile(img1.PostedFile);
            }
            else
            {
                imgcheck.Text = "업로드 하지 못했습니다.";
            }
        }
    }
}