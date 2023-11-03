using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace EmployeeForm
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-MUBSA3S\\SQLEXPRESS;initial catalog=EMPLOYEE01;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                BindState();
                BindStatus();

            }
        }


        public void Clear()
        {
            txtname.Text = "";
            rblgender.ClearSelection();
            txtemail.Text = "";
            ddlstate.SelectedValue = "0";
            ddlcity.SelectedValue = "0";
            txtpass.Text = "";
            btnregister.Text = "Register";
        }
        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblregistration join tblgender on rgender=gid join tblstate on rstate =stid join tblcity on rcity =cityid", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvmregistration.DataSource = dt;
            gvmregistration.DataBind();

        }
        public void BindStatus()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblgender", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblgender.DataValueField = "gid";
            rblgender.DataTextField = "gname";
            rblgender.DataSource = dt;
            rblgender.DataBind();

        }
        public void BindState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblstate where stid='" + ddlstate.SelectedValue + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.DataValueField = "stid";
            ddlstate.DataTextField = "stname";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        public void BindCity()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblcity where stid='" + ddlstate.SelectedValue + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcity.DataValueField = "cityid";
            ddlcity.DataTextField = "cityname";
            ddlcity.DataSource = dt;
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            if (btnregister.Text == "Register")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tblregistration(rname,rgender,remail,rstate,rcity,rpassword,rdob)values('" + txtname.Text + "','" + rblgender.SelectedValue + "','" + txtemail.Text + "','" + ddlstate.SelectedValue + "','" + ddlcity.SelectedValue + "','" + txtpass.Text + "','" + txtdob.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Clear();
            }
            else
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("update tblregistration set rname='" + txtname.Text + "',rgender='" + rblgender.SelectedValue + "',remail='" + txtemail.Text + "',rstate='" + ddlstate.SelectedValue + "',rcity='" + ddlcity.SelectedValue + "',rpassword='" + txtpass.Text + "',rdob='" + txtdob.Text + "' where rid='" + Request.QueryString["pp"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Clear();

            }
        }



        protected void ddlstate_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindCity();

        }
    }
}