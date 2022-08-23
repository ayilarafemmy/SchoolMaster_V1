﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="admit-form.aspx.cs" Inherits="admit_form" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Normalize CSS -->
    <link rel="stylesheet" href="css/normalize.css">
    <!-- Main CSS -->
    <link rel="stylesheet" href="css/main.css">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <!-- Fontawesome CSS -->
    <link rel="stylesheet" href="css/all.min.css">
    <!-- Flaticon CSS -->
    <link rel="stylesheet" href="fonts/flaticon.css">
    <!-- Animate CSS -->
    <link rel="stylesheet" href="css/animate.min.css">
    <!-- Select 2 CSS -->
    <link rel="stylesheet" href="css/select2.min.css">
    <!-- Date Picker CSS -->
    <link rel="stylesheet" href="css/datepicker.min.css">
    <!-- Custom CSS -->
    <link rel="stylesheet" href="style.css">
    <!-- Modernize js -->
    <script src="js/modernizr-3.6.0.min.js"></script>
      <div class="breadcrumbs-area">
                    <h3>Students</h3>
                    <ul>
                        <li>
                            <a href="Dashboard">Dashboard</a>
                        </li>
                        <li>Student Admission Form</li>
                    </ul>
                </div>
                <!-- Breadcubs Area End Here -->
                <!-- Admit Form Area Start Here -->
                <div class="card height-auto">
                    <div class="card-body">
                        <div class="heading-layout1">
                            <div class="item-title">
                                <h3>Add New Students
                                    <asp:Label ID="Label1" runat="server" Text="*" Visible="False"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text="*" Visible="False"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text="*" Visible="False"></asp:Label>
                                </h3>
                            </div>
                            <div class="dropdown">
                                <a class="dropdown-toggle" href="#" role="button" data-toggle="dropdown"
                                    aria-expanded="false">...</a>

                                <div class="dropdown-menu dropdown-menu-right">
                                    <a class="dropdown-item" href="#"><i
                                            class="fas fa-times text-orange-red"></i>Close</a>
                                    <a class="dropdown-item" href="#"><i
                                            class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                    <a class="dropdown-item" href="#"><i
                                            class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                </div>
                            </div>
                        </div>
                        <form class="new-added-form">
                            <div class="row">
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>First Name *</label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Last Name *</label>
                                   <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Maxlength="50"></asp:TextBox>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Gender *</label>   <br />
          <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
              <asp:ListItem>Select Gender</asp:ListItem>
              <asp:ListItem>Female</asp:ListItem>
              <asp:ListItem>Male</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Date Of Birth *</label>
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Roll</label>
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Blood Group *</label>
                                   <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                       <asp:ListItem>Select Blood Group</asp:ListItem>
                                       <asp:ListItem>A+</asp:ListItem>
                                       <asp:ListItem>A-</asp:ListItem>
                                       <asp:ListItem>B+</asp:ListItem>
                                       <asp:ListItem>B-</asp:ListItem>
                                       <asp:ListItem>0+</asp:ListItem>
                                       <asp:ListItem>O-</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Religion *</label>
                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
              <asp:ListItem>Select Religion</asp:ListItem>
              <asp:ListItem>Islam</asp:ListItem>
              <asp:ListItem>Christianity</asp:ListItem>
               <asp:ListItem>Hindu</asp:ListItem>
              <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>e-Mail</label>
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Class *</label>
                                    <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Section *</label>
                                   <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Parent ID</label>
                                      <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Phone</label>
                                       <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" TextMode="Number" MinLength="11" MaxLength="14"></asp:TextBox>
                                </div>
                                <div class="col-lg-6 col-12 form-group">
                                    <label>Short BIO</label>
                                       <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" TextMode="Multiline" Height="300px"></asp:TextBox>
                                </div>
                                <div class="col-lg-6 col-12 form-group mg-t-30">
                                    <label class="text-dark-medium">Upload Student Photo (150px X 150px)</label>
                                        <asp:FileUpload ID="FileUpload1" runat="server"  CssClass="form-control-file"/>
                                </div>
                                <div class="col-12 form-group mg-t-8">
                                            <asp:Button ID="Button1" runat="server" Text="Save"  CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click"/>
                                    <asp:Button ID="Button2" runat="server" Text="Reset" CssClass="btn-fill-lg bg-blue-dark btn-hover-yellow" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <!-- Admit Form Area End Here -->
</asp:Content>

