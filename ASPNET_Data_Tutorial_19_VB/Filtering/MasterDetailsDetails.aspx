<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="MasterDetailsDetails.aspx.vb" Inherits="Filtering_MasterDetailsDetails" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3> 
        View Product Details By Category</h3>
    <p>
        Select a category:
        <asp:DropDownList ID="Categories" runat="server" DataSourceID="CategoriesDataSource"
            DataTextField="CategoryName" DataValueField="CategoryID" AutoPostBack="True" EnableViewState="False">
        </asp:DropDownList><asp:ObjectDataSource ID="CategoriesDataSource" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategories" TypeName="CategoriesBLL">
        </asp:ObjectDataSource>
        <br />
        Select a product:
        <asp:DropDownList ID="ProductsByCategory" runat="server" DataSourceID="ProductsByCategoryDataSource"
            DataTextField="ProductName" DataValueField="ProductID" AutoPostBack="True" EnableViewState="False">
        </asp:DropDownList><asp:ObjectDataSource ID="ProductsByCategoryDataSource" runat="server"
            DataObjectTypeName="Northwind+ProductsRow" DeleteMethod="DeleteProduct" InsertMethod="AddProduct"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsByCategoryID"
            TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
            <DeleteParameters>
                <asp:Parameter Name="productID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="Categories" Name="categoryID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <p>
        <asp:DetailsView ID="ProductDetails" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1" EnableViewState="False">
            <Fields>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" SortExpression="CategoryName" />
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier" ReadOnly="True" SortExpression="SupplierName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Price"
                    HtmlEncode="False" SortExpression="UnitPrice" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="Units In Stock" />
                <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="Units On Order" />
                <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="Reorder Level" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Northwind+ProductsRow"
            DeleteMethod="DeleteProduct" InsertMethod="AddProduct" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProductByProductID" TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
            <DeleteParameters>
                <asp:Parameter Name="productID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="ProductsByCategory" Name="productID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

