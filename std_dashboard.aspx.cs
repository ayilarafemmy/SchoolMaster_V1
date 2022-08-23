using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teachers_Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["SID"])))
        {
            Response.Redirect("student.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("std_profile.aspx");
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("printID_students.aspx");
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("std_classes.aspx");
    }

    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("t_Assignments.aspx");
    }

    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("t_Assessment.aspx");
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("std_reports.aspx");
    }

    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("std_Library.aspx");
    }
}
