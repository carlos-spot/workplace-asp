<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CustomSortingUI.aspx.vb" Inherits="PagingAndSorting_CustomSortingUI" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Customizing the Sorting User Interface</h2>
    <p>
        <asp:GridView ID="ProductList" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            DataKeyNames="ProductID" DataSourceID="ObjectDataSource1" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" SortExpression="CategoryName" />
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier" ReadOnly="True" SortExpression="SupplierName" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:C}" HeaderText="Price"
                    HtmlEncode="False" SortExpression="UnitPrice" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProducts" TypeName="ProductsBLL"></asp:ObjectDataSource>
    </p>
</asp:Content>