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


        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        string query = "select LineItem,Test,Exam,SessionTotal,SessionObtainable,Percentage,Rating from FinalAcademic where SID='" + Session["SID"].ToString() + "' and SessionID='"+DropDownList1.SelectedValue+"' and Rtype='Academic'";
        GridviewBind(query);
        if(GridView1.Rows.Count>1)
        {
            Button2.Visible = true;
            Label3.Visible = true;
        }
        else
        {
            Button2.Visible = false;
            Label3.Visible = false;
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
            string com = "select Concat(Year,' ',Period) as Session,SessionID from D_Session order by SessionID desc";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Session";
            DropDownList1.DataValueField = "SessionID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select Session", "0"));
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
            Label3.Visible = false;
        }
        else
        {
            Label2.Visible = false;
            Button1.Visible = true;
            Button3.Visible = false;
            GridView2.Visible = false;
            Label3.Visible = true;
            Label3.Text = "Report for "+DropDownList1.SelectedItem.Text+"";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        ExportGridToExcel(Label3.Text);

    }


}
