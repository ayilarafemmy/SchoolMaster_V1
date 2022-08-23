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

public partial class Admin_Students : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string query = "select PID,First_Name,Last_Name,Gender,Relationship,Religion,email,Phone,Alternate_Phone,Full_Address,Comments,Identity_Upload,Capture_Date,Capture_By,FirstLogin from D_Parents";
            GridviewBind(query);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            MessageBox("Kindly enter Staff First Name");
            TextBox1.BorderColor = Color.Red;
            return;
        }
        if (TextBox2.Text == "")
        {
            MessageBox("Kindly enter Staff Last Name");
            TextBox2.BorderColor = Color.Red;
            return;
        }
        if (TextBox8.Text.Length < 8)
        {
            MessageBox("Minimum 8 characters needed");
            TextBox8.BorderColor = Color.Red;
            return;
        }
        if (DropDownList1.SelectedItem.Text == "Select Gender")
        {
            MessageBox("Kindly select Students Gender");
            DropDownList1.BorderColor = Color.Red;
            return;
        }

        if (DropDownList2.SelectedItem.Text == "Select Relationship")
        {
            MessageBox("Kindly Select Relationship");
            DropDownList2.BorderColor = Color.Red;
            return;
        }
        if (DropDownList3.SelectedItem.Text == "Select Religion")
        {
            MessageBox("Kindly Select Religion");
            DropDownList3.BorderColor = Color.Red;
            return;
        }

        string strt = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        SqlConnection con = new SqlConnection(strt);
        con.Open();
        string checkUser = "select Count(*) from D_Parents where email = '" + TextBox5.Text + "'";
        SqlCommand command = new SqlCommand(checkUser, con);
        int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        if (temp >= 1)
        {
            MessageBox("Parent  with Email" + TextBox5.Text + " Exists / is deactivated");
            return;
        }
        else
        {


            //validation ends
            //check file(passport)
            if (FileUpload1.HasFile)
            {
                string FileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);

                if (FileExtention == ".jpg" || FileExtention == ".png" || FileExtention == ".jpeg" || FileExtention == ".JPG")
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
                string NewName = TextBox1.Text + "_" + DateTime.Now.ToString("ddMMyyHHmm");
                Label2.Text = NewName.ToString();
                Label3.Text = extension;
                FileUpload1.SaveAs(path + NewName + extension);

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Please Select your file";
                Label1.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (TextBox5.Text == "")
            {
                MessageBox("Email Address is very compulsory");
                return;
            }
            if (TextBox7.Text == "")
            {
                MessageBox("Phone Number is very compulsory");
                return;
            }

            //check if parent exists
            SqlCommand cmdx = new SqlCommand();
            SqlDataAdapter sdax = new SqlDataAdapter();
            DataSet dsx = new DataSet();
            SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            conx.Open();
            cmdx.CommandText = "select Email from D_Parents where Email='" + TextBox5.Text + "' OR Phone ='" + TextBox7.Text + "'";
            cmdx.Connection = conx;
            sdax.SelectCommand = cmdx;
            sdax.Fill(dsx, "D_Parents");

            if (dsx.Tables[0].Rows.Count > 0)
            {
                string myStringVariable = "Parent with Email : " + TextBox5.Text + " or Phone : " + TextBox7.Text + " already exists";
                TextBox5.BackColor = System.Drawing.Color.Red;
                TextBox7.BackColor = System.Drawing.Color.Red;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                return;

            }
            else
            {

            }
            conx.Close();


            string insert = "Insert into D_Parents (filetype,First_Name,Last_Name,Gender,Relationship,Religion,email,Phone,Alternate_Phone,Full_Address,Comments,Identity_Upload,Capture_Date,Capture_By,Password,FirstLogin) values ('" + Label3.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "','" + DropDownList3.SelectedItem.Text + "','" + TextBox5.Text + "','" + TextBox7.Text + "','" + TextBox3.Text + "','" + TextBox8.Text + "','" + TextBox4.Text + "','" + Label2.Text + "','" + DateTime.Now.AddHours(5).ToString("dd/MM/yyyy") + "','" + Session["StaffID"].ToString() + "','Parent123','0')";
            insertRecord(insert);

            //pick messaging parameters from webconfig
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
                string StaffMail = "Dear " + TextBox1.Text + "," + Environment.NewLine + "" + Environment.NewLine + " Welcome to the " + Institution + " School Management Platform" + Environment.NewLine + " We are so excited to have you onboard. Your Login Credentials are as below: " + Environment.NewLine + "" + Environment.NewLine + "WebPortal Address: " + URL + "" + Environment.NewLine + "Username: Email: " + TextBox5.Text + " " + Environment.NewLine + " Password: Parent123" + Environment.NewLine + "" + Environment.NewLine + "On this platform you will be able to monitor the progress of your Child(ren),reach out to the school, get the latest information, make payments etc.  " + Environment.NewLine + "" + Environment.NewLine + " Welcome!!! ";
                SendMail(TextBox5.Text, StaffMail, "Parent SignUp - Important Details", ServerName, SenderEmail, Institution, Mail_Password, joe);

                string AdminMail = "Dear Admin, " + Environment.NewLine + " Parent Signup Alert ." + Environment.NewLine + "" + Environment.NewLine + " Name: " + TextBox1.Text + ", Email: " + TextBox5.Text + " and Phone:" + TextBox7.Text + "";
                SendMail(AdminEmail, AdminMail, "Parent Signup", ServerName, SenderEmail, Institution, Mail_Password, joe);

                string quee = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('Parent Registration', '" + StaffMail + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                insertRecord(quee);

            }
            if (SendSMS == "Yes")
            {
                var message = "Hi " + TextBox1.Text + "," + Environment.NewLine + " Welcome to the " + Institution + " Portal" + Environment.NewLine + " Your Login details: " + Environment.NewLine + "URL: " + URL + "" + Environment.NewLine + "Username: Email: " + TextBox5.Text + " " + Environment.NewLine + " Password: Parent123" + Environment.NewLine + "" + Environment.NewLine + "Please check email for details ";

                string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + SMS_Email + "&subacct=" + SMSID + "&subacctpwd=" + SMS_Password + "&message=" + message + "&sender=" + SMS_Sender + "&sendto=" + TextBox7.Text + "&msgtype=0";
                System.Net.WebClient c = new System.Net.WebClient();
                var response = c.DownloadString(apicommand);


                string SMSMMM = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('SMS Message', '" + message + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                insertRecord(SMSMMM);
            }



            MessageBox("Details Captured Successfully");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "1;url=Admin_Parents.aspx";
            this.Page.Controls.Add(meta);
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
                GridView1.DataSource = dr;
                GridView1.DataBind();
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


    protected void Button2_Click(object sender, EventArgs e)
    {
        string qqy = "select PID,First_Name,Last_Name,Gender,Relationship,Religion,email,Phone,Alternate_Phone,Full_Address,Comments,Identity_Upload,Capture_Date,Capture_By,FirstLogin from D_Parents where First_Name like '%" + TextBox2a.Text + "%' or Last_Name like '%" + TextBox2a.Text + "%' OR email like '%" + TextBox2a.Text + "%' OR PID like '%" + TextBox1.Text + "%' OR Phone like '%" + TextBox2a.Text + "%'";
        GridviewBind(qqy);

        if (GridView1.Rows.Count == 0)
        {
            MessageBox("Your Search Returned No Result");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=Admin_Parents.aspx";
            this.Page.Controls.Add(meta); return;
        }
    }

}
