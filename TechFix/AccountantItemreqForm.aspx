<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixAccountant.Master" AutoEventWireup="true" CodeBehind="AccountantItemreqForm.aspx.cs" Inherits="TechFix.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="common-form-container">
        <h2>Request Inventory Item</h2>

 <asp:Label ID="lblMessage" runat="server" CssClass="common-input-label" Text="" />

        <div class="common-form-group">
            <asp:Label ID="lblItemIdLabel" runat="server" Text="Item ID:" CssClass="common-input-label" />
            <asp:TextBox ID="txtItemId" runat="server" CssClass="common-input-box" ReadOnly="true" />
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblItemNameLabel" runat="server" Text="Item Name:" CssClass="common-input-label" />
            <asp:TextBox ID="txtItemName" runat="server" CssClass="common-input-box" ReadOnly="true" />
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblBrandLabel" runat="server" Text="Brand:" CssClass="common-input-label" />
            <asp:TextBox ID="txtBrand" runat="server" CssClass="common-input-box" ReadOnly="true" />
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblSerialNoLabel" runat="server" Text="Serial No:" CssClass="common-input-label" />
            <asp:TextBox ID="txtSerialNo" runat="server" CssClass="common-input-box" ReadOnly="true" />
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblQuantityLabel" runat="server" Text="Quantity:" CssClass="common-input-label" />
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="common-input-box" />
        </div>

        <div class="common-form-group">
            <asp:Button ID="btnSendRequest" runat="server" Text="Send Request" CssClass="common-button-green" OnClick="btnSendRequest_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="common-button" OnClick="btnBack_Click" />
        </div>
    </div>
</asp:Content>
