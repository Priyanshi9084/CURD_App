using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;

namespace EmployeeForm
{
    public partial class ImageForm1 : System.Web.UI.Page
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
        public void Clear()
        {
            txtname.Text = "";
            txtage.Text = "";
            btnsubmit.Text = "Submit";
        }
        public void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("tblusers_display", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvimage.DataSource = dt;
            gvimage.DataBind();

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Submit")
            {
                string FN = DateTime.Now.Ticks.ToString() + Path.GetFileName(fuimage.PostedFile.FileName);
                fuimage.SaveAs(Server.MapPath("Userpics" + "\\" + FN));
                con.Open();
                SqlCommand cmd = new SqlCommand("tblusers_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uname", txtname.Text);
                cmd.Parameters.AddWithValue("@uage", txtage.Text);
                cmd.Parameters.AddWithValue("@uimaage", FN);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                Clear();

            }
            else if (btnsubmit.Text == "Update")
            {

                string FN = Path.GetFileName(fuimage.PostedFile.FileName);
                if (FN != "")
                {
                    FN = DateTime.Now.ToString() + FN;
                    fuimage.SaveAs(Server.MapPath("Userpics" + "\\" + FN));
                    File.Delete(Server.MapPath("Userpics" + "\\" + ViewState["IMG"]));
                    con.Open();
                    SqlCommand cmd = new SqlCommand("tblusers_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uid", ViewState["id"]);
                    cmd.Parameters.AddWithValue("@uname", txtname.Text);
                    cmd.Parameters.AddWithValue("@uage", txtage.Text);
                    cmd.Parameters.AddWithValue("@uimaage", FN);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BindGrid();
                    Clear();
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("tblusers_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uid", ViewState["id"]);
                    cmd.Parameters.AddWithValue("@uname", txtname.Text);
                    cmd.Parameters.AddWithValue("@uage", txtage.Text);
                    cmd.Parameters.AddWithValue("@uimaage", ViewState["IMG"]);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BindGrid();
                    Clear();
                }

            }

        }

        protected void gvimage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                string[] arr = e.CommandArgument.ToString().Split(',');
                con.Open();
                SqlCommand cmd = new SqlCommand("tblusers_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", arr[0]);
                cmd.ExecuteNonQuery();
                con.Close();
                File.Delete(Server.MapPath("Userpics" + "\\" + arr[1]));
                BindGrid();
            }
            else if (e.CommandName == "B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("tblusers_Edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["uname"].ToString();
                txtage.Text = dt.Rows[0]["uage"].ToString();
                ViewState["IMG"] = dt.Rows[0]["uimaage"].ToString();
                btnsubmit.Text = "Update";
                ViewState["id"] = e.CommandArgument;



            }
        }
    }
}