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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select Sessionid, concat(Year, '-', Period) as kini,Year from D_Session where Status='Open'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Session");

            if (ds.Tables[0].Rows.Count == 1)
            {
                Label4.Text = ds.Tables[0].Rows[0]["Sessionid"].ToString();
                //Label2.Text = ds.Tables[0].Rows[0]["Year"].ToString();
                TextBox1.Text = ds.Tables[0].Rows[0]["kini"].ToString();
            }
            else
            {

            }


            BindGrid();
            BindGrid1();
            string query = "select a.ResultID,CONCAT(c.FirstName,' ',c.LastName) as Student,CONCAT(b.Year,' ',b.Period) as Term,a.Subject,a.Score,a.ObtainableScore,a.PercentageObtained,a.AssessmentType, a.Comment from D_AcademicReports a, D_Session b, D_Students c where b.SessionID = a.Term and a.SID = c.SID and a.Teacher='"+Session["StaffID"].ToString()+"' order by a.ResultID desc";
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
            DropDownList2.Items.Insert(0, new ListItem("Others Areas", "0"));
            con.Close();
        }
    }
    protected void BindGrid1a()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select SID, CONCAT(FirstName,' ',LastName) as Name from D_Students where Class='" + DropDownList1.SelectedValue + "' order by Name asc";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList4.DataSource = dt;
            DropDownList4.DataBind();
            DropDownList4.DataTextField = "Name";
            DropDownList4.DataValueField = "SID";
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, new ListItem("Select Student", "0"));
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (DropDownList4.SelectedItem.Text == "Select Student")
        {
            MessageBox("Kindly Select Student");
            DropDownList4.BorderColor = Color.Red;
            return;
        }
        if (DropDownList3.SelectedItem.Text == "Assessment Type")
        {
            MessageBox("Kindly Select Assessment Type");
            DropDownList3.BorderColor = Color.Red;
            return;
        }
        if (TextBox2.Text.Length < 5)
        {
            MessageBox("Kindly Provide Comment");
            TextBox2.BorderColor = Color.Red;
            return;
        }


        //validation ends
        //check file(passport)
        if (FileUpload1.HasFile)
        {
            string FileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
            string path = Server.MapPath("~/Assessment/");
            string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            string NewName = DropDownList1.SelectedItem.Text + "_" + DateTime.Now.ToString("ddMMyyHHmm");
            Label2.Text = NewName.ToString();
            Label3.Text = Label2.Text + extension;
            FileUpload1.SaveAs(path + NewName + extension);
            if (FileUpload1.PostedFile.ContentLength >= 412345678)
            {
                MessageBox("This is a local server, max allowed is 41Mb, file upload is " + FileUpload1.PostedFile.ContentLength + "");
                return;
            }

        }
        else
        {
            Label3.Text = ConfigurationManager.AppSettings["InstitutionLogo"];
        }

        if(TextBox4.Text =="")
        {
            MessageBox("Kindly Enter Score");
            return;
        }
        if (TextBox5.Text == "")
        {
            MessageBox("Kindly Enter Max Score");
            return;
        }
        if(DropDownList3.SelectedValue=="0")
        {
            MessageBox("Kindly Select Assessment Type");
            return;
        }

                    //TextBox sid = (TextBox)row.FindControl("SID");
                    //TextBox Name = (TextBox)row.FindControl("Name");
                    string classs = DropDownList1.SelectedValue;
                    string oni = DateTime.Now.ToString("dd/MM/yyyy");
                    string timess = DateTime.Now.AddHours(5).ToString("hh:mm:ss");
                    string status = "Present";


                        // calculare score
                        Decimal scc = Decimal.Parse(TextBox4.Text);
                        Decimal max = Decimal.Parse(TextBox5.Text);
                        if(scc > max)
                        {
                            MessageBox("Score is greater than Max Obtainable School");
                            TextBox4.BorderColor = Color.Red;
                            TextBox5.BorderColor = Color.Red;
                            return;
                        }
                        decimal d = (scc / max) * 100;
                        decimal dc = Math.Round(d, 0);

        string entry = "INSERT INTO D_AcademicReports(SID, Term, Score, EntryDate, Subject, Teacher, AssessmentType, Comment, ObtainableScore, PercentageObtained, UFile) VALUES('" + DropDownList4.SelectedValue + "', '" + Label4.Text + "', '" + TextBox4.Text + "','" + DateTime.Now.ToString("dd/MM/yyyy hh:mm") + "', '" + DropDownList2.SelectedItem.Text + "', '" + Session["StaffID"].ToString() + "', '" + DropDownList3.SelectedItem.Text + "', '" + TextBox2.Text + "', '" + TextBox5.Text + "', '" + dc.ToString() + "', '" + Label3.Text + "')";
        insertRecord(entry);
        MessageBox("Saved Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "1;url=t_Assessment.aspx";
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
        string qqy = "select a.ResultID,CONCAT(c.FirstName, ' ', c.LastName) as Student,CONCAT(b.Year, ' ', b.Period) as Term,a.Subject,a.Score,a.ObtainableScore,a.PercentageObtained,a.AssessmentType, a.Comment from D_AcademicReports a, D_Session b, D_Students c where b.SessionID = a.Term and a.SID = c.SID and a.Teacher = '" + Session["StaffID"].ToString() + "' and  Material like '%" + TextBox2a.Text + "%' or Student like '%" + TextBox2a.Text + "%' OR Term like '%" + TextBox2a.Text + "%' and a.AssessmentType ='" + TextBox2a.Text + "' order by a.ResultID desc";
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
            DropDownList4.Enabled = false;
        }
        else
        {
            DropDownList4.Enabled = true;
            GridView2.Visible = false;
            BindGrid1a();

        }
    }
}
