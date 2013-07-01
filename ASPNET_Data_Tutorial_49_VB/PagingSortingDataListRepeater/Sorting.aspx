<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Sorting.aspx.vb" Inherits="PagingSortingDataListRepeater_Sorting" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Sorting Data in a Repeater Control</h2>
    <p>
        Sort the results by:
        <asp:DropDownList ID="SortBy" runat="server">
            <asp:ListItem Value="ProductName">Name</asp:ListItem>
            <asp:ListItem Value="ProductName DESC">Name (Reverse Order)</asp:ListItem>
            <asp:ListItem Value="CategoryName">Category</asp:ListItem>
            <asp:ListItem Value="SupplierName">Supplier</asp:ListItem>
        </asp:DropDownList>
        <asp:Button runat="server" ID="RefreshRepeater" Text="Refresh" /></p>
    <p>
        <asp:Repeater ID="SortableProducts" runat="server" DataSourceID="ProductsDataSource" EnableViewState="False">
            <ItemTemplate>
                <h4><asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>'>
                </asp:Label></h4>
                Category:
                <asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Eval("CategoryName") %>'>
                </asp:Label><br />
                Supplier:
                <asp:Label ID="SupplierNameLabel" runat="server" Text='<%# Eval("SupplierName") %>'>
                </asp:Label><br />
                <br />
                <br />
            </ItemTemplate>        
        </asp:Repeater>
        
        <asp:ObjectDataSource ID="ProductsDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProducts" TypeName="ProductsBLL"></asp:ObjectDataSource>
    </p>
</asp:Content>

