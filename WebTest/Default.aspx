<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        <%--Definicion del SQLDataSource que va a tener el GridView2 --%>
        <asp:SqlDataSource ID="ProductsDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice] FROM [Products]"
            DeleteCommand="DELETE FROM Products WHERE ProductID = @ProductID">
            <DeleteParameters>
                <asp:Parameter Name="ProductID" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <%--Grid que lista todos los productos y muestra un boton de borrar--%>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="ProductsDataSource" EnableViewState="False">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Price" HtmlEncode="False" SortExpression="UnitPrice" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        
        <%--Definicion del SQLDataSource que va a tener el DetailsView 'ManageProductsDataSource' --%>
        <asp:SqlDataSource ID="ManageProductsDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = @ProductID" 
            InsertCommand="INSERT INTO [Products] ([ProductName], [UnitPrice], [Discontinued])VALUES (@ProductName, @UnitPrice, @Discontinued)"
            SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice], [Discontinued] FROM [Products]"
            UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName,[UnitPrice] = @UnitPrice, [Discontinued] = @Discontinued WHERE [ProductID] = @ProductID">
            <DeleteParameters>
                <asp:Parameter Name="ProductID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="Discontinued" Type="Boolean" />
                <asp:Parameter Name="ProductID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="UnitPrice" Type="Decimal" />
                <asp:Parameter Name="Discontinued" Type="Boolean" />
            </InsertParameters>
        </asp:SqlDataSource>

        <%--DetailsView que muestra la informacion de un producto a la vez y permite actualizar y registrar uno nuevo--%>
        <asp:DetailsView ID="ManageProducts" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="ProductID" DataSourceID="ManageProductsDataSource" EnableViewState="False">
            <Fields>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </p>
</asp:Content>
