using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class all_parents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string query = "select SID,Admission_ID,Parent_ID,FirstName,LastName,Gender,DOB,Roll_No,BG,Religion,Email,Class,Section,Bio,Photo,Capture_Date,Capture_By,LoginC from D_Students";
            GridviewBind(query);

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
        string qqy = "SID,Admission_ID,Parent_ID,FirstName,LastName,Gender,DOB,Roll_No,BG,Religion,Email,Class,Section,Bio,Photo,Capture_Date,Capture_By,LoginC from D_Students where FirstName like '%" + TextBox1.Text+ "%' or LastName like '%" + TextBox1.Text + "%' OR SID like '%" + TextBox1.Text + "%'";
        GridviewBind(qqy);

        if(GridView1.Rows.Count ==0)
        {
            MessageBox("Your Search Returned No Result");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=all-student.aspx";
            this.Page.Controls.Add(meta); return;
        }
    }
}
