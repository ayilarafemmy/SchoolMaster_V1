<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js" lang="">
<head runat="server">
   <head>
    <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>School Master | Admin</title>
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
    <!-- Full Calender CSS -->
    <link rel="stylesheet" href="css/fullcalendar.min.css">
    <!-- Animate CSS -->
    <link rel="stylesheet" href="css/animate.min.css">
    <!-- Custom CSS -->
    <link rel="stylesheet" href="style.css">
    <!-- Modernize js -->
    <script src="js/modernizr-3.6.0.min.js"></script>
</head>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Preloader Start Here -->
   <%-- --%>
    <!-- Preloader End Here -->
    <div id="wrapper" class="wrapper bg-ash">
       <!-- Header Menu Area Start Here -->
        <div class="navbar navbar-expand-md header-menu-one bg-light">
            <div class="nav-bar-header-one">
                <div class="header-logo">
                    <a href="#">
                        <asp:Image ID="Image3" runat="server" Width="150px" Height="80px" />
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
                    <h3 class="text-dark-high"><strong>Demo International School, Lagos</strong></h3>
                </ul>
                <ul class="navbar-nav">
                    <li class="navbar-item dropdown header-admin">
                        <a class="navbar-nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown"
                            aria-expanded="false">
                            <div class="admin-title">
                                <h5 class="item-title">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h5>
                                <span>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></span>
                            </div>
                            <div class="admin-img">
                        <asp:Image ID="Image1" runat="server" />
                            </div>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right">
                            <div class="item-header">
                                <h6 class="item-title">
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></h6>
                            </div>
                            <div class="item-content">
                                <ul class="settings-list">
                                    <li><a href="profile.aspx"><i class="flaticon-user"></i>My Profile</a></li>
                                    <li><a href="Messages.aspx"><i class="flaticon-chat-comment-oval-speech-bubble-with-text-lines"></i>Message</a></li>
                                    <li><a href="acct_settings.aspx"><i class="flaticon-gear-loading"></i>Account Settings</a></li>
                                    <li><a href="logout.aspx"><i class="flaticon-turn-off"></i>Log Out</a></li>
                                </ul>
                            </div>
                        </div>
                    </li>
                    <li class="navbar-item dropdown header-message">
                        <a class="navbar-nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown"
                            aria-expanded="false">
                            <i class="far fa-envelope"></i>
                            <div class="item-title d-md-none text-16 mg-l-10">Message</div>
                            <span></span>
                        </a>

                        <div class="dropdown-menu dropdown-menu-right">
                            <div class="item-header">
                                <h6 class="item-title">
                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></h6>
                            </div>
                            <div class="item-content">
                               <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </li>

                     <li class="navbar-item dropdown header-language">
                        <a class="navbar-nav-link dropdown-toggle" href="#" role="button"
                        data-toggle="dropdown" aria-expanded="false"><i class="fas fa-globe-americas"></i>EN</a>
                        <div class="dropdown-menu dropdown-menu-right">
                            <a class="dropdown-item" href="#">English</a>
                            <a class="dropdown-item" href="#">Spanish</a>
                            <a class="dropdown-item" href="#">Franchis</a>
                            <a class="dropdown-item" href="#">Chiness</a>
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
                        <%--<a href="#"><img src="img/logo1.png" alt="logo"></a>--%>
                        <asp:Image ID="Image2" runat="server" Width="80px" Height="120px" />
                    </div>
               </div>
                <div class="sidebar-menu-content">
                    <ul class="nav nav-sidebar-menu sidebar-toggle-view">
                         <li class="nav-item">
                            <a href="Dashboard.aspx" class="nav-link"><i
                                    class="flaticon-dashboard"></i><span>Dashboard</span></a>
                        </li>
                           <li class="nav-item">
                            <a href="Admin_Students.aspx" class="nav-link"><i
                                    class="flaticon-classmates"></i><span>Students</span></a>
                        </li>
                           <li class="nav-item">
                            <a href="Admin_Staff.aspx" class="nav-link"><i
                                    class="flaticon-multiple-users-silhouette"></i><span>Staff</span></a>
                        </li>
                        <li class="nav-item">
                            <a href="Admin_Parents.aspx" class="nav-link"><i
                                    class="flaticon-couple"></i><span>Parents</span></a>
                        </li>
                     <li class="nav-item">
                            <a href="Admin_LMS.aspx" class="nav-link"><i
                                    class="flaticon-books"></i><span>LMS</span></a>
                        </li>
                          <li class="nav-item">
                            <a href="Admin_AccountsIN.aspx" class="nav-link"><i
                                    class="flaticon-technological"></i><span>Accounts</span></a>
                        </li>
                       <li class="nav-item">
                            <a href="Admin_Classes.aspx" class="nav-link"><i
                                    class="flaticon-maths-class-materials-cross-of-a-pencil-and-a-ruler"></i><span>Classes</span></a>
                        </li>
                        <li class="nav-item">
                            <a href="all-subject.aspx" class="nav-link"><i
                                    class="flaticon-open-book"></i><span>Subjects</span></a>
                        </li>
                        <li class="nav-item">
                            <a href="class-routine.aspx" class="nav-link"><i class="flaticon-calendar"></i><span>Class
                                    Routine</span></a>
                        </li>
                        <li class="nav-item">
                            <a href="student-attendence.aspx" class="nav-link"><i
                                    class="flaticon-checklist"></i><span>Attendence</span></a>
                        </li>
                       <li class="nav-item">
                            <a href="exams.aspx" class="nav-link"><i
                                    class="flaticon-shopping-list"></i><span>Examinations</span></a>
                        </li>
                          <li class="nav-item">
                            <a href="Academics.aspx" class="nav-link"><i
                                    class="flaticon-shopping-list"></i><span>Academic reports</span></a>
                        </li>
                        <li class="nav-item">
                            <a href="transport.aspx" class="nav-link"><i
                                    class="flaticon-bus-side-view"></i><span>Transport</span></a>
                        </li>
                         <li class="nav-item">
                            <a href="invoicing.aspx" class="nav-link"><i class="flaticon-bed"></i><span>Invoices</span></a>
                        </li>
                        <li class="nav-item">
                            <a href="servicemgt.aspx" class="nav-link"><i class="flaticon-shopping-list"></i><span>Service Management</span></a>
                        </li>

                        <li class="nav-item">
                            <a href="notice-board.aspx" class="nav-link"><i
                                    class="flaticon-script"></i><span>Notice</span></a>
                        </li>
                        <li class="nav-item">
                            <a href="account-settings.aspx" class="nav-link"><i
                                    class="flaticon-settings"></i><span>Configuration</span></a>
                        </li>
                        <li class="nav-item">
                            <a href="adminsignout.aspx" class="nav-link"><i
                                    class="flaticon-bus-side-view"></i><span>Sign Out</span></a>
                        </li>
                    </ul>
                </div>
            </div>
            <!-- Sidebar Area End Here -->
            <div class="dashboard-content-one">
                <!-- Breadcubs Area Start Here -->
                <div class="breadcrumbs-area">
                    <h3>Admin Dashboard</h3>
                </div>
                <!-- Breadcubs Area End Here -->
                <!-- Dashboard summery Start Here -->
                <div class="row gutters-20">
                    <div class="col-xl-3 col-sm-6 col-12">
                        <div class="dashboard-summery-one mg-b-20">
                            <div class="row align-items-center">
                                <div class="col-6">
                                    <div class="item-icon bg-light-green ">
                                        <i class="flaticon-classmates text-green"></i>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="item-content">
                                        <div class="item-title">Students</div>

                                        <div class="item-number"><span class="counter" data-num="15000">
                                            <asp:Label ID="LabelD1" runat="server" Text="*"></asp:Label></span></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6 col-12">
                        <div class="dashboard-summery-one mg-b-20">
                            <div class="row align-items-center">
                                <div class="col-6">
                                    <div class="item-icon bg-light-blue">
                                        <i class="flaticon-multiple-users-silhouette text-blue"></i>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="item-content">
                                        <div class="item-title">Staff</div>
                                        <div class="item-number"><span class="counter" data-num="2250">
                                            <asp:Label ID="LabelD2" runat="server" Text="Label"></asp:Label></span></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6 col-12">
                        <div class="dashboard-summery-one mg-b-20">
                            <div class="row align-items-center">
                                <div class="col-6">
                                    <div class="item-icon bg-light-yellow">
                                        <i class="flaticon-couple text-orange"></i>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="item-content">
                                        <div class="item-title">Parents</div>
                                        <div class="item-number"><span class="counter" data-num="5690">
                                            <asp:Label ID="LabelD3" runat="server" Text="Label"></asp:Label></span></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6 col-12">
                        <div class="dashboard-summery-one mg-b-20">
                            <div class="row align-items-center">
                                <div class="col-6">
                                    <div class="item-icon bg-light-red">
                                        <i class="flaticon-money text-red"></i>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="item-content">
                                        <div class="item-title">Income</div>
                                        <div class="item-number"><span>
                                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></span><span class="counter" data-num="193000"><asp:Label ID="LabelD4" runat="server" Text="Label"></asp:Label></span></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Dashboard summery End Here -->
                <!-- Dashboard Content Start Here -->
                <div class="row gutters-20">
                    <div class="col-12 col-xl-8 col-6-xxxl">
                        <div class="card dashboard-card-one pd-b-20">
                            <div class="card-body">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3>Earnings</h3>
                                    </div>
                                </div>
                                <div class="earning-report">
                                    <div class="item-content">
                                        <div class="single-item pseudo-bg-blue">
                                            <h4>Total Collections</h4>
                                        </div>
                                        <div class="single-item pseudo-bg-red">
                                            <h4>Fees Collection</h4>
                                        </div>
                                    </div>
                                    <div class="dropdown">
                                        <a class="date-dropdown-toggle" href="#" role="button" data-toggle="dropdown"
                                            aria-expanded="false">
                                                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></a><br />
                                        <div>

                                               </div>
                                    </div>
                                </div>
                                <div class="earning-chart-wrap">
                                    <asp:GridView ID="GridView3" runat="server" CssClass="table table-striped table-bordered table-hover"></asp:GridView>

                                    <canvas id="earning-line-chart" width="660" height="320"></canvas>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-xl-4 col-3-xxxl">
                        <div class="card dashboard-card-two pd-b-20">
                            <div class="card-body">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3>Expenses</h3>
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
                                <div class="expense-report">
                                    <div class="monthly-expense pseudo-bg-Aquamarine">
                                        <div class="expense-date">
                                                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></div>
                                        <div class="expense-amount"><span>₦</span> <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></div>
                                    </div>
                                    <div class="monthly-expense pseudo-bg-blue">
                                        <div class="expense-date">
                                                        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></div>
                                        <div class="expense-amount"><span>₦</span> <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></div>
                                    </div>
                                    <div class="monthly-expense pseudo-bg-yellow">
                                        <div class="expense-date">
                                                            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></div>
                                        <div class="expense-amount"><span>₦</span> <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></div>
                                    </div>
                                </div>
                                <div class="expense-chart-wrap">
                                    <canvas id="expense-bar-chart" width="100" height="300"></canvas>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-xl-6 col-3-xxxl">
                        <div class="card dashboard-card-three pd-b-20">
                            <div class="card-body">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3>Students</h3>
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
                                <div class="doughnut-chart-wrap">
                                    <canvas id="student-doughnut-chart" width="100" height="300"></canvas>
                                </div>
                                <div class="student-report">
                                    <div class="student-count pseudo-bg-blue">
                                        <h4 class="item-title">Female Students</h4>
                                        <div class="item-number">
                                                                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></div>
                                    </div>
                                    <div class="student-count pseudo-bg-yellow">
                                        <h4 class="item-title">Male Students</h4>
                                        <div class="item-number">
                                                                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-xl-6 col-4-xxxl">
                        <div class="card dashboard-card-four pd-b-20">
                            <div class="card-body">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3>Event Calender</h3>
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
                                <div class="calender-wrap">
                                    <div id="fc-calender" class="fc-calender"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-xl-6 col-4-xxxl">
                        <div class="card dashboard-card-five pd-b-20">
                            <div class="card-body pd-b-14">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3>Traffic Data</h3>
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
                                <h6 class="traffic-title">Parents Access</h6>
                                <div class="traffic-number">
                                                                        <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                                </div>
                                 <h6 class="traffic-title">Students Access</h6>
                                <div class="traffic-number">
                                                                        <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                                </div>
                                  <h6 class="traffic-title">Teachers Access</h6>
                                <div class="traffic-number">
                                                                        <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-xl-6 col-4-xxxl">
                        <div class="card dashboard-card-six pd-b-20">
                            <div class="card-body">
                                <div class="heading-layout1 mg-b-17">
                                    <div class="item-title">
                                        <h3>Notice Board</h3>
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
                                <div class="notice-box-wrap">
                                    <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                                    <asp:Label ID="Label18" runat="server" Text="Label" Visible="False"></asp:Label>
                                    <asp:Label ID="Label19" runat="server" Text="Label" Visible="False"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Dashboard Content End Here -->
                <!-- Footer Area Start Here -->
                <footer class="footer-wrap-layout1">
                    <div class="copyright">© Copyrights <a href="#">DataPlus </a> 2023. All rights reserved</div>
                </footer>
                <!-- Footer Area End Here -->
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
    <!-- Moment Js -->
    <script src="js/moment.min.js"></script>
    <!-- Waypoints Js -->
    <script src="js/jquery.waypoints.min.js"></script>
    <!-- Scroll Up Js -->
    <script src="js/jquery.scrollUp.min.js"></script>
    <!-- Full Calender Js -->
    <script src="js/fullcalendar.min.js"></script>
    <!-- Chart Js -->
    <script src="js/Chart.min.js"></script>
    <!-- Custom Js -->
    <script src="js/main.js"></script>
        </div>
    </form>
</body>
</html>
