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
    
    public partial class usercart : System.Web.UI.Page
    {
        ConnectionClass ob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"]!=null)
            {
                if (!IsPostBack)
                {
                    grid_bind();
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        public void grid_bind()
        {
            string s = "select ProTab.p_image, ProTab.p_name, ProTab.p_price,CartTab.cart_id, CartTab.quantity, CartTab.totalprice  from ProTab join CartTab on ProTab.p_id = CartTab.p_id where u_id =" + Convert.ToInt32(Session["uid"]) + "";
            DataSet ds = ob.Fn_Adapetr(s);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            string str1 = "select sum(totalprice) from CartTab where u_id=" + Convert.ToInt32(Session["uid"]) + "";
            string sum = ob.Fn_Scalar(str1).ToString();

            if (sum == "")
            {
                Label1.Text = "0";
                Button8.Visible = false;
            }
            else
            {
                Label1.Text = sum;
                Session["sum"] = sum.ToString();
            }
        }
        protected void Button1_Command(object sender, CommandEventArgs e)
        {
            int cartid = Convert.ToInt32(e.CommandArgument);
            string s = "delete from CartTab where cart_id = " + cartid + "";
            int i = ob.Fn_Nonquery(s);
           
                grid_bind();
           
        }

        protected void Button2_Command(object sender, CommandEventArgs e)
        {
            int cartid = Convert.ToInt32(e.CommandArgument);
            string s = "select ProTab.p_price, CartTab.quantity, CartTab.totalprice from ProTab join CartTab on ProTab.p_id = CartTab.p_id where CartTab.cart_id="+cartid+"";
            SqlDataReader dr = ob.Fn_Reader(s);
            int pprice = 0;
            int qty = 0;
            int totalprice = 0;
            int totalprice1 = 0;
            int quantity = 0;
            if (dr.Read()){
                pprice = Convert.ToInt32(dr["p_price"]);
                qty = Convert.ToInt32(dr["quantity"]);
                quantity = qty + 1;
                totalprice = Convert.ToInt32(dr["totalprice"]);
                totalprice1 = quantity * pprice;
            }
            string str = "update CartTab set quantity="+quantity+", totalprice="+totalprice1+" where cart_id ="+cartid+"";
            int i = ob.Fn_Nonquery(str);
            grid_bind();

        }

        protected void Button3_Command(object sender, CommandEventArgs e)
        {
            int cartid2 = Convert.ToInt32(e.CommandArgument);
            string st = "select ProTab.p_price, CartTab.quantity, CartTab.totalprice from ProTab join CartTab on ProTab.p_id = CartTab.p_id where CartTab.cart_id=" + cartid2 + "";
            SqlDataReader dr = ob.Fn_Reader(st);
            int pprice = 0;
            int qty = 0;
            int totalprice = 0;
            int totalprice1 = 0;
            int quantity = 0;
            if (dr.Read())
            {
                pprice = Convert.ToInt32(dr["p_price"]);
                qty = Convert.ToInt32(dr["quantity"]);
                quantity = qty - 1;

              
                totalprice = Convert.ToInt32(dr["totalprice"]);
                totalprice1 = quantity * pprice;
            }

            if (quantity == 0)
            {
                Button1_Command(sender, e);

            }

            else
            {

                string str = "update CartTab set quantity=" + quantity + ", totalprice=" + totalprice1 + " where cart_id =" + cartid2 + "";
                int i = ob.Fn_Nonquery(str);
                grid_bind();
            }

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHome.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            int maxvalue;
            int count;
            int counter = 0;
            string st = "select max(cart_id) from CartTab where u_id =" + Convert.ToInt32(Session["uid"]) + "";
            maxvalue = Convert.ToInt32(ob.Fn_Scalar(st));

            string str1 = "select count(*) from CartTab where u_id =" + Convert.ToInt32(Session["uid"]) + "";
           count = Convert.ToInt32(ob.Fn_Scalar(str1));

            for(int i = maxvalue; i>0; i--)
            {
                string str2="select * from CartTab where cart_id="+i+ " and u_id= "+Convert.ToInt32(Session["uid"])+" ";
                SqlDataReader dr = ob.Fn_Reader(str2);
                if (dr.Read())
                {
                    int p_id = Convert.ToInt32(dr["p_id"]);
                    int quantity = Convert.ToInt32(dr["quantity"]);
                    decimal totalprice = Convert.ToInt32(dr["totalprice"]);


                    string str3 = "insert into OrderTab values(" + i + ", " + p_id + ", " + Convert.ToInt32(Session["uid"]) + ", " + quantity + ", " + totalprice + ",'ordered')";
                     int p = ob.Fn_Nonquery(str3);
                    if (p == 1)
                    {
                        counter++;
                        
                    }

                }
                else
                {
                    continue;
                }

                if (count == counter)
                {
                    break;
                }
            }
            DateTime currentDate = DateTime.Now;
            string billDate = currentDate.ToString("d");

            string str5 = "insert into BillTab values('" + billDate + "'," + Convert.ToInt32(Session["uid"]) + ", " + Convert.ToInt32(Label1.Text) + ", 'inbilling')";
            int x = ob.Fn_Nonquery(str5);

            string s = "delete from CartTab where u_id = " + Convert.ToInt32(Session["uid"]) + "";
            int pl= ob.Fn_Nonquery(s);
            grid_bind();
            Response.Redirect("viewBill.aspx");

        }
    }
}