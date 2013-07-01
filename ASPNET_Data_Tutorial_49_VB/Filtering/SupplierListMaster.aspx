<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="SupplierListMaster.aspx.vb" Inherits="Filtering_SupplierListMaster" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>
        Suppliers</h3>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SupplierID"
            DataSourceID="ObjectDataSource1" EnableViewState="False">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="SupplierID" DataNavigateUrlFormatString="ProductsForSupplierDetails.aspx?SupplierID={0}"
                    Text="View Products" />
                <asp:BoundField DataField="CompanyName" HeaderText="Company" SortExpression="CompanyName" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetSuppliers" TypeName="SuppliersBLL" UpdateMethod="UpdateSupplierAddress">
            <UpdateParameters>
                <asp:Parameter Name="supplierID" Type="Int32" />
                <asp:Parameter Name="address" Type="String" />
                <asp:Parameter Name="city" Type="String" />
                <asp:Parameter Name="country" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

