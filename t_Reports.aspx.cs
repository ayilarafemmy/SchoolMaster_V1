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
            //string query = "select a.ResultID,CONCAT(c.FirstName,' ',c.LastName) as Student,CONCAT(b.Year,' ',b.Period) as Term,a.Subject,a.Score,a.ObtainableScore,a.PercentageObtained,a.AssessmentType, a.Comment from D_AcademicReports a, D_Session b, D_Students c where b.SessionID = a.Term and a.SID = c.SID and a.Teacher='"+Session["StaffID"].ToString()+"' order by a.ResultID desc";
            //GridviewBind(query);
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

    protected void Button1_Click(object sender, EventArgs e)
    {


        if (TextBox2.Text.Length < 1)
        {
            MessageBox("Kindly Provide Comment");
            TextBox2.BorderColor = Color.Red;
            return;
        }



        if (TextBox5.Text == "")
        {
            MessageBox("Kindly Enter Co-Corricular Comments");
            return;
        }
        if (TextBox2.Text == "")
        {
            MessageBox("Kindly Enter Other Comments");
            return;
        }
        //check if it exists
        SqlCommand cmdx = new SqlCommand();
            SqlDataAdapter sdax = new SqlDataAdapter();
            DataSet dsx = new DataSet();
            SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            conx.Open();
            cmdx.CommandText = "select count(*) from FinalAcademic where SessionID='" + Label4.Text + "' and SID ='" + DropDownList2.SelectedValue + "'";
            cmdx.Connection = conx;
            sdax.SelectCommand = cmdx;
            sdax.Fill(dsx, "FinalAcademic");

            if (dsx.Tables[0].Rows.Count > 20)
            {
                string myStringVariable = "Record for Session : " + TextBox1.Text + " for Student" + DropDownList2.SelectedItem.Text + " already exists";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                return;

            }
            else
            {

            }
        try
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    TextBox Subject = (TextBox)row.FindControl("Subject");
                    TextBox Test = (TextBox)row.FindControl("Test");
                    TextBox MaxScoreTest = (TextBox)row.FindControl("MaxScoreTest");
                    TextBox Examination = (TextBox)row.FindControl("Examination");
                    TextBox MaxScoreExamination = (TextBox)row.FindControl("MaxScoreExamination");
                    if (Test.Text != "")
                    {
                        Test.Text = "0";
                    }
                    if (Examination.Text != "")
                    {
                        Examination.Text = "0";
                    }
                    Decimal totalscore = Decimal.Parse(Test.Text) + Decimal.Parse(Examination.Text);
                    Decimal alltotal = Decimal.Parse(MaxScoreTest.Text) + Decimal.Parse(MaxScoreExamination.Text);
                    Decimal percent = Math.Round((totalscore / alltotal) * 100);
                    string rating = "";
                    if (percent < 50)
                    {
                        rating = "Failed";
                    }
                    if (percent > 50)
                    {
                        rating = "Passed";
                    }

                    string classs = DropDownList1.SelectedValue;
                    string oni = DateTime.Now.ToString("dd/MM/yyyy");
                    string timess = DateTime.Now.AddHours(5).ToString("hh:mm:ss");
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO FinalAcademic (SessionID,SID,Rtype,LineItem,Test,TestTotal,Exam,ExamTotal,SessionTotal,SessionObtainable,Percentage,Rating,EnteredBy,EntryDate) VALUES ('" + Label4.Text + "','" + DropDownList2.SelectedValue + "','Academic',@Subject,@Test,@MaxScoreTest,@Examination,@MaxScoreExamination,'" + totalscore.ToString() + "','" + alltotal.ToString() + "','" + percent.ToString() + "','" + rating.ToString() + "','" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')", con))
                        {

                            cmd.Parameters.AddWithValue("@MaxScoreTest", MaxScoreTest.Text.Trim());
                            cmd.Parameters.AddWithValue("@Examination", Examination.Text.Trim());
                            cmd.Parameters.AddWithValue("@Subject", Subject.Text.Trim());
                            cmd.Parameters.AddWithValue("@Test", Test.Text.Trim());
                            cmd.Parameters.AddWithValue("@MaxScoreExamination", MaxScoreExamination.Text.Trim());
                            //cmd.Parameters.AddWithValue("@status", status);
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
        catch(Exception kk)
        {

        }

        //bind 2nd Grid
        string jjn = "select LineItem,Test,Exam,SessionTotal,SessionObtainable,Percentage,Rating from FinalAcademic where SID='"+DropDownList2.SelectedValue+"' and SessionID='"+Label4.Text+"' and Rtype='Academic'";
        GridviewBind1(jjn);

        if(GridView2.Rows.Count < 1)
        {
            MessageBox("There is an issue, please check your entries");
            return;
        }
        else
        {
            Button1.Visible = false;
            Button2.Visible = true;
            GridView1.Visible = false;
            GridView2.Visible = true;

        }



        //MessageBox("Saved Successfully");
        //HtmlMeta meta = new HtmlMeta();
        //meta.HttpEquiv = "Refresh";
        //meta.Content = "1;url=t_Reports.aspx";
        //this.Page.Controls.Add(meta);
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


    //protected void GridviewBind1(string query)
    //{
    //    try
    //    {
    //        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
    //        using (SqlConnection con = new SqlConnection(constring))
    //        {
    //            con.Open();
    //            SqlCommand cmd = new SqlCommand(query, con);
    //            SqlDataReader dr = cmd.ExecuteReader();
    //            GridView2.DataSource = dr;
    //            GridView2.DataBind();
    //            con.Close();
    //        }
    //    }
    //    catch (Exception kk)
    //    {
    //        string success = "Possibe Network issue " + kk + "";
    //        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + success + "');", true);
    //        return;
    //    }
    //}
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select SID, CONCAT(FirstName,' ',LastName) as Name from D_Students where Class='" + DropDownList1.SelectedValue + "' order by Name asc";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "Name";
            DropDownList2.DataValueField = "SID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Select Student", "0"));
            con.Close();
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //select D_AcademicReports and populate and bind to Grid
        if(DropDownList2.SelectedItem.Text== "Select Student")
        { }
        else
        {
            Label5.Text = DropDownList2.SelectedItem.Text;
            string query = "SELECT Subject,MAX(CASE WHEN AssessmentType = 'Test' THEN Score ELSE '' END) AS 'Test', MAX(CASE WHEN AssessmentType =  'Test' THEN ObtainableScore ELSE '' END) AS 'MaxScoreTest', MAX(CASE WHEN AssessmentType =  'Examination' THEN Score ELSE '' END) AS 'Examination', MAX(CASE WHEN AssessmentType =  'Examination' THEN ObtainableScore ELSE '' END) AS 'MaxScoreExamination' FROM D_AcademicReports where SID='"+DropDownList2.SelectedValue+"' and Term='"+Label4.Text+"' GROUP BY Subject";
            GridviewBind(query);
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}
