<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="SimplePagingSorting.aspx.vb" Inherits="PagingAndSorting_SimplePagingSorting" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Simple Paging &amp; Sorting</h2>
    <p>
        <asp:Label ID="PagingInformation" runat="server"></asp:Label>
    </p>
    <p>
        Jump directly to a page:
        <asp:DropDownList ID="PageList" runat="server" AutoPostBack="True">
        </asp:DropDownList></p>
    <p>
        <asp:Button ID="SortPriceDescending" runat="server" Text="Sort by Price" />
    </p>
    <p>
        <asp:GridView ID="Products" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1" EnableViewState="False" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True"
                    SortExpression="CategoryName" />
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier" ReadOnly="True"
                    SortExpression="SupplierName" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Price" DataFormatString="{0:C}" HtmlEncode="False" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
            SelectMethod="GetProducts" TypeName="ProductsBLL" DeleteMethod="DeleteProduct">
            <DeleteParameters>
                <asp:Parameter Name="productID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>