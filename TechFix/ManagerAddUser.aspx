<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixManager.Master" AutoEventWireup="true" CodeBehind="ManagerAddUser.aspx.cs" Inherits="TechFix.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add New User</h2>
    <div class="common-form-container">

        <div class="common-form-group">
            <asp:Label ID="lblFName" runat="server" CssClass="common-input-label" Text="First Name"></asp:Label>
            <asp:TextBox ID="txtFName" runat="server" CssClass="common-input-box" placeholder="Enter first name"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblUName" runat="server" CssClass="common-input-label" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUName" runat="server" CssClass="common-input-box" placeholder="Enter username"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblPWord" runat="server" CssClass="common-input-label" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPWord" runat="server" TextMode="Password" CssClass="common-input-box" placeholder="Enter password"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblUMail" runat="server" CssClass="common-input-label" Text="Email"></asp:Label>
            <asp:TextBox ID="txtUMail" runat="server" CssClass="common-input-box" placeholder="Enter email"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblURole" runat="server" CssClass="common-input-label" Text="User Role"></asp:Label>
            <asp:DropDownList ID="ddlURole" runat="server" CssClass="common-select-box">
                <asp:ListItem Text="Manager" Value="mgr"></asp:ListItem>
                <asp:ListItem Text="Accountant" Value="acc"></asp:ListItem>
                <asp:ListItem Text="Supplier" Value="sup"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="common-form-group">
            <asp:Button ID="btnAddUser" runat="server" Text="Add User" CssClass="common-button-green" OnClick="AddUser_Click" />
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="common-input-label" ForeColor="Red" />
    </div>
</asp:Content>
