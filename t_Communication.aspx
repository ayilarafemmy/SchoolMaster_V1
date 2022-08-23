<%@ Page Title="" Language="C#" MasterPageFile="~/nteacher.master" AutoEventWireup="true" CodeFile="t_Communication.aspx.cs" Inherits="Admin_Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadcrumbs-area">
                    <h3>Communications</h3>
                    <ul>
                        <li>
                            <a href="Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Teachers Communication</li>
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
                                        <h3>Send Message</h3>
                                    </div>
                                </div>
                                <form class="new-added-form">
                                    <div class="row">
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <asp:Label ID="Label2" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text="*" Visible="false"></asp:Label>

                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Classes *</label>   <br />
          <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" BackColor="#FF9900">
                                    </asp:DropDownList>
                                        </div>

                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Message*</label>
                                       <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Multiline" Height="50px" MaxLength="500" BorderColor="#FF9900" BorderWidth="1px"></asp:TextBox>  </div>
                                               <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                               <label class="text-dark-medium"><strong>Select Student(s)*</strong></label>
                                         <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false">
                                                <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="chkEmployee" runat="server" />
            </ItemTemplate>
             <HeaderTemplate>
                Select Students
         </HeaderTemplate>
        </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="150px">
                  <HeaderTemplate>
                Student Name
         </HeaderTemplate>
                  <ItemTemplate>
                      <asp:TextBox ID="Name" runat="server" Text='<%#Eval("Name")%>' ItemStyle-Width="150px"></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
             <asp:TemplateField ItemStyle-Width="150px">
                  <HeaderTemplate>
                Student ID
         </HeaderTemplate>
                  <ItemTemplate>
                      <asp:TextBox ID="SID" runat="server" Text='<%#Eval("SID")%>' ItemStyle-Width="150px"></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>

    </Columns>
                                            </asp:GridView>
                                 </div>

                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button1" runat="server" Text="Send Message" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click" style="height: 48px" />
                                            <button type="reset" class="btn-fill-lg bg-blue-dark btn-hover-yellow">Reset</button>
                                            <br />

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
                                        <h3>All Messages</h3>
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
                                   <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover" DataKeyNames="MID" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateDeleteButton="true"></asp:GridView>
                                   <%--<asp:GridView ID="GridView1" runat="server"   "></asp:GridView>--%>
                           </div>
                        </div>
                    </div>
                </div>
</div>
</asp:Content>

