<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ConfirmationOnDelete.aspx.vb" Inherits="EditInsertDelete_ConfirmationOnDelete" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Client-Side Confirmation on Delete</h2>
    <p>
        <asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1">
            <ItemTemplate>                
                <h3><i><%# Eval("ProductName") %></i></h3>
                <b>Category:</b>
                <asp:Label ID="CategoryNameLabel" runat="server" Text='<%# Eval("CategoryName") %>'>
                </asp:Label><br />
                <b>Supplier:</b>
                <asp:Label ID="SupplierNameLabel" runat="server" Text='<%# Eval("SupplierName") %>'>
                </asp:Label><br />
                <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete"
                    Text="Delete" OnClientClick="return confirm('Are you certain that you want to delete this product?');">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteProduct"
            SelectMethod="GetProducts" TypeName="ProductsBLL">
            <DeleteParameters>
                <asp:Parameter Name="productID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID"
            DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" SortExpression="CategoryName" />
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier" ReadOnly="True" SortExpression="SupplierName" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>