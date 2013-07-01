<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CategoriesAndProducts.aspx.vb" Inherits="DataListRepeaterFiltering_CategoriesAndProducts" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Categories &amp; Products Master/Detail on One Page</h2>
    <div class="FloatLeft">
        <asp:Repeater ID="Categories" runat="server" DataSourceID="CategoriesDataSource" OnItemCommand="Categories_ItemCommand">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            
            <ItemTemplate>
                <li><asp:LinkButton CommandName="ListProducts" CommandArgument='<%# Eval("CategoryID") %>' runat="server" ID="ViewCategory" Text='<%# String.Format("{0} ({1:N0})", Eval("CategoryName"), Eval("NumberOfProducts")) %>'></asp:LinkButton></li>
            </ItemTemplate>
            
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="CategoriesDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCategoriesAndNumberOfProducts" TypeName="CategoriesBLL"></asp:ObjectDataSource>
        &nbsp;
    </div>
    <div>
        <asp:DataList ID="CategoryProducts" runat="server" DataKeyField="ProductID" DataSourceID="CategoryProductsDataSource" RepeatColumns="2" EnableViewState="False">
            <ItemTemplate>
                <h5><%# Eval("ProductName") %></h5>
                <p>
                    Supplied by <%# Eval("SupplierName") %><br />
                    <%# Eval("UnitPrice", "{0:C}") %>
                </p>
            </ItemTemplate>
        </asp:DataList><asp:ObjectDataSource ID="CategoryProductsDataSource" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsByCategoryID"
            TypeName="ProductsBLL">
            <SelectParameters>
                <asp:Parameter Name="categoryID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>

