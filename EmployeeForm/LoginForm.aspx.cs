using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace EmployeeForm
{
    public partial class LoginForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-MUBSA3S\\SQLEXPRESS;initial catalog=EMPLOYEE01;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblregistration where remail= '" + txtemail.Text + "' and rpassword='" + txtpass.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {

                Session["idd"] = dt.Rows[0]["rid"].ToString();
                Response.Redirect("Homepage.aspx");

            }
            else if (txtemail.Text == "" && txtpass.Text == "")
            {
                lblmsg.Text = "Please Enter the Email and password!!";
            }
            else
            {
                lblmsg.Text = "Login Failed !!";
            }
        }
    }
}