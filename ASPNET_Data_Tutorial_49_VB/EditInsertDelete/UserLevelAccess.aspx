<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="UserLevelAccess.aspx.vb" Inherits="EditInsertDelete_UserLevelAccess" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Limiting Access Based on the User</h2>
    <p>
        Choose your level of access:
        <asp:DropDownList ID="Suppliers" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
            DataSourceID="AllSuppliersDataSource" DataTextField="CompanyName" DataValueField="SupplierID">
            <asp:ListItem Value="-1">Show/Edit ALL Suppliers</asp:ListItem>
        </asp:DropDownList><asp:ObjectDataSource ID="AllSuppliersDataSource" runat="server"
            SelectMethod="GetSuppliers" TypeName="SuppliersBLL"
            UpdateMethod="UpdateSupplierAddress">
            <UpdateParameters>
                <asp:Parameter Name="supplierID" Type="Int32" />
                <asp:Parameter Name="address" Type="String" />
                <asp:Parameter Name="city" Type="String" />
                <asp:Parameter Name="country" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="SingleSupplierDataSource" runat="server"
            SelectMethod="GetSupplierBySupplierID" TypeName="SuppliersBLL" UpdateMethod="UpdateSupplierAddress">
            <UpdateParameters>
                <asp:Parameter Name="supplierID" Type="Int32" />
                <asp:Parameter Name="address" Type="String" />
                <asp:Parameter Name="city" Type="String" />
                <asp:Parameter Name="country" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="Suppliers" Name="supplierID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <h3>Supplier Information</h3>
    <p>
        <asp:DetailsView ID="SupplierDetails" runat="server" AllowPaging="True" AutoGenerateRows="False"
            DataKeyNames="SupplierID" DataSourceID="AllSuppliersDataSource">
            <Fields>
                <asp:BoundField DataField="CompanyName" HeaderText="Company" ReadOnly="True" SortExpression="CompanyName" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" ReadOnly="True" SortExpression="Phone" />
                <asp:CommandField ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>
    </p>
    <h3>Products Provided by Supplier</h3>
    <p>
        <asp:GridView ID="ProductsBySupplier" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="ProductsBySupplierDataSource">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty/Unit" SortExpression="QuantityPerUnit" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" ReadOnly="True"
                    SortExpression="Discontinued" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ProductsBySupplierDataSource" runat="server" SelectMethod="GetProductsBySupplierID"
            TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
            <UpdateParameters>
                <asp:Parameter Name="productName" Type="String" />
                <asp:Parameter Name="quantityPerUnit" Type="String" />
                <asp:Parameter Name="productID" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="SupplierDetails" Name="supplierID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

