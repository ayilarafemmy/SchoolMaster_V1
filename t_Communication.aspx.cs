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
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["StaffID"])))
        {
            Response.Redirect("teacher.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        if (!IsPostBack)
        {
            //get the term


            BindGrid();
            string query = "select MID,Message,Recipients,Date,SMS,Email,App from D_messagess where Sender='"+Session["StaffID"].ToString()+"' order by MID desc";
            GridviewBind(query);
        }
    }
    protected void BindGrid()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select ClassID,FClass from D_Classes where Teacher='"+Session["StaffID"].ToString()+"' or AssistantTeacher='"+ Session["StaffID"].ToString() + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "FClass";
            DropDownList1.DataValueField = "ClassID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select Class", "0"));
            con.Close();
        }
    }
    //protected void BindGrid1()
    //{
    //    string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
    //    using (SqlConnection con = new SqlConnection(constring))
    //    {
    //        con.Open();
    //        string com = "Select SubjectID,Subject from D_Subjects";
    //        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
    //        DataTable dt = new DataTable();
    //        adpt.Fill(dt);
    //        DropDownList2.DataSource = dt;
    //        DropDownList2.DataBind();
    //        DropDownList2.DataTextField = "Subject";
    //        DropDownList2.DataValueField = "SubjectID";
    //        DropDownList2.DataBind();
    //        DropDownList2.Items.Insert(0, new ListItem("Others Areas", "0"));
    //        con.Close();
    //    }
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (TextBox2.Text.Length < 5)
        {
            MessageBox("Kindly Enter Message");
            TextBox2.BorderColor = Color.Red;
            return;
        }
        if(DropDownList1.SelectedItem.Text =="Select Class")
        {
            MessageBox("Kindly Select Class");
            return;
        }


        //validation ends
        //check file(passport)
        foreach (GridViewRow row in GridView2.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                if (chkEmployee.Checked)
                {
                    TextBox sid = (TextBox)row.FindControl("SID");
                    TextBox Name = (TextBox)row.FindControl("Name");
                    string classs = DropDownList1.SelectedValue;
                    string oni = DateTime.Now.ToString("dd/MM/yyyy");
                    string timess = DateTime.Now.AddHours(5).ToString("hh:mm:ss");
                    string status = "Present";
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString))
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

                        //get parents email & phone
                        string jjj = sid.Text.Trim();
                        SqlCommand cmdx = new SqlCommand();
                        SqlDataAdapter sdax = new SqlDataAdapter();
                        DataSet dsx = new DataSet();
                        SqlConnection contx = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
                        contx.Open();
                        cmdx.CommandText = "SELECT a.Email,a.Phone from D_Parents a, D_Students b where a.PID = b.Parent_ID and b.SID = '"+ jjj + "'";
                        cmdx.Connection = contx;
                        sdax.SelectCommand = cmdx;
                        sdax.Fill(dsx, "D_Students");
                        string Email = dsx.Tables[0].Rows[0]["Email"].ToString();
                        string Phone = dsx.Tables[0].Rows[0]["Phone"].ToString();
                        contx.Close();

                        if (sendmail == "Yes")
                        {
                            int joe = int.Parse(ServerPort);
                            string StaffMail = ""+TextBox2.Text+"";
                            SendMail(Email, StaffMail, "Message from " + Institution + "", ServerName, SenderEmail, Institution, Mail_Password, joe);

                            string quee = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('Parent Message from Teacher', '" + StaffMail + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                            insertRecord(quee);

                        }
                        if (SendSMS == "Yes")
                        {
                            var message = ""+TextBox2.Text+"";

                            string apicommand = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" + SMS_Email + "&subacct=" + SMSID + "&subacctpwd=" + SMS_Password + "&message=" + message + "&sender=" + SMS_Sender + "&sendto=" + Phone + "&msgtype=0";
                            System.Net.WebClient c = new System.Net.WebClient();
                            var response = c.DownloadString(apicommand);


                            string SMSMMM = "insert into D_Logs (Activity, Details, Done_By,Capturetime) values ('SMS Message', '" + message + "', '" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                            insertRecord(SMSMMM);
                        }


                        using (SqlCommand cmd = new SqlCommand("INSERT INTO D_Messagess (Message,StaffID,Date,Sender,Recipients,MessageTarget,Direction,SMS,Email,App) VALUES('"+TextBox2.Text+"','','"+DateTime.Now.ToString("dd/MM/yyyy")+"','"+Session["StaffID"].ToString()+"','"+DropDownList1.SelectedItem.Text+"','P','Outgoing','Y','Y','Y')", con))
                        {
                            cmd.Parameters.AddWithValue("@sid", sid.Text.Trim());
                            cmd.Parameters.AddWithValue("@name", Name.Text.Trim());
                            cmd.Parameters.AddWithValue("@classs", classs);
                            cmd.Parameters.AddWithValue("@oni", oni);
                            cmd.Parameters.AddWithValue("@timess", timess);
                            cmd.Parameters.AddWithValue("@status", status);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }
                else
                {
                    MessageBox("Kindly Select Student(s)");
                    return;
                }
            }
        }



        MessageBox("Sent Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=t_Communication.aspx";
        this.Page.Controls.Add(meta);
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
        int ResultID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        string constr = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM D_AcademicReports WHERE ResultID = @ResultID"))
            {
                cmd.Parameters.AddWithValue("@ResultID", ResultID);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        string query = "select a.ResultID,CONCAT(c.FirstName,' ',c.LastName) as Student,CONCAT(b.Year,' ',b.Period) as Term,a.Subject,a.Score,a.ObtainableScore,a.PercentageObtained,a.AssessmentType, a.Comment from D_AcademicReports a, D_Session b, D_Students c where b.SessionID = a.Term and a.SID = c.SID and a.Teacher='" + Session["StaffID"].ToString() + "' order by a.ResultID desc";
        GridviewBind(query);
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
        string qqy = "select Message,Recipients,Date,SMS,Email,App from D_messagess where Sender='" + Session["StaffID"].ToString() + "' and  Message like '%" + TextBox2a.Text + "%' or Date like '%" + TextBox2a.Text + "%' OR Recipients like '%" + TextBox2a.Text + "%' and Recipients ='" + TextBox2a.Text + "' order by MID desc";
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

    protected void GridviewBind1(string query)
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Select Class")
        {
            GridView2.Visible = false;

        }
        else
        {
            GridView2.Visible = true;
            string jj = "select SID, CONCAT(FirstName,' ',LastName) as Name from D_Students where Class='" + DropDownList1.SelectedValue + "' order by Name asc";
            GridviewBind1(jj);

            if (GridView2.Rows.Count < 1)
            {
                MessageBox("Class does not have any student");
                return;
            }
        }
    }
}
