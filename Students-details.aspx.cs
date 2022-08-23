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

    SqlCommand cmdz = new SqlCommand();
    SqlConnection conz = new SqlConnection();
    SqlDataAdapter sdaz = new SqlDataAdapter();
    DataSet dsz = new DataSet();

    SqlCommand cmdy = new SqlCommand();
    SqlConnection cony = new SqlConnection();
    SqlDataAdapter sday = new SqlDataAdapter();
    DataSet dsy = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select * from D_Students where SID=" + Request.QueryString["SID"].ToString()+"";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Students");
            Label1.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            TextBox1.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["Roll_No"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
            DropDownList2.SelectedValue = ds.Tables[0].Rows[0]["Religion"].ToString();
            LinkButton1.Text = ds.Tables[0].Rows[0]["Class"].ToString();
            LinkButton2.Text = ds.Tables[0].Rows[0]["Section"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["Capture_Date"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["Bio"].ToString();
            string ue = ds.Tables[0].Rows[0]["Photo"].ToString();
            string ext = ds.Tables[0].Rows[0]["filetype"].ToString();
            Image1.ImageUrl = "~/Students/" + ue+""+ext+"";
            con.Close();

            SqlConnection cony = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            cony.Open();
            cmdy.CommandText = "select Class from D_Classes where ClassID=" + LinkButton1.Text + "";
            cmdy.Connection = cony;
            sday.SelectCommand = cmdy;
            sday.Fill(dsy, "D_Classes");
            string classs = dsy.Tables[0].Rows[0]["Class"].ToString();
            Label10.Text = " : "+classs+"";

            cmdz.CommandText = "select Section from D_Sections where SectionsID=" + LinkButton2.Text + "";
            cmdz.Connection = cony;
            sdaz.SelectCommand = cmdz;
            sdaz.Fill(dsz, "D_Sections");
            string seec = dsz.Tables[0].Rows[0]["Section"].ToString();
            Label11.Text = " : " + seec + "";

            cony.Close();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}
