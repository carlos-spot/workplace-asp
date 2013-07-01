<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DetailsBySelecting.aspx.vb" Inherits="Filtering_DetailsBySelecting" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>
        View Product Details</h3>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID"
            DataSourceID="ProductDetailsDataSource" EnableViewState="False">
            <Fields>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True"
                    SortExpression="CategoryName" />
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier" ReadOnly="True"
                    SortExpression="SupplierName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Price" SortExpression="UnitPrice" DataFormatString="{0:c}" HtmlEncode="False" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="Units In Stock" SortExpression="UnitsInStock" />
                <asp:BoundField DataField="UnitsOnOrder" HeaderText="Units On Order" SortExpression="UnitsOnOrder" />
                <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" SortExpression="ReorderLevel" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ProductDetailsDataSource" runat="server" DataObjectTypeName="Northwind+ProductsRow"
            DeleteMethod="DeleteProduct" InsertMethod="AddProduct" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProductByProductID" TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
            <DeleteParameters>
                <asp:Parameter Name="productID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ProductsGrid" Name="productID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <p>
        <asp:GridView ID="ProductsGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="AllProductsDataSource" EnableViewState="False">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Unit Price"
                    HtmlEncode="False" SortExpression="UnitPrice" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="AllProductsDataSource" runat="server" DataObjectTypeName="Northwind+ProductsRow"
            DeleteMethod="DeleteProduct" InsertMethod="AddProduct" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProducts" TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
            <DeleteParameters>
                <asp:Parameter Name="productID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

