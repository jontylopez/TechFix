<%@ Page Title="Manual Request" Language="C#" MasterPageFile="~/TechFixAccountant.Master" AutoEventWireup="true" CodeBehind="AccountantItemManualReqForm.aspx.cs" Inherits="TechFix.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="common-form-container">
        <h2>Manual Inventory Request</h2>

        <div class="common-form-group">
            <asp:Label ID="lblItemName" runat="server" CssClass="common-input-label" Text="Item Name:" />
            <asp:TextBox ID="txtItemName" runat="server" CssClass="common-input-box" placeholder="Enter item name" />
            <asp:RequiredFieldValidator ID="rfvItemName" runat="server" ControlToValidate="txtItemName" ErrorMessage="Item Name is required." CssClass="error-message" />
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblBrand" runat="server" CssClass="common-input-label" Text="Brand:" />
            <asp:TextBox ID="txtBrand" runat="server" CssClass="common-input-box" placeholder="Enter brand" />
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblSerialNo" runat="server" CssClass="common-input-label" Text="Serial Number:" />
            <asp:TextBox ID="txtSerialNo" runat="server" CssClass="common-input-box" placeholder="Enter serial number" />
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblQuantity" runat="server" CssClass="common-input-label" Text="Quantity:" />
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="common-input-box" placeholder="Enter quantity" />
            <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Quantity is required." CssClass="error-message" />
            <asp:RangeValidator ID="rvQuantity" runat="server" ControlToValidate="txtQuantity" MinimumValue="1" MaximumValue="10000" Type="Integer" ErrorMessage="Please enter a valid quantity (1-10,000)." CssClass="error-message" />
        </div>

        <asp:HiddenField ID="hfReqStatus" runat="server" Value="pendingmgr" />

        <div class="common-form-group">
            <asp:Button ID="btnSendRequest" runat="server" Text="Send Request" CssClass="common-button-green" OnClick="btnSendRequest_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="common-button" OnClick="btnBack_Click" />
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="common-input-label" Text="" />
    </div>
</asp:Content>
