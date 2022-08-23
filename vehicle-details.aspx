<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="vehicle-details.aspx.cs" Inherits="parents_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="breadcrumbs-area">
                    <h3>Vehicles</h3>
                    <ul>
                        <li>
                            <a href="dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Vehicle Details</li>
                    </ul>
                </div>
                <!-- Breadcubs Area End Here -->
                <!-- Student Details Area Start Here -->
                <div class="card height-auto">
                    <div class="card-body">
                        <div class="heading-layout1">
                            <div class="item-title">
                                <h3>Vehicle Details</h3>
                            </div>
                        </div>
                        <div class="single-info-details">
                            <div class="item-img">
           <asp:Image ID="Image1" runat="server"  Width="350" Height="450" Visible="false"/>
                            </div>
                            <div class="item-content">
                                <div class="header-inline item-header">
                                    <h3 class="text-dark-medium font-medium">
           <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label> <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label></h3>
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
                                                <td>Plate Number:</td>
                                                <td class="font-medium text-dark-medium">
                                                    <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton><asp:TextBox ID="TextBox1" runat="server" Visible="false" CssClass="form-control"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>Vehicle Purpose:</td>
                                                <td class="font-medium text-dark-medium">
                                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                         <asp:ListItem Value="0">Select Purpose</asp:ListItem>
                                         <asp:ListItem Value="1">School Bus</asp:ListItem>
                                         <asp:ListItem Value="2">Official Vehicle</asp:ListItem></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td>RouteID:</td>
                                                <td class="font-medium text-dark-medium">
                                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control"></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td>Driver:</td>
                                                <td class="font-medium text-dark-medium">
                           <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control"></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td>Support Staff:</td>
                                                <td class="font-medium text-dark-medium">
                               <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control"></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td>Status:</td>
                                                <td class="font-medium text-dark-medium">
                                    <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control">
                                         <asp:ListItem Value="0">Select Status</asp:ListItem>
                                         <asp:ListItem Value="1">Active</asp:ListItem>
                                         <asp:ListItem Value="2">Deactivated</asp:ListItem></asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td>Phone:</td>
                                                <td class="font-medium text-dark-medium">
                                       <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Comments:</td>
                                                <td class="font-medium text-dark-medium">
                                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" MaxLength="4050"></asp:TextBox></td>
                                            </tr>

                                            <tr>
                                                <td>Download Document:</td>
                                                <td class="font-medium text-dark-medium">
                                                    <asp:LinkButton ID="LinkButton2" runat="server">LinkButton</asp:LinkButton></td>
                                            </tr>


                                            <tr>
                                                <td colspan="2">
                                                    <asp:Button ID="Button1" runat="server" Text="Delete" CssClass="btn-fill-md radius-4 text-light bg-orange-red" OnClick="Button1_Click" />
                                                    <asp:Button ID="Button2" runat="server" Text="Modify"  CssClass="btn-fill-md radius-4 text-light bg-light-sea-green" OnClick="Button2_Click"/>
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

