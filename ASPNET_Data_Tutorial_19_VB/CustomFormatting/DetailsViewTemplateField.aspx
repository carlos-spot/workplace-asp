<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="DetailsViewTemplateField.aspx.vb" Inherits="CustomFormatting_DetailsViewTemplateField" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Custom Formatting with a TemplateField</h2>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1" AllowPaging="True" EnableViewState="False">
            <Fields>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" SortExpression="CategoryName" />
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier" ReadOnly="True" SortExpression="SupplierName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit" SortExpression="QuantityPerUnit" />
                <asp:TemplateField HeaderText="Price and Inventory">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("UnitPrice", "{0:C}") %>'></asp:Label>
                        <br />
                        <strong>
                        (In Stock / On Order: </strong>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("UnitsInStock") %>'></asp:Label>
                        <strong>/</strong>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("UnitsOnOrder") %>'></asp:Label><strong>)</strong>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Discontinued" SortExpression="Discontinued">
                    <ItemTemplate>
                        <%#DisplayDiscontinuedAsYESorNO(CType(Eval("Discontinued"), Boolean))%>
                    </ItemTemplate>
                </asp:TemplateField>
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
</asp:Content>

