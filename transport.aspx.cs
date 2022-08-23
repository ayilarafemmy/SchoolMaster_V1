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
using System.Net.Mail;
using System.Net;

public partial class Admin_Students : System.Web.UI.Page
{
    SqlCommand cmdj = new SqlCommand();
    SqlConnection conj = new SqlConnection();
    SqlDataAdapter sdaj = new SqlDataAdapter();
    DataSet dsj = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string query = "select a.VehicleID, a.PlateNo, a.VehiclePurpose, b.Route,a.comment, a.Status,concat(c.FirstName, ' ',c.LastName) as Driver from D_Vehicles a, D_Routes b, D_Staff c where a.RouteID = b.RoutesID and a.Driver = c.StaffID";
            GridviewBind(query);
            BindGrid();
            //BindGrid1();
            BindGrid2();
            BindGrid3();
        }
    }
    protected void BindGrid()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "Select RoutesID,Route from D_Routes order by routesID asc";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList4.DataSource = dt;
            DropDownList4.DataBind();
            DropDownList4.DataTextField = "Route";
            DropDownList4.DataValueField = "RoutesID";
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, new ListItem("Select Route", "0"));
            con.Close();
        }
    }
    //protected void BindGrid1()
    //{
    //    string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
    //    using (SqlConnection con = new SqlConnection(constring))
    //    {
    //        con.Open();
    //        string com = "Select VehicleID,PlateNo from D_Vehicles";
    //        SqlDataAdapter adpt = new SqlDataAdapter(com, con);
    //        DataTable dt = new System.Data.DataTable();
    //        adpt.Fill(dt);
    //        DropDownList5.DataSource = dt;
    //        DropDownList5.DataBind();
    //        DropDownList5.DataTextField = "PlateNo";
    //        DropDownList5.DataValueField = "VehicleID";
    //        DropDownList5.DataBind();
    //        DropDownList5.Items.Insert(0, new ListItem("Select Vehicle", "0"));
    //        con.Close();
    //    }
    //}
    protected void BindGrid2()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select Concat(FirstName,' ',LastName) as Name,StaffID from D_Staff";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "StaffID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select Driver", "0"));
            con.Close();
        }
    }
    protected void BindGrid3()
    {
        string constring = ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            string com = "select Concat(FirstName,' ',LastName) as Name,StaffID from D_Staff;";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new System.Data.DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "Name";
            DropDownList2.DataValueField = "StaffID";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("Select Support Staff", "0"));
            con.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList4.SelectedItem.Text == "Select Route")
        {
            MessageBox("Kindly Select Route");
            DropDownList4.BorderColor = Color.Red;
            return;
        }

        if (DropDownList1.SelectedItem.Text == "Select Driver")
        {
            DropDownList1.SelectedItem.Text = "";
        }
        if (DropDownList2.SelectedItem.Text == "Select Support Staff")
        {
            DropDownList2.SelectedItem.Text = "";
        }
        if (DropDownList3.SelectedItem.Text == "Select Purpose")
        {
            MessageBox("Select Purpose");
            return;
        }




            //validation ends
            //check file(passport)
            if (FileUpload1.HasFile)
        {
            string FileExtention = System.IO.Path.GetExtension(FileUpload1.FileName);

            if (FileExtention == ".jpg" || FileExtention == ".png" || FileExtention == ".jpeg" || FileExtention == ".JPG" || FileExtention == ".pdf" || FileExtention == ".doc")
            {

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Only PNG,JPG,pdf and word Files are allowed";
                Label1.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string path = Server.MapPath("~/Vehicles/");
            string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            string NewName = DropDownList4.SelectedItem.Text + "_" + DateTime.Now.ToString("ddMMyyHHmm");
            Label2.Text = NewName.ToString();
            Label3.Text = NewName + extension;
            FileUpload1.SaveAs(path + NewName + extension);

        }
        else
        {
            Label1.Visible = true;
            Label1.Text = "Please Select your file";
            Label1.ForeColor = System.Drawing.Color.Red;
            return;
        }

        //if (TextBox7.Text == "")
        //{
        //    MessageBox("Phone Number is very compulsory");
        //    return;
        //}
        if (TextBox1.Text == "")
        {
            MessageBox("Kindly provide Vehicle Plate Number");
            return;
        }

        //check if vehicle exists
        SqlCommand cmdx = new SqlCommand();
        SqlDataAdapter sdax = new SqlDataAdapter();
        DataSet dsx = new DataSet();
        SqlConnection conx = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
        conx.Open();
        cmdx.CommandText = "select PlateNo from D_Vehicles where PlateNo='" + TextBox1.Text + "'";
        cmdx.Connection = conx;
        sdax.SelectCommand = cmdx;
        sdax.Fill(dsx, "D_Vehicles");

        if (dsx.Tables[0].Rows.Count > 0)
        {
            string myStringVariable = "Vehicle with Plateno : " + TextBox1.Text + " exists";
            TextBox1.BackColor = System.Drawing.Color.Red;
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            return;

        }
        else
        {

        }
        conx.Close();



        string insert = "Insert into D_Vehicles(Phone,RouteID,PlateNo,Driver,SupportStaff,VehiclePurpose,Comment,VehicleDoc,Status,Capture_Date,Capture_By) values (''"+ TextBox7.Text+ "',"+DropDownList4.SelectedValue+"','"+ TextBox1.Text+ "','"+ DropDownList1.SelectedValue + "','"+ DropDownList2.SelectedValue + "','"+ DropDownList3.SelectedItem.Text+ "','"+ TextBox4.Text+ "','"+ Label3.Text + "','Active','"+DateTime.Now.ToString("dd/MM/yyyy")+"','"+Session["StaffID"].ToString()+"')";
        insertRecord(insert);


        MessageBox("Details Captured Successfully");
        HtmlMeta meta = new HtmlMeta();
        meta.HttpEquiv = "Refresh";
        meta.Content = "0;url=transport.aspx";
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
    public static void SendMail(string receiver, string body, string subject, string server, string Senderemail, string SenderID, string Mail_Password, int joe)
    {

        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("" + server + "");

        mail.From = new MailAddress("" + Senderemail + "", "" + SenderID + "");
        mail.To.Add(receiver);
        mail.Subject = subject;
        mail.Body = body;
        SmtpServer.EnableSsl = true;
        SmtpServer.Port = joe;
        SmtpServer.Credentials = new System.Net.NetworkCredential("" + Senderemail + "", "" + Mail_Password + "");
        SmtpServer.EnableSsl = false;
        NetworkCredential NetworkCred = new NetworkCredential("" + Senderemail + "", "" + Mail_Password + "");
        SmtpServer.Send(mail);


    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        string qqy = "select a.VehicleID, a.PlateNo, a.VehiclePurpose, b.Route,a.comment, a.Status,concat(c.FirstName, ' ',c.LastName) as Driver from D_Vehicles a, D_Routes b, D_Staff c where a.RouteID = b.RoutesID and a.Driver = c.StaffID where Driver like '%" + TextBox2a.Text + "%' or a.PlateNo like '%" + TextBox2a.Text + "%' OR b.Route like '%" + TextBox2a.Text + "%' OR a.Status like '%" + TextBox1.Text + "%'";
        GridviewBind(qqy);

        if (GridView1.Rows.Count == 0)
        {
            MessageBox("Your Search Returned No Result");
            HtmlMeta meta = new HtmlMeta();
            meta.HttpEquiv = "Refresh";
            meta.Content = "0;url=transport.aspx";
            this.Page.Controls.Add(meta); return;
        }
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get phone number of driver
        if (DropDownList1.SelectedItem.Text == "Select Driver")
        {
            TextBox7.Text = "";
        }
        else
        {
            SqlConnection conj = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            conj.Open();
            cmdj.CommandText = "select Phone from D_Staff where StaffID='" + DropDownList1.SelectedValue + "'";
            cmdj.Connection = conj;
            sdaj.SelectCommand = cmdj;
            sdaj.Fill(dsj, "D_Staff");

            if (dsj.Tables[0].Rows.Count == 1)
            {
                TextBox7.Text = dsj.Tables[0].Rows[0]["Phone"].ToString();
            }
            conj.Close();
        }

    }
}
