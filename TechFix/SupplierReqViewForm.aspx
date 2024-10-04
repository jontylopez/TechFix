<%@ Page Title="" Language="C#" MasterPageFile="~/SupplierMaser.Master" AutoEventWireup="true" CodeBehind="SupplierReqViewForm.aspx.cs" Inherits="TechFix.WebForm16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Request Details</h2>

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
            <asp:Label ID="lblSerialNo" runat="server" Text="Serial No" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtSerialNo" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="common-input-label"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="common-form-group">
            <asp:Button ID="btnSendQuotation" runat="server" Text="Send Quotation" CssClass="common-button-green" OnClick="btnSendQuotation_Click" />
            <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="common-button-red" OnClick="btnReject_Click" OnClientClick="return confirm('Are you sure you want to reject this request?');" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="common-button" OnClick="btnBack_Click" />
        </div>
    </div>
</asp:Content>
