<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="UIValidation.aspx.vb" Inherits="EditInsertDelete_UIValidation" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Exploring the Data Modification Events</h2>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1" DefaultMode="Insert">
            <Fields>
                <asp:TemplateField HeaderText="ProductName" SortExpression="ProductName">
                    <InsertItemTemplate>
                        <asp:TextBox ID="InsertProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="InsertProductName"
                            ErrorMessage="You must provide the product's name" ValidationGroup="InsertValidationControls">*</asp:RequiredFieldValidator>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UnitPrice" SortExpression="UnitPrice">
                    <InsertItemTemplate>
                        <asp:TextBox ID="InsertUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>' Columns="6"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="InsertUnitPrice"
                            ErrorMessage="You must provide the product's price" ValidationGroup="InsertValidationControls">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="InsertUnitPrice"
                            ErrorMessage="The price must be greater than or equal to zero and cannot include the currency symbol" Operator="GreaterThanEqual"
                            Type="Currency" ValueToCompare="0" ValidationGroup="InsertValidationControls">*</asp:CompareValidator>
                    </InsertItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowInsertButton="True" ValidationGroup="InsertValidationControls" />
            </Fields>
        </asp:DetailsView>
     </p>
     <p>
        <asp:Label ID="MustProvideUnitPriceMessage" runat="server" CssClass="Warning" Text="You must provide a price for the product."></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" ValidationGroup="EditValidationControls" />
                <asp:TemplateField HeaderText="ProductName" SortExpression="ProductName">
                    <EditItemTemplate>
                        <asp:TextBox ID="EditProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EditProductName"
                            ErrorMessage="You must provide the product's name" ValidationGroup="EditValidationControls">*</asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UnitPrice" SortExpression="UnitPrice">
                    <EditItemTemplate>
                        <asp:TextBox ID="EditUnitPrice" runat="server" Text='<%# Bind("UnitPrice", "{0:n2}") %>' Columns="6"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="EditUnitPrice"
                            ErrorMessage="The price must be greater than or equal to zero and cannot include the currency symbol"
                            Operator="GreaterThanEqual" Type="Currency" ValueToCompare="0" ValidationGroup="EditValidationControls">*</asp:CompareValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("UnitPrice", "{0:c}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetProducts"
            TypeName="ProductsBLL" UpdateMethod="UpdateProduct" InsertMethod="AddProduct">
            <UpdateParameters>
                <asp:Parameter Name="productName" Type="String" />
                <asp:Parameter Name="unitPrice" Type="Decimal" />
                <asp:Parameter Name="productID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="productName" Type="String" />
                <asp:Parameter Name="supplierID" Type="Int32" />
                <asp:Parameter Name="categoryID" Type="Int32" />
                <asp:Parameter Name="quantityPerUnit" Type="String" />
                <asp:Parameter Name="unitPrice" Type="Decimal" />
                <asp:Parameter Name="unitsInStock" Type="Int16" />
                <asp:Parameter Name="unitsOnOrder" Type="Int16" />
                <asp:Parameter Name="reorderLevel" Type="Int16" />
                <asp:Parameter Name="discontinued" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
             ShowSummary="False" ValidationGroup="EditValidationControls" />
         <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
             ShowSummary="False" ValidationGroup="InsertValidationControls" />
    </p>
</asp:Content>