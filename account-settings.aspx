<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="account-settings.aspx.cs" Inherits="kids" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-size: x-small;
            color: #FF3300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="dashboard-content-one">
                <!-- Breadcubs Area Start Here -->
                <div class="breadcrumbs-area">
                    <h3>Application Management</h3>
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
                                       <p> <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/z1.jpg" Width="100px" Height="100px" BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton1_Click"/></p> <asp:ImageButton ID="ImageButton2" runat="server"  ImageUrl="~/z2.jpg" Width="100px" Height="100px" BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton2_Click" /><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/z3.jpg" Width="100px" Height="100px"  BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton3_Click"/><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/z4.jpg" Width="100px" Height="100px"  BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton4_Click"/><asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/z5.jpg" Width="100px" Height="100px"  BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton5_Click"/>
                                        <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/z6.jpg" Width="100px" Height="100px"  BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton6_Click"/><br />
                                        <br />
                                        <br />
                                        <br /><br />

                                        <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/z7.jpg" Width="100px" Height="100px"  BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton7_Click"/><asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/z8.jpg" Width="100px" Height="100px"  BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton8_Click"/><asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/z3.jpg" Width="100px" Height="100px"  BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton3_Click" Visible="False"/><asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/z3.jpg" Width="100px" Height="100px"  BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton3_Click" Visible="False"/><asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="~/z3.jpg" Width="100px" Height="100px"  BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton3_Click" Visible="False"/>
                                        <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="~/z3.jpg" Width="100px" Height="100px"  BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton3_Click" Visible="False"/><asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="~/z3.jpg" Width="100px" Height="100px"  BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton3_Click" Visible="False"/><asp:ImageButton ID="ImageButton14" runat="server" ImageUrl="~/z3.jpg" Width="100px" Height="100px"  BorderWidth="1px" BorderColor="#ff9933" OnClick="ImageButton3_Click" Visible="False"/>

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
                          <a class="auto-style1">....Caution: Once you save the session, you will close the last open session</a>
                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label><strong>Year *</strong></label>
                             <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                                 <asp:ListItem>Select Year</asp:ListItem>
                                 <asp:ListItem>2022</asp:ListItem>
                                 <asp:ListItem>2023</asp:ListItem>
                                 <asp:ListItem>2024</asp:ListItem>
                                 <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label><strong>Start Month *</strong></label>
                                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                                <asp:ListItem>Select Month</asp:ListItem>
                                                <asp:ListItem>Jan</asp:ListItem>
                                                <asp:ListItem>Feb</asp:ListItem>
                                                <asp:ListItem>Mar</asp:ListItem>
                                                <asp:ListItem>Apr</asp:ListItem>
                                                <asp:ListItem>May</asp:ListItem>
                                                <asp:ListItem>Jun</asp:ListItem>
                                                <asp:ListItem>Jul</asp:ListItem>
                                                <asp:ListItem>Aug</asp:ListItem>
                                                <asp:ListItem>Sep</asp:ListItem>
                                                <asp:ListItem>Oct</asp:ListItem>
                                                <asp:ListItem>Nov</asp:ListItem>
                                                <asp:ListItem>Dec</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>
                                                <asp:Label ID="Label5" runat="server" Text="Period" Visible="true"></asp:Label></label>
                              <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" Placeholder="E.g 1st Term"></asp:TextBox>
                                        </div>
                                      <br />
                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button2" runat="server" Text="Submit" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button2_Click" />
                                        </div>
                         <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered table-hover" ></asp:GridView>
                    </asp:Panel>
                     <asp:Panel ID="Panel1a" runat="server" Visible="false">
                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>
                                                <asp:Label ID="Label7" runat="server" Text="Start Time" Visible="true"></asp:Label></label>
                              <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" Placeholder="E.g 10:00 am"></asp:TextBox>
                                        </div>
                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>
                                                <asp:Label ID="Label8" runat="server" Text="End Time" Visible="true"></asp:Label></label>
                              <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" Placeholder="E.g 11:00 am"></asp:TextBox>
                                        </div>
                                      <br />
                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button5" runat="server" Text="Submit" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button5_Click"/>
                                        </div>
                         <asp:GridView ID="GridView3" runat="server" CssClass="table table-striped table-bordered table-hover" ></asp:GridView>
                    </asp:Panel>
                     <asp:Panel ID="Panel1b" runat="server" Visible="false">
                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>
                                                <asp:Label ID="Label10" runat="server" Text="Start Time" Visible="true"></asp:Label></label>
                              <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" Placeholder="E.g 10:00 am"></asp:TextBox>
                                        </div>
                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>
                                                <asp:Label ID="Label11" runat="server" Text="End Time" Visible="true"></asp:Label></label>
                              <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" Placeholder="E.g 11:00 am"></asp:TextBox>
                                        </div>
                                      <br />
                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button7" runat="server" Text="Submit" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button7_Click"/>
                                        </div>
                         <asp:GridView ID="GridView4" runat="server" CssClass="table table-striped table-bordered table-hover" ></asp:GridView>
                    </asp:Panel>
                      <asp:Panel ID="Panel1c" runat="server" Visible="false">
                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>
                                                <asp:Label ID="Label12" runat="server" Text="Route" Visible="true"></asp:Label></label>
                              <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" Placeholder="E.g Ikeja-Lekki"></asp:TextBox>
                                        </div>
                                      <br />
                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button8" runat="server" Text="Submit" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button8_Click"/>
                                        </div>
                         <asp:GridView ID="GridView5" runat="server" CssClass="table table-striped table-bordered table-hover" ></asp:GridView>
                    </asp:Panel>
                     <asp:Panel ID="Panel1d" runat="server" Visible="false">
                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>
                                                <asp:Label ID="Label15" runat="server" Text="Subject Area" Visible="true"></asp:Label></label>
                              <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control" Placeholder="E.g Mathematics"></asp:TextBox>
                                        </div>
                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>
                                                <asp:Label ID="Label16" runat="server" Text="Comment" Visible="true"></asp:Label></label>
                              <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                                        </div>
                                      <br />
                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button9" runat="server" Text="Submit" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button9_Click"/>
                                        </div>
                         <asp:GridView ID="GridView6" runat="server" CssClass="table table-striped table-bordered table-hover" ></asp:GridView>
                    </asp:Panel>
                     <asp:Panel ID="Panel1e" runat="server" Visible="false">
                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>
                                                <asp:Label ID="Label17" runat="server" Text="Payment Key" Visible="true"></asp:Label></label>
                              <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                      <br />
                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button10" runat="server" Text="Submit" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button10_Click"/>
                                        </div>
                         <asp:GridView ID="GridView7" runat="server" CssClass="table table-striped table-bordered table-hover" ></asp:GridView>
                    </asp:Panel>
                     <asp:Panel ID="Panel1f" runat="server" Visible="false">
                         <asp:GridView ID="GridView8" runat="server" CssClass="table table-striped table-bordered table-hover" ></asp:GridView>
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
</div>
</asp:Content>

