﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Parents_Dashboard2.aspx.cs" Inherits="Admin_Parents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js" lang="">
<head runat="server">
     <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>School Master | Guardian</title>
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- Favicon -->
    <link rel="shortcut icon" type="image/x-icon" href="img/favicon.png">
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
    <!-- Data Table CSS -->
    <link rel="stylesheet" href="css/jquery.dataTables.min.css">
    <!-- Custom CSS -->
    <link rel="stylesheet" href="style.css">
    <!-- Modernize js -->
    <script src="js/modernizr-3.6.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <%--  --%>
    <!-- Preloader End Here -->
    <div id="wrapper" class="wrapper bg-ash">
        <!-- Header Menu Area Start Here -->
        <div class="navbar navbar-expand-md header-menu-one bg-light">
            <div class="nav-bar-header-one">
                <div class="header-logo">
                    <a href="#">
                         <asp:Image ID="Image1" runat="server"  Width="170px" Height="80px"/>
                    </a>
                </div>
                  <div class="toggle-button sidebar-toggle">
                    <button type="button" class="item-link">
                        <span class="btn-icon-wrap">
                            <span></span>
                            <span></span>
                            <span></span>
                        </span>
                    </button>
                </div>
            </div>
            <div class="d-md-none mobile-nav-bar">
               <button class="navbar-toggler pulse-animation" type="button" data-toggle="collapse" data-target="#mobile-navbar" aria-expanded="false">
                    <i class="far fa-arrow-alt-circle-down"></i>
                </button>
                <button type="button" class="navbar-toggler sidebar-toggle-mobile">
                    <i class="fas fa-bars"></i>
                </button>
            </div>
            <div class="header-main-menu collapse navbar-collapse" id="mobile-navbar">
                <ul class="navbar-nav">
                   <asp:Label ID="Labelza" runat="server" Text="Label"></asp:Label>
                </ul>
                <ul class="navbar-nav">
                    <li class="navbar-item dropdown header-admin">
                        <a class="navbar-nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown"
                            aria-expanded="false">
                            <div class="admin-title">
                                <h5 class="item-title">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>  <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></h5>
                            </div>
                            <div class="admin-img">
                                <img src="img/figure/admin.jpg" alt="Admin">
                            </div>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right">
                            <div class="item-header">
                                <h6 class="item-title">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></h6>
                            </div>
                            <div class="item-content">
                                <ul class="settings-list">
                                    <li><a href="profile.aspx"><i class="flaticon-user"></i>My Profile</a></li>
                                    <li><a href="logout.aspx"><i class="flaticon-turn-off"></i>Log Out</a></li>
                                </ul>
                            </div>
                        </div>
                    </li>

                </ul>
            </div>
        </div>
        <!-- Header Menu Area End Here -->
        <!-- Page Area Start Here -->
        <div class="dashboard-page-one">
            <!-- Sidebar Area Start Here -->
            <div class="sidebar-main sidebar-menu-one sidebar-expand-md sidebar-color">
               <div class="mobile-sidebar-header d-md-none">
                    <div class="header-logo">
                        <a href="#"><img src="img/logo1.png" alt="logo"></a>
                    </div>
               </div>
                <div class="sidebar-menu-content">
                    <ul class="nav nav-sidebar-menu sidebar-toggle-view">
                          <li class="nav-item">
                            <a href="parents_dashboard2.aspx" class="nav-link"><i
                                    class="flaticon-dashboard"></i><span>Dashboard</span></a>
                        </li>
                         <li class="nav-item">
                            <a href="kids.aspx" class="nav-link"><i
                                    class="flaticon-multiple-users-silhouette"></i><span>My Kids</span></a>
                        </li>
                         <li class="nav-item">
                            <a href="Communication.aspx" class="nav-link"><i
                                    class="flaticon-multiple-users-silhouette"></i><span>Communications</span></a>
                        </li>
                         <li class="nav-item">
                            <a href="finances.aspx" class="nav-link"><i
                                    class="flaticon-couple"></i><span>Finances</span></a>
                        </li>
                           <li class="nav-item">
                            <a href="plogout.aspx" class="nav-link"><i
                                    class="flaticon-bus-side-view"></i><span>Sign Out</span></a>
                        </li>

                    </ul>
                </div>
            </div>
            <!-- Sidebar Area End Here -->
            <div class="dashboard-content-one">
                <!-- Breadcubs Area Start Here -->
                <div class="breadcrumbs-area">
                    <h3>Parent Dashboard</h3>
                </div>
                <!-- Breadcubs Area End Here -->

                <div class="card height-auto">
                    <div class="card-body">
                     <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/icon2.jpg" Width="150px" Height="150px"  BorderWidth="3px" BorderColor="Orange" OnClick="ImageButton2_Click" BorderStyle="None"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/icon1.jpg" Width="150px" Height="150px"  BorderWidth="3px" BorderColor="Orange" OnClick="ImageButton3_Click" BorderStyle="None"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/icon3.jpg" Width="150px" Height="150px"  BorderWidth="3px" BorderColor="Orange" OnClick="ImageButton4_Click" BorderStyle="None"/>
                     <br />  <br />  <br />  <br />  <br />  <br />  <br />  <br />  <br />  <br />  <br />  <br />
                    </div>
                </div>
                <!-- Dashboard Content Start Here -->

                <footer class="footer-wrap-layout1">
                    <div class="copyright">© Copyrights <a href="#">DataPlus </a> 2022. All rights reserved.</div>
                </footer>
                <!-- Dashboard Content End Here -->
            </div>
        </div>
        <!-- Page Area End Here -->
    </div>
    <!-- jquery-->
    <script src="js/jquery-3.3.1.min.js"></script>
    <!-- Plugins js -->
    <script src="js/plugins.js"></script>
    <!-- Popper js -->
    <script src="js/popper.min.js"></script>
    <!-- Bootstrap js -->
    <script src="js/bootstrap.min.js"></script>
    <!-- Counterup Js -->
    <script src="js/jquery.counterup.min.js"></script>
    <!-- Waypoints Js -->
    <script src="js/jquery.waypoints.min.js"></script>
    <!-- Scroll Up Js -->
    <script src="js/jquery.scrollUp.min.js"></script>
    <!-- Data Table Js -->
    <script src="js/jquery.dataTables.min.js"></script>
    <!-- Custom Js -->
    <script src="js/main.js"></script>

        </div>
    </form>
</body>
</html>
