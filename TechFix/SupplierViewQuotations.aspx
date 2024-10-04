<%@ Page Title="" Language="C#" MasterPageFile="~/SupplierMaser.Master" AutoEventWireup="true" CodeBehind="SupplierViewQuotations.aspx.cs" Inherits="TechFix.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Your Submitted Quotations</h2>
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="common-message"></asp:Label>
        <asp:GridView ID="gvQuotations" runat="server" AutoGenerateColumns="false" CssClass="common-table" GridLines="None" CellPadding="10">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Quotation ID" />
                <asp:BoundField DataField="itemName" HeaderText="Item Name" />
                <asp:BoundField DataField="brand" HeaderText="Brand" />
                <asp:BoundField DataField="unitPrice" HeaderText="Unit Price" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="totalPrice" HeaderText="Total Price" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="finalPrice" HeaderText="Final Price" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="discount" HeaderText="Discount (%)" DataFormatString="{0:P2}" />
                <asp:BoundField DataField="quotStat" HeaderText="Quotation Status" />
                <asp:BoundField DataField="dateCreated" HeaderText="Date Created" DataFormatString="{0:dd-MM-yyyy}" />
            </Columns>
        </asp:GridView>
</asp:Content>
