<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Admin_Parents.aspx.cs" Inherits="Admin_Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadcrumbs-area">
                    <h3>Parent Management</h3>
                    <ul>
                        <li>
                            <a href="Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Parent</li>
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
                                        <h3>Add New Parent</h3>
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
                                              <label>Relationship *</label>
                                   <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                       <asp:ListItem>Select Relationship</asp:ListItem>
                                       <asp:ListItem>Father</asp:ListItem>
                                       <asp:ListItem>Mother</asp:ListItem>
                                       <asp:ListItem>Guardian</asp:ListItem>
                                       <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Religion *</label>
                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
              <asp:ListItem>Select Religion</asp:ListItem>
              <asp:ListItem>Christianity</asp:ListItem>
              <asp:ListItem>Islam</asp:ListItem>
               <asp:ListItem>Hindu</asp:ListItem>
              <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>
                                        </div>

                                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                             <label>e-Mail</label>
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                        </div>
                                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                             <label>Phone*</label>
                                       <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" TextMode="Number" MinLength="11" MaxLength="14"></asp:TextBox>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                             <label>Alternate Phone</label>
                                       <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Number" MinLength="11" MaxLength="14"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Full Address</label>
                                       <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" TextMode="Multiline" Height="120px"></asp:TextBox>  </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Comments</label>
                                       <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" TextMode="Multiline" Height="120px"></asp:TextBox>  </div>
                                             <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                               <label class="text-dark-medium">Upload Means ID (JPEG or PNG)</label>
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
                                        <h3>All Parents</h3>
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
                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/Parents-details.aspx?PID={0}",
                    HttpUtility.UrlEncode(Eval("PID").ToString()))%>'
                    Text="Manage" />
            </ItemTemplate>
        </asp:TemplateField>
                                         <asp:BoundField DataField="PID" HeaderText="ParentID" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="First_Name" HeaderText="First Name" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Last_Name" HeaderText="Last Name" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Gender" HeaderText="Gender" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                         <asp:BoundField DataField="Relationship" HeaderText="Relationship" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
  <asp:BoundField DataField="Religion" HeaderText="Religion" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                         <asp:BoundField DataField="email" HeaderText="email" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Phone" HeaderText="Phone" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Alternate_Phone" HeaderText="Alternate Phone" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Full_Address" HeaderText="Full Address" ItemStyle-Width="350" >
<ItemStyle Width="100%"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Comments" HeaderText="Comments" ItemStyle-Width="350" >
<ItemStyle Width="350px"></ItemStyle>
        </asp:BoundField>

                                         <asp:BoundField DataField="Identity_Upload" HeaderText="ID Name" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Capture_Date" HeaderText="Capture Date" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Capture_By" HeaderText="Capture By" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                           <asp:BoundField DataField="FirstLogin" HeaderText="Login Status" ItemStyle-Width="100" >
<ItemStyle Width="100px"></ItemStyle>
        </asp:BoundField>
                                                </Columns>
                                       </asp:GridView>
                           </div>
                        </div>
                    </div>
                </div>
</div>
</asp:Content>

