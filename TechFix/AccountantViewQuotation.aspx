<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixAccountant.Master" AutoEventWireup="true" CodeBehind="AccountantViewQuotation.aspx.cs" Inherits="TechFix.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Quotation Details</h2>

    <div class="common-form-container">
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

        <div class="common-form-group">
            <asp:Label ID="lblItemName" runat="server" Text="Item Name" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtItemName" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblBrand" runat="server" Text="Brand" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtBrand" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblCurrentQuantity" runat="server" Text="Current Quantity" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtCurrentQuantity" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblUnitPrice" runat="server" Text="Unit Price" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="common-form-group">
    <asp:Label ID="lblTotalPrice" runat="server" Text="Total Price" CssClass="common-input-label"></asp:Label>
    <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
</div>

        <div class="common-form-group">
            <asp:Label ID="lblFinalPrice" runat="server" Text="Final Price" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtFinalPrice" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblDiscount" runat="server" Text="Discount" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtDiscount" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="common-input-box" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblQuotationStatus" runat="server" Text="Quotation Status" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtQuotationStatus" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblDateCreated" runat="server" Text="Date Created" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtDateCreated" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Button ID="btnUpdateInventory" runat="server" Text="Update Inventory" CssClass="common-button-green" OnClick="btnUpdateInventory_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="common-button btn-secondary" OnClick="btnBack_Click" />
        </div>
    </div>
</asp:Content>
