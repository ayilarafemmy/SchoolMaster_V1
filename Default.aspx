<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="pl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
     <meta charset="UTF-8">
  <title>School Master - Parent Login </title>
  <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css'><link rel="stylesheet" href="LoginEngine/style.css">
     <style type="text/css">
         .auto-style1 {
             font-size: x-large;
         }
         .auto-style2 {
             width: 100%;
         }
     </style>
</head>
<body>

        <div>
            <!-- partial:index.partial.html -->
<h2>   <asp:Label ID="Labelza" runat="server" CssClass="auto-style1" Text="*"></asp:Label></h2>
<div class="container" id="container">
	<div class="form-container sign-up-container">

		</form>
	</div>
	<div class="form-container sign-in-container">
		<form id="form1" runat="server">

            <table class="auto-style2">
                <tr>
                    <td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/student.jpg" Height="120px" Width="160px" OnClick="ImageButton1_Click" /></td>
                    <td><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/parent.jpg" Height="120px" Width="160px" OnClick="ImageButton2_Click" /></td>
                </tr>
                <tr>
                    <td><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/teacher.jpg" Height="120px" Width="160px" OnClick="ImageButton3_Click" /></td>
                    <td><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/admin.jpg" Height="120px" Width="160px" OnClick="ImageButton4_Click1" /></td>
                </tr>
            </table>





	</div>
	<div class="overlay-container">
		<div class="overlay">
			<div class="overlay-panel overlay-left">

			</div>
			<div class="overlay-panel overlay-right">

				<h1>Welcome to </h1>
				<p><asp:Label ID="Label2" runat="server" Text="Label" CssClass="auto-style1"></asp:Label><br /><br />Kindly Click button to access your space and login</p>
                  <asp:Image ID="Image1" runat="server"  Height="100px" Width="120px"/><br />
               <%-- <asp:Button ID="Button1" runat="server" Text="Forgot Password" CssClass="ghost" />--%>
				<%--<button class="ghost" id="signUp">Sign Up</button>--%>
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
