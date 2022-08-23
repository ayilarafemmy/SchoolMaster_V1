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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindGrid();
            BindGrid1();
            string query = "select top 30 Source, Destination, Amount, Description, Type, Purpose, TransDate, Balance, PaidBy, EnteredBy, EntryDate, Comment, SupportingDoc from D_Account order by ACID desc";
            GridviewBind(query);
        }
    }
    protected void BindGrid()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select ClassID,Class from D_Classes";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Class";
            DropDownList1.DataValueField = "ClassID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("All Classes", "0"));
            con.Close();
        }
    }
    protected void BindGrid1()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select PPID,Purpose from D_PaymentPurpose";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "Purpose";
            DropDownList2.DataValueField = "PPID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Select Payment Purpose", "0"));
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            MessageBox("Kindly enter Student ID or Payment Subject");
            TextBox1.BorderColor = Color.Red;
            return;
        }

        if (int.Parse(TextBox2.Text) < 100)
        {
            MessageBox("Minimum of 100 Naira is required");
            TextBox2.BorderColor = Color.Red;
            return;
        }
        if (TextBox3.Text == "")
        {
            MessageBox("Kindly Provide Transaction Date");
            TextBox3.BorderColor = Color.Red;
            return;
        }

        //validation ends
        //check file(passport)
        if (FileUpload1.HasFile)
        {
            string FileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
            string path = Server.MapPath("~/Transaction/");
            string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            string NewName = TextBox1.Text + "_" + DateTime.Now.ToString("ddMMyyHHmm");
            Label2.Text = NewName.ToString();
            Label3.Text = extension;
            FileUpload1.SaveAs(path + NewName + extension);
            if (FileUpload1.PostedFile.ContentLength >= 412345678)
            {
                MessageBox("This is a local server, max allowed is 41Mb, file upload is " + FileUpload1.PostedFile.ContentLength + "");
                return;
            }

        }
        else
        {
            Label1.Visible = true;
            Label1.Text = "Please Select your file";
            Label1.ForeColor = System.Drawing.Color.Red;
            return;
        }


        //check if Name exists
        SqlCommand cmdx = new SqlCommand();
        SqlDataAdapter sdax = new SqlDataAdapter();
        DataSet dsx = new DataSet();

        SqlCommand cmdy = new SqlCommand();
        SqlDataAdapter sday = new SqlDataAdapter();
        DataSet dsy = new DataSet();

        SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        conx.Open();
        cmdx.CommandText = "select Balance from D_CustomerConfig where DID='1'";
        cmdx.Connection = conx;
        sdax.SelectCommand = cmdx;
        sdax.Fill(dsx, "D_CustomerConfig");

        if (dsx.Tables[0].Rows.Count > 0)
        {
            string Bala = dsx.Tables[0].Rows[0]["Balance"].ToString();
            if(Bala =="")
            {
                Bala = "0";
            }
            Label5.Text = Bala;
        }
        conx.Close();

        int current = int.Parse(Label5.Text);
        int topay = int.Parse(TextBox2.Text);
        int tt = current + topay;
        int takeout = current - topay;

        if (DropDownList2.SelectedValue == "1" || DropDownList2.SelectedValue == "4" || DropDownList2.SelectedValue == "5" || DropDownList2.SelectedValue == "10" || DropDownList2.SelectedValue == "8")
        {
            //Get Parent ID, email and Phone and communicate
            conx.Open();
            cmdy.CommandText = "select a.Phone as Phone,a.email as email, a.first_Name as FirstName,a.Last_Name as LastName from D_Parents a,D_Students b where a.PID = b.Parent_ID and SID = '"+TextBox1.Text+"';";
            cmdy.Connection = conx;
            sday.SelectCommand = cmdy;
            sday.Fill(dsy, "D_Parents");

            if (dsy.Tables[0].Rows.Count == 1)
            {
                Label6.Text = "First Name : " + dsy.Tables[0].Rows[0]["FirstName"].ToString();
                Label7.Text = "Last Name : " + dsy.Tables[0].Rows[0]["LastName"].ToString();
                Label8.Text = dsy.Tables[0].Rows[0]["email"].ToString();
                Label9.Text = dsy.Tables[0].Rows[0]["Phone"].ToString();
                Label6.Visible = true;
                Label7.Visible = true;
            }
            else
            {
                Label6.Visible = false;
                Label7.Visible = false;

                MessageBox("Kindly confirm the student ID provided is correct!");
                TextBox1.BorderColor = Color.Red;
                return;
            }
            conx.Close();
            string kk = "" + TextBox4.Text + ", " + Label6.Text + ", " + Label7.Text + "";
            string query = "insert into D_Account (Source,Destination,Amount,Description,Type,Purpose,TransDate,Balance,PaidBy,EnteredBy,EntryDate,Comment,SupportingDoc) values ('" + TextBox1.Text + "','inflow','" + TextBox2.Text + "','" + kk + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.Text + "','" + TextBox3.Text + "','" + tt + "','" + TextBox1.Text + "','" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','Comment','" + Label2.Text + "')";
            insertRecord(query);

            string balancd = "Update D_CustomerConfig set Balance='" + tt + "' where DID='1'";
            insertRecord(balancd);


            if (sendmail == "Yes")
            {
                int joe = int.Parse(ServerPort);
                string AdminMail = "Dear Admin, " + Environment.NewLine + " Inflow Capture Alert ." + Environment.NewLine + "" + Environment.NewLine + " Payee: " + TextBox1.Text + "," + Environment.NewLine + " Amount: " + TextBox2.Text + " and Description:" + kk + "";
                SendMail(AdminEmail, AdminMail, "Inflow Capture Alert", ServerName, SenderEmail, Institution, Mail_Password, joe);

                string Parent = "Dear Parent, " + Environment.NewLine + " Payment Alert ." + Environment.NewLine + "" + Environment.NewLine + " Amount: " + TextBox2.Text + ", " + Environment.NewLine + "Purpose: " + DropDownList2.SelectedItem.Text + " " + Environment.NewLine + "Student ID: " + TextBox1.Text + " " + Environment.NewLine + "and Description:" + TextBox4.Text + " ";
                SendMail(Label8.Text, Parent, "Payment Alert", ServerName, SenderEmail, Institution, Mail_Password, joe);

                string quee = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('Parent Registration', '" + AdminMail + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                insertRecord(quee);

            }
            if (SendSMS == "Yes")
            {
                var message = "Dear Parent," + Environment.NewLine + " Thanks for Paying to " + Institution + "" + Environment.NewLine + "" + Environment.NewLine + "For: " + DropDownList2.SelectedItem.Text + "" + Environment.NewLine + "Amount: " + TextBox2.Text + " " + Environment.NewLine + " Student ID: " + TextBox1.Text + "" + Environment.NewLine + "" + Environment.NewLine + "Please check email for details ";

                string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + SMS_Email + "&subacct=" + SMSID + "&subacctpwd=" + SMS_Password + "&message=" + message + "&sender=" + SMS_Sender + "&sendto=" + Label9.Text + "&msgtype=0";
                System.Net.WebClient c = new System.Net.WebClient();
                var response = c.DownloadString(apicommand);


                string SMSMMM = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('SMS Message', '" + message + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                insertRecord(SMSMMM);
            }

        }
        else
        {
            string query = "insert into D_Account (Source,Destination,Amount,Description,Type,Purpose,TransDate,Balance,PaidBy,EnteredBy,EntryDate,Comment,SupportingDoc) values ('" + TextBox1.Text + "','Expenses','" + TextBox2.Text + "','" + TextBox4.Text + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList2.Text + "','" + TextBox3.Text + "','" + tt + "','" + TextBox1.Text + "','" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','Comment','" + Label2.Text + "')";
            insertRecord(query);

            string balancd = "Update D_CustomerConfig set Balance='" + takeout + "' where DID='1'";
            insertRecord(balancd);


            if (sendmail == "Yes")
            {
                int joe = int.Parse(ServerPort);
                string AdminMail = "Dear Admin, " + Environment.NewLine + " Outflow Capture Alert ." + Environment.NewLine + "" + Environment.NewLine + " Payee: " + TextBox1.Text + "," + Environment.NewLine + " Amount: " + TextBox2.Text + " and Description:" + TextBox4.Text + "";
                SendMail(AdminEmail, AdminMail, "Outflow Capture Alert", ServerName, SenderEmail, Institution, Mail_Password, joe);


                string quee = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('Parent Registration', '" + AdminMail + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                insertRecord(quee);

            }

        }


        MessageBox("Capture Successful");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=Admin_AccountsIN.aspx";
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
        string qqy = "Source,Destination,Amount,Description,Type,Purpose,TransDate,Balance,PaidBy,EnteredBy,EntryDate,Comment,SupportingDoc from D_Account where Source like '%" + TextBox2a.Text + "%' or Purpose like '%" + TextBox2a.Text + "%' OR TransDate like '%" + TextBox2a.Text + "%'";
        GridviewBind(qqy);

        if (GridView1.Rows.Count == 0)
        {
            MessageBox("Your Search Returned No Result");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=Admin_AccountsIN.aspx";
            this.Page.Controls.Add(meta); return;
        }
    }




    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DropDownList2.SelectedValue=="0")
        {
            Button1.Visible = false;
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
        }
        else
        {
            Button1.Visible = true;
            TextBox1.Enabled = true;
            TextBox2.Enabled = true;
        }
        if (DropDownList2.SelectedValue == "1" || DropDownList2.SelectedValue == "4" || DropDownList2.SelectedValue == "5" || DropDownList2.SelectedValue == "10" || DropDownList2.SelectedValue == "8")
        {
            Label4.Text = "Student ID";
        }
        else
        {
            Label4.Text = "Payment Subject";
        }
    }
}
