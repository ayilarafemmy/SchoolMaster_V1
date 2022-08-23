<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="add-book.aspx.cs" Inherits="add_book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="breadcrumbs-area">
                    <h3>Learning Management System</h3>
                    <ul>
                        <li>
                            <a href="Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Add New Material</li>
                    </ul>
                </div>
                <!-- Breadcubs Area End Here -->
                <!-- Add New Book Area Start Here -->
                <div class="card height-auto">
                    <div class="card-body">
                        <div class="heading-layout1">
                            <div class="item-title">
                                <h3>Add New Material<asp:Label ID="Label1" runat="server" Text="*" Visible="False"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text="*" Visible="False"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text="*" Visible="False"></asp:Label>
                                </h3>
                            </div>

                        </div>
                        <form class="new-added-form">
                            <div class="row">
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Material *</label>
                                   <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Subject *</label>
                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Expiry Date *</label>
                                   <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Enabled="true" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Class *</label>
                                  <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Description</label>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                 <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Material Type</label>
                                   <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                                       <asp:ListItem>Select Material Type</asp:ListItem>
                                       <asp:ListItem>PDF</asp:ListItem>
                                       <asp:ListItem>Word</asp:ListItem>
                                       <asp:ListItem>Image</asp:ListItem>
                                       <asp:ListItem>Multimedia</asp:ListItem>
                                       <asp:ListItem>Video</asp:ListItem>
                                       <asp:ListItem>Audio</asp:ListItem>
                                       <asp:ListItem>Others</asp:ListItem>
                                     </asp:DropDownList>
                                </div>
                                <div class="col-xl-3 col-lg-6 col-12 form-group">
                                    <label>Upload File *</label>
                                    <asp:FileUpload ID="FileUpload1" runat="server"  CssClass="form-control-file"/>
                                </div>
                                <div class="col-md-3 d-none d-xl-block form-group">

                                </div>
                                <div class="col-12 form-group mg-t-8">
           <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click" />
                                    <button type="reset" class="btn-fill-lg bg-blue-dark btn-hover-yellow">Reset</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
</asp:Content>

