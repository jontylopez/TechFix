<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TechFix.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - TechFix</title>
    <link rel="stylesheet" href="../Css/Style.css" />
</head>
<body class="login-body"> 
    <div class="login-container">
        <div class="login-header">
            <div class="login-logo-container">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/TechFixLogo.png" CssClass="login-logo" />
                <h2 class="login-title">TechFix - Inventory Management System</h2>
            </div>
        </div>
        <form id="form1" runat="server">
            <asp:Label ID="lblMessage" runat="server" CssClass="login-error-message" ForeColor="Red"></asp:Label>
            <div class="login-form-group">
                <asp:Label ID="Label1" runat="server" Text="User Name" CssClass="login-input-label"></asp:Label>
                <asp:TextBox ID="txtUName" runat="server" CssClass="login-input-box"></asp:TextBox>
            </div>
            <div class="login-form-group">
                <asp:Label ID="Label2" runat="server" Text="Password" CssClass="login-input-label"></asp:Label>
                <asp:TextBox ID="txtPWord" runat="server" TextMode="Password" CssClass="login-input-box"></asp:TextBox>
            </div>
            <div class="login-form-group">
                <asp:Button ID="btnLogin" runat="server" OnClick="Button1_Click" Text="Login" CssClass="login-button" />
            </div>
        </form>
        <div class="login-footer">
            <p>&copy; 2024 TechFix. All rights reserved.</p>
        </div>
    </div>
</body>
</html>