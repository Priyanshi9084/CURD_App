using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EmployeeForm
{
    public partial class Changepassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-MUBSA3S\\SQLEXPRESS;initial catalog=EMPLOYEE01;integrated security=true"); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idd"] != null && Session["idd"].ToString() != "")
            {

                if (!IsPostBack)
                {

                    //Pageload code

                }
            }
            else
            {
                Response.Redirect("LogoutForm1.aspx");
            }
        }




        protected void btncp_Click(object sender, EventArgs e)
        {
            if (txtnewpassword.Text == txtconfirmnewpassword.Text)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update tblregistration set rpassword='" + txtnewpassword.Text + "' where rid='" + Session["idd"] + "' and rpassword='" + txtcurrentpassword.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    lblmsg.Text = "Your password has been Change Successfully  !!";

                }
                else
                {
                    lblmsg.Text = "Your password has not been Change Successfully  !!";
                }

            }
            else
            {
                lblmsg.Text = "Password Do not match !!";
            }
        }
    }
}