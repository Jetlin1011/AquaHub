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
    public partial class admedit : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)

        {
            int catid = Convert.ToInt32(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                string s = "select  * from CatTab where cat_id=" + catid + "";
                SqlDataReader dr = obj.Fn_Reader(s);
                if (dr.Read())
                {
                    TextBox1.Text = dr["cat_name"].ToString();
                    TextBox3.Text = dr["cat_description"].ToString();
                    TextBox4.Text = dr["cat_status"].ToString();

                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string catid = Request.QueryString["id"];
            string pho = "~/PHO/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(pho));

            string st = "update CatTab set cat_name='" + TextBox1.Text + "', cat_image='" + pho + "', cat_description='" + TextBox3.Text + "',cat_status='" + TextBox4.Text + "' where cat_id ="+catid+"";
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
    }
}