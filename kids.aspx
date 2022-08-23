<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Parents.master" AutoEventWireup="true" CodeFile="kids.aspx.cs" Inherits="kids" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="dashboard-content-one">
                <!-- Breadcubs Area Start Here -->
                <div class="breadcrumbs-area">
                    <h3>My Kid(s)</h3>
                </div>
                <!-- Breadcubs Area End Here -->

                      <div class="row">
                    <div class="col-4-xxxl col-12">
                        <div class="card height-auto">
                            <div class="card-body">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3></h3>
                                    </div>
                                </div>
                                    <div class="row">

                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Child *</label>
                                           <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Requests *</label>
                                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                                <asp:ListItem>Select Request</asp:ListItem>
                                                <asp:ListItem>Profile</asp:ListItem>
                                                <asp:ListItem>Attendance</asp:ListItem>
                                                <asp:ListItem>Time Table</asp:ListItem>
                                                <asp:ListItem>Exams Schedule</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click"/>
          <asp:Button ID="Button3" runat="server" Text="New Request" CssClass="btn-fill-lg bg-blue-dark btn-hover-yellow" Visible="false"/>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                    <div class="col-8-xxxl col-12">
                        <div class="card height-auto">
                            <div class="card-body">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3>
                                            <asp:Label ID="Label1" runat="server" Text="Request" Visible="false"></asp:Label></h3>


                  <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <div class="col-12-xxxl col-xl-6 col-12">
                                            <div class="kids-details-box mb-5">
                                                <div class="item-img">
                                                 <asp:Image ID="Image1" runat="server" Height="150" Width="150"/>
                                                </div>
                                                <div class="item-content table-responsive">
                                                    <table class="table text-nowrap">
                                                        <tbody>
                                                            <tr>
                                                                <td>Name:</td>
                                                                <td>
                                                                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>  </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Gender:</td>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Class:</td>
                                                                <td>
                                                                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Roll:</td>
                                                                <td>#<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Section:</td>
                                                                <td>
                                                                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Id:</td>
                                                                <td>
                                                                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Admission Date:</td>
                                                                <td>
                                                                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div></asp:Panel>
                  <asp:Panel ID="Panel2" runat="server" Visible="false">
                    <div class="col-12-xxxl col-xl-6 col-12">
                                            <div class="kids-details-box mb-5">
                                                <div class="item-img">
                                                    <asp:Button ID="Button2" runat="server" Text="Download"  CssClass="btn-fill-lg bg-blue-dark btn-hover-yellow"  Visible="false" OnClick="Button2_Click"/>
                                                  <br /><br />  <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered table-hover"></asp:GridView>
                                                </div>

                                            </div>
                                        </div></asp:Panel>
                                    </div>
                                </div>
                                <form class="mg-b-20">
                                    <div class="row gutters-8">
                                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover"></asp:GridView>
                                    </div>
                                </form>

                        </div>
                    </div>
                </div>
                <!-- Dashboard Content Start Here -->

                <footer class="footer-wrap-layout1">
                    <div class="copyright">© Copyrights <a href="#">DataPlus </a> 2022. All rights reserved.</div>
                </footer>
                <!-- Dashboard Content End Here -->
            </div>
</asp:Content>

