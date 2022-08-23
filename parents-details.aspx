<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="parents-details.aspx.cs" Inherits="parents_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="breadcrumbs-area">
                    <h3>Parents</h3>
                    <ul>
                        <li>
                            <a href="dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Parents Details</li>
                    </ul>
                </div>
                <!-- Breadcubs Area End Here -->
                <!-- Student Details Area Start Here -->
                <div class="card height-auto">
                    <div class="card-body">
                        <div class="heading-layout1">
                            <div class="item-title">
                                <h3>Parent Details</h3>
                            </div>
                        </div>
                        <div class="single-info-details">
                            <div class="item-img">
           <asp:Image ID="Image1" runat="server"  Width="350" Height="450"/>
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
               <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label> <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Gender:</td>
                                                <td class="font-medium text-dark-medium">
                   <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Relationship:</td>
                                                <td class="font-medium text-dark-medium">
                       <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Email:</td>
                                                <td class="font-medium text-dark-medium">
                           <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Address:</td>
                                                <td class="font-medium text-dark-medium">
                               <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Religion:</td>
                                                <td class="font-medium text-dark-medium">
                                   <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Phone:</td>
                                                <td class="font-medium text-dark-medium">
                                       <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Alternate Number:</td>
                                                <td class="font-medium text-dark-medium">
                                           <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></td>
                                            </tr>

                                            <tr>
                                                <td>Email:</td>
                                                <td class="font-medium text-dark-medium">
                                           <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></td>
                                            </tr>

                                            <tr>
                                                <td>Registration Date:</td>
                                                <td class="font-medium text-dark-medium">
                                           <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></td>
                                            </tr>

                                            <tr>
                                                <td>First Login:</td>
                                                <td class="font-medium text-dark-medium">
                                           <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label></td>
                                            </tr>

                                            <tr>
                                                <td colspan="2">
                                                    <asp:Button ID="Button1" runat="server" Text="Delete" CssClass="btn-fill-md radius-4 text-light bg-orange-red" />
                                                    <asp:Button ID="Button2" runat="server" Text="Modify"  CssClass="btn-fill-md radius-4 text-light bg-light-sea-green"/>
                                                    <asp:Button ID="Button3" runat="server" Text="Submit" Visible="False" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="2">
                                                    &nbsp;</td>
                                            </tr>

                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="GridView2" runat="server">
                                                    </asp:GridView>
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

