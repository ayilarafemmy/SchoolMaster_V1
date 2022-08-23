<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Teachers.master" AutoEventWireup="true" CodeFile="t_students.aspx.cs" Inherits="t_students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="dashboard-content-one">
                <!-- Breadcubs Area Start Here -->
                <div class="breadcrumbs-area">
                    <h3>My Students</h3>
                </div>
                <!-- Breadcubs Area End Here -->

                <div class="card height-auto">
                    <div class="card-body">
                   <form class="mg-b-20">
                            <div class="row gutters-8">
                                <div class="col-3-xxxl col-xl-3 col-lg-3 col-12 form-group">
           <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="StudentID OR First Name OR Last Name"></asp:TextBox>
                                    </div>

                                <div class="col-1-xxxl col-xl-2 col-lg-3 col-12 form-group">
               <asp:Button ID="Button1" runat="server" Text="Search" CssClass="fw-btn-fill btn-gradient-yellow" OnClick="Button1_Click" />

                                </div>
                                 <div class="col-1-xxxl col-xl-2 col-lg-3 col-12 form-group">
               <asp:Button ID="Button2" runat="server" Text="Download Record" CssClass="fw-btn-fill btn-danger"  Width="200px" Visible="false" OnClick="Button2_Click"/>

                                </div>
                            </div>
                        </form>



                       <div style="overflow-x:auto;width:100%">
                                <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false">
                                     <Columns>


                                         <%-- <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/t_student-details.aspx?SID={0}",
                    HttpUtility.UrlEncode(Eval("SID").ToString()))%>'
                    Text="Manage" />
            </ItemTemplate>
        </asp:TemplateField>--%>
                                               <asp:BoundField DataField="Class" HeaderText="Class" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
                                         <asp:BoundField DataField="SID" HeaderText="StudentID" ItemStyle-Width="150" >
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
                                         <asp:BoundField DataField="Roll_No" HeaderText="Roll_No" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
    </asp:BoundField>
                                          <asp:ImageField DataImageUrlField="Image" HeaderText="Image" ItemStyle-Width="150px" ItemStyle-Height="150px"></asp:ImageField>
    </Columns>
                                </asp:GridView>
                        </div>

                    </div>
                </div>
      </div>
</asp:Content>

