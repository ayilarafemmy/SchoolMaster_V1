using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Parents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["PID"].ToString()=="")
        {
            Response.Redirect("parent_login.aspx");
        }
        Label1.Text = Session["First_Name"].ToString();
        Label3.Text = Session["Last_Name"].ToString();
        Label2.Text = Session["First_Name"].ToString();
        Label4.Text = Session["Last_Name"].ToString();
        Panel1.Visible = true;
        Panel2.Visible = true;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel6.Visible = false;
    }
}
