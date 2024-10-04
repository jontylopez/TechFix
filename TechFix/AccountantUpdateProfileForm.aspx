<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixAccountant.Master" AutoEventWireup="true" CodeBehind="AccountantUpdateProfileForm.aspx.cs" Inherits="TechFix.WebForm20" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Update Profile</h2>

    <div class="common-form-container">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="message-label"></asp:Label>
        <div class="common-form-group">
            <asp:Label ID="lblFName" runat="server" Text="First Name" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtFName" runat="server" CssClass="common-input-box"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblUMail" runat="server" Text="Email" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtUMail" runat="server" CssClass="common-input-box"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblCurrentPassword" runat="server" Text="Current Password" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="common-input-box" TextMode="Password"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblNewPassword" runat="server" Text="New Password" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtNewPassword" runat="server" CssClass="common-input-box" TextMode="Password"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm New Password" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="common-input-box" TextMode="Password"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:CheckBox ID="chkShowPassword" runat="server" Text="Show Password" AutoPostBack="true" OnCheckedChanged="chkShowPassword_CheckedChanged" />
        </div>

        <div class="common-form-group">
            <asp:Button ID="btnUpdate" runat="server" Text="Update Profile" CssClass="common-button-green" OnClick="btnUpdate_Click" />
        </div>
    </div>
</asp:Content>
