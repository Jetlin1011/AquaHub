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
    public partial class login : System.Web.UI.Page
    {
        ConnectionClass ob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select count(userid) from LogTab where username = '" + TextBox1.Text + "' and password = '" + TextBox2.Text + "'";
            string cid = ob.Fn_Scalar(s);
            int c_id = Convert.ToInt32(cid);
            if (c_id == 1)
            {
                string str= "select userid from LogTab where username='" + TextBox1.Text + "' and password = '" + TextBox2.Text + "'";
                string uid = ob.Fn_Scalar(str);
                Session["uid"] = uid;
                int regid = Convert.ToInt32(uid);
                string str1 = "select logtype from LogTab where userid="+regid+"";
                string logtype = ob.Fn_Scalar(str1);
                if (logtype == "admin")
                {
                    Response.Redirect("admIndex.aspx");
                }

                else if (logtype == "user")
                {
                    Response.Redirect("UserHome.aspx");
                }
                else
                {
                    Console.WriteLine("invalid login");
                }
            }

        }
    }
}