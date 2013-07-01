<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CustomizedUI.aspx.vb" Inherits="EditInsertDelete_CustomizedUI" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Using TemplateFields for a Customized Data Modification Interface</h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:TemplateField HeaderText="Category" SortExpression="CategoryName">
                    <EditItemTemplate>
                        <asp:DropDownList ID="Categories" runat="server" DataSourceID="CategoriesDataSource" DataTextField="CategoryName" DataValueField="CategoryID" SelectedValue='<%# Bind("CategoryID") %>' AppendDataBoundItems="True">
                            <asp:ListItem Value="">(None)</asp:ListItem>
                        </asp:DropDownList><asp:ObjectDataSource ID="CategoriesDataSource" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetCategories" TypeName="CategoriesBLL">
                        </asp:ObjectDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Supplier" SortExpression="SupplierName">
                    <EditItemTemplate>
                        <asp:DropDownList ID="Suppliers" runat="server" DataSourceID="SuppliersDataSource"
                            DataTextField="CompanyName" DataValueField="SupplierID" SelectedValue='<%# Bind("SupplierID") %>' AppendDataBoundItems="True">
                                <asp:ListItem Value="">(None)</asp:ListItem>
                        </asp:DropDownList><asp:ObjectDataSource ID="SuppliersDataSource" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetSuppliers" TypeName="SuppliersBLL">
                        </asp:ObjectDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("SupplierName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Discontinued" SortExpression="Discontinued">
                    <ItemTemplate>
                        <asp:RadioButtonList ID="DiscontinuedChoice" runat="server" Enabled="False" SelectedValue='<%# Bind("Discontinued") %>'>
                            <asp:ListItem Value="False">Active</asp:ListItem>
                            <asp:ListItem Value="True">Discontinued</asp:ListItem>
                        </asp:RadioButtonList>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:RadioButtonList ID="DiscontinuedChoice" runat="server" SelectedValue='<%# Bind("Discontinued") %>'>
                            <asp:ListItem Value="False">Active</asp:ListItem>
                            <asp:ListItem Value="True">Discontinued</asp:ListItem>
                        </asp:RadioButtonList>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
            SelectMethod="GetProducts" TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
            <UpdateParameters>
                <asp:Parameter Name="productName" Type="String" />
                <asp:Parameter Name="categoryID" Type="Int32" />
                <asp:Parameter Name="supplierID" Type="Int32" />
                <asp:Parameter Name="discontinued" Type="Boolean" />
                <asp:Parameter Name="productID" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>