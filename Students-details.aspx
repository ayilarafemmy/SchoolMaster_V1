<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Students-details.aspx.cs" Inherits="parents_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            display: block;
            font-size: large;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            border: 1px solid #ced4da;
            background-color: #fff;
        }
        .auto-style3 {
            display: block;
            width: 100%;
            height: calc(2.25rem + 2px);
            font-size: large;
            line-height: 1.5;
            color: #495057;
            background-clip: padding-box;
            border-radius: .25rem;
            transition: none;
            border: 1px solid #ced4da;
            background-color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="breadcrumbs-area">
                    <h3>Students</h3>
                    <ul>
                        <li>
                            <a href="dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Students Details</li>
                    </ul>
                </div>
                <!-- Breadcubs Area End Here -->
                <!-- Student Details Area Start Here -->
                <div class="card height-auto">
                    <div class="card-body">
                        <div class="heading-layout1">
                            <div class="item-title">
                                <h3>Student Details</h3>
                            </div>
                        </div>
                        <div class="single-info-details">
                            <div class="item-img">
           <asp:Image ID="Image1" runat="server"  Width="200" Height="250"/>
                            </div>
                            <div class="item-content">
                                <div class="header-inline item-header">
                                    <h3 class="text-dark-medium font-medium">
           <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h3>
                                    <div class="header-elements">
                                        <ul>
                                            <li><a href="#"><i class="far fa-edit"></i></a></li>
                                            <li><a href="#"><i class="fas fa-print"></i></a></li>
                                            <li><a href="#"><i class="fas fa-download"></i></a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="info-table table-responsive">
                                    <table class="table text-nowrap">
                                        <tbody>
                                            <tr>
                                                <td>Name:</td>
                                                <td class="font-medium text-dark-medium">
                                                    <table class="w-100">
                                                        <tr>
                                                            <td>
                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style2" Width="173px"></asp:TextBox> </td>
                                                            <td> <asp:TextBox ID="TextBox4" runat="server" CssClass="auto-style2" Width="248px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Gender:</td>
                                                <td class="font-medium text-dark-medium">
                                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style3">
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                    </asp:DropDownList></td>

                                            </tr>
                                            <tr>
                                                <td>Roll No:</td>
                                                <td class="font-medium text-dark-medium">
                       <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Email:</td>
                                                <td class="font-medium text-dark-medium">
                                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style3"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Date of Birth:</td>
                                                <td class="font-medium text-dark-medium">
                               <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Religion:</td>
                                                <td class="font-medium text-dark-medium">
                                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="auto-style3">
                                                        <asp:ListItem>Islam</asp:ListItem>
                                                        <asp:ListItem>Christianity</asp:ListItem>
                                                        <asp:ListItem>Hindu</asp:ListItem>
                                                        <asp:ListItem>Others</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td>Class:</td>
                                                <td class="font-medium text-dark-medium">
                                      <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton><asp:Label ID="Label10" runat="server" Text="*" Visible="true">
                                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control"></asp:DropDownList></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Section:</td>
                                                <td class="font-medium text-dark-medium">
                                           <asp:LinkButton ID="LinkButton2" runat="server">LinkButton</asp:LinkButton> <asp:Label ID="Label11" runat="server" Text="*"></asp:Label> </td>
                                            </tr>

                                            <tr>
                                                <td>Registration Date:</td>
                                                <td class="font-medium text-dark-medium">
                                           <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></td>
                                            </tr>

                                            <tr>
                                                <td>Short Bio:</td>
                                                <td class="font-medium text-dark-medium">
                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style3" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="2">
                                                    <asp:Button ID="Button1" runat="server" Text="Delete" CssClass="btn-fill-md radius-4 text-light bg-orange-red" />
                                                    <asp:Button ID="Button2" runat="server" Text="Modify"  CssClass="btn-fill-md radius-4 text-light bg-light-sea-green" OnClick="Button2_Click"/>
                                                    <asp:Button ID="Button3" runat="server" Text="Submit" Visible="False" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>

