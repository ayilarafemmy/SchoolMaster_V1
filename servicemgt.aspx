<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="servicemgt.aspx.cs" Inherits="Admin_Students" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            color: #042954;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadcrumbs-area">
                    <h3>Service Management</h3>
                    <ul>
                        <li>
                            <a href="Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Classes, Transport and Facilities</li>
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
                                        <h3>Manage a Service</h3>
                                    </div>
                                </div>
                                <form class="new-added-form">
                                    <div class="row">
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <asp:Label ID="Label2" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text="*" Visible="false"></asp:Label>
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
                                            <label>Service</label>
                                            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                                                <asp:ListItem>Select Service</asp:ListItem>
                                                <asp:ListItem>Class</asp:ListItem>
                                                <asp:ListItem>Transport</asp:ListItem>
                                            </asp:DropDownList>
                                         </div>

                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>New Service *</label>
                                     <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" Visible="false">
                                             </asp:DropDownList>
                                            <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control" Enabled="true" AutoPostBack="True" Visible="false">
                                             </asp:DropDownList>
                                        </div>

                                             <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                               <label class="text-dark-medium">Comments</label>
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Height="70px"  TextMode="MultiLine"></asp:TextBox>
                                 </div>

                                        <div class="col-12 form-group mg-t-8">
                                            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="btn btn-success" Width="200px" Height="40px" style="font-size: large; background-color: #FFAE01"  />
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
                                        <label>.</label>
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

