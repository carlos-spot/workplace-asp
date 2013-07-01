<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SectionLevelTutorialListing.ascx.vb" Inherits="UserControls_SectionLevelTutorialListing" %>
<asp:Repeater ID="TutorialList" runat="server" EnableViewState="False">
    <HeaderTemplate><ul></HeaderTemplate>
    <ItemTemplate>
        <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Url") %>' Text='<%# Eval("Title") %>'></asp:HyperLink>
                - <%# Eval("Description") %></li>
    </ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
</asp:Repeater>
