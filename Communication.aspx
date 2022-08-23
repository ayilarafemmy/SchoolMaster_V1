<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Parents.master" AutoEventWireup="true" CodeFile="Communication.aspx.cs" Inherits="kids" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="dashboard-content-one">
                <!-- Breadcubs Area Start Here -->
                <div class="breadcrumbs-area">
                    <h3>Communications</h3>
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
                                       <p> <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/a1.jpg" Width="150px" Height="150px" BorderWidth="2px" BorderColor="#ff9933" OnClick="ImageButton1_Click" BorderStyle="None"/></p> <asp:ImageButton ID="ImageButton2" runat="server"  ImageUrl="~/a2.jpg" Width="150px" Height="150px" BorderWidth="2px" BorderColor="#ff9933" OnClick="ImageButton2_Click" BorderStyle="None" /><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/a3.jpg" Width="150px" Height="150px"  BorderWidth="2px" BorderColor="#ff9933" OnClick="ImageButton3_Click" BorderStyle="None"/>

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
                         <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered table-hover">

                         </asp:GridView>
                    </asp:Panel>
                     <asp:Panel ID="Panel2" runat="server" Visible="false">
                    </asp:Panel>
                      <asp:Panel ID="Panel3" runat="server" Visible="false">
                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Child *</label>
                                           <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Recipients *</label>
                                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                                <asp:ListItem>Select Recipient</asp:ListItem>
                                                <asp:ListItem>Administrator</asp:ListItem>
                                                <asp:ListItem>Teacher</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Message *</label>
                               <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" MaxLength="2500"></asp:TextBox>
                                        </div>

                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button1" runat="server" Text="Send Message" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click"/>
          <asp:Button ID="Button3" runat="server" Text="New Request" CssClass="btn-fill-lg bg-blue-dark btn-hover-yellow" Visible="false"/>
                                        </div>
                    </asp:Panel>
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

