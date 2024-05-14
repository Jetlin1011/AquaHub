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
    public partial class singleitem : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int pid = Convert.ToInt32(Request.QueryString["pid"]);

                string str = "Select * from ProTab where p_id = " + pid + "";
                SqlDataReader dr = obj.Fn_Reader(str);
                if (dr.Read())
                {
                    Image1.ImageUrl = dr["p_image"].ToString();
                    Label1.Text = dr["p_name"].ToString();
                    Label3.Text = dr["p_description"].ToString();
                    Label2.Text = dr["p_price"].ToString();
                }
                if (Label4.Text == "" || Label4.Text == "0")
                {
                    Button4.Enabled = false;
                }
                else
                {
                    Button4.Enabled = true;

                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(Request.QueryString["pid"]);

            string st1 = "select p_stock from ProTab where p_id = " + pid + "";
            int no = Convert.ToInt32(obj.Fn_Scalar(st1));
            

                int count;
            string i =Label4.Text;
            if (i == "")
            {
                count = 0;

            }
            else if (i == "0")
            {
                Label4.Text = "0";

            }

            else if(i=="1") {
                Label4.Text = "0";
                Button4.Enabled = false;
                Button2.Enabled = true;
            }
            else
            {
                int qty = Convert.ToInt32(Label4.Text);

                if (no >= qty)
                {
                    count = Convert.ToInt32(Label4.Text);
                    count = count - 1;
                    Label4.Text = count.ToString();
                    Button3.Enabled = true;

                }
                else
                {
                    Button2.Enabled = false;


                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(Request.QueryString["pid"]);

            string st1 = "select p_stock from ProTab where p_id = " + pid + "";
            int no = Convert.ToInt32(obj.Fn_Scalar(st1));

            int count;
            string i = Label4.Text;
            if (i == "")
            {
                count = 1;
                Label4.Text = count.ToString();
                Button4.Enabled = true;

            }

            else
            {
                int qty = Convert.ToInt32(Label4.Text);

                if (no > qty)
                {

                    count = Convert.ToInt32(Label4.Text);
                    count = count + 1;
                    Label4.Text = count.ToString();
                    Button4.Enabled = true;
                    Button2.Enabled = true;

                }
                else
                {
                    Button3.Enabled = false;


                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {


                int qty = Convert.ToInt32(Label4.Text);
                decimal tprice = qty * Convert.ToInt32(Label2.Text);
                int pid = Convert.ToInt32(Request.QueryString["pid"]);
                int uid = Convert.ToInt32(Session["uid"]);

                string st1 = "select p_stock from ProTab where p_id = " + pid + "";
                int no = Convert.ToInt32(obj.Fn_Scalar(st1));


                string s = "insert into CartTab values(" + pid + "," + uid + "," + Convert.ToInt32(Label4.Text) + "," + tprice + ",'incart')";
                int j = obj.Fn_Nonquery(s);
            }
            else
            {
                Response.Redirect("login.aspx");
            }
           
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string cs = "select cat_id from ProTab where p_id=" + Convert.ToInt32(Request.QueryString["pid"]) + "";
            string catid = obj.Fn_Scalar(cs).ToString();
            Response.Redirect("products.aspx?cid=" + catid);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("usercart.aspx");

        }
    }
}