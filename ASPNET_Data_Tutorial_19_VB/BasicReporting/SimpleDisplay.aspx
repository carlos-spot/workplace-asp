<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="SimpleDisplay.aspx.vb" Inherits="BasicReporting_SimpleDisplay" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Northwind+ProductsRow"
        DeleteMethod="DeleteProduct" InsertMethod="AddProduct" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetProducts" TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
        <DeleteParameters>
            <asp:Parameter Name="productID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <br />
    <h3>
        FormView Example</h3>
    <p>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" EnableViewState="False">
            <ItemTemplate>
                <h4><%# Eval("ProductName") %> (<%# Eval("UnitPrice", "{0:c}") %>)</h4>
                Category: <%# Eval("CategoryName") %>; Supplier: <%# Eval("SupplierName") %>
            </ItemTemplate>
        </asp:FormView>
    </p>
    <h3>
        DetailsView Examle</h3>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1" AllowPaging="True" EnableViewState="False">
            <Fields>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" SortExpression="CategoryName" />
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier" ReadOnly="True" SortExpression="SupplierName" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Price"
                    HtmlEncode="False" SortExpression="UnitPrice">
                </asp:BoundField>
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
            </Fields>
        </asp:DetailsView>
        &nbsp;</p>
    <h3>
        GridView Example</h3>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            DataKeyNames="ProductID" DataSourceID="ObjectDataSource1" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" SortExpression="CategoryName" />
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier" ReadOnly="True" SortExpression="SupplierName" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Price"
                    HtmlEncode="False" SortExpression="UnitPrice">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:CheckBoxField>
            </Columns>
        </asp:GridView>
        &nbsp;</p>
</asp:Content>

