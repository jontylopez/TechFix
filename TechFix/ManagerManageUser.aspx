<%@ Page Title="" Language="C#" MasterPageFile="~/TechFixManager.Master" AutoEventWireup="true" CodeBehind="ManagerManageUser.aspx.cs" Inherits="TechFix.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Manage Users</h2>
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" CssClass="common-table">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="User ID" ReadOnly="true" />
                <asp:BoundField DataField="fName" HeaderText="First Name" />
                <asp:BoundField DataField="uName" HeaderText="Username" />
                <asp:BoundField DataField="uMail" HeaderText="Email" />
                <asp:BoundField DataField="uRole" HeaderText="User Role" />

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfUserId" runat="server" Value='<%# Eval("id") %>' />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="common-button-green" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="common-button-red" OnClick="btnDelete_Click"  OnClientClick="return confirm('Are you sure you want to delete this item?');"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
</asp:Content>
