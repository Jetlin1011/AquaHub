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

    public partial class admIndex : System.Web.UI.Page
    {
        ConnectionClass ob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {

                grid_bind();
            }
            else
            {
                Response.Redirect("login.aspx");

            }
        }

        public void grid_bind()
        {
            string str = "select * from CatTab";
            DataSet ds = ob.Fn_Adapetr(str);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCat.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string s = "update CatTab set cat_status = 'removed' where cat_id = "+getid+"";
            int j = ob.Fn_Nonquery(s);
            grid_bind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow rw = GridView1.Rows[e.NewSelectedIndex];

            int getid2 = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Value);
            Response.Redirect("admedit.aspx?id="+getid2);
        }

    

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            int cdip = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("admproducts.aspx?cid="+cdip);

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");

        }
    }
}