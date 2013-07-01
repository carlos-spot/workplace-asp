<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CustomButtons.aspx.vb" Inherits="CustomButtonsDataListRepeater_CustomButtons" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Adding Custom Buttons to the DataList and Repeater</h2>
    <p>
        <asp:Repeater ID="Categories" runat="server" DataSourceID="CategoriesDataSource">
            <ItemTemplate>
                <h3><%# Eval("CategoryName") %></h3>
                <p>
                    <%# Eval("Description") %>
                    [<asp:LinkButton runat="server" CommandName="ShowProducts" CommandArgument='<%# Eval("CategoryID") %>' ID="ShowProducts">Show Products</asp:LinkButton>]
                </p>
                <asp:BulletedList ID="ProductsInCategory" runat="server" DataTextField="ProductName">
                </asp:BulletedList>
            </ItemTemplate>
            <SeparatorTemplate><hr /></SeparatorTemplate>
        </asp:Repeater>
        
        <asp:ObjectDataSource ID="CategoriesDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCategories" TypeName="CategoriesBLL"></asp:ObjectDataSource>
    </p>
</asp:Content>