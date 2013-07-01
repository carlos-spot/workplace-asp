<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Basics.aspx.vb" Inherits="EditInsertDelete_Basics" title="Untitled Page" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        The Basics of Editing, Inserting, and Deleting</h2>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteProduct"
            InsertMethod="AddProduct" SelectMethod="GetProducts"
            TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
            <DeleteParameters>
                <asp:Parameter Name="productID" Type="Int32" />
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
    <h3>Editing, Inserting, and Deleting Data from a FormView</h3>
    <p>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="ProductID" DataSourceID="ObjectDataSource1" AllowPaging="True">
            <EditItemTemplate>
                ProductID:
                <asp:Label ID="ProductIDLabel1" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label><br />
                ProductName:
                <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>'>
                </asp:TextBox><br />
                SupplierID:
                <asp:TextBox ID="SupplierIDTextBox" runat="server" Text='<%# Bind("SupplierID") %>'>
                </asp:TextBox><br />
                CategoryID:
                <asp:TextBox ID="CategoryIDTextBox" runat="server" Text='<%# Bind("CategoryID") %>'>
                </asp:TextBox><br />
                QuantityPerUnit:
                <asp:TextBox ID="QuantityPerUnitTextBox" runat="server" Text='<%# Bind("QuantityPerUnit") %>'>
                </asp:TextBox><br />
                UnitPrice:
                <asp:TextBox ID="UnitPriceTextBox" runat="server" Text='<%# Bind("UnitPrice") %>'>
                </asp:TextBox><br />
                UnitsInStock:
                <asp:TextBox ID="UnitsInStockTextBox" runat="server" Text='<%# Bind("UnitsInStock") %>'>
                </asp:TextBox><br />
                UnitsOnOrder:
                <asp:TextBox ID="UnitsOnOrderTextBox" runat="server" Text='<%# Bind("UnitsOnOrder") %>'>
                </asp:TextBox><br />
                ReorderLevel:
                <asp:TextBox ID="ReorderLevelTextBox" runat="server" Text='<%# Bind("ReorderLevel") %>'>
                </asp:TextBox><br />
                Discontinued:
                <asp:CheckBox ID="DiscontinuedCheckBox" runat="server" Checked='<%# Bind("Discontinued") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                    Text="Update">
                </asp:LinkButton>
                <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel">
                </asp:LinkButton>
            </EditItemTemplate>
            <InsertItemTemplate>
                ProductName:
                <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>'>
                </asp:TextBox><br />
                SupplierID:
                <asp:TextBox ID="SupplierIDTextBox" runat="server" Text='<%# Bind("SupplierID") %>'>
                </asp:TextBox><br />
                CategoryID:
                <asp:TextBox ID="CategoryIDTextBox" runat="server" Text='<%# Bind("CategoryID") %>'>
                </asp:TextBox><br />
                QuantityPerUnit:
                <asp:TextBox ID="QuantityPerUnitTextBox" runat="server" Text='<%# Bind("QuantityPerUnit") %>'>
                </asp:TextBox><br />
                UnitPrice:
                <asp:TextBox ID="UnitPriceTextBox" runat="server" Text='<%# Bind("UnitPrice") %>'>
                </asp:TextBox><br />
                UnitsInStock:
                <asp:TextBox ID="UnitsInStockTextBox" runat="server" Text='<%# Bind("UnitsInStock") %>'>
                </asp:TextBox><br />
                UnitsOnOrder:
                <asp:TextBox ID="UnitsOnOrderTextBox" runat="server" Text='<%# Bind("UnitsOnOrder") %>'>
                </asp:TextBox><br />
                ReorderLevel:
                <asp:TextBox ID="ReorderLevelTextBox" runat="server" Text='<%# Bind("ReorderLevel") %>'>
                </asp:TextBox><br />
                Discontinued:
                <asp:CheckBox ID="DiscontinuedCheckBox" runat="server" Checked='<%# Bind("Discontinued") %>' /><br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                    Text="Insert">
                </asp:LinkButton>
                <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                    Text="Cancel">
                </asp:LinkButton>
            </InsertItemTemplate>
            <ItemTemplate>
                ProductID:
                <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label><br />
                ProductName:
                <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Bind("ProductName") %>'>
                </asp:Label><br />
                SupplierID:
                <asp:Label ID="SupplierIDLabel" runat="server" Text='<%# Bind("SupplierID") %>'>
                </asp:Label><br />
                CategoryID:
                <asp:Label ID="CategoryIDLabel" runat="server" Text='<%# Bind("CategoryID") %>'>
                </asp:Label><br />
                QuantityPerUnit:
                <asp:Label ID="QuantityPerUnitLabel" runat="server" Text='<%# Bind("QuantityPerUnit") %>'>
                </asp:Label><br />
                UnitPrice:
                <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:Label><br />
                UnitsInStock:
                <asp:Label ID="UnitsInStockLabel" runat="server" Text='<%# Bind("UnitsInStock") %>'>
                </asp:Label><br />
                UnitsOnOrder:
                <asp:Label ID="UnitsOnOrderLabel" runat="server" Text='<%# Bind("UnitsOnOrder") %>'>
                </asp:Label><br />
                ReorderLevel:
                <asp:Label ID="ReorderLevelLabel" runat="server" Text='<%# Bind("ReorderLevel") %>'>
                </asp:Label><br />
                Discontinued:
                <asp:CheckBox ID="DiscontinuedCheckBox" runat="server" Checked='<%# Bind("Discontinued") %>'
                    Enabled="false" /><br />
                CategoryName:
                <asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Bind("CategoryName") %>'>
                </asp:Label><br />
                SupplierName:
                <asp:Label ID="SupplierNameLabel" runat="server" Text='<%# Bind("SupplierName") %>'>
                </asp:Label><br />
                <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit"
                    Text="Edit">
                </asp:LinkButton>
                <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete">
                </asp:LinkButton>
                <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New"
                    Text="New">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:FormView>
        &nbsp;</p>
    <h3>
        Editing, Inserting, and Deleting Data from a DetailsView</h3>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1" AllowPaging="True">
            <Fields>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False"
                    ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID" />
                <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
                <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder" />
                <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
                <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" ReadOnly="True"
                    SortExpression="CategoryName" InsertVisible="False" />
                <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" ReadOnly="True"
                    SortExpression="SupplierName" InsertVisible="False" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
        &nbsp;</p>
    <h3>
        Editing and Deleting Data from a GridView</h3>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False"
                    ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID" />
                <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
                <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder" />
                <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
                <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" ReadOnly="True"
                    SortExpression="CategoryName" />
                <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" ReadOnly="True"
                    SortExpression="SupplierName" />
            </Columns>
        </asp:GridView>
        &nbsp;&nbsp;</p>
</asp:Content>
