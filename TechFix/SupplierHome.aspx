<%@ Page Title="" Language="C#" MasterPageFile="~/SupplierMaser.Master" AutoEventWireup="true" CodeBehind="SupplierHome.aspx.cs" Inherits="TechFix.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Pending Requests for Quotation</h2>
<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
       
        <asp:GridView ID="gvPendingRequests" runat="server" AutoGenerateColumns="false" CssClass="common-table">
            <Columns>
                
                <asp:BoundField DataField="itemName" HeaderText="Item Name" />
                
                <asp:BoundField DataField="quantity" HeaderText="Quantity" />

                
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnView" runat="server" Text="View" CssClass="common-button" CommandArgument='<%# Eval("id") %>' OnClick="btnView_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</asp:Content>
