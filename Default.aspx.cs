using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class pl : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    SqlCommand cmd1 = new SqlCommand();
    SqlConnection con1 = new SqlConnection();
    SqlDataAdapter sda1 = new SqlDataAdapter();
    DataSet ds1 = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = ConfigurationManager.AppSettings["Institution"];
        Labelza.Text = ConfigurationManager.AppSettings["Institution"];
        string joe = ConfigurationManager.AppSettings["InstitutionLogo"];
        Image1.ImageUrl = joe;
    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("student.aspx");
    }

    protected void ImageButton4_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("admin.aspx");
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("parent.aspx");
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("teacher.aspx");
    }
}
