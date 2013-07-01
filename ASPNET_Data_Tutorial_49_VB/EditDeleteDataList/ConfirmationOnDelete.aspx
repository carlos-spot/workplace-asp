<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ConfirmationOnDelete.aspx.vb" Inherits="EditDeleteDataList_ConfirmationOnDelete" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Confirming on Delete</h2>
    <p>
        <asp:DataList ID="Products" runat="server" DataKeyField="ProductID" DataSourceID="ProductsDataSource">
            <ItemTemplate>
                <h3>
                   <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>'>
                   </asp:Label>
                </h3>
                
                Category:
                <asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Eval("CategoryName") %>'>
                </asp:Label><br />
                Supplier:
                <asp:Label ID="SupplierNameLabel" runat="server" Text='<%# Eval("SupplierName") %>'>
                </asp:Label>
                <br /><br />
                
                <%-- 
                    OPTIONAL: You can use the programmatic approach (see the code-behind class)...
                    Or the declarative approach...
                    To add a confirmation box declaratively, add the following to the Button Web control below:
                    OnClientClick="return confirm('Are you certain that you want to delete this product?');"
                --%>

                <asp:Button runat="server" ID="DeleteButton" CommandName="Delete" Text="Delete" />
                
                <br /><br />
            </ItemTemplate>
        </asp:DataList><asp:ObjectDataSource ID="ProductsDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProducts" TypeName="ProductsBLL"></asp:ObjectDataSource>
    </p>
</asp:Content>