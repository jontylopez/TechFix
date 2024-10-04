<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixAccountant.Master" AutoEventWireup="true" CodeBehind="AccountantHome.aspx.cs" Inherits="TechFix.WebForm2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Items to Restock</h2>
<asp:GridView ID="gvItemsToRestock" runat="server" AutoGenerateColumns="false" CssClass="common-table">
    <Columns>
        <asp:BoundField DataField="itemName" HeaderText="Item Name" />
        <asp:BoundField DataField="brand" HeaderText="Brand" />
        <asp:BoundField DataField="serialNo" HeaderText="Serial Number" />
        <asp:BoundField DataField="quantity" HeaderText="Quantity" />
    </Columns>
</asp:GridView>


    <h2>Manager Approved Quotations</h2>

    <asp:GridView ID="gvApprovedQuotations" runat="server" AutoGenerateColumns="false" CssClass="common-table" OnRowCommand="gvApprovedQuotations_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Quotation ID" />
             <asp:BoundField DataField="invID" HeaderText="Inventory ID" />
             <asp:BoundField DataField="reqID" HeaderText="Reques ID" />
            <asp:BoundField DataField="supID" HeaderText="Supplier ID" />
            <asp:BoundField DataField="unitPrice" HeaderText="Unit Price" />
            <asp:BoundField DataField="discount" HeaderText="Discount Percentage" />
            <asp:BoundField DataField="finalPrice" HeaderText="Final Price" />
                    
           <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="btnViewQuotation" runat="server" Text="View Quotation" CssClass="common-button" CommandName="ViewQuotation" CommandArgument='<%# Eval("id") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="message-label"></asp:Label>
</asp:Content>

