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
using System.Text;
using System.IO;

public partial class Admin_Students : System.Web.UI.Page
{
    SqlCommand cmdj = new SqlCommand();
    SqlConnection conj = new SqlConnection();
    SqlDataAdapter sdaj = new SqlDataAdapter();
    DataSet dsj = new DataSet();

    SqlCommand cmdk = new SqlCommand();
    SqlConnection conk = new SqlConnection();
    SqlDataAdapter sdak = new SqlDataAdapter();
    DataSet dsk = new DataSet();

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
        if (string.IsNullOrEmpty(Convert.ToString(Session["Email"])))
        {
            Response.Redirect("admin.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }


        if (!IsPostBack)
        {

            //BindGrid();
           BindGrid2();
        }
    }

    protected void BindGrid1(string query,string field,string value)
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = query;
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataBind();
            DropDownList3.DataTextField = field;
            DropDownList3.DataValueField = value;
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("Select New Service", "0"));
            con.Close();
        }
    }
    protected void BindGrid1a(string query, string field, string value)
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = query;
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList5.DataSource = dt;
            DropDownList5.DataBind();
            DropDownList5.DataTextField = field;
            DropDownList5.DataValueField = value;
            DropDownList5.DataBind();
            DropDownList5.Items.Insert(0, new ListItem("Select New Service", "0"));
            con.Close();
        }
    }
    protected void BindGrid2()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select Fclass,ClassID from D_Classes";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Fclass";
            DropDownList1.DataValueField = "ClassID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select Class", "0"));
            con.Close();
        }
    }


    protected void BindGrid3()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select SID, CONCAT(FirstName,' ',LastName) as Student from D_Students where class ='" + DropDownList1.SelectedValue + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "Student";
            DropDownList2.DataValueField = "SID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Select Student", "0"));
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Select Class")
        {
            MessageBox("Kindly Select Class");
            DropDownList1.BorderColor = Color.Red;
            return;
        }
        if (DropDownList2.SelectedItem.Text == "Select Student")
        {
            MessageBox("Kindly Select Student");
            DropDownList2.BorderColor = Color.Red;
            return;
        }
        if (DropDownList4.SelectedItem.Text == "Select Service")
        {
            MessageBox("Kindly Select Service");
            DropDownList4.BorderColor = Color.Red;
            return;
        }


        if (TextBox3.Text.Length < 2)
        {
            MessageBox("Kindly provide Comments");
            return;
        }

        if (DropDownList4.SelectedItem.Text == "Class")
        {
            //update history of students
            //string inserto = "insert into ";
            //assign new class
            if (DropDownList3.SelectedItem.Text == "Select  New Service")
            {
                MessageBox("Kindly Select New Service");
                DropDownList3.BorderColor = Color.Red;
                return;
            }
            string jj = "Update D_Students set class='"+DropDownList3.SelectedValue+"' where SID='"+DropDownList2.SelectedValue+"'";
            insertRecord(jj);

            string jjs = "insert into D_Logs (Activity,Details,Done_By,Capturetime) values ('Class Change for:"+DropDownList2.SelectedValue+"','Old class"+DropDownList1.SelectedItem.Text+", New Class: "+DropDownList3.SelectedItem.Text+"','"+Session["StaffID"].ToString()+"','"+DateTime.Now.ToString("dd/MM/yyyy hh:mm:yyyy")+"')";
            insertRecord(jjs);

        }
        if (DropDownList4.SelectedItem.Text == "Transport")
        {
            //assign new route to student
            if (DropDownList5.SelectedItem.Text == "Select  New Service")
            {
                MessageBox("Kindly Select New Service");
                DropDownList5.BorderColor = Color.Red;
                return;
            }
            string students = "Update D_Students set RouteID = '"+DropDownList5.SelectedValue+"' where SID='"+DropDownList2.SelectedValue+"'";
            insertRecord(students);

            string jjs = "insert into D_Logs (Activity,Details,Done_By,Capturetime) values ('Route Change for:" + DropDownList2.SelectedValue + "','New Route: " + DropDownList5.SelectedItem.Text + "','" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:yyyy") + "')";
            insertRecord(jjs);

        }

        //string insert = "Insert into D_LineItem(Description,Amount,InvoiceID,Item,LineTotal,Quantity) values ('" + TextBox3.Text+"','"+TextBox7.Text+"','"+Label4.Text+"','"+DropDownList3.SelectedItem.Text+"','"+TextBox4.Text+"','"+DropDownList5.SelectedItem.Text+"')";
        //insertRecord(insert);


        MessageBox("Details Captured Successfully");
        //string query = "select LineID,Item,Quantity,Amount,Description,LineTotal from D_LineItem where InvoiceID = '" + Label4.Text+"'";
        //GridviewBind(query);
        if(GridView1.Rows.Count >=1)
        {
            Label5.Visible = false;
            Button2.Visible = true;
        }
        else
        {
            Label5.Visible = false;
            Button2.Visible = false;
        }
        TextBox3.Text = "";
        DropDownList3.SelectedItem.Text = "Select Purpose";


    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
        {
            (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        }
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int LineID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        string constr = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM D_LineItem WHERE LineID = @LineID"))
            {
                cmd.Parameters.AddWithValue("@LineID", LineID);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //string query = "select LineID,Item,Quantity,Amount,Description,LineTotal from D_LineItem where InvoiceID = '" + Label4.Text + "'";
        //GridviewBind(query);
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



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get phone number of driver
        if (DropDownList1.SelectedItem.Text == "Select Class")
        {
            DropDownList2.SelectedValue = "0";

        }
        else
        {
             BindGrid3();
            if(DropDownList2.Items.Count < 2)
            {
                MessageBox("Class " + DropDownList1.SelectedItem.Text + " has no students");
                DropDownList1.BorderColor = Color.Red;
                return;
            }
            else
            {
                DropDownList2.Enabled = true;
            }

        }

    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedItem.Text == "Select Student")
        {
            DropDownList3.Enabled = false;


        }
        else
        {
            DropDownList3.Enabled = true;
               }
    }



    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DropDownList3.SelectedItem.Text== "Select Purpose")
        {

        }
        else
        {

        }
    }



    protected void Button2_Click(object sender, EventArgs e)
    {

        if (GridView1.Rows.Count < 1)
        {
            MessageBox("You need to generate line items!");
            return;
        }
        //validate
        if (DropDownList4.SelectedItem.Text == "Select Term")
        {
            MessageBox("Kindly select Term");
            return;
        }
        if (DropDownList1.SelectedItem.Text == "Select Class")
        {
            MessageBox("Kindly select Class");
            return;
        }
        if (DropDownList2.SelectedItem.Text == "Select Student")
        {
            MessageBox("Kindly select Student");
            return;
        }
        //   get parent details

        SqlConnection conj = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        conj.Open();
        cmdj.CommandText = "select a.PID, CONCAT(a.First_Name,' ',a.Last_Name) as Parent, a.email,a.Phone, b.SID, b.Roll_No, CONCAT(b.FirstName,' ',b.LastName) as Student,b.Balance,c.FClass from D_Parents a, D_Students b,D_Classes c where a.PID = b.Parent_ID and b.SID='" + DropDownList2.SelectedValue + "' and c.ClassID=b.Class";
        cmdj.Connection = conj;
        sdaj.SelectCommand = cmdj;
        sdaj.Fill(dsj, "D_Students");

        if (dsj.Tables[0].Rows.Count == 1)
        {
            Label8.Text = dsj.Tables[0].Rows[0]["PID"].ToString();
            Label9.Text = dsj.Tables[0].Rows[0]["Parent"].ToString();
            Label10.Text = dsj.Tables[0].Rows[0]["email"].ToString();
            Label11.Text = dsj.Tables[0].Rows[0]["Phone"].ToString();
            Label12.Text = dsj.Tables[0].Rows[0]["Roll_No"].ToString();
            Label13.Text = dsj.Tables[0].Rows[0]["Student"].ToString();
            Label7.Text = dsj.Tables[0].Rows[0]["Balance"].ToString();
            Label14.Text = dsj.Tables[0].Rows[0]["FClass"].ToString();
        }
        else
        {
            MessageBox("Bill cannot be sent for student " + DropDownList2.SelectedItem.Text + ", Parent may not be well provisioned");
            return;
        }
        conj.Close();

        //get amount Due
        SqlConnection conk = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        conk.Open();
        //cmdk.CommandText = "SELECT sum(CAST(amount AS int)) as Amount FROM D_LineItem where InvoiceID='" + + "'";
        cmdk.Connection = conk;
        sdak.SelectCommand = cmdk;
        sdak.Fill(dsk, "D_LineItem");

        if (dsk.Tables[0].Rows.Count == 1)
        {
            Label6.Text = dsk.Tables[0].Rows[0]["Amount"].ToString();
        }
        conk.Close();


        //enter data
        //string jj = "Insert into D_Invoice (InvoiceID,Term,StudentID,Dateraised,Notes,Total,EnteredBy) values ('" + Label4.Text + "','" + DropDownList4.SelectedValue + "','" + DropDownList2.SelectedValue + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + TextBox2.Text + "','" + Label6.Text + "','" + Session["StaffID"].ToString() + "')";
        //insertRecord(jj);
        //update student accoutnBalance
        if (Label7.Text == "")
        {
            Label7.Text = "0";
        }
        int balance = int.Parse(Label7.Text);
        int Newmoney = int.Parse(Label6.Text);
        int newbalance = balance + Newmoney;

        Label16.Text = Newmoney.ToString();
        Label17.Text = newbalance.ToString();
        string uu = "Update D_Students set Balance = '" + newbalance + "' where SID = '" + DropDownList2.SelectedValue + "'";
        insertRecord(uu);

        //notify parents
        if (sendmail == "Yes")
        {
            int joe = int.Parse(ServerPort);
            //string Parent = "Dear " + Label10.Text + ", " + Environment.NewLine + "Top of the day to you. Please find below the details of Bill for your child:" + Label13.Text + "." + Environment.NewLine + "" + Environment.NewLine + "Term:" + DropDownList4.SelectedItem.Text + "" + Environment.NewLine + "" + Environment.NewLine + "Total Amount: " + Label16.Text + " Naira, " + Environment.NewLine + "Important Information: " + TextBox2.Text + "" + Environment.NewLine + "Line Item(s): " + getgvdata(GridView1) + " " + Environment.NewLine + "and Total Outstanding for Student:" + Label17.Text + "" + Environment.NewLine + "" + Environment.NewLine + " Please ensure prompt payment ";
            //SendMail(Label10.Text, Parent, "Bill Alert", ServerName, SenderEmail, Institution, Mail_Password, joe);

            //string quee = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('Bill Sent', 'PID" + Label8.Text + " with Invoice ID:" + Label4.Text + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
            //insertRecord(quee);

        }
        if (SendSMS == "Yes")
        {
            var message = "Dear Parent," + Environment.NewLine + " " + Institution + " Bill Alert " + Environment.NewLine + "" + Environment.NewLine + "For: " + Label13.Text + "" + Environment.NewLine + "Term: " + DropDownList4.SelectedItem.Text + " " + Environment.NewLine + " Total Amount: " + Label16.Text + "" + Environment.NewLine + "" + Environment.NewLine + "Please check email for details ";

            string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + SMS_Email + "&subacct=" + SMSID + "&subacctpwd=" + SMS_Password + "&message=" + message + "&sender=" + SMS_Sender + "&sendto=" + Label11.Text + "&msgtype=0";
            System.Net.WebClient c = new System.Net.WebClient();
            var response = c.DownloadString(apicommand);


            string SMSMMM = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('SMS Message', '" + message + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
            insertRecord(SMSMMM);
        }
        //create log
        //bye
        MessageBox("Submitted Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=invoicing.aspx";
        this.Page.Controls.Add(meta);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    public string getgvdata(GridView gv)
    {
        StringBuilder strBuilder = new StringBuilder();
        StringWriter strWriter = new StringWriter(strBuilder);
        HtmlTextWriter htw = new HtmlTextWriter(strWriter);
        gv.RenderControl(htw);
        return strBuilder.ToString();
    }


    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DropDownList4.SelectedItem.Text== "Select Service")
        {
            DropDownList5.Visible = false;
            DropDownList3.Visible = false;
            DropDownList3.BorderColor = Color.Red;
        }
        if (DropDownList4.SelectedItem.Text == "Class")
        {
            DropDownList5.Visible = false;
            DropDownList3.Visible = true;
            DropDownList3.Enabled = true;
            string query = "Select ClassID,FClass as Class from D_Classes";
            BindGrid1(query, "Class", "ClassID");
        }
        if (DropDownList4.SelectedItem.Text == "Transport")
        {
            DropDownList3.Visible = false;
            DropDownList5.Visible = true;
            string query1a = "Select RoutesID,Route from D_Routes";
            BindGrid1a(query1a, "Route", "RoutesID");
        }

    }


}
