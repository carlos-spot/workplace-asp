<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="DeclarativeParams.aspx.vb" Inherits="BasicReporting_DeclarativeParams" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Information About Chef Anton's Gumbo Mix</h3>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID"
        DataSourceID="ObjectDataSource1" EnableViewState="False">
        <Fields>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" InsertVisible="False"
                ReadOnly="True" SortExpression="ProductID" />
            <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
            <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" SortExpression="CategoryName" />
            <asp:BoundField DataField="SupplierName" HeaderText="Supplier" ReadOnly="True" SortExpression="SupplierName" />
            <asp:BoundField DataField="UnitPrice" DataFormatString="{0:c}" HeaderText="Price"
                HtmlEncode="False" SortExpression="UnitPrice">
            </asp:BoundField>
            <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued">
                <ItemStyle HorizontalAlign="Center" />
            </asp:CheckBoxField>
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
        SelectMethod="GetProductByProductID" TypeName="ProductsBLL">
        <SelectParameters>
            <asp:Parameter DefaultValue="5" Name="productID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <h3>
        View Suppliers By Country</h3>
    <p>
        Enter a country:
        <asp:TextBox ID="CountryName" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="Button1"
            runat="server" Text="Show Suppliers" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SupplierID"
            DataSourceID="ObjectDataSource2" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="CompanyName" HeaderText="Company" SortExpression="CompanyName" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetSuppliersByCountry" TypeName="SuppliersBLL" UpdateMethod="UpdateSupplierAddress">
            <UpdateParameters>
                <asp:Parameter Name="supplierID" Type="Int32" />
                <asp:Parameter Name="address" Type="String" />
                <asp:Parameter Name="city" Type="String" />
                <asp:Parameter Name="country" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="CountryName" Name="country" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

