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

public partial class t_attendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(Convert.ToString(Session["StaffID"])))
        {
            Response.Redirect("teacher.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }
        Label1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        if (!IsPostBack)
        {
            BindGrid();

            string query = "select a.Name,a.Status,a.Date,a.time,a.SID as StudentID,b.FClass as Class,Concat(c.FirstName,' ',c.LastName) as Staff from D_Attendance a, D_Classes b, D_Staff c where a.Class = b.classID and a.Takenby=c.staffID and b.ClassID in (Select ClassID from D_Classes where Teacher='"+ Session["StaffID"].ToString()+ "' or AssistantTeacher='"+ Session["StaffID"].ToString()+ "') order by a.AIDD desc;";
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
            string com = "Select ClassID,FClass from D_Classes where Teacher ='"+ Session["StaffID"].ToString()+ "' or AssistantTeacher ='"+ Session["StaffID"].ToString()+ "'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
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


    protected void Button2_Click(object sender, EventArgs e)
    {

        string query = "select a.Name,a.Status,a.Date,a.time,a.SID as StudentID,b.FClass as Class,Concat(c.FirstName,' ',c.LastName) as Staff from D_Attendance a, D_Classes b, D_Staff c where a.Class = b.classID and a.Takenby=c.staffID and b.FClass like '" + TextBox2.Text + "%' OR Subject like '%" + TextBox2.Text + "%' OR Staff like '%" + TextBox2.Text + "%' OR a.Date like '%" + TextBox2.Text + "%'";
        GridviewBind(query);
        if (GridView1.Rows.Count == 0)
        {
            MessageBox("Your Search returned no data");
            return;
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "Select Class")
        {
            Label2.Visible = false;
            Button1.Visible = false;
            Button3.Visible = false;
            GridView2.Visible = false;
        }
        else
        {
            Label2.Visible = true;
            Button1.Visible = true;
            Button3.Visible = true;
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
