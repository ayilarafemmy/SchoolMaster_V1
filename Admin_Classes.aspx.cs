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
            BindGrid2();
            string query = "select a.ClassID,a.Class as GeneralClass,a.CreateBy,a.CreateDate,b.Section,a.FClass as Class,CONCAT(c.FirstName, ' ', c.LastName) as Teacher,CONCAT(c.FirstName, ' ', c.LastName) as AssistantTeacher,a.RollNo from D_Classes a, D_Sections b, D_Staff c where a.Teacher=c.StaffID and a.AssistantTeacher = c.StaffID";
            GridviewBind(query);
        }
    }
    protected void BindGrid()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select SectionsID,Section from D_Sections";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Section";
            DropDownList1.DataValueField = "SectionsID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select Section", "0"));
            con.Close();
        }
    }
    protected void BindGrid1()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select StaffID, Concat(FirstName,LastName) as FullName from D_Staff where secondaryrole='Teacher'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "FullName";
            DropDownList2.DataValueField = "StaffID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("None for Now", "0"));
            con.Close();
        }
    }
    protected void BindGrid2()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select StaffID, Concat(FirstName,LastName) as FullName from D_Staff where secondaryrole='Teacher'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList4.DataSource = dt;
            DropDownList4.DataBind();
            DropDownList4.DataTextField = "FullName";
            DropDownList4.DataValueField = "StaffID";
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, new ListItem("None for Now", "0"));
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            MessageBox("Kindly enter Class");
            TextBox1.BorderColor = Color.Red;
            return;
        }


        if (TextBox3.Text == "")
        {
            MessageBox("Kindly Provide Ensure all Details are entered");
            TextBox3.BorderColor = Color.Red;
            return;
        }


        //check if Name exists
        SqlCommand cmdx = new SqlCommand();
        SqlDataAdapter sdax = new SqlDataAdapter();
        DataSet dsx = new DataSet();
        SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        conx.Open();
        cmdx.CommandText = "select FClass from D_Classes where FClass='" + TextBox3.Text + "'";
        cmdx.Connection = conx;
        sdax.SelectCommand = cmdx;
        sdax.Fill(dsx, "D_Classes");

        if (dsx.Tables[0].Rows.Count > 0)
        {
            string myStringVariable = "Class : " + TextBox3.Text + " already exists";
            TextBox1.BackColor = System.Drawing.Color.Red;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            return;

        }
        else
        {

        }
        conx.Close();


        string query = "insert into D_Classes (Class,CreateBy,CreateDate,Section,FClass,Teacher,AssistantTeacher,RollNo) values ('" + TextBox1.Text+"','"+Session["StaffID"].ToString()+"','"+DateTime.Now.ToString("dd/MM/yyyy")+ "','" + DropDownList1.SelectedValue + "','"+TextBox3.Text+"','"+DropDownList2.SelectedValue+"','"+DropDownList4.SelectedValue+"','0')";
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
            string AdminMail = "Dear Admin, " + Environment.NewLine + " Class Creation Alert ." + Environment.NewLine + "" + Environment.NewLine + " Class: " + TextBox3.Text + ", Session: " +    DropDownList1.SelectedItem.Text + "";
            SendMail(AdminEmail, AdminMail, "Class Creation", ServerName, SenderEmail, Institution, Mail_Password, joe);

            string quee = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('Class Creation', '"+ AdminMail + "', '"+Session["StaffID"].ToString()+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"')";
            insertRecord(quee);

        }



        MessageBox("Created Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "1;url=Admin_Classes.aspx";
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
        string qqy = "select a.ClassID,a.Class as GeneralClass,a.CreateBy,a.CreateDate,b.Section,a.FClass as Class,Teacher,AssistantTeacher,RollNo from D_Classes a, D_Sections b where a.Section = b.SectionsID and GeneralClass like '%" + TextBox2a.Text + "%' or Class like '%" + TextBox2a.Text + "%' OR AssistantTeacher like '%" + TextBox2a.Text + "%'";
        GridviewBind(qqy);

        if (GridView1.Rows.Count == 0)
        {
            MessageBox("Your Search Returned No Result");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=Admin_LMS.aspx";
            this.Page.Controls.Add(meta); return;
        }
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DropDownList1.SelectedItem.Text== "Select Section")
        {
            TextBox3.Text = "";
        }
        else
        {
            TextBox3.Text = ""+TextBox1.Text+"-"+DropDownList1.SelectedItem.Text+"";
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        if(TextBox1.Text.Length < 3)
        {
            DropDownList1.Enabled = false;
        }
        else
        {
            DropDownList1.Enabled = true;
        }
    }
}
