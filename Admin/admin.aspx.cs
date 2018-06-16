using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["id"].ToString().Equals("metoo"))
                {
                    check.Text = Session["id"].ToString() + "님";
                }
                else
                {
                    Response.Redirect("../User/Index.aspx");
                }
            }
            catch (Exception e1)  
            {
                Response.Redirect("../User/Index.aspx");
            }
        }
    }
}