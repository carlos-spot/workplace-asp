<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Paging.aspx.vb" Inherits="PagingSortingDataListRepeater_Paging" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Paging Data in a DataList</h2>
    <h3>Default Paging</h3>
    <p>
        <asp:DataList ID="ProductsDefaultPaging" runat="server" Width="100%" DataKeyField="ProductID" RepeatColumns="2" DataSourceID="ProductsDefaultPagingDataSource" EnableViewState="False">
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
            <ItemStyle Width="50%" />
        </asp:DataList>
        
        <asp:ObjectDataSource ID="ProductsDefaultPagingDataSource" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsAsPagedDataSource"
            TypeName="ProductsBLL">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="0" Name="pageIndex" QueryStringField="pageIndex"
                    Type="Int32" />
                <asp:QueryStringParameter DefaultValue="4" Name="pageSize" QueryStringField="pageSize"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <p style="text-align:center;">
        <asp:Button runat="server" ID="FirstPage" Text="<< First" />
        <asp:Button runat="server" ID="PrevPage" Text="< Prev" />
        <asp:Button runat="server" ID="NextPage" Text="Next >" />
        <asp:Button runat="server" ID="LastPage" Text="Last >>"  />
    </p>
    <p style="text-align:center;">
        <asp:Label runat="server" ID="CurrentPageNumber"></asp:Label>
    </p>
</asp:Content>

