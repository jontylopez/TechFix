<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixManager.Master" AutoEventWireup="true" CodeBehind="ManagerReqView.aspx.cs" Inherits="TechFix.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Request Details</h2>

    <div class="common-form-container">

        <div class="common-form-group">
            <asp:Label ID="lblItemName" runat="server" CssClass="common-input-label" Text="Item Name"></asp:Label>
            <asp:TextBox ID="txtItemName" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblBrand" runat="server" CssClass="common-input-label" Text="Brand"></asp:Label>
            <asp:TextBox ID="txtBrand" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblSerialNo" runat="server" CssClass="common-input-label" Text="Serial No"></asp:Label>
            <asp:TextBox ID="txtSerialNo" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblQuantity" runat="server" CssClass="common-input-label" Text="Quantity"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblStatus" runat="server" CssClass="common-input-label" Text="Request Status"></asp:Label>
            <asp:TextBox ID="txtStatus" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="common-button-green" OnClick="btnApprove_Click" />
        </div>

        <div class="common-form-group">
            <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="common-button-red" OnClick="btnReject_Click"  OnClientClick="return confirm('Are you sure you want to reject this item?');"/>
        </div>

        <div class="common-form-group">
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="common-button" OnClick="btnBack_Click" />
        </div>
    </div>
</asp:Content>
