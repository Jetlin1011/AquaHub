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
    public partial class paymentpage : System.Web.UI.Page
    {
        ConnectionClass objcls = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Session["uid"]);
            int accno = Convert.ToInt32(TextBox2.Text);


            ServiceReference4.ServiceClient obj = new ServiceReference4.ServiceClient();
            int balance = obj.BalanceCheck(uid, accno);
            if (balance == -1)
            {
                Label1.Text = "*account number does not match!";
            }
            else if (balance < Convert.ToDecimal(Session["sum"]))
            {
                string st = "delete from OrderTab where status='ordered' and u_id =" + Convert.ToInt32(Session["uid"]) + "";
                int j = objcls.Fn_Nonquery(st);
                string st1 = "delete from BillTab where status='inbilling' and u_id =" + Convert.ToInt32(Session["uid"]) + "";
                objcls.Fn_Nonquery(st1);
                Session.Remove("sum");
                Response.Redirect("insufficientfunds.aspx");
            }
            else
            {
                decimal newbalance = Convert.ToDecimal(balance)- Convert.ToDecimal(Session["sum"]);
                int u = obj.BalanceUpdate(uid, accno, newbalance);
                if (u == 1)
                {

                    string str1 = "UPDATE ProTab SET ProTab.p_stock =  ProTab.p_stock - OrderTab.quantity  FROM ProTab INNER JOIN OrderTab ON ProTab.p_id = OrderTab.p_id WHERE OrderTab.status = 'ordered'";

                    objcls.Fn_Nonquery(str1);

                    string or = "update OrderTab set status = 'nowpaid' where status ='ordered'";
                    string bi = "update BillTab set status = 'nowbilled' where status ='inbilling'";

                    objcls.Fn_Nonquery(or);
                    objcls.Fn_Nonquery(bi);

                }
            }

            Response.Redirect("printbill.aspx");

        }
    }
}