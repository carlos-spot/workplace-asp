<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Basics.aspx.vb" Inherits="DataListRepeaterBasics_Basics" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>DataList and Repeater Basics</h2>
    <p>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource2" EnableViewState="False">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0" style="border: solid 1px black;">
                    <tr>
                        <th class="HeaderStyle">Product Categories</th>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="4" cellspacing="0">
                                <tr>
            </HeaderTemplate>
            <ItemTemplate>
                                    <td class="RowStyle"><%# Eval("CategoryName") %></td>
            </ItemTemplate>
            <AlternatingItemTemplate>
                                    <td class="AlternatingRowStyle"><%# Eval("CategoryName") %></td>
            </AlternatingItemTemplate>
            <FooterTemplate>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCategories" TypeName="CategoriesBLL"></asp:ObjectDataSource>
        <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID" DataSourceID="ObjectDataSource1" EnableViewState="False">
            <HeaderTemplate><h3>Product Information</h3></HeaderTemplate>
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
        </asp:DataList>&nbsp;
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProducts" TypeName="ProductsBLL"></asp:ObjectDataSource>
    </p>
</asp:Content>

