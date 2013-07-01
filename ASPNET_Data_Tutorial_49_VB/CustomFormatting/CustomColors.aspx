<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CustomColors.aspx.vb" Inherits="CustomFormatting_CustomColors" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Products More Than $75.00 are Displayed in a <span class="ExpensivePriceEmphasis">Bold, Italic Font</span></h3>
    <p>
        <asp:DetailsView ID="ExpensiveProductsPriceInBoldItalic" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="ProductID" DataSourceID="ObjectDataSource1" EnableViewState="False">
            <Fields>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" SortExpression="CategoryName" />
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier" ReadOnly="True" SortExpression="SupplierName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Price"
                    HtmlEncode="False" SortExpression="UnitPrice" />
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteProduct"
            InsertMethod="AddProduct" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProducts"
            TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
            <DeleteParameters>
                <asp:Parameter Name="productID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="productName" Type="String" />
                <asp:Parameter Name="supplierID" Type="Int32" />
                <asp:Parameter Name="categoryID" Type="Int32" />
                <asp:Parameter Name="quantityPerUnit" Type="String" />
                <asp:Parameter Name="unitPrice" Type="Decimal" />
                <asp:Parameter Name="unitsInStock" Type="Int16" />
                <asp:Parameter Name="unitsOnOrder" Type="Int16" />
                <asp:Parameter Name="reorderLevel" Type="Int16" />
                <asp:Parameter Name="discontinued" Type="Boolean" />
                <asp:Parameter Name="productID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="productName" Type="String" />
                <asp:Parameter Name="supplierID" Type="Int32" />
                <asp:Parameter Name="categoryID" Type="Int32" />
                <asp:Parameter Name="quantityPerUnit" Type="String" />
                <asp:Parameter Name="unitPrice" Type="Decimal" />
                <asp:Parameter Name="unitsInStock" Type="Int16" />
                <asp:Parameter Name="unitsOnOrder" Type="Int16" />
                <asp:Parameter Name="reorderLevel" Type="Int16" />
                <asp:Parameter Name="discontinued" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </p>
    <h3>
        Products With 10 or Less Units In Stock Displayed in <span class="LowUnitsInStockEmphasis">Red</span></h3>
    <p>
        <asp:FormView ID="LowStockedProductsInRed" runat="server" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1" AllowPaging="True" EnableViewState="False">            
            <ItemTemplate>
                <b>Product:</b>
                <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Bind("ProductName") %>'>
                </asp:Label><br />
                <b>Units In Stock:</b>
                <asp:Label ID="UnitsInStockLabel" runat="server" Text='<%# Bind("UnitsInStock") %>'>
                </asp:Label>
            </ItemTemplate>
        </asp:FormView>
        &nbsp;</p>
    <h3>
        <span class="AffordablePriceEmphasis">Highlight</span> Products With Prices Less than $10.00</h3>
    <p>
        <asp:GridView ID="HighlightCheapProducts" runat="server" AutoGenerateColumns="False"
            DataKeyNames="ProductID" DataSourceID="ObjectDataSource1" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" SortExpression="CategoryName" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Price"
                    HtmlEncode="False" SortExpression="UnitPrice" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>

