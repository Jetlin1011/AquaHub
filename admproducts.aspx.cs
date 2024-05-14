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
    public partial class admproducts : System.Web.UI.Page
    {
            ConnectionClass ob = new ConnectionClass();
            protected void Page_Load(object sender, EventArgs e)
            {
                grid_bind();
            }
            public void grid_bind()
            {
            int cid = Convert.ToInt32(Request.QueryString["cid"]);

                string str = "select ProTab.p_id, ProTab.p_name, ProTab.p_image, ProTab.p_description, ProTab.p_price, ProTab.p_stock, ProTab.p_status, CatTab.cat_name from ProTab Join CatTab on ProTab.cat_id = CatTab.cat_id where ProTab.cat_id="+cid+"";
                DataSet ds = ob.Fn_Adapetr(str);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }

           
            protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                int i = e.RowIndex;
                int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
                string s = "update ProTab set p_status = 'removed' where p_id = " + getid + "";
                int j = ob.Fn_Nonquery(s);
                grid_bind();
            }

            protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
            {
                GridViewRow rw = GridView1.Rows[e.NewSelectedIndex];

                int getid2 = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
                Response.Redirect("admeditproducts.aspx?id=" + getid2);
            }



            protected void LinkButton1_Command(object sender, CommandEventArgs e)
            {
                int cdip = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("admproducts.aspx?cid=" + cdip);

            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("admindex.aspx");

        }
    }
    }