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
        if (string.IsNullOrEmpty(Convert.ToString(Session["StaffID"])))
        {
            Response.Redirect("teacher.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("t_students.aspx");
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("t_attendance.aspx");
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("t_classes.aspx");
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
        Response.Redirect("t_Reports.aspx");
    }

    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("t_Communication.aspx");
    }
}
