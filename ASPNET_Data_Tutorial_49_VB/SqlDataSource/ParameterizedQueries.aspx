<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ParameterizedQueries.aspx.vb" Inherits="SqlDataSource_ParameterizedQueries" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Using Parameterized Queries</h2>
    <h4>
    </h4>
    <h3>
        Products $25.00 and Under</h3>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="Products25BucksAndUnderDataSource" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False"
                    ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Price" HtmlEncode="False" DataFormatString="{0:c}" SortExpression="UnitPrice" />
            </Columns>
        </asp:GridView>
        
        <asp:SqlDataSource ID="Products25BucksAndUnderDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
            SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice] FROM [Products] WHERE ([UnitPrice] <= @UnitPrice)">
            <SelectParameters>
                <asp:Parameter DefaultValue="25.00" Name="UnitPrice" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
     </p>
    <h3>
        List Products that Cost Less Than...</h3>
    <p>
        Maximum price: $<asp:TextBox ID="MaxPrice" runat="server" Columns="5"></asp:TextBox>&nbsp;
        <asp:Button ID="DisplayProductsLessThanButton" runat="server" Text="Display Matching Products" /></p>
    <p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ProductsFilteredByPriceDataSource" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Price" HtmlEncode="False" DataFormatString="{0:c}" SortExpression="UnitPrice" />
            </Columns>
        </asp:GridView>
        
        <asp:SqlDataSource ID="ProductsFilteredByPriceDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
            SelectCommand="SELECT ProductName, UnitPrice&#13;&#10;FROM Products&#13;&#10;WHERE UnitPrice <= @MaximumPrice OR @MaximumPrice = -1.0">
            <SelectParameters>
                <asp:ControlParameter ControlID="MaxPrice" Name="MaximumPrice" PropertyName="Text" DefaultValue="-1.0" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <h3>
        Products in the Beverages Category</h3>
    <p>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="BeverageProductsDataSource" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False"
                    ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID" />
                <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
                <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder" />
                <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="BeverageProductsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
            SelectCommand="GetProductsByCategory" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="CategoryID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <h3>
        Your Randomly Selected Category...</h3>
    <p>
        <asp:SqlDataSource ID="RandomCategoryDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
            SelectCommand="SELECT TOP 1 CategoryID, CategoryName&#13;&#10;FROM Categories&#13;&#10;ORDER BY NEWID()">
        </asp:SqlDataSource>
        <asp:Label ID="CategoryNameLabel" runat="server"></asp:Label>&nbsp;</p>
    <p>
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="ProductsByCategoryDataSource" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False"
                    ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID" />
                <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
                <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder" />
                <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="ProductsByCategoryDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
            SelectCommand="GetProductsByCategory" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter Name="CategoryID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>

