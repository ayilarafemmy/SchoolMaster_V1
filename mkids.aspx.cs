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

public partial class all_subject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            BindGrid1();

            string query = "Select SubjectID,Subject,Subject_Area,Class,Create_Date,Create_By from D_Subjects order by SubjectID desc";
            GridviewBind(query);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //check if it exist
        SqlCommand cmdx = new SqlCommand();
        SqlDataAdapter sdax = new SqlDataAdapter();
        DataSet dsx = new DataSet();
        SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        conx.Open();
        cmdx.CommandText = "select Subject from D_Subjects where Subject='" + TextBox1.Text + "'";
        cmdx.Connection = conx;
        sdax.SelectCommand = cmdx;
        sdax.Fill(dsx, "D_Subjects");

        if (dsx.Tables[0].Rows.Count > 0)
        {
            string myStringVariable = "Subject : " + TextBox1.Text + " already exists";
            TextBox1.BackColor = System.Drawing.Color.Red;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            return;

        }
        else
        {

        }
        conx.Close();
        //create and log

        if(TextBox1.Text.Length < 6)
        {
            MessageBox("Kindly enter Subject");
            return;
        }
        if (DropDownList1.SelectedItem.Text == "Select Subject Area")
        {
            MessageBox("Kindly select Subject Area");
            return;
        }
        if (DropDownList2.SelectedItem.Text == "Select Class")
        {
            MessageBox("Kindly select Class");
            return;
        }
        string query = "insert into D_Subjects (Subject,Subject_Area,Class,Create_Date,Create_By) values ('"+TextBox1.Text+"','"+DropDownList1.SelectedItem.Text+"','"+DropDownList2.SelectedItem.Text+"','"+DateTime.Now.ToString("dd/MMM/yyyy")+"','"+Session["StaffID"].ToString()+"')";
        insertRecord(query);

        MessageBox("Details Captured Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "1;url=all-subject.aspx";
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
            string com = "Select SAID,Subject_Area from D_Subject_Area";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Subject_Area";
            DropDownList1.DataValueField = "SAID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select Subject Area", "0"));
            con.Close();
        }
    }
    protected void BindGrid1()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select ClassID,Class from D_Classes";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "Class";
            DropDownList2.DataValueField = "ClassID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Select Class", "0"));
            con.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        string query = "Select SubjectID,Subject,Subject_Area,Class,Create_Date,Create_By from D_Subjects where SubjectID like '%" + TextBox2.Text+ "%' OR Subject like '%" + TextBox2.Text+ "%' OR Subject_Area like '%" + TextBox2.Text+"%' OR Class like '%"+TextBox2.Text+"%'";
        GridviewBind(query);
        if(GridView1.Rows.Count ==0)
        {
            MessageBox("Your Search returned no data");
            return;
        }
    }
}
