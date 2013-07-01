<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CategoryListMaster.aspx.vb" Inherits="DataListRepeaterFiltering_CategoryListMaster" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Two-Page Master/Detail Report</h2>
    <p>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1" EnableViewState="False">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            
            <ItemTemplate>
                <%-- You can use an anchor element... --%>
                <li><a href='ProductsForCategoryDetails.aspx?CategoryID=<%# Eval("CategoryID") %>'><%# Eval("CategoryName") %></a> - <%# Eval("Description") %></li>                 
                 
                 <%-- Or a HyperLink Web control...
                 <li><asp:HyperLink runat="server" Text='<%# Eval("CategoryName") %>' NavigateUrl='<%# "ProductsForCategoryDetails.aspx?CategoryID=" & Eval("CategoryID") %>'></asp:HyperLink>
                  - <%# Eval("Description") %></li>
                 --%>
            </ItemTemplate>
            
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCategories" TypeName="CategoriesBLL"></asp:ObjectDataSource>
    </p>
</asp:Content>