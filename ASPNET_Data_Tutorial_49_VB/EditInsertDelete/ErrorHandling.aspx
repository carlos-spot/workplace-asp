<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ErrorHandling.aspx.vb" Inherits="EditInsertDelete_ErrorHandling" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Gracefully Handling BLL- and DAL-Level Exceptions</h2>
    <p>
        <asp:Label ID="ExceptionDetails" runat="server" CssClass="Warning"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit" ReadOnly="True"
                    SortExpression="QuantityPerUnit" />
                <asp:BoundField ApplyFormatInEditMode="True" DataField="UnitPrice" DataFormatString="{0:c}"
                    HeaderText="Price" HtmlEncode="False" SortExpression="UnitPrice">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="UnitsInStock" HeaderText="Units In Stock" SortExpression="UnitsInStock">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetProducts" TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
            <UpdateParameters>
                <asp:Parameter Name="productName" Type="String" />
                <asp:Parameter Name="unitPrice" Type="Decimal" />
                <asp:Parameter Name="unitsInStock" Type="Int16" />
                <asp:Parameter Name="productID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>