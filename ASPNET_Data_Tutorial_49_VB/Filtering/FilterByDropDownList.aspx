<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="FilterByDropDownList.aspx.vb" Inherits="Filtering_FilterByDropDownList" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>
        View Products By Category</h3>
    <p>
        Select a category:
        <asp:DropDownList ID="Categories" runat="server" AutoPostBack="True" DataSourceID="CategoriesDataSource"
            DataTextField="CategoryName" DataValueField="CategoryID" AppendDataBoundItems="True" EnableViewState="False">
            <asp:ListItem Value="-1">-- Choose a Category --</asp:ListItem>
        </asp:DropDownList><asp:ObjectDataSource ID="CategoriesDataSource" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategories" TypeName="CategoriesBLL">
        </asp:ObjectDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="productsDataSource" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier" ReadOnly="True" SortExpression="SupplierName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Price"
                    HtmlEncode="False" SortExpression="UnitPrice">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="productsDataSource" runat="server" DataObjectTypeName="Northwind+ProductsRow"
            DeleteMethod="DeleteProduct" InsertMethod="AddProduct" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProductsByCategoryID" TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
            <DeleteParameters>
                <asp:Parameter Name="productID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="Categories" Name="categoryID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

