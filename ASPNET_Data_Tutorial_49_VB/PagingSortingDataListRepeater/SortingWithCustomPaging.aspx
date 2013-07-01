<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="SortingWithCustomPaging.aspx.vb" Inherits="PagingSortingDataListRepeater_SortingWithCustomPaging" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Sorting and Paging Data in a Repeater</h2>
    <h3>Custom Paging</h3>
    <p style="text-align:center;">
        <asp:Button runat="server" id="SortByProductName" Text="Sort by Product Name" />
        <asp:Button runat="server" id="SortByCategoryName" Text="Sort by Category" />
        <asp:Button runat="server" id="SortBySupplierName" Text="Sort by Supplier" />
    </p>
    <p>
        <asp:Repeater ID="Products" runat="server" DataSourceID="ProductsDataSource" EnableViewState="False">
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
            SelectMethod="GetProductsPagedAndSorted" TypeName="ProductsBLL">
            <SelectParameters>
                <asp:Parameter Name="sortExpression" Type="String" />
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="maximumRows" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>        
    </p>
    <p style="text-align:center;">
        <asp:Button runat="server" ID="FirstPage" Text="<< First" />
        <asp:Button runat="server" ID="PrevPage" Text="< Prev" />
        <asp:Button runat="server" ID="NextPage" Text="Next >" />
        <asp:Button runat="server" ID="LastPage" Text="Last >>" />
    </p>
    <p style="text-align:center;">
        <asp:Label runat="server" ID="CurrentPageNumber"></asp:Label>
    </p>
</asp:Content>