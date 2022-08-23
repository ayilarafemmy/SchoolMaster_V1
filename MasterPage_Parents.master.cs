using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_Parents : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["PID"])))
        {
            Response.Redirect("parent.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        Labelza.Text = ConfigurationManager.AppSettings["Institution"];
        Label1aa.Text = Session["First_Name"].ToString();
        Label2aa.Text = Session["First_Name"].ToString();
        Label3aa.Text = Session["Last_Name"].ToString();
        Label4aa.Text = Session["Last_Name"].ToString();

        Image3.ImageUrl = ConfigurationManager.AppSettings["InstitutionLogo"];
        Image1.ImageUrl = ConfigurationManager.AppSettings["InstitutionLogo"];
    }
}
