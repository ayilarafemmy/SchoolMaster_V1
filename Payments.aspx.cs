using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["PID"])))
        {
            Response.Redirect("parent.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }
        if (!IsPostBack)
        {
            //get Key
            try {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select PGKEY from D_CustomerConfig where DID='1'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_CustomerConfig");

            if (ds.Tables[0].Rows.Count > 0)
            {
                Label9.Text = ds.Tables[0].Rows[0]["PGKEY"].ToString();
            }
            con.Close();
            }
            catch(Exception kk)
            {
                MessageBox("Error with your Payment Gateway Configuration, Please contact the DataPlus Team: Error : "+kk+"");
            }

            if(Label9.Text =="")
            {
                MessageBox("Payment Gateway is not configured");
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "0;url=finances.aspx";
                this.Page.Controls.Add(meta);
            }
            Label1.Text = Session["Email"].ToString();
            string money = Request.QueryString["Amount"];
            Label2.Text = money + "00";
            Label3.Text = Request.QueryString["kee"];
            Label4.Text = Request.QueryString["SID"];
            Label5.Text = Request.QueryString["Out"];
            Label6.Text = string.Format("{0:#,##0.00}", int.Parse(Request.QueryString["Amount"]));
            int jsh = int.Parse(Label5.Text) - int.Parse(money);
            Label7.Text = jsh.ToString();
            if(Request.QueryString["kee"].ToString().Length < 15 || Request.QueryString["kee"].ToString() =="")
            {
                MessageBox("Fraud Detected");
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "Refresh";
                meta.Content = "0;url=finances.aspx";
                this.Page.Controls.Add(meta);
            }
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        //update as successful in D_oNLine
        string u1 = "Update D_Online set TransDate='"+DateTime.Now.ToString("dd/MM/yyyy")+"',TransTime='"+DateTime.Now.AddHours(5).ToString("hh:mm:ss") +"',Status='Closed' where EntryKey='"+ Label3.Text+ "' and Status='Open'";
        insertRecord(u1);
        //move funds to D_Account
        string u2 = "insert into D_Account (Source,Destination,Amount,Description,Type,Purpose,TransDate,Balance,PaidBY) values ('1','Inflow','"+ Request.QueryString["Amount"]+ "','Paystack Payment','Online','5','"+DateTime.Now.ToString()+"','"+Label7.Text+"','"+ Label4.Text+ "')";
        insertRecord(u2);
        //Update Balance of Student
        string u3 = "Update D_Students set Balance ='"+Label7.Text+"' where SID='"+ Label4.Text+ "'";
        insertRecord(u3);
        //send mail to admin and parent
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
            string StaffMail = "Dear " + Session["First_Name"].ToString() + "," + Environment.NewLine + "" + Environment.NewLine + "" + Institution + " have successfully received your payments" + Environment.NewLine + " Details are as below: " + Environment.NewLine + "" + Environment.NewLine + "OutStanding: " + Label5.Text + " Naira" + Environment.NewLine + "Amount Paid: " + Label6.Text + " Naira" + Environment.NewLine + " Current Balance on Student's account: "+ Label7.Text + " Naira (ps: Negative Balance Mean you have extra funds with the school)" + Environment.NewLine + "" + Environment.NewLine + ""+ Environment.NewLine + " Thank You!!! ";
            SendMail(Label1.Text, StaffMail, "Payment Receipt - Important Details", ServerName, SenderEmail, Institution, Mail_Password, joe);

            string AdminMail = "Dear Admin, " + Environment.NewLine + " Payment Alert ." + Environment.NewLine + "" + Environment.NewLine + " Outstanding: " + Label5.Text + ", Amount Paid: " + Label6.Text + " and SID:" + Label4.Text + "";
            SendMail(AdminEmail, AdminMail, "Payment Alert", ServerName, SenderEmail, Institution, Mail_Password, joe);

            string quee = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('Payment Alert', '" + StaffMail + "', 'Automated','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
            insertRecord(quee);

        }
        if (SendSMS == "Yes")
        {
            var message = "Hi " + Session["First_Name"].ToString() + "," + Environment.NewLine + "" + Institution + " have received payment of: "+Label6.Text+ "Naira "+ Environment.NewLine + "" + Environment.NewLine + "Please check email for details ";

            string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + SMS_Email + "&subacct=" + SMSID + "&subacctpwd=" + SMS_Password + "&message=" + message + "&sender=" + SMS_Sender + "&sendto=" + Session["Phone"].ToString() + "&msgtype=0";
            System.Net.WebClient c = new System.Net.WebClient();
            var response = c.DownloadString(apicommand);


            string SMSMMM = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('SMS Message', '" + message + "', 'Automated','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
            insertRecord(SMSMMM);
        }

        //inform customer and redirect to finances
        MessageBox("Payment Received Successfully");
        Label8.Visible = true;
        Label8.Text = "Payment Received Successfully";
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "1;url=finances.aspx";
        this.Page.Controls.Add(meta);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Finances.aspx");
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
