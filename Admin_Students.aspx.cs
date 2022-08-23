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
using System.Drawing;

public partial class Admin_Students : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();

            string query = "select SID,Admission_ID,Parent_ID,FirstName,LastName,Gender,DOB,Roll_No,BG,Religion,Email,Class,Section,Bio,Photo,Capture_Date,Capture_By,LoginC from D_Students";
            GridviewBind(query);

            Label4.Text = ConfigurationManager.AppSettings["MaxStudents"];
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            MessageBox("Kindly enter Students First Name");
            TextBox1.BorderColor = Color.Red;
            return;
        }
        if (TextBox2.Text == "")
        {
            MessageBox("Kindly enter Students Last Name");
            TextBox2.BorderColor = Color.Red;
            return;
        }
        if (TextBox3.Text == "")
        {
            MessageBox("Kindly enter Students Date of Birth");
            TextBox3.BorderColor = Color.Red;
            return;
        }
        if (TextBox4.Text == "")
        {
            MessageBox("Kindly Select Class and Section to generate Roll Number");
            TextBox4.BorderColor = Color.Red;
            return;
        }
        if (TextBox6.Text == "")
        {
            MessageBox("Kindly enter Parent's ID");
            TextBox6.BorderColor = Color.Red;
            return;
        }
        if (TextBox8.Text.Length < 30)
        {
            MessageBox("Minimum 30 characters needed");
            TextBox8.BorderColor = Color.Red;
            return;
        }
        if (DropDownList1.SelectedItem.Text == "Select Gender")
        {
            MessageBox("Kindly select Students Gender");
            DropDownList1.BorderColor = Color.Red;
            return;
        }

        if (DropDownList2.SelectedItem.Text == "Select Blood Group")
        {
            MessageBox("Kindly enter Students Blood Group");
            DropDownList2.BorderColor = Color.Red;
            return;
        }
        if (DropDownList3.SelectedItem.Text == "Select Religion")
        {
            MessageBox("Kindly enter Students Religion");
            DropDownList3.BorderColor = Color.Red;
            return;
        }
        if (DropDownList4.SelectedItem.Text == "Select Class")
        {
            MessageBox("Kindly enter Students Class");
            DropDownList4.BorderColor = Color.Red;
            return;
        }


        //validation ends
        //check file(passport)
        if (FileUpload1.HasFile)
        {
            string FileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);

            if (FileExtention == ".jpg" || FileExtention == ".png" || FileExtention == ".jpeg" || FileExtention == ".JPG")
            {

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Only PNG & JPG Files are allowed";
                Label1.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string path = Server.MapPath("~/Students/");
            string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            string NewName = TextBox1.Text + "_" + DateTime.Now.ToString("ddMMyyHHmm");
            Label2.Text = NewName.ToString();
            Label3.Text = extension;
            FileUpload1.SaveAs(path + NewName + extension);

        }
        else
        {
            Label1.Visible = true;
            Label1.Text = "Please Select your file";
            Label1.ForeColor = System.Drawing.Color.Red;
            return;
        }

        //validate Parent ID
        SqlCommand cmdx = new SqlCommand();
        SqlDataAdapter sdax = new SqlDataAdapter();
        DataSet dsx = new DataSet();
        SqlConnection contx = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        contx.Open();
        cmdx.CommandText = "select count(*) as count from D_Parents where PID='" + TextBox6.Text + "'";
        cmdx.Connection = contx;
        sdax.SelectCommand = cmdx;
        sdax.Fill(dsx, "D_Students");
        string parentt = dsx.Tables[0].Rows[0]["count"].ToString();
        contx.Close();

        if (parentt != "1")
        {
            MessageBox("Kindly verify Parent ID");
            TextBox6.BorderColor = Color.Red;
            return;
        }
        //check if threshold is reached
        int all = int.Parse(Label4.Text);
        contx.Open();
        SqlCommand comm = new SqlCommand("SELECT COUNT(SID) FROM D_Students", contx);
        Int32 count = Convert.ToInt32(comm.ExecuteScalar());
        if (count >= all)
        {
            MessageBox("You have reached the limit allowed on the platform, limit is " + all + "");
            return;
        }
        else
        {

        }
        contx.Close();
        int jennifer = all - count;
        //add to Db & redirect to All Students
        string query = "insert into D_Students (Section,filetype,Admission_ID,Parent_ID,FirstName,LastName,Gender,DOB,Roll_No,BG,Religion,Email,Class,Bio,Photo,Capture_Date,Capture_By,Password,LoginC) values ('"+Label5.Text+"','" + Label3.Text + "','" + TextBox1.Text + "_" + DateTime.Now.ToString("ddMMyyHHss") + "','" + TextBox6.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList1.SelectedItem.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + DropDownList2.SelectedItem.Text + "','" + DropDownList3.SelectedItem.Text + "','" + TextBox5.Text + "','" + DropDownList4.SelectedValue + "','" + TextBox8.Text + "','" + Label2.Text + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + Session["StaffID"].ToString() + "','123456','0')";
        insertRecord(query);

        //increase the class roll
        string j = "update D_Classes set rollNo='"+TextBox4.Text+"' where ClassID='"+DropDownList4.SelectedValue+"'";
        insertRecord(j);

        MessageBox("Details Captured Successfully, you have "+jennifer+" Students slots left out of the "+all+" slots");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "1;url=admin_students.aspx";
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
            string com = "Select ClassID,FClass from D_Classes";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList4.DataSource = dt;
            DropDownList4.DataBind();
            DropDownList4.DataTextField = "FClass";
            DropDownList4.DataValueField = "ClassID";
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, new ListItem("Select Class", "0"));
            con.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string qqy = "SID,Admission_ID,Parent_ID,FirstName,LastName,Gender,DOB,Roll_No,BG,Religion,Email,Class,Section,Bio,Photo,Capture_Date,Capture_By,LoginC from D_Students where FirstName like '%" + TextBox1.Text + "%' or LastName like '%" + TextBox1.Text + "%' OR SID like '%" + TextBox1.Text + "%'";
        GridviewBind(qqy);

        if (GridView1.Rows.Count == 0)
        {
            MessageBox("Your Search Returned No Result");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=Admin_Students.aspx";
            this.Page.Controls.Add(meta); return;
        }
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList4.SelectedItem.Text == "Select Class")
        {

        }
        else
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlConnection cont = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            cont.Open();
            cmd.CommandText = "select count(*) as count from D_Students where Class='" + DropDownList4.SelectedValue + "'";
            cmd.Connection = cont;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Students");
            TextBox4.Text = ds.Tables[0].Rows[0]["count"].ToString();
            cont.Close();

            if (TextBox4.Text == "")
            {
                TextBox4.Text = "0";
            }
            //get the Section
            SqlCommand cmdo = new SqlCommand();
            SqlDataAdapter sdao = new SqlDataAdapter();
            DataSet dso = new DataSet();
            SqlConnection cono = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            cono.Open();
            cmdo.CommandText = "select Section as sid from D_Classes where Classid = '" + DropDownList4.SelectedValue + "'";
            cmdo.Connection = cono;
            sdao.SelectCommand = cmdo;
            sdao.Fill(dso, "D_Classes");
            Label5.Text = dso.Tables[0].Rows[0]["sid"].ToString();
            cono.Close();

        }
    }


}
