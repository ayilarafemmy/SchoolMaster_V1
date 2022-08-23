<%@ Page Title="" Language="C#" MasterPageFile="~/nstudent.master" AutoEventWireup="true" CodeFile="std_profile.aspx.cs" Inherits="Admin_Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadcrumbs-area">
                    <h3>Profile</h3>
                    <ul>
                        <li>
                            <a href="std_Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>My Profile</li>
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
                                        <h3>Student Profile</h3>
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
                                           <label>SID*</label>   <br />
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>First Name*</label>   <br />
                                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Last Name*</label>   <br />
                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Parent*</label>   <br />
                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Gender*</label>   <br />
                                            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Date Of Birth*</label>   <br />
                                            <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Roll No*</label>   <br />
                                            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Blood Group*</label>   <br />
                                            <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Religion*</label>   <br />
                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Class*</label>   <br />
                                            <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Balance*</label>   <br />
                                            <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>

                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Bio*</label>
                                       <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Multiline" Height="50px" MaxLength="500" Enabled="false"></asp:TextBox>  </div>
                                               <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                               &nbsp;<asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false">
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
                                        <h3>My Details</h3>
                                    </div>
                                </div>
                                <form class="mg-b-20">
                                    <div class="row gutters-8">
                                        <div class="col-lg-4 col-12 form-group">
                                            <asp:TextBox ID="TextBox2a" runat="server" CssClass="form-control" Placeholder="Search...." Visible="False"></asp:TextBox>
                                        </div>

                                        <div class="col-lg-2 col-12 form-group">
                                          <asp:Button ID="Button2" runat="server" Text="Search" CssClass="fw-btn-fill btn-gradient-yellow" OnClick="Button2_Click" Visible="False" />
                                        </div>
                                    </div>
                                </form>
                                <asp:Image ID="Image1" runat="server" />
                               <div style="overflow-x:auto;width:100%">
                                   <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover"></asp:GridView>
                                   <%--<asp:GridView ID="GridView1" runat="server"   "></asp:GridView>--%>
                           </div>
                        </div>
                    </div>
                </div>
</div>
</asp:Content>

