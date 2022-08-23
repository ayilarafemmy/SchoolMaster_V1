<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Admin_Staff.aspx.cs" Inherits="Admin_Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadcrumbs-area">
                    <h3>Staff Management</h3>
                    <ul>
                        <li>
                            <a href="Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Staff</li>
                        <asp:Label ID="Label1" runat="server" Text="*" Visible="false"></asp:Label>
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
                                        <h3>Add New Staff</h3>
                                    </div>
                                </div>
                                <form class="new-added-form">
                                    <div class="row">
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <asp:Label ID="Label2" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text="*" Visible="false"></asp:Label>
                                             <label>First Name *</label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Last Name *</label>
                                          <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Maxlength="50"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Gender *</label>   <br />
          <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
              <asp:ListItem>Select Gender</asp:ListItem>
              <asp:ListItem>Female</asp:ListItem>
              <asp:ListItem>Male</asp:ListItem>
                                    </asp:DropDownList>
                                        </div>

                                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                             <label>Date Of Birth *</label>
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>

                                             <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                              <label>Role *</label>
                                   <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                       <asp:ListItem>Select Staff Application Role</asp:ListItem>
                                       <asp:ListItem>Administrator</asp:ListItem>
                                       <asp:ListItem>Manager</asp:ListItem>
                                       <asp:ListItem>User</asp:ListItem>
                                    </asp:DropDownList>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Secondary Role *</label>
                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
              <asp:ListItem>Select Secondary Role</asp:ListItem>
              <asp:ListItem>Admin</asp:ListItem>
              <asp:ListItem>Teacher</asp:ListItem>
               <asp:ListItem>Library</asp:ListItem>
              <asp:ListItem>Transport</asp:ListItem>
                                        <asp:ListItem>Care</asp:ListItem>
                                        <asp:ListItem>Hostel</asp:ListItem>
                                        <asp:ListItem>Sports</asp:ListItem>
                                        <asp:ListItem>Finance</asp:ListItem>
                                        <asp:ListItem>Management</asp:ListItem>
                                        <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>
                                        </div>

                                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                             <label>e-Mail</label>
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                        </div>
                                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                             <label>Phone</label>
                                       <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" TextMode="Number" MinLength="11" MaxLength="14"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Short BIO</label>
                                       <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" TextMode="Multiline" Height="300px"></asp:TextBox>  </div>
                                             <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                               <label class="text-dark-medium">Upload Staff ID (150px X 150px)</label>
                                        <asp:FileUpload ID="FileUpload1" runat="server"  CssClass="form-control-file"/>
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
                                        <h3>All Staff</h3>
                                    </div>
                                </div>
                                <form class="mg-b-20">
                                    <div class="row gutters-8">
                                        <div class="col-lg-4 col-12 form-group">
                                            <asp:TextBox ID="TextBox2a" runat="server" CssClass="form-control" Placeholder="Search...."></asp:TextBox>
                                        </div>

                                        <div class="col-lg-2 col-12 form-group">
                                          <asp:Button ID="Button2" runat="server" Text="Search" CssClass="fw-btn-fill btn-gradient-yellow" OnClick="Button2_Click" />
                                        </div>
                                    </div>
                                </form>
                               <div style="overflow-x:auto;width:100%">
                                       <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover"  Width="100%" AutoGenerateColumns="false">
                                            <Columns>

                                          <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/Staff-details.aspx?StaffID={0}",
                    HttpUtility.UrlEncode(Eval("StaffID").ToString()))%>'
                    Text="View Details" />
            </ItemTemplate>
        </asp:TemplateField>
                                         <asp:BoundField DataField="StaffID" HeaderText="Staff ID" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Gender" HeaderText="Gender" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                         <asp:BoundField DataField="DOB" HeaderText="Date of Birth" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                             <asp:BoundField DataField="email" HeaderText="email" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Phone" HeaderText="Phone" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Role" HeaderText="Main Role" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                                           <asp:BoundField DataField="SecondaryRole" HeaderText="Secondary Role" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>

                                         <asp:BoundField DataField="Profile" HeaderText="Profile" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Bio" HeaderText="Bio" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
    </Columns>
                                       </asp:GridView>
                           </div>
                        </div>
                    </div>
                </div>
</div>
</asp:Content>

