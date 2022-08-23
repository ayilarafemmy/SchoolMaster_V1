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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["SID"])))
        {
            Response.Redirect("student.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }
        Label1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        if (!IsPostBack)
        {
            BindGrid();

            string query = "select a.Subject,b.Day,b.Period  from D_Subjects a,D_Period b,D_Classes c,D_Students d where c.ClassID = d.Class and a.SubjectID = b.Subject and d.SID = '1'";
            GridviewBind(query);
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

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
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO D_Attendance (SID,Name,Class,Date,Time,Status,TakenBy) VALUES(@sid,@name,@classs,@oni,@timess,@status,'" + Session["StaffID"].ToString() + "')", con))
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
                    TextBox sid = (TextBox)row.FindControl("SID");
                    TextBox Name = (TextBox)row.FindControl("Name");
                    string classs = DropDownList1.SelectedValue;
                    string oni = DateTime.Now.ToString("dd/MM/yyyy");
                    string timess = DateTime.Now.AddHours(5).ToString("hh:mm:ss");
                    string status = "Absent";
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO D_Attendance (SID,Name,Class,Date,Time,Status,TakenBy) VALUES(@sid,@name,@classs,@oni,@timess,@status,'" + Session["StaffID"].ToString() + "')", con))
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
            }
        }

        MessageBox("Attendance Captured Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=t_attendance.aspx";
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
