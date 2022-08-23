using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Parents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["PID"])))
        {
            Response.Redirect("parent_login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        Labelza.Text = ConfigurationManager.AppSettings["Institution"];

        Label1.Text = Session["First_Name"].ToString();
        Label3.Text = Session["Last_Name"].ToString();
        Label2.Text = Session["First_Name"].ToString();
        Label4.Text = Session["Last_Name"].ToString();
        Image1.ImageUrl = ConfigurationManager.AppSettings["InstitutionLogo"];
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("kids.aspx");
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Communication.aspx");
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("finances.aspx");
    }
}
