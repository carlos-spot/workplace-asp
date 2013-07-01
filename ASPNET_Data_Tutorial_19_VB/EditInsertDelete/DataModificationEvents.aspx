<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="DataModificationEvents.aspx.vb" Inherits="EditInsertDelete_DataModificationEvents" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Exploring the Data Modification Events</h2>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1" DefaultMode="Insert">
            <Fields>
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                <asp:CommandField ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
     </p>
     <p>
        <asp:Label ID="MustProvideUnitPriceMessage" runat="server" CssClass="Warning" Text="You must provide a price for the product."></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" ApplyFormatInEditMode="True" DataFormatString="{0:c}" HtmlEncode="False" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetProducts"
            TypeName="ProductsBLL" UpdateMethod="UpdateProduct" InsertMethod="AddProduct">
            <UpdateParameters>
                <asp:Parameter Name="productName" Type="String" />
                <asp:Parameter Name="unitPrice" Type="Decimal" />
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
</asp:Content>