<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Admin_AccountsIN.aspx.cs" Inherits="Admin_Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadcrumbs-area">
                    <h3>Accounts - Inflow</h3>
                    <ul>
                        <li>
                            <a href="Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Transactions</li>
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
                                        <h3>Add New Transaction</h3>
                                    </div>
                                </div>
                                <form class="new-added-form">
                                    <div class="row">
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                              <label>Payment Purpose *</label>
                                   <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                        </div>
                                        <br /><br /><br /><br />
                                        <asp:Panel ID="Panel1" runat="server" Visible="true">
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group" style="left: 0px; top: 0px">
                                            <asp:Label ID="Label2" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text="*" Visible="false"></asp:Label>
                                                <asp:Label ID="Label5" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label6" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label7" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label8" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label9" runat="server" Text="*" Visible="false"></asp:Label>
                                             <label>
                                                 <asp:Label ID="Label4" runat="server" Text="*"></asp:Label> *</label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" MaxLength="50" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                             <label>Amount(Naira) *</label>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" MaxLength="50" TextMode="Number"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Transaction Type *</label>   <br />
          <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
              <asp:ListItem>Select Transaction Type</asp:ListItem>
              <asp:ListItem>POS</asp:ListItem>
              <asp:ListItem>Bank Transfer</asp:ListItem>
              <asp:ListItem>Mobile Money</asp:ListItem>
              <asp:ListItem>POS Transfer</asp:ListItem>
              <asp:ListItem>Cash</asp:ListItem>
              <asp:ListItem>Others</asp:ListItem>
                                    </asp:DropDownList>
                                        </div>

                                          <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                             <label>Transaction Date</label>
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label> Payment Description*</label>
                                       <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" TextMode="Multiline" Height="120px"></asp:TextBox>  </div>
                                             <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                               <label class="text-dark-medium">Upload File*</label>
                                        <asp:FileUpload ID="FileUpload1" runat="server"  CssClass="form-control-file"/>
                                 </div>
                                            </asp:Panel>
                                        <asp:Panel ID="Panel2" runat="server">
                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click" Visible="false" />
                                            <button type="reset" class="btn-fill-lg bg-blue-dark btn-hover-yellow" >Reset</button>
                                        </div>
                                            </asp:Panel>
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
                                        <h3>Recent Transactions</h3>
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
                                         <asp:BoundField DataField="Source" HeaderText="Source" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Destination" HeaderText="Destination" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Amount" HeaderText="Amount(Naira)" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="350" >
<ItemStyle Width="350px"></ItemStyle>
        </asp:BoundField>
                                         <asp:BoundField DataField="Type" HeaderText="Payment Type" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
  <asp:BoundField DataField="Purpose" HeaderText="Purpose" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                         <asp:BoundField DataField="TransDate" HeaderText="Transaction Date" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Balance" HeaderText="Balance" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>

                                                                               <asp:BoundField DataField="EnteredBy" HeaderText="Entered By" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>

                                                                               <asp:BoundField DataField="EntryDate" HeaderText="Entry Date" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                                        <asp:BoundField DataField="SupportingDoc" HeaderText="Supporting Doc" ItemStyle-Width="250" >
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

