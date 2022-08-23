<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Parents.master" AutoEventWireup="true" CodeFile="finances.aspx.cs" Inherits="kids" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="dashboard-content-one">
                <!-- Breadcubs Area Start Here -->
                <div class="breadcrumbs-area">
                    <h3>Finances</h3>
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
                                       <p> <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/a4.jpg" Width="150px" Height="150px" BorderWidth="2px" BorderColor="#ff9933" OnClick="ImageButton1_Click" BorderStyle="None"/></p> <asp:ImageButton ID="ImageButton2" runat="server"  ImageUrl="~/a5.jpg" Width="150px" Height="150px" BorderWidth="2px" BorderColor="#ff9933" OnClick="ImageButton2_Click" /><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/a6.jpg" Width="150px" Height="150px"  BorderWidth="2px" BorderColor="#ff9933" OnClick="ImageButton3_Click"/>

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
                         <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered table-hover" ></asp:GridView>
                    </asp:Panel>
                     <asp:Panel ID="Panel2" runat="server" Visible="false">
                         <asp:Label ID="Label3" runat="server" Text="*" Visible="false"></asp:Label>
                         <asp:Label ID="Label2" runat="server" Text="*"></asp:Label> Naira Only
                    </asp:Panel>
                      <asp:Panel ID="Panel3" runat="server" Visible="false">
                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label><strong>Total Outstanding Fees(Naira) *</strong></label>
                              <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label><strong>For Who *</strong></label>
                                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>
                                                <asp:Label ID="Label4" runat="server" Text="*" Visible="false"></asp:Label></label>
                              <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" TextMode="Number" Visible="false"></asp:TextBox>
                                        </div>
                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label><strong>Amount to Pay(Naira) *</strong></label>
                              <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                        </div>
                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label><strong>Comment *</strong></label>
                              <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Multiline"></asp:TextBox>
                                        </div>
                                      <br />
                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button1" runat="server" Text="Confirm" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click"/>
          <asp:Button ID="Button3" runat="server" Text="New Request" CssClass="btn-fill-lg bg-blue-dark btn-hover-yellow" Visible="false"/>


                                            <asp:Button ID="Button6" runat="server" CssClass="btn btn-raised waves-effect g-bg-cyan" Text="Cancel" Visible="False" Height="39px" style="background-color: #669900" />

					<asp:Button ID="Button4" runat="server" />
                                            <asp:Label ID="Label14" runat="server" Text="Label" Visible="False"></asp:Label>
                                        </div>
                    </asp:Panel>
                                    </div>
                                </div>
                                <form class="mg-b-20">
                                    <div class="row gutters-8">
                                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover"></asp:GridView>
                                    </div>
                                    <asp:Label ID="Label13" runat="server" Text="Label" Visible="false"></asp:Label><asp:Label ID="Label6" runat="server" Text="Label" Visible="false"> </asp:Label>
                                    <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
                                </form>

                        </div>
                    </div>
                </div>
                <!-- Dashboard Content Start Here -->

                <footer class="footer-wrap-layout1">
                </footer>
                <!-- Dashboard Content End Here -->
            </div>
</asp:Content>

