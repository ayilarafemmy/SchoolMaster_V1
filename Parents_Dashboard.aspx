<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Parents_Dashboard.aspx.cs" Inherits="Admin_Parents" %>

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
         <%--   --%>
    <!-- Preloader End Here -->
    <div id="wrapper" class="wrapper bg-ash">
        <!-- Header Menu Area Start Here -->
        <div class="navbar navbar-expand-md header-menu-one bg-light">
            <div class="nav-bar-header-one">
                <div class="header-logo">
                    <a href="#">
                        <img src="img/logo.png" alt="logo">
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
                                    <li><a href="account.aspx"><i class="flaticon-gear-loading"></i>Account Settings</a></li>
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
                            <a href="admin_dashboard.aspx" class="nav-link"><i
                                    class="flaticon-dashboard"></i><span>Dashboard</span></a>
                        </li>
                        <li class="nav-item sidebar-nav-item">
                            <a href="#" class="nav-link"><i
                                    class="flaticon-multiple-users-silhouette"></i><span>Communication</span></a>
                            <ul class="nav sub-group-menu">
                                <li class="nav-item">
                                    <a href="all-messages.aspx" class="nav-link"><i class="fas fa-angle-right"></i>Messages</a>
                                </li>
                                <li class="nav-item">
                                    <a href="feedback.aspx" class="nav-link"><i
                                            class="fas fa-angle-right"></i>Feedback</a>
                                </li>

                            </ul>
                        </li>
                        <li class="nav-item sidebar-nav-item">
                            <a href="#" class="nav-link"><i class="flaticon-couple"></i><span>Finances</span></a>
                            <ul class="nav sub-group-menu">
                                <li class="nav-item">
                                    <a href="all-payments.aspx" class="nav-link"><i class="fas fa-angle-right"></i>My Payments</a>
                                </li>
                                <li class="nav-item">
                                    <a href="payments.aspx" class="nav-link"><i
                                            class="fas fa-angle-right"></i>Make Payments</a>
                                </li>
                            </ul>
                        </li>

                        <li class="nav-item">
                            <a href="account-settings.aspx" class="nav-link"><i
                                    class="flaticon-settings"></i><span>Account</span></a>
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
                <!-- Dashboard summery Start Here -->
                <div class="row">
                    <div class="col-3-xxxl col-sm-6 col-12">
                        <div class="dashboard-summery-one">
                            <div class="row">
                                <div class="col-6">
                                    <div class="item-icon bg-light-red">
                                        <i class="flaticon-money text-red"></i>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="item-content">
                                        <div class="item-title">Outstanding Fees</div>
                                        <div class="item-number"><span>₦</span><span class="counter" data-num="4503">4,503</span></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-3-xxxl col-sm-6 col-12">
                        <div class="dashboard-summery-one">
                            <div class="row">
                                <div class="col-6">
                                    <div class="item-icon bg-light-magenta">
                                        <i class="flaticon-shopping-list text-magenta"></i>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="item-content">
                                        <div class="item-title">Notifications</div>
                                        <div class="item-number"><span class="counter" data-num="12">12</span></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-3-xxxl col-sm-6 col-12">
                        <div class="dashboard-summery-one">
                            <div class="row">
                                <div class="col-6">
                                    <div class="item-icon bg-light-yellow">
                                        <i class="flaticon-mortarboard text-orange"></i>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="item-content">
                                        <div class="item-title">Results</div>
                                        <div class="item-number"><span class="counter" data-num="5">5</span></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-3-xxxl col-sm-6 col-12">
                        <div class="dashboard-summery-one">
                            <div class="row">
                                <div class="col-6">
                                    <div class="item-icon bg-light-blue">
                                        <i class="flaticon-head text-blue"></i>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="item-content">
                                        <div class="item-title">No of Students</div>
                                        <div class="item-number"><span></span><span class="counter" data-num="2">2</span></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Dashboard summery End Here -->
                <!-- Dashboard Content Start Here -->
                <div class="row">
                    <div class="col-5-xxxl col-12">
                        <div class="card dashboard-card-twelve">
                            <div class="card-body">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3>My Kids</h3>
                                    </div>
                                </div>
                                <div class="kids-details-wrap">
                                    <div class="row">
                                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <div class="col-12-xxxl col-xl-6 col-12">
                                            <div class="kids-details-box mb-5">
                                                <div class="item-img">
                                                 <asp:Image ID="Image1" runat="server" ImageUrl="~/Students/Olukemi_2504222046.jpeg"  Height="150" Width="150"/>
                                                </div>
                                                <div class="item-content table-responsive">
                                                    <table class="table text-nowrap">
                                                        <tbody>
                                                            <tr>
                                                                <td>Name:</td>
                                                                <td>Jessia Rose</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Gender:</td>
                                                                <td>Female</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Class:</td>
                                                                <td>2</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Roll:</td>
                                                                <td>#2225</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Section:</td>
                                                                <td>A</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Id:</td>
                                                                <td>#0021</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Date:</td>
                                                                <td>07.08.2017</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div></asp:Panel>
                                       <asp:Panel ID="Panel2" runat="server" Visible="false">
                                           <div class="col-12-xxxl col-xl-6 col-12">
                                            <div class="kids-details-box">
                                                <div class="item-img">
                                                    <asp:Image ID="Image2" runat="server" Width="150" Height="150" ImageUrl="~/Students/Jr Oladele_2404222100.png.png" /></div>
                                                <div class="item-content table-responsive">
                                                    <table class="table text-nowrap">
                                                        <tbody>
                                                            <tr>
                                                                <td>Name:</td>
                                                                <td>Jack Steve</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Gender:</td>
                                                                <td>Male</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Class:</td>
                                                                <td>3</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Roll:</td>
                                                                <td>#2205</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Section:</td>
                                                                <td>A</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Id:</td>
                                                                <td>#0045</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Date:</td>
                                                                <td>07.08.2017</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                           </asp:Panel>

                                        <asp:Panel ID="Panel3" runat="server" Visible="false">
                    <div class="col-12-xxxl col-xl-6 col-12">
                                            <div class="kids-details-box mb-5">
                                                <div class="item-img">
                                                    <img src="img/figure/student.png" alt="kids">
                                                </div>
                                                <div class="item-content table-responsive">
                                                    <table class="table text-nowrap">
                                                        <tbody>
                                                            <tr>
                                                                <td>Name:</td>
                                                                <td>Jessia Rose</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Gender:</td>
                                                                <td>Female</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Class:</td>
                                                                <td>2</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Roll:</td>
                                                                <td>#2225</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Section:</td>
                                                                <td>A</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Id:</td>
                                                                <td>#0021</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Date:</td>
                                                                <td>07.08.2017</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div></asp:Panel>
                                       <asp:Panel ID="Panel4" runat="server" Visible="true">
                                           <div class="col-12-xxxl col-xl-6 col-12">
                                            <div class="kids-details-box">
                                                <div class="item-img">
                                                    <img src="img/figure/student1.png" alt="kids">
                                                </div>
                                                <div class="item-content table-responsive">
                                                    <table class="table text-nowrap">
                                                        <tbody>
                                                            <tr>
                                                                <td>Name:</td>
                                                                <td>Jack Steve</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Gender:</td>
                                                                <td>Male</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Class:</td>
                                                                <td>3</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Roll:</td>
                                                                <td>#2205</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Section:</td>
                                                                <td>A</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Id:</td>
                                                                <td>#0045</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Date:</td>
                                                                <td>07.08.2017</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                           </asp:Panel>
                                        <asp:Panel ID="Panel5" runat="server" Visible="true">
                    <div class="col-12-xxxl col-xl-6 col-12">
                                            <div class="kids-details-box mb-5">
                                                <div class="item-img">
                                                    <img src="img/figure/student.png" alt="kids">
                                                </div>
                                                <div class="item-content table-responsive">
                                                    <table class="table text-nowrap">
                                                        <tbody>
                                                            <tr>
                                                                <td>Name:</td>
                                                                <td>Jessia Rose</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Gender:</td>
                                                                <td>Female</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Class:</td>
                                                                <td>2</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Roll:</td>
                                                                <td>#2225</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Section:</td>
                                                                <td>A</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Id:</td>
                                                                <td>#0021</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Date:</td>
                                                                <td>07.08.2017</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div></asp:Panel>
                                       <asp:Panel ID="Panel6" runat="server" Visible="false">
                                           <div class="col-12-xxxl col-xl-6 col-12">
                                            <div class="kids-details-box">
                                                <div class="item-img">
                                                    <img src="img/figure/student1.png" alt="kids">
                                                </div>
                                                <div class="item-content table-responsive">
                                                    <table class="table text-nowrap">
                                                        <tbody>
                                                            <tr>
                                                                <td>Name:</td>
                                                                <td>Jack Steve</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Gender:</td>
                                                                <td>Male</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Class:</td>
                                                                <td>3</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Roll:</td>
                                                                <td>#2205</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Section:</td>
                                                                <td>A</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Id:</td>
                                                                <td>#0045</td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Date:</td>
                                                                <td>07.08.2017</td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                           </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-7-xxxl col-12">
                        <div class="card dashboard-card-eleven">
                            <div class="card-body">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3>All Expenses</h3>
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
                                <div class="table-box-wrap">
                                    <form class="search-form-box">
                                        <div class="row gutters-8">
                                            <div class="col-lg-4 col-md-3 form-group">
                                                <input type="text" placeholder="Search by Exam ..."
                                                    class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-3 form-group">
                                                <input type="text" placeholder="Search by Subject ..."
                                                    class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-3 form-group">
                                                <input type="text" placeholder="dd/mm/yyyy" class="form-control">
                                            </div>
                                            <div class="col-lg-2 col-md-3 form-group">
                                                <button type="submit"
                                                    class="fw-btn-fill btn-gradient-yellow">SEARCH</button>
                                            </div>
                                        </div>
                                    </form>
                                    <div class="table-responsive expenses-table-box">
                                        <table class="table data-table text-nowrap">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input checkAll">
                                                            <label class="form-check-label">ID</label>
                                                        </div>
                                                    </th>
                                                    <th>Expanse</th>
                                                    <th>Amount</th>
                                                    <th>Status</th>
                                                    <th>E-Mail</th>
                                                    <th>Date</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0021</label>
                                                        </div>
                                                    </td>
                                                    <td>Exam Fees</td>
                                                    <td>₦150.00</td>
                                                    <td class="badge badge-pill badge-success d-block mg-t-8">Paid</td>
                                                    <td>akkhorschool@gmail.com</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0022</label>
                                                        </div>
                                                    </td>
                                                    <td>Semister Fees</td>
                                                    <td>₦350.00</td>
                                                    <td class="badge badge-pill badge-danger d-block mg-t-8">Due</td>
                                                    <td>akkhorschool@gmail.com</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0023</label>
                                                        </div>
                                                    </td>
                                                    <td>Exam Fees</td>
                                                    <td>₦150.00</td>
                                                    <td class="badge badge-pill badge-success d-block mg-t-8">Paid</td>
                                                    <td>akkhorschool@gmail.com</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0024</label>
                                                        </div>
                                                    </td>
                                                    <td>Exam Fees</td>
                                                    <td>₦150.00</td>
                                                    <td class="badge badge-pill badge-danger d-block mg-t-8">Due </td>
                                                    <td>akkhorschool@gmail.com</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0025</label>
                                                        </div>
                                                    </td>
                                                    <td>Exam Fees</td>
                                                    <td>₦150.00</td>
                                                    <td class="badge badge-pill badge-success d-block mg-t-8">Paid</td>
                                                    <td>akkhorschool@gmail.com</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0026</label>
                                                        </div>
                                                    </td>
                                                    <td>Semister Fees</td>
                                                    <td>₦350.00</td>
                                                    <td class="badge badge-pill badge-danger d-block mg-t-8">Due</td>
                                                    <td>akkhorschool@gmail.com</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0027</label>
                                                        </div>
                                                    </td>
                                                    <td>Exam Fees</td>
                                                    <td>₦150.00</td>
                                                    <td class="badge badge-pill badge-success d-block mg-t-8">Paid</td>
                                                    <td>akkhorschool@gmail.com</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xl-4 col-12">
                        <div class="card dashboard-card-six">
                            <div class="card-body">
                                <div class="heading-layout1 mg-b-17">
                                    <div class="item-title">
                                        <h3>Notifications</h3>
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
                                <div class="notice-box-wrap m-height-660">
                                    <div class="notice-list">
                                        <div class="post-date bg-skyblue">16 June, 2019</div>
                                        <h6 class="notice-title"><a href="#">Great School manag mene esom tus eleifend
                                                lectus
                                                sed maximus mi faucibusnting.</a></h6>
                                        <div class="entry-meta"> Jennyfar Lopez / <span>5 min ago</span></div>
                                    </div>
                                    <div class="notice-list">
                                        <div class="post-date bg-yellow">16 June, 2019</div>
                                        <h6 class="notice-title"><a href="#">Great School manag printing.</a></h6>
                                        <div class="entry-meta"> Jennyfar Lopez / <span>5 min ago</span></div>
                                    </div>
                                    <div class="notice-list">
                                        <div class="post-date bg-pink">16 June, 2019</div>
                                        <h6 class="notice-title"><a href="#">Great School manag Nulla rhoncus eleifensed
                                                mim
                                                us mi faucibus id. Mauris vestibulum non purus lobortismenearea</a></h6>
                                        <div class="entry-meta"> Jennyfar Lopez / <span>5 min ago</span></div>
                                    </div>
                                    <div class="notice-list">
                                        <div class="post-date bg-blue">16 June, 2019</div>
                                        <h6 class="notice-title"><a href="#">Great School manag mene esom text of the
                                                printing.</a></h6>
                                        <div class="entry-meta"> Jennyfar Lopez / <span>5 min ago</span></div>
                                    </div>
                                    <div class="notice-list">
                                        <div class="post-date bg-yellow">16 June, 2019</div>
                                        <h6 class="notice-title"><a href="#">Great School manag printing.</a></h6>
                                        <div class="entry-meta"> Jennyfar Lopez / <span>5 min ago</span></div>
                                    </div>
                                    <div class="notice-list">
                                        <div class="post-date bg-blue">16 June, 2019</div>
                                        <h6 class="notice-title"><a href="#">Great School manag meneesom.</a></h6>
                                        <div class="entry-meta"> Jennyfar Lopez / <span>5 min ago</span></div>
                                    </div>
                                    <div class="notice-list">
                                        <div class="post-date bg-pink">16 June, 2019</div>
                                        <h6 class="notice-title"><a href="#">Great School manag meneesom.</a></h6>
                                        <div class="entry-meta"> Jennyfar Lopez / <span>5 min ago</span></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-8 col-12">
                        <div class="card dashboard-card-eleven">
                            <div class="card-body">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3>All Exam Results</h3>
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
                                <div class="table-box-wrap">
                                    <form class="search-form-box">
                                        <div class="row gutters-8">
                                            <div class="col-lg-4 col-md-3 form-group">
                                                <input type="text" placeholder="Search by Exam ..."
                                                    class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-3 form-group">
                                                <input type="text" placeholder="Search by Subject ..."
                                                    class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-3 form-group">
                                                <input type="text" placeholder="dd/mm/yyyy" class="form-control">
                                            </div>
                                            <div class="col-lg-2 col-md-3 form-group">
                                                <button type="submit"
                                                    class="fw-btn-fill btn-gradient-yellow">SEARCH</button>
                                            </div>
                                        </div>
                                    </form>
                                    <div class="table-responsive result-table-box">
                                        <table class="table display data-table text-nowrap">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input checkAll">
                                                            <label class="form-check-label">ID</label>
                                                        </div>
                                                    </th>
                                                    <th>Exam Name</th>
                                                    <th>Subject</th>
                                                    <th>Class</th>
                                                    <th>Roll</th>
                                                    <th>Grade</th>
                                                    <th>Percent</th>
                                                    <th>Date</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0021</label>
                                                        </div>
                                                    </td>
                                                    <td>Class Test</td>
                                                    <td>English</td>
                                                    <td>2</td>
                                                    <td>#0045</td>
                                                    <td>A</td>
                                                    <td>99.00 > 100</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0022</label>
                                                        </div>
                                                    </td>
                                                    <td>Class Test</td>
                                                    <td>English</td>
                                                    <td>1</td>
                                                    <td>#0025</td>
                                                    <td>A</td>
                                                    <td>99.00 > 100</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0023</label>
                                                        </div>
                                                    </td>
                                                    <td>Class Test</td>
                                                    <td>Drawing</td>
                                                    <td>2</td>
                                                    <td>#0045</td>
                                                    <td>A</td>
                                                    <td>99.00 > 100</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0024</label>
                                                        </div>
                                                    </td>
                                                    <td>Class Test</td>
                                                    <td>English</td>
                                                    <td>1</td>
                                                    <td>#0048</td>
                                                    <td>A</td>
                                                    <td>99.00 > 100</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0025</label>
                                                        </div>
                                                    </td>
                                                    <td>Class Test</td>
                                                    <td>Chemistry</td>
                                                    <td>8</td>
                                                    <td>#0050</td>
                                                    <td>A</td>
                                                    <td>99.00 > 100</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0025</label>
                                                        </div>
                                                    </td>
                                                    <td>Class Test</td>
                                                    <td>Bangla</td>
                                                    <td>4</td>
                                                    <td>#0035</td>
                                                    <td>D</td>
                                                    <td>70.00 > 100</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0025</label>
                                                        </div>
                                                    </td>
                                                    <td>Class Test</td>
                                                    <td>Drawing</td>
                                                    <td>2</td>
                                                    <td>#0045</td>
                                                    <td>C</td>
                                                    <td>80.00 > 100</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0025</label>
                                                        </div>
                                                    </td>
                                                    <td>Class Test</td>
                                                    <td>English</td>
                                                    <td>4</td>
                                                    <td>#0048</td>
                                                    <td>B</td>
                                                    <td>99.00 > 100</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="form-check">
                                                            <input type="checkbox" class="form-check-input">
                                                            <label class="form-check-label">#0025</label>
                                                        </div>
                                                    </td>
                                                    <td>First Semister</td>
                                                    <td>English</td>
                                                    <td>2</td>
                                                    <td>#0045</td>
                                                    <td>A</td>
                                                    <td>99.00 > 100</td>
                                                    <td>22/02/2019</td>
                                                    <td>
                                                        <div class="dropdown">
                                                            <a href="#" class="dropdown-toggle" data-toggle="dropdown"
                                                                aria-expanded="false">
                                                                <span class="flaticon-more-button-of-three-dots"></span>
                                                            </a>
                                                            <div class="dropdown-menu dropdown-menu-right">
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-times text-orange-red"></i>Close</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                                                <a class="dropdown-item" href="#"><i
                                                                        class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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
