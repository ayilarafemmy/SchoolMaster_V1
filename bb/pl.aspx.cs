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
            //select* from Subscribers where BusinessEmail = '' and Password = ''
            cmd.CommandText = "select * from D_Parents where Email='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Parents");

            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["PID"] = ds.Tables[0].Rows[0]["PID"].ToString();
                Session["First_Name"] = ds.Tables[0].Rows[0]["First_Name"].ToString();
                Session["Last_Name"] = ds.Tables[0].Rows[0]["Last_Name"].ToString();
                Session["Phone"] = ds.Tables[0].Rows[0]["Phone"].ToString();
                Session["Relationship"] = ds.Tables[0].Rows[0]["Relationship"].ToString();
                Session["Email"] = ds.Tables[0].Rows[0]["Email"].ToString();
                Session["Gender"] = ds.Tables[0].Rows[0]["Gender"].ToString();

                Session["Religion"] = ds.Tables[0].Rows[0]["Religion"].ToString();
                Session["Alternate_Phone"] = ds.Tables[0].Rows[0]["Alternate_Phone"].ToString();
                Session["Full_Address"] = ds.Tables[0].Rows[0]["Full_Address"].ToString();
                Session["Identity_Upload"] = ds.Tables[0].Rows[0]["Identity_Upload"].ToString();
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
                    Response.Redirect("Parents_Dashboard2.aspx?msgs=" + "SuccessLogin");
                }

            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
                Label1.Text = "Kindly note that your registered Email is your user name...Your Username and or Password is incorrect";
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "9;url=  Parent.aspx";
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
