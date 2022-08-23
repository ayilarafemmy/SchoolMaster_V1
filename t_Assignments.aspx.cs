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
            BindGrid();
            BindGrid1();
            string query = "select LID,MaterialType,Material,Subject,Uploadedby,Class,Description,Doc,filetype,Downloadcount,Expirydate from D_LMS where  Uploadedby='" + Session["StaffID"].ToString() + "' order by LID desc";
            GridviewBind(query);
        }
    }
    protected void BindGrid()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select ClassID,Class from D_Classes where Teacher='"+Session["StaffID"].ToString()+"' or AssistantTeacher='"+ Session["StaffID"].ToString() + "'";
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
            string com = "Select SubjectID,Subject from D_Subjects";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "Subject";
            DropDownList2.DataValueField = "SubjectID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("All Subjects", "0"));
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            MessageBox("Kindly enter Material");
            TextBox1.BorderColor = Color.Red;
            return;
        }

        if (DropDownList3.SelectedItem.Text == "Select Material Type")
        {
            MessageBox("Kindly Select Material Type");
            DropDownList3.BorderColor = Color.Red;
            return;
        }
        if (TextBox2.Text.Length < 20)
        {
            MessageBox("Kindly Provide Description");
            TextBox2.BorderColor = Color.Red;
            return;
        }
        if (TextBox3.Text == "")
        {
            MessageBox("Kindly Provide Expiry Date");
            TextBox3.BorderColor = Color.Red;
            return;
        }

        //validation ends
        //check file(passport)
        if (FileUpload1.HasFile)
        {
            string FileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
            string path = Server.MapPath("~/LMS/");
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
        SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        conx.Open();
        cmdx.CommandText = "select Material from D_LMS where Material='" + TextBox1.Text + "'";
        cmdx.Connection = conx;
        sdax.SelectCommand = cmdx;
        sdax.Fill(dsx, "D_LMS");

        if (dsx.Tables[0].Rows.Count > 0)
        {
            string myStringVariable = "Material with Name : " + TextBox1.Text + " already exists";
            TextBox1.BackColor = System.Drawing.Color.Red;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            return;

        }
        else
        {

        }
        conx.Close();


        string query = "insert into D_Lms (MaterialType,Material,Subject,Uploadedby,Class,Description,Doc,filetype,Downloadcount,Expirydate) values ('" + DropDownList3.SelectedItem.Text + "','" + TextBox1.Text + "','" + DropDownList2.SelectedItem.Text + "','" + Session["StaffID"].ToString() + "','" + DropDownList1.SelectedItem.Text + "','" + TextBox2.Text + "','" + Label2.Text + "','" + Label3.Text + "','0','" + TextBox3.Text + "')";
        insertRecord(query);

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
            string AdminMail = "Dear Admin, " + Environment.NewLine + " LMS Material Upload Alert ." + Environment.NewLine + "" + Environment.NewLine + " Material: " + TextBox1.Text + ", Type: " +    DropDownList3.SelectedItem.Text + " and Description:" + TextBox2.Text + "";
            SendMail(AdminEmail, AdminMail, "LMS Upload", ServerName, SenderEmail, Institution, Mail_Password, joe);

            string quee = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('LMS Upload', '"+ AdminMail + "', '"+Session["StaffID"].ToString()+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"')";
            insertRecord(quee);

        }
        //if (SendSMS == "Yes")
        //{
        //    var message = "Hi " + TextBox1.Text + "," + Environment.NewLine + " Welcome to the " + Institution+ " Portal" + Environment.NewLine + " Your Login details: " + Environment.NewLine + "URL: " + URL + "" + Environment.NewLine + "Username: Email: " + TextBox5.Text + " " + Environment.NewLine + " Password: Parent123" + Environment.NewLine + "" + Environment.NewLine + "Please check email for details ";

        //    string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + SMS_Email + "&subacct=" + SMSID + "&subacctpwd=" + SMS_Password + "&message=" + message + "&sender=" + SMS_Sender + "&sendto=" + TextBox7.Text + "&msgtype=0";
        //    System.Net.WebClient c = new System.Net.WebClient();
        //    var response = c.DownloadString(apicommand);


        //    string SMSMMM = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('SMS Message', '" + message + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
        //    insertRecord(SMSMMM);
        //}



        MessageBox("Upload Successful");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "1;url=t_Assignments.aspx";
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
        string qqy = "select LID,MaterialType,Material,Subject,Uploadedby,Class,Description,Doc,filetype,Downloadcount,Expirydate from D_LMS where Material like '%" + TextBox2a.Text + "%' or Subject like '%" + TextBox2a.Text + "%' OR Class like '%" + TextBox2a.Text + "%' and Uploadedby ='" + Session["StaffID"].ToString() + "'";
        GridviewBind(qqy);

        if (GridView1.Rows.Count == 0)
        {
            MessageBox("Your Search Returned No Result");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=t_assignments.aspx";
            this.Page.Controls.Add(meta); return;
        }
    }

}
