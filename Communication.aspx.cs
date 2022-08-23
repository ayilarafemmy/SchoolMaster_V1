using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Web.UI.HtmlControls;

public partial class kids : System.Web.UI.Page
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
        if (string.IsNullOrEmpty(Convert.ToString(Session["PID"])))
        {
            Response.Redirect("parent.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        if (!IsPostBack)
        {

            BindGrid();
        }
    }
    protected void BindGrid()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "SELECT SID, CONCAT(FirstName, ' ', LastName) as Student from D_Students where Parent_ID='"+ Session["PID"].ToString()+ "'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Student";
            DropDownList1.DataValueField = "SID";
            DropDownList1.DataBind();
            //DropDownList1.Items.Insert(0, new ListItem("Select Student", "0"));
            DropDownList1.Items.Insert(0, new ListItem("All Student(s)", "0"));
            con.Close();
        }
    }
    protected void GridviewBind(string query)
    {
        try
        {
            string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView2.DataSource = dr;
                GridView2.DataBind();
                con.Close();
            }
        }
        catch (Exception kk)
        {
            string success = "Possibe Network issue " + kk + "";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + success + "');", true);
            return;
        }
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Select Student")
        {
            MessageBox("Kindly Select Student");
            return;
        }
        if (DropDownList2.SelectedItem.Text == "Select Recipient")
        {
            MessageBox("Kindly Select Request");
            return;
        }
        //send mail, Log it

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
        if (sendmail == "Yes")
        {
            int joe = int.Parse(ServerPort);
            string AdminMail = ""+TextBox1.Text+"";
            SendMail(AdminEmail, AdminMail, "Message from Parent", ServerName, SenderEmail, Institution, Mail_Password, joe);

        }
        string jjks = "insert into D_Messagess (Message,Date,Sender,Recipients,MessageTarget,Direction,SMS,Email,App) values ('"+TextBox1.Text+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"','"+ Session["PID"].ToString() + "','Admin','A','Incoming','N','Y','Y')";
        insertRecord(jjks);

        MessageBox("Message Sent Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "1;url=Communication.aspx";
        this.Page.Controls.Add(meta);



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



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = true;
        Panel3.Visible = false;
        Panel2.Visible = false;
        Label1.Visible = true;
        Label1.Text = "Incoming Messages";
        string pp = "select Message,Date,Sender from D_Messagess where MessageTarget = 'P'";
        GridviewBind(pp);
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel1.Visible = true;
        Label1.Visible = true;
        Label1.Text = "Sent Messages";
        string pp = "select Message,Date,Sender from D_Messagess where Sender='"+Session["PID"].ToString()+"'";
        GridviewBind(pp);
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
        Label1.Visible = true;
        Label1.Text = "Send Messages";
    }
}
