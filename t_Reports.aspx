<%@ Page Title="" Language="C#" MasterPageFile="~/nteacher.master" AutoEventWireup="true" CodeFile="t_Reports.aspx.cs" Inherits="Admin_Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="breadcrumbs-area">
                    <h3>Academic Reports</h3>
                    <ul>
                        <li>
                            <a href="Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Report Card Generator</li>
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
                                        <h3>Add New Record</h3>
                                    </div>
                                </div>
                                <form class="new-added-form">
                                    <div class="row">
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <asp:Label ID="Label2" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text="*" Visible="false"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text="*" Visible="false"></asp:Label>
                                             <label>Term *</label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" MaxLength="50" Enabled="false" BorderColor="#FF9900" BorderWidth="1px"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Classes *</label>   <br />
          <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" BackColor="#FF9900">
                                    </asp:DropDownList>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                           <label>Student *</label>   <br />
          <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="True" BackColor="#FF9900" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                        </div>
                                           <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Co-corricular Comments*</label>
                                       <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" BorderColor="#FF9900" BorderWidth="1px"></asp:TextBox>  </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Comments*</label>
                                       <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Multiline" Height="50px" BorderColor="#FF9900" BorderWidth="1px"></asp:TextBox>  </div>
                                               <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                               &nbsp;</div>

                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button1" runat="server" Text="Generate Result" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click" style="height: 48px" />

                                            <asp:Button ID="Button2" runat="server" Text="Submit"  Visible="false" CssClass="btn-fill-lg bg-blue-dark btn-hover-yellow" OnClick="Button2_Click"/>
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
                                        <h3>Report Generator For
                                            <asp:Label ID="Label5" runat="server" Text="*"></asp:Label>
                                        </h3>
                                    </div>
                                </div>
                                <form class="mg-b-20">
                                    <div class="row gutters-8">

                                        <div class="col-lg-2 col-12 form-group">
                                        </div>
                                    </div>
                                </form>
                               <div style="overflow-x:auto;width:100%">
                                   <%--<asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover" DataKeyNames="ResultID" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateDeleteButton="true"></asp:GridView>--%>
                                   <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false">

                                                    <Columns>

                 <asp:TemplateField ItemStyle-Width="150px">
                  <HeaderTemplate>
               Subject
         </HeaderTemplate>
                  <ItemTemplate>
                      <asp:TextBox ID="Subject" runat="server" Text='<%#Eval("Subject")%>' ItemStyle-Width="150px"></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
             <asp:TemplateField ItemStyle-Width="150px">
                  <HeaderTemplate>
                Test
         </HeaderTemplate>
                  <ItemTemplate>
                      <asp:TextBox ID="Test" runat="server" Text='<%#Eval("Test")%>' ItemStyle-Width="150px"></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="150px">
                  <HeaderTemplate>
                Max Score Test
         </HeaderTemplate>
                  <ItemTemplate>
                      <asp:TextBox ID="MaxScoreTest" runat="server" Text='<%#Eval("MaxScoreTest")%>' ItemStyle-Width="150px"></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
                      <asp:TemplateField ItemStyle-Width="150px">
                  <HeaderTemplate>
                Examination
         </HeaderTemplate>
                  <ItemTemplate>
                      <asp:TextBox ID="Examination" runat="server" Text='<%#Eval("Examination")%>' ItemStyle-Width="150px"></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>
                                                         <asp:TemplateField ItemStyle-Width="150px">
                  <HeaderTemplate>
                Max Score Examination
         </HeaderTemplate>
                  <ItemTemplate>
                      <asp:TextBox ID="MaxScoreExamination" runat="server" Text='<%#Eval("MaxScoreExamination")%>' ItemStyle-Width="150px"></asp:TextBox>
                  </ItemTemplate>
              </asp:TemplateField>

    </Columns>
                                   </asp:GridView>
                                   <br />
                                   <asp:GridView ID="GridView2" runat="server" Visible="false" CssClass="table table-striped table-bordered table-hover">
                                   </asp:GridView>
                           </div>
                        </div>
                    </div>
                </div>
</div>
</asp:Content>

