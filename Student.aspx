<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="pl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
     <meta charset="UTF-8">
  <title>School Master - Student Login </title>
  <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.14.0/css/all.min.css'><link rel="stylesheet" href="LoginEngine/style.css">
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
              <asp:Image ID="Image1" runat="server"  Height="100px" Width="120px"/><br />
			<h1>Student Sign In</h1>

            <asp:TextBox ID="TextBox1" runat="server" placeholder="Student ID" TextMode="Number"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Sign In" CssClass="ghost" OnClick="Button1_Click" BackColor="#FFA601" />
            	<a href="forgotpass_student.aspx">Forgot your password?</a>

            <asp:Label ID="Label1" runat="server" Text="*" Visible="false" ForeColor="#FF3300"></asp:Label>

	</div>
	<div class="overlay-container">
		<div class="overlay">
			<div class="overlay-panel overlay-left">

			</div>
			<div class="overlay-panel overlay-right">

				<h1>Dear Student</h1>
				<p>Welcome to our School's Portal<br /><br />Enter your ID and Password to continue to the school portal</p>
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
