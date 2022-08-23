using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class parents_details : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select * from D_Parents where PID=" + Request.QueryString["PID"].ToString()+"";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Parents");
            Label1.Text = ds.Tables[0].Rows[0]["First_Name"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["Last_Name"].ToString();
            Label3.Text = ds.Tables[0].Rows[0]["First_Name"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["Last_Name"].ToString();
            Label5.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["Relationship"].ToString();
            Label7.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["Full_Address"].ToString();
            Label9.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            Label11.Text = ds.Tables[0].Rows[0]["Alternate_Phone"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["Capture_Date"].ToString();
            Label14.Text = ds.Tables[0].Rows[0]["FirstLogin"].ToString();
            string ue = ds.Tables[0].Rows[0]["Identity_Upload"].ToString();
            string end = ds.Tables[0].Rows[0]["filetype"].ToString();
            Image1.ImageUrl = "~/Parents/"+ue+""+end+"";
            con.Close();


            string query = "select * from D_Students where Parent_ID = '"+ Request.QueryString["PID"].ToString()+"'";
            GridviewBind(query);
        }
    }

    protected void GridviewBind(string query)
    {
        try
        {
            string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView2.DataSource = dr;
                GridView2.DataBind();
                con.Close();
            }
        }
        catch (Exception kk)
        {
            string success = "Possibe Network issue " + kk + "";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + success + "');", true);
            return;
        }
    }
}
