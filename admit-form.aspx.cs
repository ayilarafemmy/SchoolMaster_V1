using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.HtmlControls;

public partial class admit_form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            BindGrid1();
        }
    }
    protected void BindGrid()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select ClassID,Class from D_Classes";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList4.DataSource = dt;
            DropDownList4.DataBind();
            DropDownList4.DataTextField = "Class";
            DropDownList4.DataValueField = "ClassID";
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, new ListItem("Select Class", "0"));
            con.Close();
        }
    }
    protected void BindGrid1()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select SectionsID,Section from D_Sections";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList5.DataSource = dt;
            DropDownList5.DataBind();
            DropDownList5.DataTextField = "Section";
            DropDownList5.DataValueField = "SectionsID";
            DropDownList5.DataBind();
            DropDownList5.Items.Insert(0, new ListItem("Select Section", "0"));
            con.Close();
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
        if(TextBox1.Text=="")
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
        if (DropDownList5.SelectedItem.Text == "Select Section")
        {
            MessageBox("Kindly enter Students Section");
            DropDownList5.BorderColor = Color.Red;
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
        cmdx.CommandText = "select count(*) as count from D_Parents where PID='"+TextBox6.Text+"'";
        cmdx.Connection = contx;
        sdax.SelectCommand = cmdx;
        sdax.Fill(dsx, "D_Students");
        string parentt = dsx.Tables[0].Rows[0]["count"].ToString();
        contx.Close();

        if(parentt != "1")
        {
            MessageBox("Kindly verify Parent ID");
            TextBox6.BorderColor = Color.Red;
            return;
        }
        //add to Db & redirect to All Students
        string query = "insert into D_Students (filetype,Admission_ID,Parent_ID,FirstName,LastName,Gender,DOB,Roll_No,BG,Religion,Email,Class,Section,Bio,Photo,Capture_Date,Capture_By,Password,LoginC) values ('"+Label3.Text+"','" + TextBox1.Text+"_"+DateTime.Now.ToString("ddMMyyHHss")+"','"+TextBox6.Text+"','"+TextBox1.Text+"','"+TextBox2.Text+"','"+DropDownList1.SelectedItem.Text+"','"+TextBox3.Text+"','"+TextBox4.Text+"','"+DropDownList2.SelectedItem.Text+"','"+DropDownList3.SelectedItem.Text+"','"+TextBox5.Text+"','"+DropDownList4.SelectedValue+"','"+DropDownList5.SelectedValue+"','"+TextBox8.Text+"','"+Label2.Text+"','"+DateTime.Now.ToString("dd/MM/yyyy")+"','"+Session["StaffID"].ToString()+"','123456','0')";
        insertRecord(query);

        MessageBox("Details Captured Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "1;url=all-student.aspx";
        this.Page.Controls.Add(meta);

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
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DropDownList4.SelectedItem.Text== "Select Class")
        {
            DropDownList5.Enabled = false;
        }
        else
        {
            DropDownList5.Enabled = true;
        }
    }

    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        //count the number in class to update roll
        if(DropDownList4.SelectedItem.Text != "Select Class" || DropDownList5.SelectedItem.Text != "Select Section")
        {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlConnection cont = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        cont.Open();
        cmd.CommandText = "select count(*) as count from D_Students where Class='"+DropDownList4.SelectedValue+"' and Section='"+DropDownList5.SelectedValue+"'";
        cmd.Connection = cont;
        sda.SelectCommand = cmd;
        sda.Fill(ds, "D_Students");
        TextBox4.Text = ds.Tables[0].Rows[0]["count"].ToString();
        cont.Close();

            if (TextBox4.Text == "")
            {
                TextBox4.Text = "0";
            }

        }
        else
        {
            TextBox4.Text = "";
        }
    }
}
