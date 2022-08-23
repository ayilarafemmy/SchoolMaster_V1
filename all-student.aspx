<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="all-student.aspx.cs" Inherits="all_parents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="breadcrumbs-area">
                    <h3>Students</h3>
                    <ul>
                        <li>
                            <a href="dashboard.aspx">Dashboard</a>
                        </li>
                        <li>All Students</li>
                    </ul>
                </div>
                <!-- Breadcubs Area End Here -->
                <!-- Teacher Table Area Start Here -->
                <div class="card height-auto">
                    <div class="card-body">
                        <div class="heading-layout1">
                            <div class="item-title">
                                <h3>All Students Data</h3>
                            </div>

                        </div>
                        <form class="mg-b-20">
                            <div class="row gutters-8">
                                <div class="col-3-xxxl col-xl-3 col-lg-3 col-12 form-group">
           <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Search by SID OR Email or Phone or Name"></asp:TextBox>
                                    </div>

                                <div class="col-1-xxxl col-xl-2 col-lg-3 col-12 form-group">
               <asp:Button ID="Button1" runat="server" Text="Search" CssClass="fw-btn-fill btn-gradient-yellow" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </form>
                       <div style="overflow-x:auto;width:100%">
                                <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false">
                                     <Columns>


                                          <asp:TemplateField>
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/Students-details.aspx?SID={0}",
                    HttpUtility.UrlEncode(Eval("SID").ToString()))%>'
                    Text="View" />
            </ItemTemplate>
        </asp:TemplateField>
                                         <asp:BoundField DataField="SID" HeaderText="StudentID" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
           <asp:BoundField DataField="Parent_ID" HeaderText="ParentID" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Gender" HeaderText="Gender" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                         <asp:BoundField DataField="DOB" HeaderText="Date of Birth" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
  <asp:BoundField DataField="Religion" HeaderText="Religion" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                         <asp:BoundField DataField="BG" HeaderText="Blood Group" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                             <asp:BoundField DataField="email" HeaderText="email" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Class" HeaderText="Class" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Section" HeaderText="Section" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>

                                         <asp:BoundField DataField="Photo" HeaderText="Photo" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Capture_Date" HeaderText="Capture Date" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                          <asp:BoundField DataField="Capture_By" HeaderText="Capture By" ItemStyle-Width="250" >
<ItemStyle Width="250px"></ItemStyle>
        </asp:BoundField>
                                           <asp:BoundField DataField="LoginC" HeaderText="Login Status" ItemStyle-Width="100" >
<ItemStyle Width="100px"></ItemStyle>
        </asp:BoundField>
    </Columns>
                                </asp:GridView>
                        </div>
                </div>
</div>
</asp:Content>

