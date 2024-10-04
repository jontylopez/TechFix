<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixManager.Master" AutoEventWireup="true" CodeBehind="ManagerHome.aspx.cs" Inherits="TechFix.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>Pending Requests</h2>
    <asp:GridView ID="gvPendingRequests" runat="server" AutoGenerateColumns="false" CssClass="common-table" OnRowCommand="gvPendingRequests_RowCommand">
        <Columns>
            <asp:BoundField DataField="itemName" HeaderText="Item Name" />
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnView" runat="server" Text="View" CssClass="common-button" CommandName="View" CommandArgument='<%# Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <h2>Pending Quotations</h2>
    <asp:GridView ID="gvPendingQuotations" runat="server" AutoGenerateColumns="false" CssClass="common-table" OnRowCommand="gvPendingQuotations_RowCommand">
        <Columns>
            <asp:BoundField DataField="reqID" HeaderText="Request ID" />
            <asp:BoundField DataField="invID" HeaderText="Inventory ID" />
            <asp:BoundField DataField="supID" HeaderText="Supplier ID" /> 
            <asp:BoundField DataField="unitPrice" HeaderText="Unit Price" />
            <asp:BoundField DataField="totalPrice" HeaderText="Total Price" />
            <asp:BoundField DataField="finalPrice" HeaderText="Final Price" />
            <asp:BoundField DataField="discount" HeaderText="Discount" />
            <asp:BoundField DataField="quotStat" HeaderText="Quotation Status" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnViewQuotation" runat="server" Text="View" CssClass="common-button" CommandName="ViewQuotation" CommandArgument='<%# Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
</asp:Content>
