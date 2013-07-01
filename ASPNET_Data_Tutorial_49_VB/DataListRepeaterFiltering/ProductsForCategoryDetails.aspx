<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ProductsForCategoryDetails.aspx.vb" Inherits="DataListRepeaterFiltering_ProductsForCategoryDetails" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Products Belonging to the Selected Category</h2>
    <p>
        <asp:HyperLink ID="lnkBackToCategories" runat="server" NavigateUrl="~/DataListRepeaterFiltering/CategoryListMaster.aspx"><< Return to List of Categories...</asp:HyperLink>
    </p>
    <hr />
    <p>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="CategoryID" DataSourceID="CategoryDataSource" EnableViewState="False" Width="100%"> 
            <ItemTemplate>                
                <h3><asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Bind("CategoryName") %>'>
                </asp:Label></h3>
                <p>
                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Bind("Description") %>'>
                    </asp:Label>
                </p>
            </ItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="CategoryDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCategoryByCategoryID" TypeName="CategoriesBLL">
            <SelectParameters>
                <asp:QueryStringParameter Name="categoryID" QueryStringField="CategoryID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <hr />
    <p>
        <asp:DataList ID="ProductsInCategory" runat="server" DataKeyField="ProductID" DataSourceID="ProductsInCategoryDataSource" RepeatColumns="2" EnableViewState="False">
            <ItemTemplate>
                <h5><%# Eval("ProductName") %></h5>
                <p>
                    Supplied by <%# Eval("SupplierName") %><br />
                    <%# Eval("UnitPrice", "{0:C}") %>
                </p>
            </ItemTemplate>
        </asp:DataList><asp:ObjectDataSource ID="ProductsInCategoryDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsByCategoryID"
            TypeName="ProductsBLL">
            <SelectParameters>
                <asp:QueryStringParameter Name="categoryID" QueryStringField="CategoryID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Label ID="NoProductsMessage" runat="server" Text="There are no products for the selected category..."></asp:Label>
    </p>
</asp:Content>

