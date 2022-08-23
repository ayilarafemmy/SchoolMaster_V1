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

public partial class t_students : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["StaffID"])))
        {
            Response.Redirect("teacher.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        if (!IsPostBack)
        {
            string query = "select a.SID,a.FirstName,a.LastName,a.Gender,a.DOB,a.Roll_No,concat('~/Students/',a.Photo, a.filetype) as Image,b.FClass as Class from D_Students a, D_Classes b where a.Class = b.ClassID and (b.Teacher ='"+ Session["StaffID"].ToString()+ "' OR b.AssistantTeacher='" + Session["StaffID"].ToString() + "') order by b.FClass desc";
            GridviewBind(query);

            if(GridView1.Rows.Count >= 1)
            {
                Button2.Visible = true;
            }
            else
            {
                Button2.Visible = false;
            }
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
        string qqy = "select SID,FirstName,LastName,Gender,DOB,Roll_No,concat('~/Students/',Photo,filetype) as Image from D_Students where SID like '%"+TextBox1.Text+ "%' OR FirstName like '%" + TextBox1.Text + "%' OR LastName like '%" + TextBox1.Text + "%' AND Class = '" + Session["classID"].ToString() + "' and Section = '" + Session["sectionsID"].ToString() + "'";
        GridviewBind(qqy);

        if (GridView1.Rows.Count == 0)
        {
            MessageBox("Your Search Returned No Result");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=t_students.aspx";
            this.Page.Controls.Add(meta); return;
        }
    }

    protected void export(string query, string filename)
    {
        string constr = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);

                        //Build the CSV file data as a Comma separated string.
                        string csv = string.Empty;

                        foreach (DataColumn column in dt.Columns)
                        {
                            //Add the Header row for CSV file.
                            csv += column.ColumnName + ',';
                        }

                        //Add new line.
                        csv += "\r\n";

                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (DataColumn column in dt.Columns)
                            {
                                //Add the Data rows.
                                csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                            }

                            //Add new line.
                            csv += "\r\n";
                        }

                        //Download the CSV file.
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".csv");
                        Response.Charset = "";
                        Response.ContentType = "application/text";
                        Response.Output.Write(csv);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string jj = "select a.SID,a.FirstName,a.LastName,a.Gender,a.DOB,a.Roll_No,concat('~/Students/',a.Photo, a.filetype) as Image,b.FClass as Class from D_Students a, D_Classes b where a.Class = b.ClassID and (b.Teacher ='" + Session["StaffID"].ToString() + "' OR b.AssistantTeacher='" + Session["StaffID"].ToString() + "') order by b.FClass desc";
        export(jj, "mystd_" + DateTime.Now.ToString("ddMMyyyy-hhmm") + "");
    }
}
