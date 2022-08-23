using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Web.UI.HtmlControls;

public partial class add_book : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["Email"])))
        {
            Response.Redirect("Default.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
        }

        if (Session["Email"] != null)
        {


        }
        else
        {
            Response.Redirect("Default.aspx");
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //check if name exist
        //upload file
        if (FileUpload1.HasFile)
        {
            string FileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);
            string path = Server.MapPath("~/LMS/");
            string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            string NewName = TextBox1.Text + "_" + DateTime.Now.ToString("ddMMyyHHmm");
            Label2.Text = NewName.ToString();
            Label3.Text = extension;
            FileUpload1.SaveAs(path + NewName + extension);
            if(FileUpload1.PostedFile.ContentLength >= 412345678)
            {
                MessageBox("This is a local server, max allowed is 41Mb, file upload is " + FileUpload1.PostedFile.ContentLength + "");
                return;
            }

        }
        else
        {
            Label1.Visible = true;
            Label1.Text = "Please Select your file";
            Label1.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (TextBox1.Text.Length < 3)
        {
            MessageBox("Kindly Provide Your Material Name");
            TextBox1.BorderColor = Color.Red;
            return;
        }
        if (TextBox2.Text.Length < 20)
        {
            MessageBox("Kindly Provide Description");
            TextBox2.BorderColor = Color.Red;
            return;
        }
        if (TextBox3.Text=="")
        {
            MessageBox("Kindly Provide Expiry Date");
            TextBox3.BorderColor = Color.Red;
            return;
        }
        if(DropDownList1.SelectedItem.Text== "Select Subject Area")
        {
            MessageBox("Select Subject Area");
            return;
        }
        if (DropDownList2.SelectedItem.Text == "Select Class")
        {
            MessageBox("Select Class");
            return;
        }
        if (DropDownList3.SelectedItem.Text == "Select Material Type")
        {
            MessageBox("Select Material Type");
            return;
        }


        string query = "insert into D_Lms (MaterialType,Material,Subject,Uploadedby,Class,Description,Doc,filetype,Downloadcount,Expirydate) values ('"+DropDownList3.SelectedItem.Text+"','" + TextBox1.Text+"','"+DropDownList1.SelectedItem.Text+"','"+Session["StaffID"].ToString()+"','"+DropDownList2.SelectedItem.Text+"','"+TextBox2.Text+"','"+ Label2.Text+ "','"+ Label3.Text + "','0','"+TextBox3.Text+"')";
        insertRecord(query);

        MessageBox("Upload Successful");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=add-book.aspx";
        this.Page.Controls.Add(meta);
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
}
