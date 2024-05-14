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

    public partial class orderhistory : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {

                if (!IsPostBack)
                {
                    string str = "Select OrderTab.order_id, OrderTab.quantity, OrderTab.totalprice, ProTab.p_name, ProTab.p_price from OrderTab join ProTab on ProTab.p_id = OrderTab.p_id where OrderTab.status ='paid' and OrderTab.u_id=" + Convert.ToInt32(Session["uid"]) + "";
                    DataSet ds = obj.Fn_Adapetr(str);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (Label)e.Row.FindControl("lblIndex");
                lbl.Text = (e.Row.RowIndex + 1).ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHome.aspx");
        }
    }
}