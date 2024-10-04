<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixAccountant.Master" AutoEventWireup="true" CodeBehind="AccountantAddInventoryForm.aspx.cs" Inherits="TechFix.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="common-form-container">
        <asp:Label ID="lblMessage" runat="server" CssClass="common-input-label" Text="" />
        <h2>Add Inventory Item</h2>

         <div class="common-form-group">
     <label>Item Name:</label>
     <asp:TextBox ID="txtItemName" runat="server" CssClass="common-input-box" />
 </div>

 <div class="common-form-group">
     <label>Brand:</label>
     <asp:TextBox ID="txtBrand" runat="server" CssClass="common-input-box" />
 </div>

 <div class="common-form-group">
     <label>Serial No:</label>
     <asp:TextBox ID="txtSerialNo" runat="server" CssClass="common-input-box" />
 </div>

 <div class="common-form-group">
     <label>Quantity:</label>
     <asp:TextBox ID="txtQuantity" runat="server" CssClass="common-input-box" />
 </div>

 <div class="common-form-group">
     <label>Unit Price:</label>
     <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="common-input-box" />
 </div>

 <div class="common-form-group">
     <label>Supplier:</label>
     <asp:TextBox ID="txtSupplier" runat="server" CssClass="common-input-box" />
 </div>

        <div class="common-form-group">
            <asp:Button ID="btnSaveInventory" runat="server" Text="Save Inventory" CssClass="common-button-green" OnClick="btnSaveInventory_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="common-button" OnClick="btnBack_Click" />
        </div>

        
    </div>
</asp:Content>
