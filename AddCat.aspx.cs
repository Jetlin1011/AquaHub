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
    public partial class AddCat : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string pho = "~/PHO/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(pho));

            string st = "insert into CatTab values('" + TextBox1.Text + "','" + pho + "','" + TextBox3.Text + "','" + TextBox4.Text + "')";
                int i = obj.Fn_Nonquery(st);

            if (i == 1)
            {
                Response.Redirect("admIndex.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("admIndex.aspx");

        }

      
        protected void Button3_Click1(object sender, EventArgs e)
        {
            Response.Redirect("admaddproducts.aspx");

        }
    }
}