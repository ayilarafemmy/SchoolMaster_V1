using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Image1.ImageUrl = ConfigurationManager.AppSettings["InstitutionLogo"];
        if (string.IsNullOrEmpty(Convert.ToString(Session["Email"])))
        {
            Response.Redirect("admin.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        if (Session["Email"] != null)
        {
            Labela.Text = ""+Session["FirstName"].ToString()+""+" "+Session["LastName"].ToString()+"";
            Labelb.Text = "" + Session["Role"].ToString() + "";
            Imagea.ImageUrl = ConfigurationManager.AppSettings["InstitutionLogo"];
            Labelc.Text = "" + Session["FirstName"].ToString() + "" + " " + Session["LastName"].ToString() + "";
            Label1.Text = ConfigurationManager.AppSettings["Institution"];

        }
        else
        {
            Response.Redirect("admin.aspx");
        }

        Image3.ImageUrl = ConfigurationManager.AppSettings["InstitutionLogo"];

    }

}
