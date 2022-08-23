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


            string query = "select StaffID,FirstName,LastName,Gender,DOB,Role,SecondaryRole,Email,Phone,Profile,Bio from D_Staff";
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
        if (TextBox3.Text == "")
        {
            MessageBox("Kindly enter Staff Date of Birth");
            TextBox3.BorderColor = Color.Red;
            return;
        }
        if (TextBox8.Text.Length < 30)
        {
            MessageBox("Minimum 30 characters needed");
            TextBox8.BorderColor = Color.Red;
            return;
        }
        if (DropDownList1.SelectedItem.Text == "Select Gender")
        {
            MessageBox("Kindly select Students Gender");
            DropDownList1.BorderColor = Color.Red;
            return;
        }

        if (DropDownList2.SelectedItem.Text == "Select Staff Application Role")
        {
            MessageBox("Kindly Select Staff Application Role");
            DropDownList2.BorderColor = Color.Red;
            return;
        }
        if (DropDownList3.SelectedItem.Text == "Select Secondary Role")
        {
            MessageBox("Kindly Select Secondary Role");
            DropDownList3.BorderColor = Color.Red;
            return;
        }

        //CHECK IF STAFF exist
        string strt = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        SqlConnection con = new SqlConnection(strt);
        con.Open();
        string checkUser = "select Count(*) from D_Staff where email = '" + TextBox5.Text + "'";
        SqlCommand command = new SqlCommand(checkUser, con);
        int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        if (temp >= 1)
        {
            MessageBox("User  with Email" + TextBox5.Text + " Exists / is deactivated");
            return;
        }
        else
        {

        }

        con.Close();

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

            string path = Server.MapPath("~/Staff/");
            string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            string NewName = TextBox1.Text + "_" + DateTime.Now.ToString("ddMMyyHHmm");

            Label3.Text = extension;
            Label2.Text = NewName.ToString() + extension;
            FileUpload1.SaveAs(path + NewName + extension);

        }
        else
        {
            Label1.Visible = true;
            Label1.Text = "Please Select your file";
            Label1.ForeColor = System.Drawing.Color.Red;
            return;
        }

        //check if threshold is reached
        ////int all = int.Parse(Label4.Text);
        ////contx.Open();
        ////SqlCommand comm = new SqlCommand("SELECT COUNT(SID) FROM D_Students", contx);
        ////Int32 count = Convert.ToInt32(comm.ExecuteScalar());
        ////if (count >= all)
        ////{
        ////    MessageBox("You have reached the limit allowed on the platform, limit is " + all + "");
        ////    return;
        ////}
        ////else
        ////{

        ////}
        ////contx.Close();
        ////int jennifer = all - count;
        //add to Db & redirect to All Students
        if(TextBox5.Text =="")
        {
            MessageBox("Email Address is very compulsory");
            return;
        }
        string query = "insert into D_Staff (FirstName,LastName,Phone,Email,Role,SecondaryRole,FullAddress,CreateBy,CreateDate,Password,Profile,Gender,DOB,Bio) values ('"+TextBox1.Text+"','"+TextBox2.Text+"','"+ TextBox7.Text+ "','"+ TextBox5.Text+ "','"+ DropDownList2.SelectedValue+ "','"+ DropDownList3.SelectedValue+ "','','"+Session["StaffID"].ToString()+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"','123456','"+Label2.Text+"','"+DropDownList1.SelectedItem.Text+"','"+ TextBox3.Text+ "','"+ TextBox8.Text+ "')";
        insertRecord(query);
        //string query = "insert into D_Students (filetype,Admission_ID,Parent_ID,FirstName,LastName,Gender,DOB,Roll_No,BG,Religion,Email,Class,Section,Bio,Photo,Capture_Date,Capture_By,Password,LoginC) values ('" + Label3.Text + "','" + TextBox1.Text + "_" + DateTime.Now.ToString("ddMMyyHHss") + "','" + TextBox6.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList1.SelectedItem.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + DropDownList2.SelectedItem.Text + "','" + DropDownList3.SelectedItem.Text + "','" + TextBox5.Text + "','" + DropDownList4.SelectedValue + "','" + DropDownList5.SelectedValue + "','" + TextBox8.Text + "','" + Label2.Text + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + Session["StaffID"].ToString() + "','123456','0')";
        //insertRecord(query);

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
            string StaffMail = "Dear " + TextBox1.Text + "," + Environment.NewLine + "" + Environment.NewLine + " Welcome to the " + Institution + " School Management Platform" + Environment.NewLine + " We are so excited to have you onboard. Your Login Credentials are as below: " + Environment.NewLine + "" + Environment.NewLine + "WebPortal Address: " + URL + "" + Environment.NewLine + "Username: Email: " + TextBox5.Text + " " + Environment.NewLine + " Password: 123456" + Environment.NewLine + "" + Environment.NewLine + "On this platform you will be able to carry out functionalities based on your roles: "+DropDownList2.SelectedItem.Text+" and "+DropDownList3.SelectedItem.Text+". " + Environment.NewLine + "" + Environment.NewLine + " Welcome!!! ";
            SendMail(TextBox5.Text, StaffMail, "Staff SignUp - Important Details", ServerName, SenderEmail, Institution, Mail_Password, joe);

            string AdminMail = "Dear Admin, " + Environment.NewLine + " Staff Signup Alert ." + Environment.NewLine + "" + Environment.NewLine + " Name: " + TextBox1.Text + ", Email: " + TextBox5.Text + " and Phone:" + TextBox7.Text + "";
            SendMail(AdminEmail, AdminMail, "Staff Signup", ServerName, SenderEmail, Institution, Mail_Password, joe);

            string quee = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('Staff Registration', '"+StaffMail+"', '"+Session["StaffID"].ToString()+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"')";
            insertRecord(quee);

        }
        if (SendSMS == "Yes")
        {
            var message = "Hi " + TextBox1.Text + "," + Environment.NewLine + " Welcome to the " + Institution+ " Portal" + Environment.NewLine + " Your Login details: " + Environment.NewLine + "URL: " + URL + "" + Environment.NewLine + "Username: Email: " + TextBox5.Text + " " + Environment.NewLine + " Password: 12345" + Environment.NewLine + "" + Environment.NewLine + "Please check email for details ";

            string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + SMS_Email + "&subacct=" + SMSID + "&subacctpwd=" + SMS_Password + "&message=" + message + "&sender=" + SMS_Sender + "&sendto=" + TextBox7.Text + "&msgtype=0";
            System.Net.WebClient c = new System.Net.WebClient();
            var response = c.DownloadString(apicommand);


            string SMSMMM = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('SMS Message', '" + message + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
            insertRecord(SMSMMM);
        }



        MessageBox("Details Captured Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "1;url=admin_staff.aspx";
        this.Page.Controls.Add(meta);
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
        string qqy = "select StaffID,FirstName,LastName,Gender,DOB,Role,SecondaryRole,Email,Phone,Profile,Bio from D_Staff where FirstName like '%" + TextBox1.Text + "%' or LastName like '%" + TextBox1.Text + "%' OR StaffID like '%" + TextBox1.Text + "%'";
        GridviewBind(qqy);

        if (GridView1.Rows.Count == 0)
        {
            MessageBox("Your Search Returned No Result");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=Admin_Staff.aspx";
            this.Page.Controls.Add(meta); return;
        }
    }

}
