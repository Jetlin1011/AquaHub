using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace Aquahub
{
    public partial class accountupdate : System.Web.UI.Page
    {

        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            decimal balance = Convert.ToDecimal(TextBox1.Text);
            string s= "insert into AccTab values("+Convert.ToInt32(Session["uid"])+","+Convert.ToInt32(TextBox2.Text)+","+balance+")";
            int i = obj.Fn_Nonquery(s);
            if (i == 1)
            {
                Response.Redirect("UserHome.aspx");
            }
        }
    }
}