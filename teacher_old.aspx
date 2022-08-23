<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teacher_old.aspx.cs" Inherits="parent_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js" lang="">
<head runat="server">
  <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>School Master | Teachers Login</title>
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
    <!-- Select 2 CSS -->
    <link rel="stylesheet" href="css/select2.min.css">
    <!-- Date Picker CSS -->
    <link rel="stylesheet" href="css/datepicker.min.css">
    <!-- Custom CSS -->
    <link rel="stylesheet" href="style.css">
    <!-- Modernize js -->
    <script src="js/modernizr-3.6.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div id="wrapper" class="wrapper bg-ash">
         <!-- Header Menu Area Start Here -->
        <div class="navbar navbar-expand-md header-menu-one bg-light">
            <div class="d-md-none mobile-nav-bar">
               <button class="navbar-toggler pulse-animation" type="button" data-toggle="collapse" data-target="#mobile-navbar" aria-expanded="false">
                    <i class="far fa-arrow-alt-circle-down"></i>
                </button>
                <button type="button" class="navbar-toggler sidebar-toggle-mobile">
                    <i class="fas fa-bars"></i>
                </button>
            </div>
        </div>
        <!-- Header Menu Area End Here -->
        <!-- Page Area Start Here -->
        <div class="dashboard-page-one">
            <!-- Sidebar Area Start Here -->
           <div class="sidebar-main sidebar-menu-one sidebar-expand-md sidebar-color">

            </div>
            <!-- Sidebar Area End Here -->
            <div class="dashboard-content-one">
                <!-- Breadcubs Area Start Here -->
                <div class="breadcrumbs-area">

                    <ul>

                    </ul>
                    <br /><br />
                </div>
                <!-- Breadcubs Area End Here -->
                <!-- Add New Teacher Area Start Here -->
                <div class="card height-auto">
                    <div class="card-body">
                        <div class="heading-layout1">
                            <div class="item-title">
                                <h3>Teacher's Login </h3>
                                <p>
                                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                                </p>
                            </div>
                           <div class="dropdown">
                                <a class="dropdown-toggle" href="#" role="button"
                                data-toggle="dropdown" aria-expanded="false">...</a>

                                <div class="dropdown-menu dropdown-menu-right">
                                    <a class="dropdown-item" href="#"><i class="fas fa-times text-orange-red"></i>Close</a>
                                    <a class="dropdown-item" href="#"><i class="fas fa-cogs text-dark-pastel-green"></i>Edit</a>
                                    <a class="dropdown-item" href="#"><i class="fas fa-redo-alt text-orange-peel"></i>Refresh</a>
                                </div>
                            </div>
                        </div>
                        <form class="new-added-form">
                            <div class="row">
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Email Address *</label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">

                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">

                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">

                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Password *</label>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">

                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">

                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">

                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">

                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">

                                </div>

                                <div class="col-12 form-group mg-t-8">
                 <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click" />
                 <asp:Button ID="Button2" runat="server" Text="Reset"  CssClass="btn-fill-lg bg-blue-dark btn-hover-yellow"/>
                                </div>
                            </div>
                        </form>
                    </div>
                    <br /><br />
                </div>
                <!-- Add New Teacher Area End Here -->
                <footer class="footer-wrap-layout1">
                    <div class="copyright">© Copyrights <a href="#">DataPlus</a> 2022. All rights reserved. </div>
                </footer>
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
    <!-- Select 2 Js -->
    <script src="js/select2.min.js"></script>
    <!-- Date Picker Js -->
    <script src="js/datepicker.min.js"></script>
    <!-- Smoothscroll Js -->
    <script src="js/jquery.smoothscroll.min.html"></script>
    <!-- Scroll Up Js -->
    <script src="js/jquery.scrollUp.min.js"></script>
    <!-- Custom Js -->
    <script src="js/main.js"></script>
        </div>
    </form>
</body>
</html>
