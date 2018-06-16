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

            imgpath1.Text = fileName;

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

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }
    }
}