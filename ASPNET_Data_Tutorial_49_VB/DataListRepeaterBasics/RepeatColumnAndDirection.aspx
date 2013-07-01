<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="RepeatColumnAndDirection.aspx.vb" Inherits="DataListRepeaterBasics_RepeatColumnAndDirection" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Showing Multiple Records per Row</h2>
    <p>
        <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID" DataSourceID="ObjectDataSource1" EnableViewState="False" RepeatColumns="3">
            <ItemTemplate>
                <h4><asp:Label runat="server" ID="ProductNameLabel" Text='<%# Eval("ProductName") %>'></asp:Label></h4>
                Available in the <asp:Label runat="server" ID="CategoryNameLabel" Text='<%# Eval("CategoryName") %>'></asp:Label>
                store for <asp:Label runat="server" ID="UnitPriceLabel" Text='<%# Eval("UnitPrice", "{0:C}") %>'></asp:Label>
            </ItemTemplate>
        </asp:DataList>
        
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProducts" TypeName="ProductsBLL"></asp:ObjectDataSource>
    </p>
</asp:Content>

