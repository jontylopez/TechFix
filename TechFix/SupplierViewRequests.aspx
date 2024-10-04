<%@ Page Title="" Language="C#" MasterPageFile="~/SupplierMaser.Master" AutoEventWireup="true" CodeBehind="SupplierViewRequests.aspx.cs" Inherits="TechFix.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h2>Supplier Requests</h2>

    <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
    
    <asp:GridView ID="gvSupplierRequests" runat="server" CssClass="common-table" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="itemName" HeaderText="Item Name" />
            <asp:BoundField DataField="brand" HeaderText="Brand" />
            <asp:BoundField DataField="serialNo" HeaderText="Serial Number" />
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="reqStatus" HeaderText="Request Status" />
            <asp:BoundField DataField="actionStatus" HeaderText="Action Status" />
            <asp:BoundField DataField="actionDate" HeaderText="Action Date" DataFormatString="{0:yyyy-MM-dd}" />
        </Columns>
    </asp:GridView>
</asp:Content>
