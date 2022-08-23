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
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    SqlCommand cmdj = new SqlCommand();
    SqlConnection conj = new SqlConnection();
    SqlDataAdapter sdaj = new SqlDataAdapter();
    DataSet dsj = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        con.Open();
        cmd.CommandText = "select Sessionid, concat(Year, '-', Period) as kini,Year from D_Session where Status='Open'";
        cmd.Connection = con;
        sda.SelectCommand = cmd;
        sda.Fill(ds, "D_Session");

        if (ds.Tables[0].Rows.Count ==1)
        {
            Label1.Text = ds.Tables[0].Rows[0]["Sessionid"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["Year"].ToString();
            TextBox1.Text = ds.Tables[0].Rows[0]["kini"].ToString();
        }
        else
        {

        }
            if (!IsPostBack)
        {
            BindGrid();
            BindGrid1();
            BindGrid2();

            //string query = "select a.EID,a.Term,a.Class,b.Subject,a.Date,a.Time,Concat(c.FirstName,' ',c.LastName) as Invigilator,a.SessionID from D_Exams a, D_Subjects b, D_Staff c where a.Subject = b.SubjectID and a.Invigilator = c.StaffID;";
            //GridviewBind(query);
        }
        con.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //check if it exist
        SqlCommand cmdx = new SqlCommand();
        SqlDataAdapter sdax = new SqlDataAdapter();
        DataSet dsx = new DataSet();
        SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        conx.Open();
        cmdx.CommandText = "select subject from D_Exams where Subject='" + DropDownList1.SelectedValue + "' and SessionID='"+ Label1.Text + "' and Class='"+Label3.Text+"' and Time='"+DropDownList3.SelectedValue+ "' and Date='"+TextBox3.Text+"'";
        cmdx.Connection = conx;
        sdax.SelectCommand = cmdx;
        sdax.Fill(dsx, "D_Exams");

        if (dsx.Tables[0].Rows.Count >= 1)
        {
            string myStringVariable = "Subject : " + DropDownList1.SelectedItem.Text + " already exists for this period and day this term exam date";
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
            MessageBox("The Session need to be created first!");
            return;
        }
        if (DropDownList1.SelectedItem.Text == "Select Subject Area")
        {
            MessageBox("Kindly select Subject Area");
            return;
        }
        if (DropDownList2.SelectedItem.Text == "Select Staff")
        {
            MessageBox("Kindly select Staff");
            return;
        }
        if (DropDownList3.SelectedItem.Text == "Select Period")
        {
            MessageBox("Kindly select Period");
            return;
        }
        if(TextBox3.Text=="")
        {
            MessageBox("Kindly select Exams Date");
            return;
        }

        DateTime dd = Convert.ToDateTime(TextBox3.Text);
        string jj = dd.ToString("ddddddd dd/MM/yyyy");
        string hh = dd.ToString("dd/MM/yyyy");

        string query = "insert into D_Exams (Term,Class,Subject,Time,SessionID,Invigilator,Date,CreateDate,CreatedBy,Status,ExamDate) values ('"+TextBox1.Text+"','"+Label3.Text+"','"+DropDownList1.SelectedValue+"','"+DropDownList3.SelectedValue+"','"+Label1.Text+"','"+DropDownList2.SelectedValue+"','"+ jj + "','"+DateTime.Now.ToString("dd/MM/yyyy")+"','"+Session["StaffID"].ToString()+"','Future','"+hh+"')";
         insertRecord(query);

        MessageBox("Exam Captured Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=exams.aspx";
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
            string com = "Select SubjectID,Subject from D_Subjects";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Subject";
            DropDownList1.DataValueField = "SubjectID";
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
            string com = "Select Concat(FirstName,' ',LastName) as Name,StaffID from D_Staff";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "Name";
            DropDownList2.DataValueField = "StaffID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Select Staff", "0"));
            con.Close();
        }
    }
    protected void BindGrid2()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select ETID,Time from D_ExamPeriod";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataBind();
            DropDownList3.DataTextField = "Time";
            DropDownList3.DataValueField = "ETID";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, new ListItem("Select Period", "0"));
            con.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
      if(DropDownList4.SelectedValue=="0")
        {
            MessageBox("Kindly Select Year");
            return;
        }
        if (DropDownList5.SelectedValue == "0")
        {
            MessageBox("Kindly Select Start Month");
            return;
        }
        if(TextBox2.Text =="")
        {
            MessageBox("Kindly Enter Period");
            TextBox2.BorderColor = System.Drawing.Color.Red;
            return;
        }

        string q = "update D_Session set Status = 'Close',ClosedBy='" + Session["StaffID"].ToString() + "',EndMonth='"+DateTime.Now.ToString("MMM")+"' where Status='Open'";
        insertRecord(q);
        string q1 = "insert into  D_Session (Year,StartMonth,Period,CreatedBy,CreateDate,Status) values ('"+DropDownList4.SelectedItem.Text+"','"+DropDownList5.SelectedItem.Text+"','"+TextBox2.Text+"','"+Session["StaffID"].ToString()+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"','Open')";
        insertRecord(q1);

        MessageBox("Created Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=account-settings.aspx";
        this.Page.Controls.Add(meta);
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //populate Class

        if(DropDownList1.SelectedItem.Text== "Select Subject Area")
        {
            Label3.Visible = false;
        }
        else
        {
            Label3.Visible = true;
            SqlConnection conj = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            conj.Open();
            cmdj.CommandText = "select Class from D_SubjectS where Subjectid='" + DropDownList1.SelectedValue+"'";
            cmdj.Connection = conj;
            sdaj.SelectCommand = cmdj;
            sdaj.Fill(dsj, "D_SubjectS");

            if (dsj.Tables[0].Rows.Count == 1)
            {
                Label3.Text = dsj.Tables[0].Rows[0]["Class"].ToString();
            }
            conj.Close();
        }


    }



    protected void Button3_Click(object sender, EventArgs e)
    {
        string query = "select * from D_Session";
        GridviewBind(query);
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        MessageBox("Am here");
        if (DropDownList4.SelectedValue == "0")
        {
            MessageBox("Kindly Select Year");
            return;
        }
        if (DropDownList5.SelectedValue == "0")
        {
            MessageBox("Kindly Select Start Month");
            return;
        }
        if (TextBox2.Text == "")
        {
            MessageBox("Kindly Enter Period");
            TextBox2.BorderColor = System.Drawing.Color.Red;
            return;
        }

        string q = "update D_Session set Status = 'Close',ClosedBy='" + Session["StaffID"].ToString() + "',EndMonth='" + DateTime.Now.ToString("MMM") + "' where Status='Open'";
        insertRecord(q);
        string q1 = "insert into  D_Session (Year,StartMonth,Period,CreatedBy,CreateDate,Status) values ('" + DropDownList4.SelectedItem.Text + "','" + DropDownList5.SelectedItem.Text + "','" + TextBox2.Text + "','" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','Open')";
        insertRecord(q1);

        MessageBox("Created Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=account-settings.aspx";
        this.Page.Controls.Add(meta);
    }
}
