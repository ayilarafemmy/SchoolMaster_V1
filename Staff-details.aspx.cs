﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class parents_details : System.Web.UI.Page
{
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();

    SqlCommand cmdz = new SqlCommand();
    SqlConnection conz = new SqlConnection();
    SqlDataAdapter sdaz = new SqlDataAdapter();
    DataSet dsz = new DataSet();

    SqlCommand cmdy = new SqlCommand();
    SqlConnection cony = new SqlConnection();
    SqlDataAdapter sday = new SqlDataAdapter();
    DataSet dsy = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolMaster"].ConnectionString);
            con.Open();
            cmd.CommandText = "select * from D_Staff where StaffID=" + Request.QueryString["StaffID"].ToString()+"";
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(ds, "D_Staff");
            Label1.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            TextBox1.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["Role"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0]["SecondaryRole"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["CreateDate"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["Bio"].ToString();
            string ue = ds.Tables[0].Rows[0]["Profile"].ToString();
            Image1.ImageUrl = "~/Staff/" + ue+"";
            con.Close();



            cony.Close();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}
