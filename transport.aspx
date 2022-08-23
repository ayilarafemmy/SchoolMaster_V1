<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="transport.aspx.cs" Inherits="Admin_Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadcrumbs-area">
                    <h3>Transport Management</h3>
                    <ul>
                        <li>
                            <a href="Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Transport</li>
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
                                        <h3>Add Vehicle</h3>
                                    </div>
                                </div>
                                <form class="new-added-form">
                                    <div class="row">
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <asp:Label ID="Label2" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text="*" Visible="false"></asp:Label>
                                             <label>Route *</label>
                                            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Vehicle Number *</label>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Placeholder="e.g KJA 938 JF"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Driver *</label>
                                     <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                              <label>Support Staff *</label>
                                   <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Vehicle Purpose *</label>
                                     <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                                         <asp:ListItem Value="0">Select Purpose</asp:ListItem>
                                         <asp:ListItem Value="1">School Bus</asp:ListItem>
                                         <asp:ListItem Value="2">Official Vehicle</asp:ListItem>
                                             </asp:DropDownList>
                                        </div>
                                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                             <label>Contact Number*</label>
                                       <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" TextMode="Number" MinLength="11" MaxLength="14" Enabled="false"></asp:TextBox>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Comments</label>
                                       <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" TextMode="Multiline" Height="120px"></asp:TextBox>  </div>
                                             <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                               <label class="text-dark-medium">Upload Vehicle Details (JPEG or PNG)</label>
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
                                        <h3>All Vehicles</h3>
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
                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/vehicle-details.aspx?VehicleID={0}",
                    HttpUtility.UrlEncode(Eval("VehicleID").ToString()))%>'
                    Text="Manage" />
            </ItemTemplate>
        </asp:TemplateField>
                                         <asp:BoundField DataField="VehicleID" HeaderText="VehicleID" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="PlateNo" HeaderText="Plate No" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="VehiclePurpose" HeaderText="Vehicle Purpose" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Route" HeaderText="Route" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                         <asp:BoundField DataField="Comment" HeaderText="Comment" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
  <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="250" >
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

