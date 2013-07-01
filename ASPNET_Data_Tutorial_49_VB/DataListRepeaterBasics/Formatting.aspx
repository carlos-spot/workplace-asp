<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Formatting.aspx.vb" Inherits="DataListRepeaterBasics_Formatting" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Custom Formatting</h2>
    <h3>Formatting Using the <code>ItemDataBound</code> Event Handler</h3>
    <p>
        <asp:DataList ID="ItemDataBoundFormattingExample" runat="server" DataKeyField="ProductID" DataSourceID="ObjectDataSource1"
            EnableViewState="False">
            <HeaderTemplate>
                <h3>
                    Product Information</h3>
            </HeaderTemplate>
            <ItemTemplate>
                <h4>
                    <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label></h4>
                <table border="0">
                    <tr>
                        <td class="ProductPropertyLabel">
                            Category:</td>
                        <td>
                            <asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label></td>
                        <td class="ProductPropertyLabel">
                            Supplier:</td>
                        <td>
                            <asp:Label ID="SupplierNameLabel" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="ProductPropertyLabel">
                            Qty/Unit:</td>
                        <td>
                            <asp:Label ID="QuantityPerUnitLabel" runat="server" Text='<%# Eval("QuantityPerUnit") %>'></asp:Label></td>
                        <td class="ProductPropertyLabel">
                            Price:</td>
                        <td>
                            <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice", "{0:C}") %>'></asp:Label></td>
                    </tr>
                </table>
            </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:DataList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProducts" TypeName="ProductsBLL"></asp:ObjectDataSource>
        &nbsp;</p>
    <h3>Formatting Using Formatting Functions</h3>
    <p>
        <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID" DataSourceID="ObjectDataSource1"
            EnableViewState="False">
            <HeaderTemplate>
                <h3>
                    Product Information</h3>
            </HeaderTemplate>
            <ItemTemplate>
                <h4><asp:Label ID="ProductNameLabel" runat="server" Text='<%# DisplayProductNameAndDiscontinuedStatus(CType(Eval("ProductName"), String), CType(Eval("Discontinued"), Boolean)) %>'></asp:Label></h4>
                <table border="0">
                    <tr>
                        <td class="ProductPropertyLabel">
                            Category:</td>
                        <td>
                            <asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label></td>
                        <td class="ProductPropertyLabel">
                            Supplier:</td>
                        <td>
                            <asp:Label ID="SupplierNameLabel" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="ProductPropertyLabel">
                            Qty/Unit:</td>
                        <td>
                            <asp:Label ID="QuantityPerUnitLabel" runat="server" Text='<%# Eval("QuantityPerUnit") %>'></asp:Label></td>
                        <td class="ProductPropertyLabel">
                            Price:</td>
                        <td>
                            <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# DisplayPrice(CType(CType(Container.DataItem, System.Data.DataRowView).Row, Northwind.ProductsRow)) %>'></asp:Label></td>
                    </tr>
                </table>
            </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:DataList>
        &nbsp;</p>
</asp:Content>

