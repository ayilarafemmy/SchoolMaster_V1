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
            BindGrid();
            BindGrid1();
            BindGrid2();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select * from D_Vehicles where VehicleID=" + Request.QueryString["VehicleID"].ToString()+"";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Vehicles");
            LinkButton1.Text = ds.Tables[0].Rows[0]["PlateNo"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            DropDownList1.SelectedItem.Text = ds.Tables[0].Rows[0]["VehiclePurpose"].ToString();
            DropDownList2.SelectedValue = ds.Tables[0].Rows[0]["RouteID"].ToString();
            string driver = ds.Tables[0].Rows[0]["Driver"].ToString();
            if(driver=="" || driver == "NULL" || driver =="0")
            {
                DropDownList3.SelectedValue = "0";
            }
            else
            {
                DropDownList3.SelectedValue = driver;
            }
            string supportstaff = ds.Tables[0].Rows[0]["SupportStaff"].ToString();
            if (supportstaff == "" || supportstaff == "NULL" || supportstaff == "0")
            {
                DropDownList4.SelectedValue = "0";
            }
            else
            {
                DropDownList4.SelectedValue = supportstaff;
            }
            DropDownList5.SelectedItem.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["Comment"].ToString();
            LinkButton2.Text = ds.Tables[0].Rows[0]["VehicleDoc"].ToString();

            con.Close();


            string query = "select * from D_Vehicles where VehicleID='" + Request.QueryString["VehicleID"].ToString() + "'";
            GridviewBind(query);
        }
    }
    protected void BindGrid()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select RoutesID,Route from D_Routes order by routesID asc";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "Route";
            DropDownList2.DataValueField = "RoutesID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Select Route", "0"));
            con.Close();
        }
    }
    protected void BindGrid1()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select Concat(FirstName,' ',LastName) as Name,StaffID from D_Staff";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataBind();
            DropDownList3.DataTextField = "Name";
            DropDownList3.DataValueField = "StaffID";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("Select Driver", "0"));
            con.Close();
        }
    }
    protected void BindGrid2()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select Concat(FirstName,' ',LastName) as Name,StaffID from D_Staff";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList4.DataSource = dt;
            DropDownList4.DataBind();
            DropDownList4.DataTextField = "Name";
            DropDownList4.DataValueField = "StaffID";
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, new ListItem("Select Support Staff", "0"));
            con.Close();
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

    protected void Button2_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
