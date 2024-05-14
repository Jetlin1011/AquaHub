using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aquahub
{
    public partial class AdmRegister : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select max(userid) from LogTab";
            string regid = obj.Fn_Scalar(s);

            int reg_id = 0;

            if (regid == "")
            {
                reg_id = 1;
            }
            else
            {
                reg_id = Convert.ToInt32(regid) + 1;
            }

            string ins = "insert into AdmTab values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ")";
            int i = obj.Fn_Nonquery(ins);
            if (i != 0)
            {
                string inslog = "insert into LogTab values(" + reg_id + ",'" + TextBox4.Text + "','" + TextBox5.Text + "','admin', 'active')";
                int j = obj.Fn_Nonquery(inslog);
            }

        }
    }
}