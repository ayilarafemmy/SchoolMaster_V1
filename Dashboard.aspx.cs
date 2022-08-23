using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    SqlCommand cmd1 = new SqlCommand();
    SqlConnection con1 = new SqlConnection();
    SqlDataAdapter sda1 = new SqlDataAdapter();
    DataSet ds1 = new DataSet();

    SqlCommand cmd2 = new SqlCommand();
    SqlConnection con2 = new SqlConnection();
    SqlDataAdapter sda2 = new SqlDataAdapter();
    DataSet ds2 = new DataSet();

    SqlCommand cmd3 = new SqlCommand();
    SqlConnection con3 = new SqlConnection();
    SqlDataAdapter sda3 = new SqlDataAdapter();
    DataSet ds3 = new DataSet();

    SqlCommand cmd4 = new SqlCommand();
    SqlConnection con4 = new SqlConnection();
    SqlDataAdapter sda4 = new SqlDataAdapter();
    DataSet ds4 = new DataSet();

    SqlCommand cmd5 = new SqlCommand();
    SqlConnection con5 = new SqlConnection();
    SqlDataAdapter sda5 = new SqlDataAdapter();
    DataSet ds5 = new DataSet();

    SqlCommand cmd6 = new SqlCommand();
    SqlConnection con6 = new SqlConnection();
    SqlDataAdapter sda6 = new SqlDataAdapter();
    DataSet ds6 = new DataSet();

    SqlCommand cmd7 = new SqlCommand();
    SqlConnection con7 = new SqlConnection();
    SqlDataAdapter sda7 = new SqlDataAdapter();
    DataSet ds7 = new DataSet();

    SqlCommand cmd8 = new SqlCommand();
    SqlConnection con8 = new SqlConnection();
    SqlDataAdapter sda8 = new SqlDataAdapter();
    DataSet ds8 = new DataSet();

    SqlCommand cmd9 = new SqlCommand();
    SqlConnection con9 = new SqlConnection();
    SqlDataAdapter sda9 = new SqlDataAdapter();
    DataSet ds9 = new DataSet();

    SqlCommand cmd10 = new SqlCommand();
    SqlConnection con10 = new SqlConnection();
    SqlDataAdapter sda10 = new SqlDataAdapter();
    DataSet ds10 = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["Email"])))
        {
            Response.Redirect("admin.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        if (Session["Email"] != null)
        {


        }
        else
        {
            Response.Redirect("admin.aspx");
        }
        Image3.ImageUrl = ConfigurationManager.AppSettings["InstitutionLogo"];
        Label1.Text = Session["FirstName"].ToString() + Session["LastName"].ToString();
        Label2.Text = Session["Role"].ToString();
        Image1.ImageUrl = "img/figure/admin.jpg";
        Label3.Text = Session["FirstName"].ToString() + Session["LastName"].ToString();
        string joe = ConfigurationManager.AppSettings["InstitutionLogo"];
        Image2.ImageUrl = joe;

        if(Session["Role"].ToString() == "Administrator" || Session["Role"].ToString() == "Manager")
        {
            Label18.Text = "Allow";
        }
        if(Session["SecondaryRole"].ToString() == "Management" || Session["SecondaryRole"].ToString() == "Admin" || Session["SecondaryRole"].ToString() == "Finance")
        {
            Label19.Text = "Allow";
        }

        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select count(SID) as sid from D_students";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_students");
            LabelD1.Text = ds.Tables[0].Rows[0]["sid"].ToString();
            cmd1.CommandText = "select count(StaffID) as StaffID from D_Staff";
            cmd1.Connection = con;
            sda1.SelectCommand = cmd1;
            sda1.Fill(ds1, "D_Staff");
            LabelD2.Text = ds1.Tables[0].Rows[0]["StaffID"].ToString();

            cmd2.CommandText = "select count(PID) as SN from D_Parents";
            cmd2.Connection = con;
            sda2.SelectCommand = cmd2;
            sda2.Fill(ds2, "D_Parents");
            LabelD3.Text = ds2.Tables[0].Rows[0]["SN"].ToString();

            cmd3.CommandText = "SELECT sum(CAST(amount AS INT)) as newam FROM D_Account";
            cmd3.Connection = con;
            sda3.SelectCommand = cmd3;
            sda3.Fill(ds3, "D_Account");
            LabelD4.Text = ds3.Tables[0].Rows[0]["newam"].ToString();

            cmd4.CommandText = "select count(MID) as CID4 from D_Messagess where StaffID='"+ Session["StaffID"].ToString()+ "'";
            cmd4.Connection = con;
            sda4.SelectCommand = cmd4;
            sda4.Fill(ds4, "D_Messagess");
            Label4.Text = ds4.Tables[0].Rows[0]["CID4"].ToString() + "Messages";

            cmd5.CommandText = "SELECT sum(CAST(amount AS INT)) as jj FROM D_Account where destination = 'Expenses' and EntryDate  like '%/"+ DateTime.Now.AddMonths(-2).ToString("MM/yyyy") + "'";
            cmd5.Connection = con;
            sda5.SelectCommand = cmd5;
            sda5.Fill(ds5, "D_Account");
            Label8.Text = ds5.Tables[0].Rows[0]["jj"].ToString();

            cmd6.CommandText = "SELECT sum(CAST(amount AS INT)) as ii FROM D_Account where destination = 'Expenses' and EntryDate  like '%/" + DateTime.Now.AddMonths(-1).ToString("MM/yyyy") + "'";
            cmd6.Connection = con;
            sda6.SelectCommand = cmd6;
            sda6.Fill(ds6, "D_Account");
            Label10.Text = ds6.Tables[0].Rows[0]["ii"].ToString();

            cmd7.CommandText = "SELECT sum(CAST(amount AS INT)) as i0 FROM D_Account where destination = 'Expenses' and EntryDate  like '%/" + DateTime.Now.ToString("MM/yyyy") + "'";
            cmd7.Connection = con;
            sda7.SelectCommand = cmd7;
            sda7.Fill(ds7, "D_Account");
            Label12.Text = ds7.Tables[0].Rows[0]["i0"].ToString();

            cmd7.CommandText = "SELECT sum(CAST(amount AS INT)) as i0 FROM D_Account where destination = 'Expenses' and EntryDate  like '%/" + DateTime.Now.ToString("MM/yyyy") + "'";
            cmd7.Connection = con;
            sda7.SelectCommand = cmd7;
            sda7.Fill(ds7, "D_Account");
            Label12.Text = ds7.Tables[0].Rows[0]["i0"].ToString();

            cmd8.CommandText = "select count(SID) as fem from D_students where Gender='Female'";
            cmd8.Connection = con;
            sda8.SelectCommand = cmd8;
            sda8.Fill(ds8, "D_students");
            Label13.Text = ds8.Tables[0].Rows[0]["fem"].ToString();

            cmd9.CommandText = "select count(SID) as fem from D_students where Gender='Male'";
            cmd9.Connection = con;
            sda9.SelectCommand = cmd9;
            sda9.Fill(ds9, "D_students");
            Label14.Text = ds9.Tables[0].Rows[0]["fem"].ToString();


            con.Close();

        }
        catch (Exception kol)
        {

        }




        //in body//still not done

        Label5.Text = "₦";
        Label6.Text = DateTime.Now.ToString("MMM , yyyy");
        string query = "select  Top 5 a.ACID, a.Amount,b.Purpose,a.Type from D_Account a, D_PaymentPurpose b where entrydate like '%/"+ DateTime.Now.ToString("MM/yyyy") + "' and a.Purpose = b.PPID and a.destination = 'inflow' order by ACID desc";
        GridviewBind(query);
        Label7.Text = DateTime.Now.AddMonths(-2).ToString("MMM , yyyy");

        Label9.Text = DateTime.Now.AddMonths(-1).ToString("MMM , yyyy");
      // Label10.Text = "100,000";
        Label11.Text = DateTime.Now.ToString("MMM , yyyy");
        //Label13.Text = "4,500";
        //Label14.Text = "11,500";
        Label15.Text = "1100";
        Label16.Text = "2560";
        Label17.Text = "980";


        if (Label18.Text != "Allow")
        {
            LabelD1.Text = "********";
            LabelD2.Text = "********";
            LabelD3.Text = "********";
            LabelD4.Text = "********";
            GridView3.Visible = false;

            Label8.Text = "********";
            Label10.Text = "********";
            Label12.Text = "********";
        }
        //if (Label19.Text != "Allow")
        //{
        //    LabelD1.Text = "********";
        //    LabelD2.Text = "********";
        //    LabelD3.Text = "********";
        //    LabelD4.Text = "********";
        //}
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
                GridView3.DataSource = dr;
                GridView3.DataBind();
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
