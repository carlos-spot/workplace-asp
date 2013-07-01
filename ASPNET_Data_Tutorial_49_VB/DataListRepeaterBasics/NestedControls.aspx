<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="NestedControls.aspx.vb" Inherits="DataListRepeaterBasics_NestedControls" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Nested DataBinding</h2>
    <p>
        <asp:Repeater ID="CategoryList" runat="server" DataSourceID="CategoriesDataSource" EnableViewState="False">
            <ItemTemplate>
                <h4><%# Eval("CategoryName") %></h4>
                <p><%# Eval("Description") %></p>
                
                <%--The following Repeater and ObjectDataSource example, illustrate how to have
                    the data bound to the Repeater declaratively. However, with this approach we
                    need to set the ObjectDataSource's CategoryID parameter in the outer Repeater's
                    ItemDataBound event handler...
                <asp:Repeater runat="server" ID="ProductsByCategoryList" EnableViewState="False"
                        DataSourceID="ProductsByCategoryDataSource">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><strong><%# Eval("ProductName") %></strong> (<%# Eval("UnitPrice", "{0:C}") %>)</li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
                
                
                <asp:ObjectDataSource ID="ProductsByCategoryDataSource" runat="server" 
                           SelectMethod="GetProductsByCategoryID" TypeName="ProductsBLL">
                   <SelectParameters>
                        <asp:Parameter Name="CategoryID" Type="Int32" />
                   </SelectParameters>
                </asp:ObjectDataSource>
                 --%>
                
                <asp:Repeater runat="server" ID="ProductsByCategoryList" EnableViewState="False"
                        DataSource='<%# GetProductsInCategory(CType(Eval("CategoryID"), Integer)) %>'>
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><strong><%# Eval("ProductName") %></strong> (<%# Eval("UnitPrice", "{0:C}") %>)</li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
                
            </ItemTemplate>
            
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
        
        <asp:ObjectDataSource ID="CategoriesDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCategories" TypeName="CategoriesBLL"></asp:ObjectDataSource>
    </p>
</asp:Content>