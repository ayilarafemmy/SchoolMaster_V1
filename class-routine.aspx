<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="class-routine.aspx.cs" Inherits="all_subject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="breadcrumbs-area">
                    <h3>Period Management</h3>
                    <ul>
                        <li>
                            <a href="Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Time Table</li>
                    </ul>
                </div>
                <!-- Breadcubs Area End Here -->
                <!-- All Subjects Area Start Here -->
                <div class="row">
                    <div class="col-4-xxxl col-12">
                        <div class="card height-auto">
                            <div class="card-body">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3>Create New</h3>
                                    </div>
                                </div>
                                <form class="new-added-form">
                                    <div class="row">
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
                                            <label>Session *<asp:Label ID="Label4" runat="server" Text="Label" Visible="false"></asp:Label>
                                            </label>
                                          &nbsp;<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Subject *</label>
                                           <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Select Teacher *</label>
                                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Select Period *</label>
                                            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Select Day *</label>
                                            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="0">Select Day</asp:ListItem>
                                                <asp:ListItem Value="1">Monday</asp:ListItem>
                                                <asp:ListItem Value="2">Tuesday</asp:ListItem>
                                                <asp:ListItem Value="3">Wednesday</asp:ListItem>
                                                <asp:ListItem Value="4">Thursday</asp:ListItem>
                                                <asp:ListItem Value="5">Friday</asp:ListItem>
                                                <asp:ListItem Value="6">Saturday</asp:ListItem>
                                                <asp:ListItem Value="7">Sunday</asp:ListItem>
                                             </asp:DropDownList>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Class *</label><br />
                                             <asp:Label ID="Label3" runat="server" Text="*" Visible="false"></asp:Label>
                                        </div>

                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click" />
                                            <button type="reset" class="btn-fill-lg bg-blue-dark btn-hover-yellow">Reset</button>
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
                                        <h3>All Class Sessions</h3>
                                    </div>
                                </div>
                                <form class="mg-b-20">
                                    <div class="row gutters-8">
                                        <div class="col-lg-4 col-12 form-group">
                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Placeholder="Search...."></asp:TextBox>
                                        </div>

                                        <div class="col-lg-2 col-12 form-group">
                                          <asp:Button ID="Button2" runat="server" Text="Search" CssClass="fw-btn-fill btn-gradient-yellow" OnClick="Button2_Click" />
                                        </div>
                                    </div>
                                </form>
                               <div style="overflow-x:auto;width:100%">
                                       <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover"></asp:GridView>
                           </div>
                        </div>
                    </div>
                </div>
</div>
</asp:Content>

