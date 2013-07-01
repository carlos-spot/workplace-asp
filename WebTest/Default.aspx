<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ProductID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
                    SortExpression="ProductName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" 
                    SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" 
                    SortExpression="UnitPrice" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" 
                    SortExpression="UnitsInStock" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <ul>
            <li type="square">Hola Carlos</li>
            <li type="square">Hola Yuliana</li>
            <li type="dics">Hola Carlos</li>
            <li type="dics">Hola Carlos</li>
        </ul>
        <div runat="server" id="myDivList">
        alskdjfkla
        </div>
    </p>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
    
        SelectCommand="SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice], [UnitsInStock] FROM [Products] WHERE ([ProductName] LIKE '%' + @ProductName + '%')">
    <SelectParameters>
        <asp:Parameter DefaultValue="P" Name="ProductName" Type="String" />
    </SelectParameters>
</asp:SqlDataSource>

<asp:DetailsView ID="ManageProducts" runat="server" AllowPaging="True"
    AutoGenerateRows="False" DataKeyNames="ProductID"
    DataSourceID="ManageProductsDataSource" EnableViewState="False">
    <Fields>
        <asp:BoundField DataField="ProductID" HeaderText="ProductID"
            InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
        <asp:BoundField DataField="ProductName" HeaderText="ProductName"
            SortExpression="ProductName" />
        <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice"
            SortExpression="UnitPrice" />
        <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued"
            SortExpression="Discontinued" />
    </Fields>
</asp:DetailsView>
<asp:SqlDataSource ID="ManageProductsDataSource" runat="server"
    ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
    DeleteCommand=
        "DELETE FROM [Products] WHERE [ProductID] = @ProductID"
    InsertCommand=
        "INSERT INTO [Products] ([ProductName], [UnitPrice], [Discontinued])
         VALUES (@ProductName, @UnitPrice, @Discontinued)"
    SelectCommand=
        "SELECT [ProductID], [ProductName], [UnitPrice], [Discontinued]
         FROM [Products]"
    UpdateCommand=
        "UPDATE [Products] SET [ProductName] = @ProductName,
         [UnitPrice] = @UnitPrice, [Discontinued] = @Discontinued
         WHERE [ProductID] = @ProductID">
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
<h2>
        The Basics of Editing, Inserting, and Deleting</h2>
        
    <h3>Editing, Inserting, and Deleting Data from a FormView
    <asp:ObjectDataSource 
            ID="ObjectDataSource1" runat="server" SelectMethod="GetProducts" TypeName="ProductsBLL">
            <%--ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteProduct"
            InsertMethod="AddProduct" SelectMethod="GetProducts"
            TypeName="ProductsBLL" UpdateMethod="UpdateProduct" 
        >--%>
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
    </h3>
    <p>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="ProductID" DataSourceID="ObjectDataSource1" AllowPaging="True">
            <EditItemTemplate>
                ProductID:
                <asp:Label ID="ProductIDLabel1" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label><br />
                ProductName:
                <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>'>
                </asp:TextBox><br />
                SupplierID:
                <asp:TextBox ID="SupplierIDTextBox" runat="server" Text='<%# Bind("SupplierID") %>'>
                </asp:TextBox><br />
                CategoryID:
                <asp:TextBox ID="CategoryIDTextBox" runat="server" Text='<%# Bind("CategoryID") %>'>
                </asp:TextBox><br />
                QuantityPerUnit:
                <asp:TextBox ID="QuantityPerUnitTextBox" runat="server" Text='<%# Bind("QuantityPerUnit") %>'>
                </asp:TextBox><br />
                UnitPrice:
                <asp:TextBox ID="UnitPriceTextBox" runat="server" Text='<%# Bind("UnitPrice") %>'>
                </asp:TextBox><br />
                UnitsInStock:
                <asp:TextBox ID="UnitsInStockTextBox" runat="server" Text='<%# Bind("UnitsInStock") %>'>
                </asp:TextBox><br />
                UnitsOnOrder:
                <asp:TextBox ID="UnitsOnOrderTextBox" runat="server" Text='<%# Bind("UnitsOnOrder") %>'>
                </asp:TextBox><br />
                ReorderLevel:
                <asp:TextBox ID="ReorderLevelTextBox" runat="server" Text='<%# Bind("ReorderLevel") %>'>
                </asp:TextBox><br />
                Discontinued:
                <asp:CheckBox ID="DiscontinuedCheckBox" runat="server" Checked='<%# Bind("Discontinued") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="Update">
                </asp:LinkButton>
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel">
                </asp:LinkButton>
            </EditItemTemplate>
            <InsertItemTemplate>
                ProductName:
                <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>'>
                </asp:TextBox><br />
                SupplierID:
                <asp:TextBox ID="SupplierIDTextBox" runat="server" Text='<%# Bind("SupplierID") %>'>
                </asp:TextBox><br />
                CategoryID:
                <asp:TextBox ID="CategoryIDTextBox" runat="server" Text='<%# Bind("CategoryID") %>'>
                </asp:TextBox><br />
                QuantityPerUnit:
                <asp:TextBox ID="QuantityPerUnitTextBox" runat="server" Text='<%# Bind("QuantityPerUnit") %>'>
                </asp:TextBox><br />
                UnitPrice:
                <asp:TextBox ID="UnitPriceTextBox" runat="server" Text='<%# Bind("UnitPrice") %>'>
                </asp:TextBox><br />
                UnitsInStock:
                <asp:TextBox ID="UnitsInStockTextBox" runat="server" Text='<%# Bind("UnitsInStock") %>'>
                </asp:TextBox><br />
                UnitsOnOrder:
                <asp:TextBox ID="UnitsOnOrderTextBox" runat="server" Text='<%# Bind("UnitsOnOrder") %>'>
                </asp:TextBox><br />
                ReorderLevel:
                <asp:TextBox ID="ReorderLevelTextBox" runat="server" Text='<%# Bind("ReorderLevel") %>'>
                </asp:TextBox><br />
                Discontinued:
                <asp:CheckBox ID="DiscontinuedCheckBox" runat="server" Checked='<%# Bind("Discontinued") %>' /><br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                    Text="Insert">
                </asp:LinkButton>
                <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel">
                </asp:LinkButton>
            </InsertItemTemplate>
            <ItemTemplate>
                ProductID:
                <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label><br />
                ProductName:
                <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Bind("ProductName") %>'>
                </asp:Label><br />
                SupplierID:
                <asp:Label ID="SupplierIDLabel" runat="server" Text='<%# Bind("SupplierID") %>'>
                </asp:Label><br />
                CategoryID:
                <asp:Label ID="CategoryIDLabel" runat="server" Text='<%# Bind("CategoryID") %>'>
                </asp:Label><br />
                QuantityPerUnit:
                <asp:Label ID="QuantityPerUnitLabel" runat="server" Text='<%# Bind("QuantityPerUnit") %>'>
                </asp:Label><br />
                UnitPrice:
                <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:Label><br />
                UnitsInStock:
                <asp:Label ID="UnitsInStockLabel" runat="server" Text='<%# Bind("UnitsInStock") %>'>
                </asp:Label><br />
                UnitsOnOrder:
                <asp:Label ID="UnitsOnOrderLabel" runat="server" Text='<%# Bind("UnitsOnOrder") %>'>
                </asp:Label><br />
                ReorderLevel:
                <asp:Label ID="ReorderLevelLabel" runat="server" Text='<%# Bind("ReorderLevel") %>'>
                </asp:Label><br />
                Discontinued:
                <asp:CheckBox ID="DiscontinuedCheckBox" runat="server" Checked='<%# Bind("Discontinued") %>'
                    Enabled="false" /><br />
                CategoryName:
                <asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Bind("CategoryName") %>'>
                </asp:Label><br />
                SupplierName:
                <asp:Label ID="SupplierNameLabel" runat="server" Text='<%# Bind("SupplierName") %>'>
                </asp:Label><br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton>
                <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton>
                <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:FormView>
        &nbsp;</p>
    <h3>
        Editing, Inserting, and Deleting Data from a DetailsView</h3>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1" AllowPaging="True">
            <Fields>
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
                <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" ReadOnly="True"
                    SortExpression="CategoryName" InsertVisible="False" />
                <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" ReadOnly="True"
                    SortExpression="SupplierName" InsertVisible="False" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
        &nbsp;</p>
    <h3>
        Editing and Deleting Data from a GridView</h3>
    <p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
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
                <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" ReadOnly="True"
                    SortExpression="CategoryName" />
                <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" ReadOnly="True"
                    SortExpression="SupplierName" />
            </Columns>
        </asp:GridView>
        &nbsp;&nbsp;</p>
</asp:Content>
