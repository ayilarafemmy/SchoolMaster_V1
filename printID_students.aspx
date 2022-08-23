<%@ Page Title="" Language="C#" MasterPageFile="~/nstudent.master" AutoEventWireup="true" CodeFile="printID_students.aspx.cs" Inherits="t_attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 78px;
        }
        .auto-style2 {
            width: 42%
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="breadcrumbs-area">
                    <h3>Identity Management</h3>
                    <ul>
                        <li>
                            <a href="std_Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>My ID</li>
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
                                        <h3>Action</h3>
                                    </div>
                                </div>
                                <form class="new-added-form">
                                    <div class="row">
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                             &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Enabled="false" Visible="False"></asp:DropDownList>
                                        </div>

                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button1" runat="server" Text="Print ID" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click" />
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
                                            <asp:Label ID="Label3" runat="server" Text="My Classes this Term" Visible="False"></asp:Label>
                                        </h3>

                                    </div>
                                </div>
                                <form class="mg-b-20">
                                    <div class="row gutters-8">

                                        <div class="col-lg-2 col-12 form-group">
                                          <asp:Button ID="Button2" runat="server" Text="Download" CssClass="fw-btn-fill btn-gradient-yellow" OnClick="Button2_Click" Visible="False"/>
                                        </div>
                                    </div>
                                </form>
                                <div id="pp">

                                    <table class="auto-style2" id="Joe">
                                        <tr>
                                            <td class="auto-style1" rowspan="6">
                                                <asp:Image ID="Image4" runat="server" Height="150px" Width="150px" />
                                            </td>
                                            <td>&nbsp;</td>
                                            <td><strong>
                                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                                </strong></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td><strong>Class:</strong>
                                                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td><strong>Roll No:</strong>
                                                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td><strong>Blood Group:</strong>
                                                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td><strong>
                                                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                                                </strong></td>
                                        </tr>
                                    </table>
&nbsp;</div>
                               <div style="overflow-x:auto;width:100%">
                                       <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover" Visible="false"></asp:GridView>
                           </div>
                        </div>
                    </div>
                </div>
</div>

</asp:Content>

