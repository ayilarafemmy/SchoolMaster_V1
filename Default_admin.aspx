<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_admin.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="no-js" lang="">
<head runat="server">
     <meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <title>School Master | Admin Login</title>
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
              <!-- Preloader Start Here -->
  <%--  <div id="preloader">--%>
        <br />
              </div>
    <!-- Preloader End Here -->
    <div id="wrapper" class="wrapper bg-ash">

        <!-- Page Area Start Here -->
        <div class="dashboard-page-one">

            <div class="dashboard-content-one">

                <!-- All Subjects Area Start Here -->
                <div class="row">
                    <div class="col-4-xxxl col-12">
                        <div class="card height-auto">
                            <div class="card-body">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3 class="text-center">Admin Login</h3>
                                        <br />
                                         <asp:Label ID="Label1" runat="server" Text="*" Visible="false"></asp:Label>
                                    </div>

                                </div>
                                <form class="new-added-form">
                                    <div class="row">
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Email / StaffID *</label>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Password *</label>
                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <div class="col-12 form-group mg-t-8">
                                           <asp:Button ID="Button1" runat="server" Text="Sign In" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click" />
                                        </div>

                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>

                </div>

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
