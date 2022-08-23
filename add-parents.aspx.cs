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

public partial class admit_form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["Email"])))
            {
                Response.Redirect("Default.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }

            if (Session["Email"] != null)
            {


            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        catch (Exception pp)
        {
        }


        if (!IsPostBack)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlConnection cont = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            cont.Open();
            cmd.CommandText = "select * from D_CustomerConfig where DID=" + ConfigurationManager.AppSettings["DID"] + "";
            cmd.Connection = cont;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "CustomerConfig");
            Label2.Text = ds.Tables[0].Rows[0]["ServerName"].ToString();
            Label3.Text = ds.Tables[0].Rows[0]["SenderEmail"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["SMS_ID"].ToString();
            Label5.Text = ds.Tables[0].Rows[0]["ServerPort"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["Mail_Password"].ToString();
            Label7.Text = ds.Tables[0].Rows[0]["School"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["Sms_Sender"].ToString();
            Label9.Text = ds.Tables[0].Rows[0]["SendSMS"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["SendEmail"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["Admin_URL"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["SMS_Email"].ToString();
            Label14.Text = ds.Tables[0].Rows[0]["SMS_Password"].ToString();
            cont.Close();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string FileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);

            if (FileExtention == ".jpg" || FileExtention == ".png" || FileExtention == ".jpeg")
            {

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Only PNG & JPG Files are allowed";
                Label1.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string path = Server.MapPath("~/Parents/");
            string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            string NewName = TextBox1.Text + "_" + TextBox2.Text + "_" + DateTime.Now.ToString("ddMMyyHHmm");
            Label11.Text = NewName.ToString();
            Label15.Text = extension;
            FileUpload1.SaveAs(path + NewName + extension);

        }
        else
        {
            Label1.Visible = true;
            Label1.Text = "Please Select your file";
            Label1.ForeColor = System.Drawing.Color.Red;
            return;
        }

        //validate texts
        if(TextBox1.Text.Length < 3)
        {
            MessageBox("Kindly Provide Your First Name");
            TextBox1.BorderColor = Color.Red;
            return;
        }
        if (TextBox2.Text.Length < 3)
        {
            MessageBox("Kindly Provide Your Last Name");
            TextBox2.BorderColor = Color.Red;
            return;
        }
        if (DropDownList1.SelectedItem.Text =="Select Gender")
        {
            MessageBox("Kindly Provide Select Gender");
            DropDownList1.BorderColor = Color.Red;
            return;
        }
        if (DropDownList6.SelectedItem.Text == "Select Relationship")
        {
            MessageBox("Kindly Provide Select Relationship");
            DropDownList6.BorderColor = Color.Red;
            return;
        }
        if (DropDownList3.SelectedItem.Text == "Select Religion")
        {
            MessageBox("Kindly Provide Select Religion");
            DropDownList3.BorderColor = Color.Red;
            return;
        }
        if (TextBox5.Text.Length < 6)
        {
            MessageBox("Kindly Provide Your Email");
            TextBox5.BorderColor = Color.Red;
            return;
        }
        if (TextBox6.Text.Length < 11)
        {
            MessageBox("Kindly Provide Your Phone Number, minimum of 11 Digits e.g 08058000848");
            TextBox6.BorderColor = Color.Red;
            return;
        }
        if (TextBox7.Text.Length < 22)
        {
            MessageBox("Kindly Provide Your Full Address");
            TextBox7.BorderColor = Color.Red;
            return;
        }
        //check if parent exists
        SqlCommand cmdx = new SqlCommand();
        SqlDataAdapter sdax = new SqlDataAdapter();
        DataSet dsx = new DataSet();
        SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        conx.Open();
        cmdx.CommandText = "select Email from D_Parents where Email='" + TextBox5.Text + "' OR Phone ='" + TextBox6.Text + "'";
        cmdx.Connection = conx;
        sdax.SelectCommand = cmdx;
        sdax.Fill(dsx, "D_Parents");

        if (dsx.Tables[0].Rows.Count > 0)
        {
            string myStringVariable = "Parent with Email : " + TextBox5.Text + " or Phone : "+TextBox6.Text+" already exists";
            TextBox5.BackColor = System.Drawing.Color.Red;
            TextBox6.BackColor = System.Drawing.Color.Red;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            return;

        }
        else
        {

        }
        conx.Close();



        //log data to DB
        string password = CreateRandomPassword(3) + CreateRandomPassword1(3);
        string insert = "Insert into D_Parents (filetype,First_Name,Last_Name,Gender,Relationship,Religion,email,Phone,Alternate_Phone,Full_Address,Comments,Identity_Upload,Capture_Date,Capture_By,Password,FirstLogin) values ('"+ Label15.Text + "','" + TextBox1.Text+ "','" + TextBox2.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList6.SelectedItem.Text + "','" + DropDownList3.SelectedItem.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox3.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','"+ Label11.Text + "','"+DateTime.Now.AddHours(5).ToString("dd/MM/yyyy")+"','"+Session["StaffID"].ToString()+"','"+ password + "','0')";
        insertRecord(insert);
        string log = "insert into D_logs (Activity,Details,Done_By,Capturetime) values ('Parent Registration','Parent "+TextBox1.Text+" with Phone "+TextBox6.Text+" Captured successfully','"+ Session["StaffID"].ToString() + "','"+DateTime.Now.AddHours(5).ToString()+"')";
        insertRecord(log);
        ////check if sms and mails are to be sent
        //mail check
        if(Label10.Text =="Yes")
        {
            int joe = int.Parse(Label5.Text);
            string ParentMail = "Dear "+TextBox1.Text+","+Environment.NewLine+ "" + Environment.NewLine + " Welcome to the " + Label7.Text + " School Management Platform"+Environment.NewLine+" We are so excited to have you onboard. Your Login Credentials are as below: "+Environment.NewLine+""+Environment.NewLine+"URL: "+ Label12.Text + ""+Environment.NewLine+"Username: Email: "+TextBox5.Text+" "+Environment.NewLine+" Password: "+ password + ""+Environment.NewLine+""+Environment.NewLine+"On this platform you will be able to monitor the progress of your Child(ren),reach out to the school, get the latest information, make payments etc. "+Environment.NewLine+""+Environment.NewLine+" Welcome!!! ";
            SendMail(TextBox5.Text,ParentMail,"Welcome to "+Label7.Text+"",Label2.Text,Label3.Text,""+Label7.Text+"",Label6.Text,joe);

            string AdminMail = "Dear Admin, "+Environment.NewLine+" Parent Signup Alert ."+Environment.NewLine+""+Environment.NewLine+" Name: "+TextBox1.Text+", Email: "+TextBox5.Text+" and Phone:"+TextBox6.Text+"";
            SendMail(Label3.Text, AdminMail, "Parent SignUp", Label2.Text, Label3.Text, Label3.Text, Label6.Text, joe);
        }
        if (Label9.Text == "Yes")
        {

            int joe = int.Parse(Label5.Text);
            var message = "Hi " + TextBox1.Text + "," + Environment.NewLine + " Welcome to the " + Label7.Text + "" + Environment.NewLine + " Your Login details: " + Environment.NewLine + "URL: " + Label12.Text + "" + Environment.NewLine + "Username: Email: " + TextBox5.Text + " " + Environment.NewLine + " Password: " + password + "" + Environment.NewLine + "" + Environment.NewLine + "Please check email for details ";

            string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + Label13.Text + "&subacct=" + Label4.Text + "&subacctpwd=" + Label14.Text + "&message=" + message + "&sender=" + Label8 + "&sendto=" + TextBox6.Text + "&msgtype=0";
            System.Net.WebClient c = new System.Net.WebClient();
            var response = c.DownloadString(apicommand);
        }

        Label1.Visible = true;
        Label1.Text = "Details Captured Successfully";
        Label1.ForeColor = System.Drawing.Color.ForestGreen;

        MessageBox("Details Captured Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "2;url=add-parents.aspx";
        this.Page.Controls.Add(meta);


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
    public static string CreateRandomPassword1(int PasswordLength)

    {

        string _allowedChars = "ABCDEFGHJKLMNOPQRSTVWXYZ";

        Random randNum = new Random();

        char[] chars = new char[PasswordLength];

        int allowedCharCount = _allowedChars.Length;

        for (int i = 0; i < PasswordLength; i++)

        {

            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];

        }

        return new string(chars);

    }
    public static string CreateRandomPassword(int PasswordLength)

    {

        string _allowedChars = "123456789";

        Random randNum = new Random();

        char[] chars = new char[PasswordLength];

        int allowedCharCount = _allowedChars.Length;

        for (int i = 0; i < PasswordLength; i++)

        {

            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];

        }

        return new string(chars);

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
}
