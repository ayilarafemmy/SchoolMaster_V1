<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Teachers.master" AutoEventWireup="true" CodeFile="Teachers_Dashboard.aspx.cs" Inherits="Teachers_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <div class="dashboard-content-one">
                <!-- Breadcubs Area Start Here -->
                <div class="breadcrumbs-area">
                    <h3>Teachers' Dashboard</h3>
                </div>
                <!-- Breadcubs Area End Here -->

                <div class="card height-auto">
                    <div class="card-body">
                     <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/a7.jpg" Width="150px" Height="150px"  BorderWidth="3px" BorderColor="Orange" OnClick="ImageButton2_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/a8.jpg" Width="150px" Height="150px"  BorderWidth="3px" BorderColor="Orange" OnClick="ImageButton3_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/a9.jpg" Width="150px" Height="150px"  BorderWidth="3px" BorderColor="Orange" OnClick="ImageButton4_Click"/>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/a10.jpg" Width="150px" Height="150px"  BorderWidth="3px" BorderColor="Orange" OnClick="ImageButton7_Click"/>
                  </div>
                </div>

               <div class="card height-auto">
                    <div class="card-body">
                     <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/a11.jpg" Width="150px" Height="150px"  BorderWidth="3px" BorderColor="Orange" OnClick="ImageButton1_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/a12.jpg" Width="150px" Height="150px"  BorderWidth="3px" BorderColor="Orange" OnClick="ImageButton5_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/a13.jpg" Width="150px" Height="150px"  BorderWidth="3px" BorderColor="Orange" OnClick="ImageButton6_Click"/>

                    </div>
                </div>

               </div>

</asp:Content>

