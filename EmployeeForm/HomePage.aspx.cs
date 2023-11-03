using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Configuration;

namespace EmployeeForm
{
    public partial class HomePage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-MUBSA3S\\SQLEXPRESS;initial catalog=EMPLOYEE01;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idd"] != null && Session["idd"].ToString() != "")
            {

                if (!IsPostBack)
                {
                    BindGrid();


                }
            }
            else
            {
                Response.Redirect("LogoutForm1.aspx");
            }
        }

        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Registration_Show", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("rid", Session["idd"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvmregistration.DataSource = dt;
            gvmregistration.DataBind();
            lblname.Text = dt.Rows[0]["rname"].ToString();

        }

        protected void gvmregistration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblregistration where rid ='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("LogoutForm.aspx");
            }
            else if (e.CommandName == "B")
            {
                Response.Redirect("RegistrationForm.aspx?pp=" + e.CommandArgument);

            }
        }
    }
}