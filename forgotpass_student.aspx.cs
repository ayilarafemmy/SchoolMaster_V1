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
using System.Net.Mail;
using System.Net;

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

    string sendmail = ConfigurationManager.AppSettings["SendEmail"];
    string SendSMS = ConfigurationManager.AppSettings["SendSMS"];
    string ServerName = ConfigurationManager.AppSettings["ServerName"];
    string SenderEmail = ConfigurationManager.AppSettings["SenderEmail"];
    string ServerPort = ConfigurationManager.AppSettings["ServerPort"];
    string Mail_Password = ConfigurationManager.AppSettings["Mail_Password"];
    string Institution = ConfigurationManager.AppSettings["Institution"];
    string URL = ConfigurationManager.AppSettings["URL"];
    string AdminEmail = ConfigurationManager.AppSettings["AdminEmail"];
    string SMSID = ConfigurationManager.AppSettings["SMSID"];
    string SMS_Email = ConfigurationManager.AppSettings["SMS_Email"];
    string SMS_Password = ConfigurationManager.AppSettings["SMS_Password"];
    string SMS_Sender = ConfigurationManager.AppSettings["SMS_Sender"];

    protected void Page_Load(object sender, EventArgs e)
    {
        Labelza.Text = ConfigurationManager.AppSettings["Institution"];
        string joe = ConfigurationManager.AppSettings["InstitutionLogo"];
        Image1.ImageUrl = joe;
    }
    void MessageBox(string x)
    {
        // Label1.Text = x;
        try
        {
            string message = x;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<script type = 'text/javascript'>");

            sb.Append("window.onload=function(){");

            sb.Append("alert('");

            sb.Append(message);

            sb.Append("')};");

            sb.Append("</script>");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());


        }
        catch (Exception ex)
        {

        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if(Label6.Text == TextBox2.Text)
        {

        }
        else
        {
            MessageBox("Code Not Matching, kindly check your email");
            return;
        }
        if(TextBox3.Text.Length < 6)
        {
            MessageBox("Minimum of 6 Characters Needed for a Password");
            return;
        }
        try
        {
            string tiwa = "Update D_Students set Password='" + TextBox3.Text+ "' where SID='"+ TextBox4.Text+ "'";
            insertRecord(tiwa);
            int joe1 = int.Parse(ServerPort);
            string StaffMail = "" + Label2.Text + "" + Environment.NewLine + "Dear Parent, Password reset for " + Label3.Text + "," + Environment.NewLine + "" + Environment.NewLine + "You have Successfully done a Password reset on " + Institution + " App" + Environment.NewLine + " " + Environment.NewLine + " New Password is: " + TextBox3.Text + " ";
            SendMail(TextBox1.Text, StaffMail, "Student Password Request - Reset Done", ServerName, SenderEmail, Institution, Mail_Password, joe1);


            MessageBox("Password Reset Done Successfully");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=student.aspx";
            this.Page.Controls.Add(meta);

        }
        catch (Exception oa)
        {
            Label1.Visible = true;
            Label1.ForeColor = Color.DarkRed;
            Label1.Text = "Error is " + oa + "";
            return;
        }
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
            if (TextBox4.Text=="")
            {
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
                Label1.Text = "Kindly provide ID";
            }

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select a.SID,concat(a.FirstName,' ',a.LastName) as Student from D_Students a, D_Parents b where a.Parent_ID = b.PID and b.email='"+ TextBox1.Text+ "' and a.SID='"+TextBox4.Text+"'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Parents");

            if (ds.Tables[0].Rows.Count > 0)
            {
                Label2.Text = ds.Tables[0].Rows[0]["SID"].ToString();
                Label3.Text = ds.Tables[0].Rows[0]["Student"].ToString();
                Random rd = new Random();
                Label6.Text = rd.Next(500000, 999999).ToString();

                //send mail
                if (sendmail == "Yes")
                {
                    int joe = int.Parse(ServerPort);
                    string StaffMail = "StudentID: "+ Label2.Text + ""+Environment.NewLine+"Dear  Parent, Password reset for: " + Label3.Text + "," + Environment.NewLine + "" + Environment.NewLine + "You have Successfully initiated a Password reset on " + Institution + " App" + Environment.NewLine + " " + Environment.NewLine + " Code is: "+ Label6.Text + " ";
                    SendMail(TextBox1.Text, StaffMail, "Student Password Request - Reset Code", ServerName, SenderEmail, Institution, Mail_Password, joe);
                }
                Label1.Visible = true;
                Label1.ForeColor = Color.Green;
                Label1.Text = "Code sent to your Parent email address: "+TextBox1.Text+"";
                Panel1.Visible = true;



            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
                Label1.Text = "Email Provided is invalid!";
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "1;url=  forgotpass_student.aspx";
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
    string insertRecord(string query)
    {
        try
        {

            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            myConnection.Open();
            SqlCommand cmd = new SqlCommand(query, myConnection);
            cmd.ExecuteNonQuery();
            myConnection.Close();
            return "1";
        }
        catch (Exception ex)
        {
            string success = "Possibe Network issue " + ex + "";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + success + "');", true);
            //MessageBox("at INSERT " + ex.Message);
            return "0" + ex.Message;
        }
    }
    public static void SendMail(string receiver, string body, string subject, string server, string Senderemail, string SenderID, string Mail_Password, int joe)
    {

        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("" + server + "");

        mail.From = new MailAddress("" + Senderemail + "", "" + SenderID + "");
        mail.To.Add(receiver);
        mail.Subject = subject;
        mail.Body = body;
        SmtpServer.EnableSsl = true;
        SmtpServer.Port = joe;
        SmtpServer.Credentials = new System.Net.NetworkCredential("" + Senderemail + "", "" + Mail_Password + "");
        SmtpServer.EnableSsl = false;
        NetworkCredential NetworkCred = new NetworkCredential("" + Senderemail + "", "" + Mail_Password + "");
        SmtpServer.Send(mail);


    }

}
