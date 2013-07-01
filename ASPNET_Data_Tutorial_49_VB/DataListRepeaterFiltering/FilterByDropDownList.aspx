<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="FilterByDropDownList.aspx.vb" Inherits="DataListRepeaterFiltering_FilterByDropDownList" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Master/Detail Filtering With a DropDownList</h2>
    <p>
        Select a category:
        <asp:DropDownList ID="Categories" runat="server" DataSourceID="CategoriesDataSource"
            DataTextField="CategoryName" DataValueField="CategoryID" AutoPostBack="True" EnableViewState="False" AppendDataBoundItems="True">
            <asp:ListItem Value="0">-- Choose a Category --</asp:ListItem>
        </asp:DropDownList><asp:ObjectDataSource ID="CategoriesDataSource" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategories" TypeName="CategoriesBLL">
        </asp:ObjectDataSource>
   </p>
   <p>
        <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID" DataSourceID="ProductsByCategoryDataSource" EnableViewState="False">
            <ItemTemplate>
                <h4><asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' /></h4>
                <table border="0">
                    <tr>
                        <td class="ProductPropertyLabel">Category:</td>
                        <td><asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Eval("CategoryName") %>' /></td>
                        <td class="ProductPropertyLabel">Supplier:</td>
                        <td><asp:Label ID="SupplierNameLabel" runat="server" Text='<%# Eval("SupplierName") %>' /></td>
                    </tr>
                    <tr>
                        <td class="ProductPropertyLabel">Qty/Unit:</td>
                        <td><asp:Label ID="QuantityPerUnitLabel" runat="server" Text='<%# Eval("QuantityPerUnit") %>' /></td>
                        <td class="ProductPropertyLabel">Price:</td>
                        <td><asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice", "{0:C}") %>' /></td>
                    </tr>
                </table>
            </ItemTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:DataList><asp:ObjectDataSource ID="ProductsByCategoryDataSource" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductsByCategoryID"
            TypeName="ProductsBLL">
            <SelectParameters>
                <asp:ControlParameter ControlID="Categories" Name="categoryID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

