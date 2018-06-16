using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Count 테이블에서 투표할때 카운트를 넣는다
//카운트 불러와서 Stu인원과 비교한다 넘게 되면 더이상 투표를 할 수가 없다.
namespace WebApplication2
{
    public partial class user : System.Web.UI.Page
    {
        string getCnt;
        string getNum;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_Click(object sender, EventArgs e)
        {
            string num = Request.Form["num"];
            string connectionString = "Data Source=10.96.124.87,1433;Initial Catalog=metoo;Persist Security Info=True;User ID=sa;Password=metoo";
            StringBuilder sb = new StringBuilder();
            num = num.Substring(0, 2); //3101에서 31만 잘라온다
            string class1 = "Stu" + num.Substring(0, 2);//Student테이블에서 자료를 찾아오기위해 Stu와 num을 합친다.

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT cnt FROM Count WHERE class=@class;", conn)) //idx는 기본키
                    {
                        cmd.Parameters.AddWithValue("@class", num);
                        int row = cmd.ExecuteNonQuery();
                        //Count 테이블에서 num(=class)의 cnt값을 불러온다
                        SqlDataReader rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            getNum = rd["cnt"].ToString();
                        }//end of if
                        else
                        {
                            Label1.Text = "저장된 자료가 없습니다.";
                        }//end of else
                        rd.Close();
                        dbcheck.Text = "연결완료!";
                    }//end of using(SELECT Count Table)

                    //아이디가 ?인 행의 Stu??값을 선택                 
                    //SELECT *
                    // FROM(SELECT * FROM 테이블 ORDER BY ROWNUM DESC)
                    // WHERE ROWNUM = 1
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE id = (SELECT MAX(Id) FROM Student);", conn)) //idx는 기본키
                    {
                        int row = cmd.ExecuteNonQuery();
                        //Count 테이블에서 num(=class)의 cnt값을 불러온다
                        SqlDataReader rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                            //string에 불러온 반 인원수를 저장한다 

                            switch (class1)
                            {
                                case "Stu11":
                                    getCnt = rd["Stu11"].ToString();
                                    break;
                                case "Stu12":
                                    getCnt = rd["Stu12"].ToString();
                                    break;
                                case "Stu13":
                                    getCnt = rd["Stu13"].ToString();
                                    break;
                                case "Stu14":
                                    getCnt = rd["Stu14"].ToString();
                                    break;
                                case "Stu15":
                                    getCnt = rd["Stu15"].ToString();
                                    break;
                                case "Stu16":
                                    getCnt = rd["Stu1"].ToString();
                                    break;

                                case "Stu21":
                                    getCnt = rd["Stu21"].ToString();
                                    break;
                                case "Stu22":
                                    getCnt = rd["Stu22"].ToString();
                                    break;
                                case "Stu23":
                                    getCnt = rd["Stu23"].ToString();
                                    break;
                                case "Stu24":
                                    getCnt = rd["Stu24"].ToString();
                                    break;
                                case "Stu25":
                                    getCnt = rd["Stu25"].ToString();
                                    break;
                                case "Stu26":
                                    getCnt = rd["Stu26"].ToString();
                                    break;

                                case "Stu31":
                                    getCnt = rd["Stu31"].ToString();
                                    break;
                                case "Stu32":
                                    getCnt = rd["Stu32"].ToString();
                                    break;
                                case "Stu33":
                                    getCnt = rd["Stu33"].ToString();
                                    break;
                                case "Stu34":
                                    getCnt = rd["Stu34"].ToString();
                                    break;
                                case "Stu35":
                                    getCnt = rd["Stu35"].ToString();
                                    break;
                                case "Stu36":
                                    getCnt = rd["Stu36"].ToString();
                                    break;
                            }
                        }//end of if
                        else
                        {
                            Label1.Text = "저장된 자료가 없습니다."; //rows가 없으면 해당 메세지를 띄운다
                        }//end of else
                        rd.Close();
                        dbcheck.Text = "연결완료!"; //db가 오류없이 연결되었다는것을 알려줌
                    }//end of using(SELECT Student Table)
                    conn.Close();
                }//end of using
            }//end of try
            catch (SqlException ex)
            {
                dbcheck.Text = ex.Message; //에러 메세지를 띄운다
            }//end of catch

            //불러온 반값 저장한거 비교하기
            // getNum(Count table)과 getCnt(Student table)비교한다
            int getN = Int32.Parse(getNum), getC = Int32.Parse(getCnt);
            if (getN >= getC) //Count table에서 가져온 투표한 인원과 student table에서 가져온 학급인원이같거나 투표한 인원이 더 큰경우 더이상 투표를 할 수 없다.
            {
                Label1.Text = "더이상 투표를 할 수 없습니다.";
            }
            else
            {
                int cnt = getN + 1;
                aa.Text = cnt + "번째학생, 학생수 : " + getC;
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        //카운트 넣기
                        using (SqlCommand cmd = new SqlCommand("UPDATE Count SET cnt=cnt+1 WHERE class = @class;", conn)) //idx는 기본키
                        {
                            cmd.Parameters.AddWithValue("@class", num);
                            int row = cmd.ExecuteNonQuery();
                        }//end of using(update)
                    }
                }
                catch (SqlException ex)
                {
                    dbcheck.Text = "연결실패!";
                }
            }
        }
    }
}