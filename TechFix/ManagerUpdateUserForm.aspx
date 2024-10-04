<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixManager.Master" AutoEventWireup="true" CodeBehind="ManagerUpdateUserForm.aspx.cs" Inherits="TechFix.WebForm12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update User</h2>
    <div class="common-form-container">

        <div class="common-form-group">
            <asp:Label ID="lblFName" runat="server" CssClass="common-input-label" Text="First Name"></asp:Label>
            <asp:TextBox ID="txtFName" runat="server" CssClass="common-input-box"></asp:TextBox>
        </div>

<div class="common-form-group">
    <asp:Label ID="lblUserName" runat="server" CssClass="common-input-label" Text="User Name"></asp:Label>
    <asp:TextBox ID="txtUName" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
</div>

        <div class="common-form-group">
            <asp:Label ID="lblUMail" runat="server" CssClass="common-input-label" Text="Email"></asp:Label>
            <asp:TextBox ID="txtUMail" runat="server" CssClass="common-input-box"></asp:TextBox>
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
            <asp:Button ID="btnSaveUser" runat="server" Text="Save" CssClass="common-button-green" OnClick="btnSaveUser_Click" />
        </div>

        <div class="common-form-group">
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="common-button" OnClick="btnBack_Click" />
        </div>
    </div>
</asp:Content>
