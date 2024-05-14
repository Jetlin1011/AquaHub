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
    public partial class index : System.Web.UI.Page
    {

        ConnectionClass objcls = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = "select * from CatTab where cat_status='available'";

                DataSet ds = objcls.Fn_Adapetr(s);






                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }

     

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int i = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("products.aspx?cid="+i);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Session.Remove("uid");
            Response.Redirect("UserHome.aspx");
        }
    }
}