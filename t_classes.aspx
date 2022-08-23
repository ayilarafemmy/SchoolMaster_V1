<%@ Page Title="" Language="C#" MasterPageFile="~/nteacher.master" AutoEventWireup="true" CodeFile="t_classes.aspx.cs" Inherits="t_attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="breadcrumbs-area">
                    <h3>Class Routine</h3>
                    <ul>
                        <li>
                            <a href="Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>My Classes</li>
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
                                        <h3>Session</h3>
                                    </div>
                                </div>
                                <form class="new-added-form">
                                    <div class="row">
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                             <asp:Label ID="Label1" runat="server" Text="*" Visible="false"></asp:Label>
                                            <label>Select Session *</label>
                                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" BackColor="#FF9900"></asp:DropDownList>
                                        </div>

                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button1" runat="server" Text="Take Attendance" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click" visible="false" />
          <asp:Button ID="Button3" runat="server" Text="Reset" CssClass="btn-fill-lg bg-blue-dark btn-hover-yellow" visible="false" />
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">

                                            <label>
                                                <asp:Label ID="Label2" runat="server" Text="Students" Visible="false"></asp:Label></label>
                                            <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false">
                                                <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:CheckBox ID="chkEmployee" runat="server" />
            </ItemTemplate>
             <HeaderTemplate>
                Select those Present
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
                                            <asp:Label ID="Label3" runat="server" Text="My Sessions this Term"></asp:Label>
                                        </h3>

                                    </div>
                                </div>
                                <form class="mg-b-20">
                                    <div class="row gutters-8">

                                        <div class="col-lg-2 col-12 form-group">
                                          <asp:Button ID="Button2" runat="server" Text="Download" CssClass="fw-btn-fill btn-gradient-yellow" OnClick="Button2_Click"/>
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

