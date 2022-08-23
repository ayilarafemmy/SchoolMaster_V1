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
using System.Security.Cryptography;
using System.Text;

public partial class kids : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    SqlCommand cmd1 = new SqlCommand();
    SqlConnection con1 = new SqlConnection();
    SqlDataAdapter sda1 = new SqlDataAdapter();
    DataSet ds1 = new DataSet();

    SqlCommand cmd2 = new SqlCommand();
    SqlConnection con2 = new SqlConnection();
    SqlDataAdapter sda2 = new SqlDataAdapter();
    DataSet ds2 = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Convert.ToString(Session["StaffID"])))
        {
            Response.Redirect("admin.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            Label2.Text = Session["FullName"].ToString();
            Label3.Text = Session["email"].ToString();
        }

        if (!IsPostBack)
        {

            BindGrid1();

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
    protected void Button4_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    int joe = Convert.ToInt32(Label12.Text);
        //    int newll = Convert.ToInt32(TextBox5.Text);
        //    int ne = joe + newll;
        //    string ppp = "Update SS_Customers Set Wallet ='" + ne + "' where Phone = '" + Session["Phone"].ToString() + "'";
        //    insertRecord(ppp);
        //    string pp = "Insert into SS_Inflow (Amount,Cust_Phone,Cust_Email,Inflow_Desc,Inflow_Comment,Inflow_Date,Inflow_Time) values ('" + TextBox5.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','Wallet Funding','Successful','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + DateTime.Now.ToString("hh:mm:ss tt") + "')";
        //    insertRecord(pp);
        //    Label14.Visible = true;
        //    Label14.Text = "Payment Successful!";
        //    HtmlMeta meta = new HtmlMeta();
        //    meta.HttpEquiv = "Refresh";
        //    meta.Content = "1;url=customer_fund.aspx";
        //    this.Page.Controls.Add(meta);
        //}
        //catch (Exception kike)
        //{
        //    Label14.Visible = true;
        //    Label14.Text = "Error is " + kike + "";
        //}
    }
    static string ComputeSha256Hash(string rawData)
    {
        // Create a SHA256
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // ComputeHash - returns byte array
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Convert byte array to a string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(TextBox1.Text=="")
        {
            MessageBox("Kindly Enter Amount to Pay");
            return;
        }
        if(DropDownList2.SelectedItem.Text== "Select Student")
        {
            MessageBox("Kindly Select Student");
            return;
        }
        string kkk = DateTime.Now.ToString("MMMyysshhmmMMddMMMyyyymmss") + "BuhariisthePresidentofNigeriaUnfortunately" + DateTime.Now.ToString("ddMMyyyyhhmmss");
        Label14.Text = ComputeSha256Hash(kkk);
        string firstLine = DateTime.Now.ToString("ddMMMyyhhddyyyyMM") + ComputeSha256Hash(kkk) + ComputeSha256Hash(kkk);

        //Label14.Visible = false;
        double hh = double.Parse(TextBox1.Text);
        int yy = (int)Math.Ceiling(hh);

        if (yy < 100)
        {
            MessageBox("Minimum Amount is 100 Naira");
            return;
        }
        else
        {

        }
        try
        {
            string jj = "insert into D_Online(EntryKey,PID,SID,Amount,Comment,Status) values ('"+Label14.Text+"','"+ Session["PID"].ToString()+"','"+DropDownList2.SelectedValue+"','"+TextBox1.Text+"','"+TextBox2.Text+"','Open')";
            insertRecord(jj);

            MessageBox("You will now be redirected to Make your Payment");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=Payments.aspx?Intent="+firstLine+"&kee="+Label14.Text+"&SID="+DropDownList2.SelectedValue+"&jaguar = "+firstLine+"&Amount="+TextBox1.Text+"&APC="+firstLine+"&PID="+ Session["PID"].ToString() + "&Out="+TextBox4.Text+"";
            this.Page.Controls.Add(meta);

        }
        catch (Exception kike)
        {
            //Label14.Visible = true;
            //Label14.Text = "Error is " + kike + "";
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



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Panel1f.Visible = false;
        Panel1e.Visible = false;
        Panel1c.Visible = false;
        Panel1.Visible = true;
        Panel1a.Visible = false;
        Panel1b.Visible = false;
        Panel1c.Visible = false;
        Panel3.Visible = false;
        Panel2.Visible = false;
        Label1.Visible = true;
        Label1.Text = "Session Management";
        string jj = "select Concat(Year,' ',Period) as Session, Year, StartMonth,EndMonth,Period,Status from D_Session order by SessionID desc";
        GridviewBind(jj);

    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Panel1f.Visible = false;
        Panel1e.Visible = false;
        Panel1c.Visible = false;
        Panel1a.Visible = true;
        Panel1b.Visible = false;
        Panel1c.Visible = false;
        Panel1.Visible = false;
        Panel3.Visible = false;
        Panel2.Visible = false;
        Label1.Visible = true;
        Label1.Text = "Period Timing Management";
        string jj1 = "select * from D_PeriodPeriod";
        GridviewBind1a(jj1);

    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Panel1f.Visible = false;
        Panel1e.Visible = false;
        Panel1d.Visible = false;
        Panel1c.Visible = false;
        Panel1b.Visible = true;
        Panel1a.Visible = false;
        Panel1.Visible = false;
        Panel3.Visible = false;
        Panel2.Visible = false;
        Label1.Visible = true;
        Label1.Text = "Exams Timing Management";
        string jj2 = "select * from D_ExamPeriod";
        GridviewBind1b(jj2);

    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Panel1f.Visible = false;
        Panel1d.Visible = false;
        Panel1c.Visible = true;
        Panel1b.Visible = false;
        Panel1a.Visible = false;
        Panel1.Visible = false;
        Panel3.Visible = false;
        Panel2.Visible = false;
        Label1.Visible = true;
        Label1.Text = "Routes Management";
        string jj3 = "select * from D_Routes";
        GridviewBind1c(jj3);

    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        Panel1f.Visible = false;
        Panel1e.Visible = false;
        Panel1d.Visible = true;
        Panel1c.Visible = false;
        Panel1b.Visible = false;
        Panel1a.Visible = false;
        Panel1.Visible = false;
        Panel3.Visible = false;
        Panel2.Visible = false;
        Label1.Visible = true;
        Label1.Text = "Subjects Management";
        string jj4 = "select * from D_Subject_Area";
        GridviewBind1d(jj4);

    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        Panel1f.Visible = false;
        Panel1e.Visible = true;
        Panel1d.Visible = false;
        Panel1c.Visible = false;
        Panel1b.Visible = false;
        Panel1a.Visible = false;
        Panel1.Visible = false;
        Panel3.Visible = false;
        Panel2.Visible = false;
        Label1.Visible = true;
        Label1.Text = "Payment Gateway Management";
        string jj5 = "select PGKey from D_CustomerConfig";
        GridviewBind1e(jj5);

    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        Panel1f.Visible = true;
        Panel1e.Visible = false;
        Panel1d.Visible = false;
        Panel1c.Visible = false;
        Panel1b.Visible = false;
        Panel1a.Visible = false;
        Panel1.Visible = false;
        Panel3.Visible = false;
        Panel2.Visible = false;
        Label1.Visible = true;
        Label1.Text = "Payment Gateway Logs";
        string jj6 = "select * from D_Online order by OPID desc";
        GridviewBind1f(jj6);

    }
    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        Panel1f.Visible = true;
        Panel1e.Visible = false;
        Panel1d.Visible = false;
        Panel1c.Visible = false;
        Panel1b.Visible = false;
        Panel1a.Visible = false;
        Panel1.Visible = false;
        Panel3.Visible = false;
        Panel2.Visible = false;
        Label1.Visible = true;
        Label1.Text = "General Logs";
        string jj6 = "select * from D_Logs order by LogID desc";
        GridviewBind1f(jj6);
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
    protected void GridviewBind1a(string query)
    {
        try
        {
            string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView3.DataSource = dr;
                GridView3.DataBind();
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
    protected void GridviewBind1b(string query)
    {
        try
        {
            string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView4.DataSource = dr;
                GridView4.DataBind();
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
    protected void GridviewBind1c(string query)
    {
        try
        {
            string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView5.DataSource = dr;
                GridView5.DataBind();
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
    protected void GridviewBind1d(string query)
    {
        try
        {
            string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView6.DataSource = dr;
                GridView6.DataBind();
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
    protected void GridviewBind1e(string query)
    {
        try
        {
            string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView7.DataSource = dr;
                GridView7.DataBind();
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
    protected void GridviewBind1f(string query)
    {
        try
        {
            string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView8.DataSource = dr;
                GridView8.DataBind();
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

    protected void BindGrid1()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select concat(FirstName,' ',LastName) as FullName,SID from D_Students where Parent_ID='" + Session["StaffID"].ToString()+ "'";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "FullName";
            DropDownList2.DataValueField = "SID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Select Student", "0"));
            con.Close();
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DropDownList2.SelectedItem.Text== "Select Student")
        {

        }
        else
        {
            //get balance of child selected
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select Balance from D_Students where SID='" + DropDownList2.SelectedValue + "'";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Students");

            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox4.Visible = true;
                Label4.Visible = true;
                TextBox4.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
                Label4.Text = "Outstanding fees for " + DropDownList2.SelectedItem.Text + " in Naira";
                if (TextBox4.Text == "")
                {
                    TextBox4.Text = "0";
                }
            }
            con.Close();
        }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //validate entries
        if (DropDownList3.SelectedItem.Text == "Select Year")
        {
            MessageBox("Kindly Select Year");
            DropDownList3.BorderColor = Color.Red;
            return;
        }
        if (DropDownList1.SelectedItem.Text == "Select Month")
        {
            MessageBox("Kindly Select Month");
            DropDownList1.BorderColor = Color.Red;
            return;
        }
        if(TextBox6.Text =="")
        {
            MessageBox("Kindly Provide the Period Definition");
            TextBox6.BorderColor = Color.Red;
            return;
        }
        //close the current Open
        string p1 = "Update D_Session set Status ='Çlosed',ClosedBy='"+Session["StaffID"].ToString()+ "',EndMonth='"+DateTime.Now.ToString("MMM")+"' where Status ='Open'";
        insertRecord(p1);
        //enter the new one
        string p2 = "Insert into D_Session (Year,StartMonth,Period,CreatedBy,CreateDate,Status) values ('"+DropDownList3.SelectedItem.Text+"','"+DropDownList1.SelectedItem.Text+"','"+TextBox6.Text+ "','" + Session["StaffID"].ToString() + "','"+DateTime.Now.ToString("dd/MM/yyyy")+"','Open')";
        insertRecord(p2);

        MessageBox("Created Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=account-settings.aspx";
        this.Page.Controls.Add(meta);

    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox5.Text == "")
        {
            MessageBox("Kindly Provide Start Time");
            TextBox5.BorderColor = Color.Red;
            return;
        }
        if (TextBox7.Text == "")
        {
            MessageBox("Kindly Provide End Time");
            TextBox7.BorderColor = Color.Red;
            return;
        }
        string time = TextBox5.Text + "-" + TextBox7.Text;
        string ojn = "Insert into D_PeriodPeriod (Timing,CreatedBy,CreateDate) values ('"+time+"','"+Session["StaffID"].ToString()+"','"+DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")+"')";
        insertRecord(ojn);
        MessageBox("Created Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=account-settings.aspx";
        this.Page.Controls.Add(meta);
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        if (TextBox8.Text == "")
        {
            MessageBox("Kindly Provide Start Time");
            TextBox8.BorderColor = Color.Red;
            return;
        }
        if (TextBox9.Text == "")
        {
            MessageBox("Kindly Provide End Time");
            TextBox9.BorderColor = Color.Red;
            return;
        }
        string time = TextBox8.Text + "-" + TextBox9.Text;
        string ojn = "Insert into D_ExamPeriod (Time,CreateBy,CreateDate) values ('" + time + "','" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "')";
        insertRecord(ojn);
        MessageBox("Created Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=account-settings.aspx";
        this.Page.Controls.Add(meta);
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        if (TextBox10.Text == "")
        {
            MessageBox("Kindly Provide Route");
            TextBox10.BorderColor = Color.Red;
            return;
        }

        string ojn = "Insert into D_Routes (Route,CreatedBy,CreateDate) values ('" + TextBox10.Text + "','" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "')";
        insertRecord(ojn);
        MessageBox("Created Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=account-settings.aspx";
        this.Page.Controls.Add(meta);
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        if (TextBox11.Text == "")
        {
            MessageBox("Kindly Provide Subject");
            TextBox11.BorderColor = Color.Red;
            return;
        }
        if (TextBox12.Text == "")
        {
            MessageBox("Kindly Provide Comment");
            TextBox12.BorderColor = Color.Red;
            return;
        }

        string ojn = "Insert into D_Subject_Area (Subject_Area,Comment,CreateBy,CreateDate) values ('" + TextBox11.Text + "','" + TextBox12.Text + "','" + Session["StaffID"].ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "')";
        insertRecord(ojn);
        MessageBox("Created Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=account-settings.aspx";
        this.Page.Controls.Add(meta);
    }

    protected void Button10_Click(object sender, EventArgs e)
    {
        if(GridView7.Rows.Count ==0)
        {
            //validate and insert
            if(TextBox13.Text =="")
            {
                MessageBox("Kindly provide Payment Gateway Key Generated on your paystack account");
                return;
            }
            string kjj = "insert into D_CustomerConfig (PGKey) values ('"+TextBox13.Text+"')";
            insertRecord(kjj);
            MessageBox("Created Successfully");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=account-settings.aspx";
            this.Page.Controls.Add(meta);
        }
        else
        {
            //validate and Update
            string kjja = "Update D_CustomerConfig  set PGKey='" + TextBox13.Text + "'";
            insertRecord(kjja);
            MessageBox("Updated Successfully");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=account-settings.aspx";
            this.Page.Controls.Add(meta);
        }

    }


}
