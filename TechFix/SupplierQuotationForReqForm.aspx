<%@ Page Title="" Language="C#" MasterPageFile="~/SupplierMaser.Master" AutoEventWireup="true" CodeBehind="SupplierQuotationForReqForm.aspx.cs" Inherits="TechFix.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h2>Submit Quotation</h2>

  <div class="common-form-container">

    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    <asp:TextBox ID="txtInventoryID" runat="server" CssClass="common-input-box" ReadOnly="true" Visible="false"></asp:TextBox>

    <asp:TextBox ID="txtRequestID" runat="server" CssClass="common-input-box" ReadOnly="true" Visible="false"></asp:TextBox>

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
      <asp:Label ID="lblUnitPrice" runat="server" Text="Unit Price" CssClass="common-input-label"></asp:Label>
      <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="common-input-box" OnTextChanged="txtUnitPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
    </div>

    <div class="common-form-group">
      <asp:Label ID="lblTotalPrice" runat="server" Text="Total Price" CssClass="common-input-label"></asp:Label>
      <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
    </div>

    <div class="common-form-group">
      <asp:Label ID="lblDiscount" runat="server" Text="Apply Discount?" CssClass="common-input-label"></asp:Label>
      <asp:CheckBox ID="chkApplyDiscount" runat="server" AutoPostBack="true" OnCheckedChanged="chkApplyDiscount_CheckedChanged" />
      <asp:TextBox ID="txtDiscount" runat="server" CssClass="common-input-box" Enabled="false" placeholder="Enter Discount %" AutoPostBack="true"  Text="0"/>
    </div>

    <div class="common-form-group">
      <asp:Label ID="lblTotalAfterDiscount" runat="server" Text="Total After Discount" CssClass="common-input-label"></asp:Label>
      <asp:TextBox ID="txtTotalAfterDiscount" runat="server" CssClass="common-input-box" ReadOnly="true"></asp:TextBox>
    </div>

    <div class="common-form-group">
      <asp:Label ID="lblDescription" runat="server" Text="Description (Optional)" CssClass="common-input-label"></asp:Label>
      <asp:TextBox ID="txtDescription" runat="server" CssClass="common-input-box" TextMode="MultiLine"></asp:TextBox>
    </div>

    <div class="common-form-group">
      <asp:Button ID="btnSendQuotation" runat="server" Text="Send Quotation" CssClass="common-button-green" OnClick="btnSendQuotation_Click" />
      <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="common-button" OnClick="btnBack_Click" />
    </div>
  </div>
</asp:Content>
