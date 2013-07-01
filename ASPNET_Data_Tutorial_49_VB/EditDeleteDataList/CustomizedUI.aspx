<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CustomizedUI.aspx.vb" Inherits="EditDeleteDataList_CustomizedUI" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        A Customized Editing Interface</h2>
    <p>
        <asp:DataList ID="Products" runat="server" DataKeyField="ProductID" DataSourceID="ProductsDataSource">
            <ItemTemplate>
                <h4><asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' /></h4>
                <table border="0">
                    <tr>
                        <td class="ProductPropertyLabel">Category:</td>
                        <td class="ProductPropertyValue"><asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Eval("CategoryName") %>' /></td>
                        <td class="ProductPropertyLabel">Supplier:</td>
                        <td class="ProductPropertyValue"><asp:Label ID="SupplierNameLabel" runat="server" Text='<%# Eval("SupplierName") %>' /></td>
                    </tr>
                    <tr>
                        <td class="ProductPropertyLabel">Discontinued:</td>
                        <td class="ProductPropertyValue"><asp:Label ID="DiscontinuedLabel" runat="server" Text='<%# Eval("Discontinued") %>' /></td>
                        <td class="ProductPropertyLabel">Price:</td>
                        <td class="ProductPropertyValue"><asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice", "{0:C}") %>' /></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button runat="Server" ID="EditButton" Text="Edit" CommandName="Edit" />
                        </td>
                    </tr>
                </table>
                <br />
            </ItemTemplate>
            <EditItemTemplate>
                <h4><asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' /></h4>
                <table border="0">
                    <tr>
                        <td class="ProductPropertyLabel">Name:</td>
                        <td colspan="3" class="ProductPropertyValue"><asp:TextBox runat="server" ID="ProductName" Width="90%" Text='<%# Eval("ProductName") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ProductName"
                                ErrorMessage="You must enter a name for the product.">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td class="ProductPropertyLabel">Category:</td>
                        <td class="ProductPropertyValue">
                            <asp:DropDownList ID="Categories" runat="server" DataSourceID="CategoriesDataSource"
                                DataTextField="CategoryName" DataValueField="CategoryID" SelectedValue='<%# Eval("CategoryID") %>' AppendDataBoundItems="True">
                                <asp:ListItem Value="" Selected="True">(None)</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="ProductPropertyLabel">Supplier:</td>
                        <td class="ProductPropertyValue">
                            <asp:DropDownList ID="Suppliers" runat="server" DataSourceID="SuppliersDataSource"
                                DataTextField="CompanyName" DataValueField="SupplierID" SelectedValue='<%# Eval("SupplierID") %>' AppendDataBoundItems="True">
                                <asp:ListItem Value="" Selected="True">(None)</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="ProductPropertyLabel">Discontinued:</td>
                        <td class="ProductPropertyValue"><asp:CheckBox runat="server" id="Discontinued" Checked='<%# Eval("Discontinued") %>' /></td>
                        <td class="ProductPropertyLabel">Price:</td>
                        <td class="ProductPropertyValue"><asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice", "{0:C}") %>' /></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button runat="Server" ID="UpdateButton" Text="Update" CommandName="Update" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button runat="Server" ID="CancelButton" Text="Cancel" CommandName="Cancel" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
                <br />
                
                <asp:ObjectDataSource ID="CategoriesDataSource" runat="server"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategories" TypeName="CategoriesBLL">
                </asp:ObjectDataSource>

                <asp:ObjectDataSource ID="SuppliersDataSource" runat="server"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetSuppliers" TypeName="SuppliersBLL">
                </asp:ObjectDataSource>
            </EditItemTemplate>
        </asp:DataList>
        
        <asp:ObjectDataSource ID="ProductsDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProducts" TypeName="ProductsBLL">
        </asp:ObjectDataSource>
    </p>
</asp:Content>

