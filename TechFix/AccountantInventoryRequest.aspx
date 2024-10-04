<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixAccountant.Master" AutoEventWireup="true" CodeBehind="AccountantInventoryRequest.aspx.cs" Inherits="TechFix.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Inventory Requests</h2>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="common-input-label"></asp:Label>

    <div class="common-form-group">
        <asp:Label ID="lblFilterSupplier" runat="server" Text="Filter by Supplier:" CssClass="common-input-label"></asp:Label>
        <asp:TextBox ID="txtSupplierName" runat="server" CssClass="common-input-box"></asp:TextBox>
        <asp:Button ID="btnFilterRequests" runat="server" Text="Search" CssClass="common-button" OnClick="btnFilterRequests_Click" />
        <asp:Button ID="btnAddRequest" runat="server" Text="Send Request" CssClass="common-button" OnClick="btnAddRequest_Click" />
    </div>

    <asp:GridView ID="gvRequests" runat="server" CssClass="common-table" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="itemName" HeaderText="Item Name" />
            <asp:BoundField DataField="brand" HeaderText="Brand" />
            <asp:BoundField DataField="serialNo" HeaderText="Serial Number" />
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="reqStatus" HeaderText="Status" />
        </Columns>
    </asp:GridView>
</asp:Content>
