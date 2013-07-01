<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="OptimisticConcurrency.aspx.vb" Inherits="EditInsertDelete_OptimisticConcurrency" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Optimistic Concurrency</h2>
    <p>
        <asp:Label ID="DeleteConflictMessage" runat="server" Visible="False" EnableViewState="False" Text="The record you attempted to delete has been modified by another user since you last visited this page. Your delete was cancelled to allow you to review the other user's changes and determine if you want to continue deleting this record." CssClass="Warning"></asp:Label>
        <asp:Label ID="UpdateConflictMessage" runat="server" Visible="False" EnableViewState="False" Text="The record you attempted to update has been modified by another user since you started the update process. Your changes have been replaced with the current values. Please review the existing values and make any needed changes." CssClass="Warning"></asp:Label>
        <%--
        You can uncomment this Label control if you want to display a message if
        the user attempts to update a record that cannot be found. This might happen
        if one user deletes a record while another is in the midst of updating the same
        record. Upon the second user clicking Update, the Update command will not
        have any affected rows, thereby returning false from the UpdateProduct method.
        
        The ProductsOptimisticConcurrencyDataSource_Updated event handler checks
        to see if the ReturnValue is false and, if so, displays this Label...
        <asp:Label ID="UpdateLostMessage" runat="server" Visible="False" EnableViewState="False" Text="The record you attempted to update was not found. This was likely due to another user deleting the record you were updating while you were entering the record's updated value." CssClass="Warning"></asp:Label>--%>
    </p>
    <p>
        <asp:GridView ID="ProductsGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="ProductsOptimisticConcurrencyDataSource">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:TemplateField HeaderText="Product" SortExpression="ProductName">
                    <EditItemTemplate>
                        <asp:TextBox ID="EditProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EditProductName"
                            ErrorMessage="You must enter a product name.">*</asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category" SortExpression="CategoryName">
                    <EditItemTemplate>
                        <asp:DropDownList ID="EditCategoryID" runat="server" DataSourceID="CategoriesDataSource" AppendDataBoundItems="true"
                            DataTextField="CategoryName" DataValueField="CategoryID" SelectedValue='<%# Bind("CategoryID") %>'>
                            <asp:ListItem Value="">(None)</asp:ListItem>
                        </asp:DropDownList><asp:ObjectDataSource ID="CategoriesDataSource" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategories" TypeName="CategoriesBLL">
                        </asp:ObjectDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="DummyCategoryID" runat="server" Text='<%# Bind("CategoryID") %>' Visible="False"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier" SortExpression="SupplierName">
                    <EditItemTemplate>
                        <asp:DropDownList ID="EditSuppliersID" runat="server" DataSourceID="SuppliersDataSource" AppendDataBoundItems="true"
                            DataTextField="CompanyName" DataValueField="SupplierID" SelectedValue='<%# Bind("SupplierID") %>'>
                            <asp:ListItem Value="">(None)</asp:ListItem>
                        </asp:DropDownList><asp:ObjectDataSource ID="SuppliersDataSource" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetSuppliers" TypeName="SuppliersBLL">
                        </asp:ObjectDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="DummySupplierID" runat="server" Text='<%# Bind("SupplierID") %>' Visible="False"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit" SortExpression="QuantityPerUnit" />
                <asp:TemplateField HeaderText="Price" SortExpression="UnitPrice">
                    <EditItemTemplate>
                        <asp:TextBox ID="EditUnitPrice" runat="server" Text='<%# Bind("UnitPrice", "{0:N2}") %>' Columns="8"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="EditUnitPrice"
                            ErrorMessage="Unit price must be a valid currency value without the currency symbol and must have a value greater than or equal to zero."
                            Operator="GreaterThanEqual" Type="Currency" ValueToCompare="0">*</asp:CompareValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="DummyUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>' Visible="false"></asp:Label>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("UnitPrice", "{0:C}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Units In Stock" SortExpression="UnitsInStock">
                    <EditItemTemplate>
                        <asp:TextBox ID="EditUnitsInStock" runat="server" Text='<%# Bind("UnitsInStock") %>' Columns="6"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="EditUnitsInStock"
                            ErrorMessage="Units in stock must be a valid number greater than or equal to zero."
                            Operator="GreaterThanEqual" Type="Integer" ValueToCompare="0">*</asp:CompareValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("UnitsInStock", "{0:N0}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Units On Order" SortExpression="UnitsOnOrder">
                    <EditItemTemplate>
                        <asp:TextBox ID="EditUnitsOnOrder" runat="server" Text='<%# Bind("UnitsOnOrder") %>' Columns="6"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="EditUnitsOnOrder"
                            ErrorMessage="Units on order must be a valid numeric value greater than or equal to zero."
                            Operator="GreaterThanEqual" Type="Integer" ValueToCompare="0">*</asp:CompareValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("UnitsOnOrder", "{0:N0}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reorder Level" SortExpression="ReorderLevel">
                    <EditItemTemplate>
                        <asp:TextBox ID="EditReorderLevel" runat="server" Text='<%# Bind("ReorderLevel") %>' Columns="6"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="EditReorderLevel"
                            ErrorMessage="Reorder level must be a valid numeric value greater than or equal to zero."
                            Operator="GreaterThanEqual" Type="Integer" ValueToCompare="0">*</asp:CompareValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("ReorderLevel", "{0:N0}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ProductsOptimisticConcurrencyDataSource" runat="server"
            ConflictDetection="CompareAllValues" DeleteMethod="DeleteProduct" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProducts" TypeName="ProductsOptimisticConcurrencyBLL" UpdateMethod="UpdateProduct">
            <DeleteParameters>
                <asp:Parameter Name="original_productID" Type="Int32" />
                <asp:Parameter Name="original_productName" Type="String" />
                <asp:Parameter Name="original_supplierID" Type="Int32" />
                <asp:Parameter Name="original_categoryID" Type="Int32" />
                <asp:Parameter Name="original_quantityPerUnit" Type="String" />
                <asp:Parameter Name="original_unitPrice" Type="Decimal" />
                <asp:Parameter Name="original_unitsInStock" Type="Int16" />
                <asp:Parameter Name="original_unitsOnOrder" Type="Int16" />
                <asp:Parameter Name="original_reorderLevel" Type="Int16" />
                <asp:Parameter Name="original_discontinued" Type="Boolean" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="productName" Type="String" />
                <asp:Parameter Name="supplierID" Type="Int32" />
                <asp:Parameter Name="categoryID" Type="Int32" />
                <asp:Parameter Name="quantityPerUnit" Type="String" />
                <asp:Parameter Name="unitPrice" Type="Decimal" />
                <asp:Parameter Name="unitsInStock" Type="Int16" />
                <asp:Parameter Name="unitsOnOrder" Type="Int16" />
                <asp:Parameter Name="reorderLevel" Type="Int16" />
                <asp:Parameter Name="discontinued" Type="Boolean" />
                <asp:Parameter Name="productID" Type="Int32" />
                <asp:Parameter Name="original_productName" Type="String" />
                <asp:Parameter Name="original_supplierID" Type="Int32" />
                <asp:Parameter Name="original_categoryID" Type="Int32" />
                <asp:Parameter Name="original_quantityPerUnit" Type="String" />
                <asp:Parameter Name="original_unitPrice" Type="Decimal" />
                <asp:Parameter Name="original_unitsInStock" Type="Int16" />
                <asp:Parameter Name="original_unitsOnOrder" Type="Int16" />
                <asp:Parameter Name="original_reorderLevel" Type="Int16" />
                <asp:Parameter Name="original_discontinued" Type="Boolean" />
                <asp:Parameter Name="original_productID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>

        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" />
    
    </p>
</asp:Content>