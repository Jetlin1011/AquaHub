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
    public partial class admeditproducts : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)

        {
            int pid = Convert.ToInt32(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                string s = "select * from ProTab where p_id="+ pid+" ";
                SqlDataReader dr = obj.Fn_Reader(s);
                if (dr.Read())
                {
                    TextBox1.Text = dr["p_name"].ToString();
                    TextBox3.Text = dr["p_description"].ToString();
                    TextBox5.Text = dr["p_price"].ToString(); 
                    TextBox6.Text = dr["p_stock"].ToString();
                    TextBox4.Text = dr["p_status"].ToString();


                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string pid2 = Request.QueryString["id"];
            string pho = "~/PHO/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(pho));

            string st = "update ProTab set p_name='" + TextBox1.Text + "', p_image='" + pho + "', p_description='" + TextBox3.Text + "',p_price=" + TextBox5.Text + ",p_stock="+TextBox6.Text+", p_status='"+TextBox4.Text+"' where p_id =" + pid2 + "";
            int i = obj.Fn_Nonquery(st);

            if (i == 1)
            {
                int pid = Convert.ToInt32(Request.QueryString["id"]);

                string s = "select * from ProTab where p_id=" + pid + " ";

                SqlDataReader dr = obj.Fn_Reader(s);
                if (dr.Read())
                {
                    string cid1 = dr["cat_id"].ToString();

                    Response.Redirect("admproducts.aspx?cid=" + cid1);

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("admIndex.aspx");

        }
    }
}