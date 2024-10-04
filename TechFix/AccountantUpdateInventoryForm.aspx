<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixAccountant.Master" AutoEventWireup="true" CodeBehind="AccountantUpdateInventoryForm.aspx.cs" Inherits="TechFix.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="common-form-container">
        <h2>Update Inventory Item</h2>

        <asp:Label ID="lblMessage" runat="server" CssClass="common-input-label" Text="" />

        <asp:HiddenField ID="hfInventoryId" runat="server" />

        <div class="common-form-group">
            <asp:Label ID="lblItemName" runat="server" CssClass="common-input-label" Text="Item Name:" />
            <asp:TextBox ID="txtItemName" runat="server" CssClass="common-input-box" ReadOnly="true" />
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblBrand" runat="server" CssClass="common-input-label" Text="Brand:" />
            <asp:TextBox ID="txtBrand" runat="server" CssClass="common-input-box" ReadOnly="true" />
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblSerialNo" runat="server" CssClass="common-input-label" Text="Serial Number:" />
            <asp:TextBox ID="txtSerialNo" runat="server" CssClass="common-input-box" ReadOnly="true" />
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblSupplier" runat="server" CssClass="common-input-label" Text="Supplier:" />
            <asp:TextBox ID="txtSupplier" runat="server" CssClass="common-input-box" ReadOnly="true" />
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblQuantity" runat="server" CssClass="common-input-label" Text="Quantity:" />
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="common-input-box" />
            <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Quantity is required." CssClass="error-message" />
            <asp:RangeValidator ID="rvQuantity" runat="server" ControlToValidate="txtQuantity" MinimumValue="1" MaximumValue="10000" Type="Integer" ErrorMessage="Please enter a valid quantity (1-10,000)." CssClass="error-message" />
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblUnitPrice" runat="server" CssClass="common-input-label" Text="Unit Price:" />
            <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="common-input-box" />
            <asp:RequiredFieldValidator ID="rfvUnitPrice" runat="server" ControlToValidate="txtUnitPrice" ErrorMessage="Unit Price is required." CssClass="error-message" />
            <asp:RangeValidator ID="rvUnitPrice" runat="server" ControlToValidate="txtUnitPrice" MinimumValue="0.01" MaximumValue="100000" Type="Double" ErrorMessage="Please enter a valid price (0.01 - 100,000)." CssClass="error-message" />
        </div>

        <div class="common-form-group">
            <asp:Button ID="btnSaveInventory" runat="server" Text="Update Inventory" CssClass="common-button-green" OnClick="btnSaveInventory_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="common-button" OnClick="btnBack_Click" />
        </div>


    </div>
</asp:Content>
