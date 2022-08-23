<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgotpass_admin.aspx.cs" Inherits="pl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
     <meta charset="UTF-8">
  <title>School Master - Admin Forgot Password </title>
  <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css'><link rel="stylesheet" href="LoginEngine/style.css">
</head>
<body>

        <div>
            <!-- partial:index.partial.html -->
<h2>   <asp:Label ID="Labelza" runat="server" CssClass="auto-style1" Text="*" style="font-size: x-large"></asp:Label></h2>
<div class="container" id="container">
	<div class="form-container sign-up-container">

		</form>
	</div>
	<div class="form-container sign-in-container">
		<form id="form1" runat="server">
              <asp:Image ID="Image1" runat="server"  Height="100px" Width="120px"/><br />
			<h1>Admin Forgot Password</h1>

            <asp:TextBox ID="TextBox1" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>

            <asp:Button ID="Button1" runat="server" Text="Get Reset Code" CssClass="ghost" OnClick="Button1_Click" BackColor="#FFA601" />
            	<a href="admin.aspx">Back To Login!</a>

            <asp:Label ID="Label1" runat="server" Text="*" Visible="false" ForeColor="#FF3300"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="*" Visible="false" ForeColor="#FF3300"></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="*" Visible="false" ForeColor="#FF3300"></asp:Label>
            <asp:Label ID="Label4" runat="server" Text="*" Visible="false" ForeColor="#FF3300"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="*" Visible="false" ForeColor="#FF3300"></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="*" Visible="false" ForeColor="#FF3300"></asp:Label>

	</div>
	<div class="overlay-container">
		<div class="overlay">
			<div class="overlay-panel overlay-left">

			</div>
			<div class="overlay-panel overlay-right">
                <asp:Panel ID="Panel1" runat="server" Visible="false">
				<h1>Dear Admin</h1>
				<p>Kindly Enter the 5-Digit code sent to your email and New Password</p>
                    Code
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Code" TextMode="Number"></asp:TextBox>
                    New Password
                    <asp:TextBox ID="TextBox3" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="Reset Password" CssClass="ghost" OnClick="Button2_Click" />
                    </asp:Panel>
			</div>
		</div>
	</div>
</div>


<footer>
	<p>
		<a target="_blank" href="www.dataplusng.com">Powered by DataPlus</a>.
	</p>
</footer>
<!-- partial -->
  <script  src="LoginEngine/script.js"></script>
        </div>
    </form>
</body>
</html>
