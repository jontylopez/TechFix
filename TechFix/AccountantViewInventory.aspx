<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixAccountant.Master" AutoEventWireup="true" CodeBehind="AccountantViewInventory.aspx.cs" Inherits="TechFix.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Inventory Management</h2>
    <div class="common-form-group">
        <asp:TextBox ID="txtSearch" runat="server" CssClass="common-input-box" placeholder="Search inventory..."></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="common-button" OnClick="SearchInventory_Click" />
        <asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="common-button" OnClick="btnAddItem_Click" />
    </div>
    <asp:GridView ID="gvInventory" runat="server" CssClass="common-table" AutoGenerateColumns="false" OnSelectedIndexChanged="gvInventory_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="true" />
        <asp:BoundField DataField="itemName" HeaderText="Item Name" />
        <asp:BoundField DataField="brand" HeaderText="Brand" />
        <asp:BoundField DataField="serialNo" HeaderText="Serial No" />
        <asp:BoundField DataField="quantity" HeaderText="Quantity" />
        <asp:BoundField DataField="unitPrice" HeaderText="Unit Price" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:HiddenField ID="hfInventoryId" runat="server" Value='<%# Eval("id") %>' />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="common-button-green" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="common-button-red" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this item?');" />
                <asp:Button ID="btnOrder" runat="server" Text="Request" CssClass="common-button" OnClick="btnOrder_Click" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
