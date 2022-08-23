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



        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string query = "select LineItem,Test,Exam,SessionTotal,SessionObtainable,Percentage,Rating from FinalAcademic where SID='"+DropDownList3.SelectedValue+"' and SessionID='"+DropDownList1.SelectedValue+"' and Rtype='Academic'";
        GridviewBind(query);

        if(GridView1.Rows.Count < 1)
        {
            MessageBox("No record found");
            return;
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
            string com = "select SessionID,concat(Year,' ',Period) as Term from D_Session order by SessionID desc";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Term";
            DropDownList1.DataValueField = "SessionID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select SSession", "0"));
            con.Close();
        }
    }
    protected void BindGrid1()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select ClassID,FClass from D_Classes";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "FClass";
            DropDownList2.DataValueField = "ClassID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Select Class", "0"));
            con.Close();
        }
    }
    protected void BindGrid2()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select SID, Concat(FirstName,' ', LastName) as Name from D_Students where Class='"+DropDownList2.SelectedValue+"'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataBind();
            DropDownList3.DataTextField = "Name";
            DropDownList3.DataValueField = "SID";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("Select Student", "0"));
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

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DropDownList1.SelectedItem.Text=="Select Session")
        {
            DropDownList2.Enabled = false;
        }
        else
        {
            DropDownList2.Enabled = true;
            BindGrid1();
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedItem.Text == "Select Class")
        {
            DropDownList3.Enabled = false;
        }
        else
        {
            DropDownList3.Enabled = true;
            BindGrid2();
        }
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedItem.Text == "Select Student")
        {
            Button1.Enabled= false;
        }
        else
        {
            Button1.Enabled = true;
        }
    }
}
