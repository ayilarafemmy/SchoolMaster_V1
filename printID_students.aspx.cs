using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class t_attendance : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["SID"])))
        {
            Response.Redirect("student.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        if (!IsPostBack)
        {
            BindGrid();

            string query = "select Material, Subject, MaterialType, Description, Class, concat(Doc,filetype) as StudyMaterial,LID from D_LMS";
            GridviewBind(query);
        }
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select concat(a.SID, ' ',a.FirstName) as stdname, a.LastName,Concat(b.First_Name,' ',b.Last_Name) as Parent,a.Gender,a.DOB,a.Roll_No,a.BG,a.Religion,c.FClass,a.Bio,concat(a.photo,a.filetype) as Pix,a.Balance  from D_Students a, D_Parents b,D_Classes c where a.Parent_ID =b.PID and c.ClassID = a.Class and a.SID = '" + Session["SID"].ToString() + "'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_students");
            //TextBox1.Text = ds.Tables[0].Rows[0]["SID"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["stdname"].ToString();
            Label5.Text = ds.Tables[0].Rows[0]["FClass"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["Roll_No"].ToString();
            Label7.Text = ds.Tables[0].Rows[0]["BG"].ToString();
            Label8.Text = ConfigurationManager.AppSettings["Institution"];
            Image4.ImageUrl = "/Students/" + ds.Tables[0].Rows[0]["Pix"].ToString();
            con.Close();
        }
        catch (Exception k)
        {
            MessageBox("Error at " + k + "");
            return;
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {



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
    protected void BindGrid()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select Concat(Year,' ',Period) as Session,SessionID from D_Session where status='Open'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Session";
            DropDownList1.DataValueField = "SessionID";
            DropDownList1.DataBind();
            //DropDownList1.Items.Insert(0, new ListItem("Select Session", "0"));
            con.Close();
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
        GridView1.GridLines = GridLines.Both;
        GridView1.HeaderStyle.Font.Bold = true;
        GridView1.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();

    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Select Session")
        {
            Label2.Visible = false;
            Button1.Visible = false;
            Button3.Visible = false;
            GridView2.Visible = false;
        }
        else
        {
            Label2.Visible = false;
            Button1.Visible = false;
            Button3.Visible = false;
            GridView2.Visible = false;
            string jj = "select a.PID,a.Session,b.Subject,a.Day,a.Period,c.FClass as Class from D_Period a, D_Subjects b, D_Classes c, D_Session d where a.Subject = b.SubjectID and a.ClassID = c.ClassID and a.Teacher='" + Session["StaffID"].ToString() + "' and a.SessionID = d.SessionID and a.SessionID='"+DropDownList1.SelectedValue+"'";
            GridviewBind(jj);

            if(GridView1.Rows.Count < 1)
            {
                MessageBox("No Session captured for session: " + DropDownList1.SelectedItem.Text + "");
                return;
            }
            else
            {
                Label3.Text = "My Sessions In "+DropDownList1.SelectedItem.Text+"";
            }


        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        ExportGridToExcel(Label3.Text);

    }


}
