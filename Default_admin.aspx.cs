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

public partial class _Default : System.Web.UI.Page
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
        //if (!IsPostBack)
        //{
        //    try
        //    {
        //        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        //        con1.Open();
        //        //select* from Subscribers where BusinessEmail = '' and Password = ''
        //        cmd1.CommandText = "select * from crm_Staff where Email='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
        //        cmd1.Connection = con1;
        //        sda.SelectCommand = cmd1;
        //        sda1.Fill(ds1, "crm_Staff");

        //        if (ds1.Tables[0].Rows.Count > 0)
        //        {
        //            Session["Status"] = ds1.Tables[0].Rows[0]["Status"].ToString();
        //            Session["SID"] = ds1.Tables[0].Rows[0]["SID"].ToString();
        //            Session["Name"] = ds.Tables[0].Rows[0]["Name"].ToString();

        //            Session["Phone"] = ds.Tables[0].Rows[0]["Phone"].ToString();
        //            Session["Email"] = ds.Tables[0].Rows[0]["Email"].ToString();
        //            Session["Role1"] = ds.Tables[0].Rows[0]["Role1"].ToString();
        //            Session["Location"] = ds.Tables[0].Rows[0]["Role2"].ToString();


        //            Label1.Visible = true;
        //            Label1.ForeColor = Color.Green;
        //            Label1.Text = "Login Successful";


        //        }
        //        else
        //        {

        //        }

        //        con1.Close();
        //    }
        //    catch (Exception oa)
        //    {
        //        Label1.Visible = true;
        //        Label1.ForeColor = Color.DarkRed;
        //        Label1.Text = "Error is " + oa + "";
        //        return;
        //    }
        //}
    }

        protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            if (TextBox1.Text.Length < 2)
            {
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
                Label1.Text = "Kindly provide Email or ID";
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
            cmd.CommandText = "select * from D_Staff where Email='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Staff");

            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["StaffID"] = ds.Tables[0].Rows[0]["StaffID"].ToString();
                Session["FirstName"] = ds.Tables[0].Rows[0]["FirstName"].ToString();
                Session["LastName"] = ds.Tables[0].Rows[0]["LastName"].ToString();
                Session["Role"] = ds.Tables[0].Rows[0]["Role"].ToString();
                Session["SecondaryRole"] = ds.Tables[0].Rows[0]["SecondaryRole"].ToString();
                Session["Email"] = ds.Tables[0].Rows[0]["Email"].ToString();
                Session["Profile"] = ds.Tables[0].Rows[0]["Profile"].ToString();

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
                    Response.Redirect("Dashboard.aspx?msgs=" + "SuccessLogin");
                }

            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
                Label1.Text = "Kindly note that your registered Staff Email Or StaffID is your user name...Your Username and or Password is incorrect";
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "9;url=  Default.aspx";
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
