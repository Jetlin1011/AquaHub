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
    public partial class products : System.Web.UI.Page
    {

        ConnectionClass objcls = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                int cid = Convert.ToInt32(Request.QueryString["cid"]);

                string s = "select * from ProTab where cat_id="+cid+" and  p_status='available' and p_stock>0";

                DataSet ds = objcls.Fn_Adapetr(s);






                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }



        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int i = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("singleitem.aspx?pid=" + i);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHome.aspx");

        }
    }
}