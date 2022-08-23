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
        if (string.IsNullOrEmpty(Convert.ToString(Session["SID"])))
        {
            Response.Redirect("student.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        if (string.IsNullOrEmpty(Convert.ToString(Session["SID"])))
        {
            Response.Redirect("student.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        Labelza.Text = ConfigurationManager.AppSettings["Institution"];
        Labela.Text = Session["FirstName"].ToString();
        //Label2aa.Text = Session["FirstName"].ToString();
        Labelb.Text = Session["LastName"].ToString();
        //Label4aa.Text = Session["LastName"].ToString();

        Image3.ImageUrl = ConfigurationManager.AppSettings["InstitutionLogo"];

    }
}
