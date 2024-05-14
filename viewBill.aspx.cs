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
    public partial class viewBill : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = "Select ProTab.p_name, ProTab.p_price, OrderTab.quantity, OrderTab.totalprice from ProTab join OrderTab on ProTab.p_id = OrderTab.p_id where OrderTab.status='ordered' and OrderTab.u_id = "+Convert.ToInt32(Session["uid"])+"";
                DataSet ds = obj.Fn_Adapetr(str);  

              

                String s = "select UserTab.u_name, UserTab.u_address, UserTab.u_phone, BillTab.bill_id, BillTab.bill_date from UserTab join BillTab on UserTab.u_id = BillTab.u_id where BillTab.u_id=" + Convert.ToInt32(Session["uid"]) + " and BillTab.status ='inbilling'";
                SqlDataReader dr = obj.Fn_Reader(s);
                if (dr.Read())
                {
                    LabelName.Text = dr["u_name"].ToString();
                    LabelAddr.Text = dr["u_address"].ToString();
                    Labelph.Text = dr["u_phone"].ToString();
                    LabelOrderDate.Text = dr["bill_date"].ToString();
                    Labelordernumber.Text = dr["bill_id"].ToString();

                }
                Labelsum.Text = Session["sum"].ToString();
                GridView1.DataSource = ds;
                GridView1.DataBind();
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
            string st = "delete from OrderTab where status='ordered' and u_id =" + Convert.ToInt32(Session["uid"]) + "";
            int j = obj.Fn_Nonquery(st);
            string st1 = "delete from BillTab where status='inbilling' and u_id =" + Convert.ToInt32(Session["uid"]) + "";
            obj.Fn_Nonquery(st1);
            Session.Remove("sum");

            Response.Redirect("UserHome.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("paymentpage.aspx");
        }
    }
}