<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ProductsForSupplierDetails.aspx.vb" Inherits="Filtering_ProductsForSupplierDetails" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <asp:HyperLink ID="lnkReturnToSupplierList" runat="server" NavigateUrl="~/Filtering/SupplierListMaster.aspx"><< Return to Supplier List</asp:HyperLink>&nbsp;
        <br />
        <br />
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="SupplierID" DataSourceID="SuppliersDataSource" EnableViewState="False">
            <ItemTemplate>
                <h3><%# Eval("CompanyName") %></h3>
                <p>
                    <asp:Label ID="AddressLabel" runat="server" Text='<%# Bind("Address") %>'></asp:Label><br />
                    <asp:Label ID="CityLabel" runat="server" Text='<%# Bind("City") %>'></asp:Label>,
                    <asp:Label ID="CountryLabel" runat="server" Text='<%# Bind("Country") %>'></asp:Label><br />
                    Phone:
                    <asp:Label ID="PhoneLabel" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                </p>
            </ItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="SuppliersDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetSupplierBySupplierID" TypeName="SuppliersBLL" UpdateMethod="UpdateSupplierAddress">
            <UpdateParameters>
                <asp:Parameter Name="supplierID" Type="Int32" />
                <asp:Parameter Name="address" Type="String" />
                <asp:Parameter Name="city" Type="String" />
                <asp:Parameter Name="country" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="supplierID" QueryStringField="SupplierID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="ProductsBySupplierDataSource" EmptyDataText="There are no products provided by this supplier..." EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" SortExpression="CategoryName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Price"
                    HtmlEncode="False" SortExpression="UnitPrice">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="UnitsInStock" HeaderText="Units In Stock" SortExpression="UnitsInStock">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ProductsBySupplierDataSource" runat="server" DataObjectTypeName="Northwind+ProductsRow"
            DeleteMethod="DeleteProduct" InsertMethod="AddProduct" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProductsBySupplierID" TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
            <DeleteParameters>
                <asp:Parameter Name="productID" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="supplierID" QueryStringField="SupplierID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

