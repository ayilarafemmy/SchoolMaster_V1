<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="account-settingsOLD.aspx.cs" Inherits="all_subject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-size: xx-small;
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="breadcrumbs-area">
                    <h3>Applications Management</h3>
                    <ul>
                        <li>
                            <a href="Dashboard.aspx">Dashboard</a>
                        </li>
                        <li>Settings</li>
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
                                        <h3>Settings</h3>
                                    </div>
                                </div>
                                <form class="new-added-form">
                                    <div class="row">
                                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
                                            <label>Session *</label>
                                          <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Subject *</label>
                                           <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Select Invigilator *</label>
                                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Select Exam Time *</label>
                                            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Select Day *</label>
                                             <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        var today = new Date();
        var month = ('0' + (today.getMonth() + 1)).slice(-2);
        var day = ('0' + today.getDate()).slice(-2);
        var year = today.getFullYear();
        var date = year + '-' + month + '-' + day;
        $('[id*=TextBox3]').attr('min', date);
    });
</script>
                                             <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                         <div class="col-12-xxxl col-lg-6 col-12 form-group">
                                            <label>Class *</label><br />
                                             <asp:Label ID="Label3" runat="server" Text="*" Visible="false"></asp:Label>
                                        </div>

                                        <div class="col-12 form-group mg-t-8">
          <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button1_Click" />
                                            <button type="reset" class="btn-fill-lg bg-blue-dark btn-hover-yellow">Reset</button>
                                        </div>
                                            </asp:Panel>
                                         <asp:Button ID="Button3" runat="server" Text="Session Configuration" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark" OnClick="Button3_Click"/><br />
                                        <asp:Button ID="Button4" runat="server" Text="Period Management" CssClass="btn-fill-lg bg-blue-dark btn-hover-yellow"/><br />
                                        <asp:Button ID="Button5" runat="server" Text="Exams Period" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark"/><br />
                                        <asp:Button ID="Button6" runat="server" Text="Routes" CssClass="btn-fill-lg bg-blue-dark btn-hover-yellow"/><br />
                                        <asp:Button ID="Button7" runat="server" Text="Vehicles" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark"/><br />
                                        <asp:Button ID="Button8" runat="server" Text="Logs" CssClass="btn-fill-lg bg-blue-dark btn-hover-yellow"/><br />
                                        <asp:Button ID="Button9" runat="server" Text="SMS Logs" CssClass="btn-fill-lg btn-gradient-yellow btn-hover-bluedark"/>
                                    </div>

                                </form>
                            </div>
                        </div>
                    </div>
                    <div class="col-8-xxxl col-12">
                        <div class="card height-auto">
                                <div class="heading-layout1">
                                    <div class="item-title">
                                        <h3>Session Configuration</h3>
                                    </div>
                                </div>
                                <form class="mg-b-20">
                                    <div class="row gutters-8">
                                        <div class="col-lg-4 col-12 form-group">
                                            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="0">Select Year</asp:ListItem>
                                                <asp:ListItem Value="1">2022</asp:ListItem>
                                                <asp:ListItem Value="2">2023</asp:ListItem>
                                                <asp:ListItem Value="3">2024</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-4 col-12 form-group">
                                            <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="0">Select Start Month</asp:ListItem>
                                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                                <asp:ListItem>May</asp:ListItem>
                                                <asp:ListItem>June</asp:ListItem>
                                                <asp:ListItem>July</asp:ListItem>
                                                <asp:ListItem>Aug</asp:ListItem>
                                                <asp:ListItem>Sept</asp:ListItem>
                                                <asp:ListItem>Oct</asp:ListItem>
                                                <asp:ListItem>Nov</asp:ListItem>
                                                <asp:ListItem>Dec</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-4 col-12 form-group">
                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Placeholder="Provide Period e.g 1st Term"></asp:TextBox>
                                        </div>
                                        <a><strong>clicking this button will close open session**</strong></a>

                                       <%-- <asp:Button ID="Button2" runat="server" Text="Create" CssClass="fw-btn-fill btn-gradient-yellow"  style="left: 0px; top: 0px" --%>/>

                                        <div class="col-lg-2 col-12 form-group"><span class="auto-style1"></span>
                                              <asp:Button ID="Button11" runat="server" Text="Button" OnClick="Button11_Click" Visible="False" />
                                            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
                                        </div>
                                    </div>
                                </form>
                               <div style="overflow-x:auto;width:100%">
                                       <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover"></asp:GridView>
                           </div>
                        </div>
                    </div>

</div>
</asp:Content>

