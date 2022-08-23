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
        Labelza.Text = ConfigurationManager.AppSettings["Institution"];
        string joe = ConfigurationManager.AppSettings["InstitutionLogo"];
        Image1.ImageUrl = joe;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            if (TextBox1.Text.Length < 2)
            {
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
                Label1.Text = "Kindly provide Email Address";
            }
            if (TextBox2.Text.Length < 5)
            {
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
                Label1.Text = "Kindly provide Your Password";
            }
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            //cmd.CommandText = "select a.StaffID,a.FirstName, a.LastName,a.Phone,a.Email,a.Role,a.SecondaryRole, c.classID, c.Class, d.sectionsID, d.Section  from D_Staff a, D_Classes c, D_Sections d where a.StaffID = b.StaffID and b.classID = c.ClassID and b.sectionsid = d.SectionsID and a.Email='" + TextBox1.Text + "' and a.Password='" + TextBox2.Text + "' and a.SecondaryRole='Teacher'";
            cmd.CommandText = "select StaffID,FirstName,LastName,Phone,Email,Role,SecondaryRole from D_Staff where Email='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "' and SecondaryRole='Teacher'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Staff");

            if (ds.Tables[0].Rows.Count >= 1)
            {
                Session["StaffID"] = ds.Tables[0].Rows[0]["StaffID"].ToString();
                Session["FirstName"] = ds.Tables[0].Rows[0]["FirstName"].ToString();
                Session["LastName"] = ds.Tables[0].Rows[0]["LastName"].ToString();
                Session["Phone"] = ds.Tables[0].Rows[0]["Phone"].ToString();
                Session["Email"] = ds.Tables[0].Rows[0]["Email"].ToString();
                Session["Role"] = ds.Tables[0].Rows[0]["Role"].ToString();
                Session["SecondaryRole"] = ds.Tables[0].Rows[0]["SecondaryRole"].ToString();
               // Session["TMID"] = ds.Tables[0].Rows[0]["TMID"].ToString();
               // Session["classID"] = ds.Tables[0].Rows[0]["classID"].ToString();
               // Session["Class"] = ds.Tables[0].Rows[0]["Class"].ToString();
               //Session["sectionsID"] = ds.Tables[0].Rows[0]["sectionsID"].ToString();
               // Session["Section"] = ds.Tables[0].Rows[0]["Section"].ToString();
                Label1.Visible = true;
                Label1.ForeColor = Color.Green;
                Label1.Text = "Login Successful";

                string ReturnUrl = Convert.ToString(Request.QueryString["url"]);
                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    Response.Redirect(ReturnUrl);
                }
                else
                {
                    Response.Redirect("Teachers_Dashboard.aspx?msgs=" + "SuccessLogin");
                }

            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
                Label1.Text = "Kindly note that your registered Staff Email Or StaffID is your user name...Your Username and or Password is incorrect";
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "9;url=  teacher.aspx";
                this.Page.Controls.Add(meta);
            }

            con.Close();
        }
        catch (Exception oa)
        {
            Label1.Visible = true;
            Label1.ForeColor = Color.DarkRed;
            Label1.Text = "Error is " + oa + "";
            return;
        }
    }
}
