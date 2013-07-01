<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="SortParameter.aspx.vb" Inherits="PagingAndSorting_SortParameter" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Efficiently Paging <i>and Sorting</i> Through Large Amounts of Data</h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" SortExpression="CategoryName" />
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier" SortExpression="CompanyName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Price"
                    HtmlEncode="False" SortExpression="UnitPrice" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProductsPagedAndSorted" TypeName="ProductsBLL" EnablePaging="True" SelectCountMethod="TotalNumberOfProducts" SortParameterName="sortExpression">
        </asp:ObjectDataSource>
    </p>
</asp:Content>