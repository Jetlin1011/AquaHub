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
    public partial class admaddproducts : System.Web.UI.Page
    {
        ConnectionClass ob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string s = "select cat_id , cat_name from CatTab";
                DataSet ds = ob.Fn_Adapetr(s);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "cat_name";
                DropDownList1.DataValueField = "cat_id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "--select--");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
             string cid =DropDownList1.SelectedItem.Value;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string p = "~/PHO/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));

            string str = "insert into ProTab values(" + DropDownList1.SelectedItem.Value + ",'" + TextBox1.Text + "','" + p + "','" + TextBox3.Text + "'," + TextBox5.Text + "," + TextBox6.Text + ",'" + TextBox4.Text + "')";
            int j = ob.Fn_Nonquery(str);
            if (j == 1)
            {
                Response.Redirect("admIndex.aspx");
            }
        }

    

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("admIndex.aspx");

        }
    }
}