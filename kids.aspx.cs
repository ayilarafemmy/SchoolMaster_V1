using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Web.UI.HtmlControls;

public partial class kids : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    SqlCommand cmd1 = new SqlCommand();
    SqlConnection con1 = new SqlConnection();
    SqlDataAdapter sda1 = new SqlDataAdapter();
    DataSet ds1 = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["PID"])))
        {
            Response.Redirect("parent.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        if (!IsPostBack)
        {

            BindGrid();
        }
    }
    protected void BindGrid()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "SELECT SID, CONCAT(FirstName, ' ', LastName) as Student from D_Students where Parent_ID='"+ Session["PID"].ToString()+ "'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Student";
            DropDownList1.DataValueField = "SID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select Student", "0"));
            con.Close();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Select Student")
        {
            MessageBox("Kindly Select Student");
            return;
        }
        if (DropDownList2.SelectedItem.Text == "Select Request")
        {
            MessageBox("Kindly Select Request");
            return;
        }

       if (DropDownList2.SelectedItem.Text == "Time Table")
        {
            string query = "select a.Session,b.FClass,c.Subject, a.Day, a.Period, CONCAT(d.FirstName,' ',d.LastName) as Teacher from D_Period a, D_Classes b, D_Subjects c, D_Staff d, D_Students e, D_Session f where a.ClassID = b.ClassID and a.Subject = c.SubjectID and a.Teacher = d.StaffID and a.ClassID = e.Class and a.SessionID = f.SessionID and f.Status = 'Open' and e.SID = '"+DropDownList1.SelectedValue+ "' order by a.PID desc";
            GridviewBind(query);

            if (GridView2.Rows.Count == 0)
            {
                MessageBox("No record found");
                return;

            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Button2.Visible = true;
                GridView2.Visible = true;
            }
        }
        if (DropDownList2.SelectedItem.Text == "Attendance")
        {
            string query = "select a.Date,CONCAT(c.FirstName,' ',c.LastName) as TakenBy, a.Status,a.Time,d.FClass as Class, a.Name as FullName, a.AIDD  from D_Attendance a, D_Students b, D_Staff c, D_Classes d Where a.SID='"+DropDownList1.SelectedValue+"' and a.SID = B.SID and a.Class = d.ClassID and a.TakenBy = c.StaffID";
            GridviewBind(query);

            if(GridView2.Rows.Count == 0)
            {
                MessageBox("No record found");
                return;

            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Button2.Visible = true;
                GridView2.Visible = true;
            }
        }

        if (DropDownList2.SelectedItem.Text == "Exams Schedule")
        {
            string query = "select a.Date, a.Class, b.Subject, c.Time, concat(d.Year, ' ', d.Period) as Session,concat(e.FirstName, ' ', e.LastName) as Invigilator  from D_Exams a, D_Subjects b, D_ExamPeriod c, D_Session d, D_Staff e, D_Classes f, D_Students g where a.Invigilator = e.StaffID and a.Time = c.ETID and b.SubjectID=a.Subject and a.SessionID = d.SessionID and d.Status = 'Open' and a.ClassID = f.ClassID and f.ClassID = g.Class and g.SID='"+DropDownList1.SelectedValue+"'";
            GridviewBind(query);

            if (GridView2.Rows.Count == 0)
            {
                MessageBox("No record found");
                return;

            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                Button2.Visible = true;
                GridView2.Visible = true;
            }
        }

        if (DropDownList2.SelectedItem.Text == "Profile")
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "SELECT a.Capture_Date,a.Admission_ID, c.section, a.SID as SID, CONCAT(a.FirstName, ' ', a.LastName) as Student, a.Roll_No, b.class as class, a.Gender,a.Photo as Photo, a.filetype as filetype  from D_Students a, D_Classes b,D_Sections c where a.Class = b.ClassID and a.section = c.SectionsID and a.SID='" + DropDownList1.SelectedValue + "' and a.Parent_ID='" + Session["PID"].ToString() + "'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Students");

            if (ds.Tables[0].Rows.Count > 0)
            {
                string filetype = ds.Tables[0].Rows[0]["filetype"].ToString();
                string photo = ds.Tables[0].Rows[0]["photo"].ToString();
                Label2.Text = ds.Tables[0].Rows[0]["Student"].ToString();
                Label3.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                Label4.Text = ds.Tables[0].Rows[0]["class"].ToString();
                Label5.Text = ds.Tables[0].Rows[0]["Roll_No"].ToString();
                Label6.Text = ds.Tables[0].Rows[0]["section"].ToString();
                Label7.Text = ds.Tables[0].Rows[0]["Admission_ID"].ToString();
                Label8.Text = ds.Tables[0].Rows[0]["Capture_Date"].ToString();
                Image1.ImageUrl = "~/Students/"+photo+""+filetype+"";
            }
            con.Close();
            Panel1.Visible = true;
            Label1.Visible = true;
            Label1.Text = Label2.Text + " Profile";
        }
        else
        {
            Panel1.Visible = false;
            Label1.Visible = false;
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
    private void ExportGridToExcel(string file)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = file + DateTime.Now.ToString("ddMMyy") + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        GridView2.GridLines = GridLines.Both;
        GridView2.HeaderStyle.Font.Bold = true;
        GridView2.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

            ExportGridToExcel(DropDownList2.SelectedItem.Text + "_" + DropDownList1.SelectedItem.Text + "");

     }
}
