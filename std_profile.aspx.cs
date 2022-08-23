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

    SqlCommand cmd1 = new SqlCommand();
    SqlConnection con1 = new SqlConnection();
    SqlDataAdapter sda1 = new SqlDataAdapter();
    DataSet ds1 = new DataSet();

    SqlCommand cmd2 = new SqlCommand();
    SqlConnection con2 = new SqlConnection();
    SqlDataAdapter sda2 = new SqlDataAdapter();
    DataSet ds2 = new DataSet();

    SqlCommand cmd3 = new SqlCommand();
    SqlConnection con3 = new SqlConnection();
    SqlDataAdapter sda3 = new SqlDataAdapter();
    DataSet ds3 = new DataSet();

    SqlCommand cmd4 = new SqlCommand();
    SqlConnection con4 = new SqlConnection();
    SqlDataAdapter sda4 = new SqlDataAdapter();
    DataSet ds4 = new DataSet();

    SqlCommand cmd5 = new SqlCommand();
    SqlConnection con5 = new SqlConnection();
    SqlDataAdapter sda5 = new SqlDataAdapter();
    DataSet ds5 = new DataSet();

    SqlCommand cmd6 = new SqlCommand();
    SqlConnection con6 = new SqlConnection();
    SqlDataAdapter sda6 = new SqlDataAdapter();
    DataSet ds6 = new DataSet();

    SqlCommand cmd7 = new SqlCommand();
    SqlConnection con7 = new SqlConnection();
    SqlDataAdapter sda7 = new SqlDataAdapter();
    DataSet ds7 = new DataSet();

    SqlCommand cmd8 = new SqlCommand();
    SqlConnection con8 = new SqlConnection();
    SqlDataAdapter sda8 = new SqlDataAdapter();
    DataSet ds8 = new DataSet();

    SqlCommand cmd9 = new SqlCommand();
    SqlConnection con9 = new SqlConnection();
    SqlDataAdapter sda9 = new SqlDataAdapter();
    DataSet ds9 = new DataSet();

    SqlCommand cmd10 = new SqlCommand();
    SqlConnection con10 = new SqlConnection();
    SqlDataAdapter sda10 = new SqlDataAdapter();
    DataSet ds10 = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["SID"])))
        {
            Response.Redirect("student.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select a.SID, a.FirstName, a.LastName,Concat(b.First_Name,' ',b.Last_Name) as Parent,a.Gender,a.DOB,a.Roll_No,a.BG,a.Religion,c.FClass,a.Bio,concat(a.photo,a.filetype) as Pix,a.Balance  from D_Students a, D_Parents b,D_Classes c where a.Parent_ID =b.PID and c.ClassID = a.Class and a.SID = '"+ Session["SID"].ToString()+ "'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_students");
            TextBox1.Text = ds.Tables[0].Rows[0]["SID"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0]["Parent"].ToString();
            TextBox6.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
            TextBox7.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
            TextBox8.Text = ds.Tables[0].Rows[0]["Roll_No"].ToString();
            TextBox9.Text = ds.Tables[0].Rows[0]["BG"].ToString();
            TextBox10.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
            TextBox11.Text = ds.Tables[0].Rows[0]["FClass"].ToString();
            TextBox12.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["Bio"].ToString();
            Image1.ImageUrl= "/Students/" + ds.Tables[0].Rows[0]["Pix"].ToString();
            con.Close();
        }
        catch(Exception k)
        {
            MessageBox("Error at " + k + "");
            return;
        }

            if (!IsPostBack)
        {
            //get the term


            string query = "select a.SID, a.FirstName, a.LastName,Concat(b.First_Name,' ',b.Last_Name) as Parent,a.Gender,a.DOB,a.Roll_No,a.BG,a.Religion,c.FClass,a.Bio,a.Balance  from D_Students a, D_Parents b,D_Classes c where a.Parent_ID =b.PID and c.ClassID = a.Class and a.SID = '"+Session["SID"].ToString() + "'";
            GridviewBind(query);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (TextBox2.Text.Length < 5)
        {
            MessageBox("Kindly Enter Message");
            TextBox2.BorderColor = Color.Red;
            return;
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

}
