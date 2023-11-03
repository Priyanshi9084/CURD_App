using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.DynamicData;
using System.Configuration;

namespace EmployeeForm
{
    public partial class EmployeeForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-MUBSA3S\\SQLEXPRESS;initial catalog=EMPLOYEE01;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idd"] != null && Session["idd"].ToString() != "")
            {

                if (!IsPostBack)
                {
                    BindStatus();
                    BindHobbies();
                    BindDepartment();
                    BindQualification();
                    BindCountry();
                    BindGrid();


                }
            }
            else
            {
                Response.Redirect("LogoutForm1.aspx");
            }
        }
        public void BindHobbies()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblhobbies", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            cblhobbies.DataValueField = "hid";
            cblhobbies.DataTextField = "hname";
            cblhobbies.DataSource = dt;
            cblhobbies.DataBind();

        }
        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblemployee join tblstatus on estatus=sid join tbldepartment on edepartment=did join tblqualification on equalification=qid join tblcountry on ecountry=cid join tblstate on estate =stid join tblcity on ecity=cityid ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvemployee.DataSource = dt;
            gvemployee.DataBind();

        }
        public void BindStatus()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblstatus", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblstatus.DataValueField = "sid";
            rblstatus.DataTextField = "sname";
            rblstatus.DataSource = dt;
            rblstatus.DataBind();

        }
        public void BindDepartment()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbldepartment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddldepartment.DataValueField = "did";
            ddldepartment.DataTextField = "dname";
            ddldepartment.DataSource = dt;
            ddldepartment.DataBind();
            ddldepartment.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        public void BindQualification()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblqualification", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlqualification.DataValueField = "qid";
            ddlqualification.DataTextField = "qname";
            ddlqualification.DataSource = dt;
            ddlqualification.DataBind();
            ddlqualification.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        public void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblcountry", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcountry.DataValueField = "cid";
            ddlcountry.DataTextField = "cname";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        public void BindState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblstate where cid='" + ddlcountry.SelectedValue + "'", con);
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

        public void Clear()
        {
            txtname.Text = "";
            rblstatus.ClearSelection();
            cblhobbies.ClearSelection();
            ddldepartment.SelectedValue = "0";
            ddlqualification.SelectedValue = "0";
            ddlcountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
            ddlcity.SelectedValue = "0";
            btnsubmit.Text = "Submit";
        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string kk = "";
            for (int i = 0; i < cblhobbies.Items.Count; i++)
            {
                if (cblhobbies.Items[i].Selected == true)
                {
                    kk += cblhobbies.Items[i].Text + ",";
                }

            }

            kk = kk.TrimEnd(',');
            if (btnsubmit.Text == "Submit")
            {

                kk = kk.TrimEnd(',');
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tblemployee(ename,estatus,edepartment,equalification,ecountry,estate,ecity,ehobbies)values('" + txtname.Text + "','" + rblstatus.SelectedValue + "','" + ddldepartment.SelectedValue + "','" + ddlqualification.SelectedValue + "','" + ddlcountry.SelectedValue + "','" + ddlstate.SelectedValue + "','" + ddlcity.SelectedValue + "','" + kk + "')", con);
                int i = cmd.ExecuteNonQuery();

                con.Close();
                BindGrid();
                Clear();
            }
            else if (btnsubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update tblemployee set ename= '" + txtname.Text + "',estatus='" + rblstatus.SelectedValue + "',edepartment='" + ddldepartment.SelectedValue + "', equalification='" + ddlqualification.SelectedValue + "',ecountry='" + ddlcountry.SelectedValue + "',estate='" + ddlstate.SelectedValue + "',ecity='" + ddlcity.SelectedValue + "',ehobbies='" + kk + "'  where empid='" + ViewState["Idd"] + "'", con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                Clear();
            }

        }

        protected void gvemployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblemployee where empid ='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();

            }
            else if (e.CommandName == "B")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblemployee where empid='" + e.CommandArgument + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["ename"].ToString();
                rblstatus.SelectedValue = dt.Rows[0]["estatus"].ToString();
                string[] arr = dt.Rows[0]["ehobbies"].ToString().Split(',');
                cblhobbies.ClearSelection();
                for (int i = 0; i < cblhobbies.Items.Count; i++)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (cblhobbies.Items[i].Text == arr[j])
                        {
                            cblhobbies.Items[i].Selected = true;
                            break;
                        }
                    }
                }

                ddldepartment.SelectedValue = dt.Rows[0]["edepartment"].ToString();
                ddlqualification.SelectedValue = dt.Rows[0]["equalification"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["ecountry"].ToString();
                BindState();
                ddlstate.SelectedValue = dt.Rows[0]["estate"].ToString();
                BindCity();
                ddlcity.SelectedValue = dt.Rows[0]["ecity"].ToString();
                btnsubmit.Text = "Update";
                ViewState["Idd"] = e.CommandArgument;

            }

        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)

        {
            BindState();
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Employee_Search", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@search", txtsearch.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                gvemployee.DataSource = dt;
                gvemployee.DataBind();
                lblmsg.Text = "These are your results !!";
            }
            else
            {
                gvemployee.DataSource = null;
                gvemployee.DataBind();
                lblmsg.Text = "No record found !!";
            }

        }
    }
}