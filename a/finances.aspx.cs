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
        if (string.IsNullOrEmpty(Convert.ToString(Session["PID"])))
        {
            Response.Redirect("parent.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
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
        Panel1.Visible = true;
        Panel3.Visible = false;
        Panel2.Visible = false;
        Label1.Visible = true;
        Label1.Text = "All Payments";
        string jj = "select a.Amount,a.Description,a.Type, b.Purpose, a.TransDate from D_Account a, D_PaymentPurpose b,D_Students c, D_Parents d where d.PID = c.Parent_ID and a.Purpose = b.PPID and a.Destination = 'inflow' and d.PID='"+Session["PID"].ToString()+"' order by a.ACID desc";
        GridviewBind(jj);

    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Panel2.Visible = true;
        Panel3.Visible = false;
        Panel1.Visible = false;
        Label1.Visible = true;
        Label1.Text = "Outstanding Payments";

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        con.Open();
        cmd.CommandText = "select sum(CAST(a.Balance AS INT)) as Balance from D_Students a, D_Parents b where a.Parent_ID = b.PID and b.PID='"+Session["PID"].ToString()+"'";
        cmd.Connection = con;
        sda.SelectCommand = cmd;
        sda.Fill(ds, "D_students");
        Label2.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
        con.Close();
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        con.Open();
        cmd.CommandText = "select sum(CAST(a.Balance AS INT)) as Balance from D_Students a, D_Parents b where a.Parent_ID = b.PID and b.PID='" + Session["PID"].ToString() + "'";
        cmd.Connection = con;
        sda.SelectCommand = cmd;
        sda.Fill(ds, "D_students");
        TextBox3.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
        con.Close();

        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
        Label1.Visible = true;
        Label1.Text = "Pay Online";
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

    protected void BindGrid1()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select concat(FirstName,' ',LastName) as FullName,SID from D_Students where Parent_ID='" + Session["PID"].ToString()+ "'";
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
}
