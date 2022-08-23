<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="invoicing.aspx.cs" Inherits="Admin_Students" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-size: large;
            text-decoration: underline;
            color: #FF0000;
        }
        .auto-style2 {
            color: #042954;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadcrumbs-area">
                    <h3>Bills Management</h3>
                    <ul>
                        <li>
                            <a href="Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Bills & Invoices</li>
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
                                        <h3>Raise Bill</h3>
                                    </div>
                                </div>
                                <form class="new-added-form">
                                    <div class="row">
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <asp:Label ID="Label2" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text="*" Visible="false"></asp:Label>
                                             <label>Term *<asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label9" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label10" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label11" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label12" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label13" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label14" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label15" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label16" runat="server" Text="Label" Visible="False"></asp:Label>
                                            <asp:Label ID="Label17" runat="server" Text="Label" Visible="False"></asp:Label>
                                            </label>
                                            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Class *</label>
                                     <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                              <label>Student *</label>
                                   <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" Enabled="false" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                        </div>

                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Notes</label>
                                       <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Multiline" Height="30px"></asp:TextBox>  </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label><strong><span class="auto-style1">Line Items</span></strong></label>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Purpose *</label>
                                     <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                             </asp:DropDownList>
                                        </div>
                                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                             <label>Amount(Naira)*</label>
                                       <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" TextMode="Number" MinLength="4" MaxLength="24" Enabled="false"></asp:TextBox>
                                        </div>

                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Quantity *</label>
                                     <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control" AutoPostBack="True" Enabled="false" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                         <asp:ListItem>Select Quantity</asp:ListItem>
                                         <asp:ListItem>1</asp:ListItem>
                                         <asp:ListItem>2</asp:ListItem>
                                         <asp:ListItem>3</asp:ListItem>
                                         <asp:ListItem>4</asp:ListItem>
                                         <asp:ListItem>5</asp:ListItem>
                                         <asp:ListItem>6</asp:ListItem>
                                         <asp:ListItem>7</asp:ListItem>
                                         <asp:ListItem>8</asp:ListItem>
                                         <asp:ListItem>9</asp:ListItem>
                                         <asp:ListItem>10</asp:ListItem>
                                             </asp:DropDownList>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Total Amount(Naira)</label>
                                       <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>  </div>
                                             <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                               <label class="text-dark-medium">Description</label>
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Height="70px"  TextMode="MultiLine"></asp:TextBox>
                                 </div>

                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button1" runat="server" Text="Add Line Item" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click" Enabled="false" />
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
                                        <h3>&nbsp;</h3>
                                    </div>
                                </div>

                                    <div class="row gutters-8">
                                         <asp:Button ID="Button2" runat="server" Text="Send Bill Now" CssClass="fw-btn-fill btn-gradient-yellow" Visible="false" OnClick="Button2_Click" />

                                        <div class="col-lg-4 col-12 form-group">
                                            <asp:TextBox ID="TextBox2a" runat="server" CssClass="form-control" Placeholder="Search...." Visible="false"></asp:TextBox>
                                        </div>

                                        <div class="col-lg-2 col-12 form-group">
                                            <asp:Label ID="Label5" runat="server" Text="'Verify Entries before Submitting" Visible="false" CssClass="auto-style2"></asp:Label>
                                                      </div>
                                    </div>
                                </>
                               <div style="overflow-x:auto;width:100%">
                                       <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover"  DataKeyNames="LineID" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateDeleteButton="true">
                                           <%-- <Columns>
                                                <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/vehicle-details.aspx?LineID={0}",
                    HttpUtility.UrlEncode(Eval("LineID").ToString()))%>'
                    Text="Delete" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Item" HeaderText="Item" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                                    <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Amount" HeaderText="Amount" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                                 <asp:BoundField DataField="LineTotal" HeaderText="Line Total" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>

                                                </Columns>--%>
                                       </asp:GridView>
                           </div>
                        </div>
                    </div>
                </div>
</div>
</asp:Content>

