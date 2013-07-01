<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="OptimisticConcurrency.aspx.vb" Inherits="EditDeleteDataList_OptimisticConcurrency" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Optimistic Concurrency</h2>
    <p>
        <asp:Label runat="server" ID="UpdateConcurrencyViolationMessage" CssClass="Warning" EnableViewState="False" Visible="False" Text="The record you attempted to update has been modified by another user since you started the update process. Your changes have been replaced with the current values. Please review the existing values and make any needed changes."></asp:Label> 
        <asp:Label runat="server" ID="DeleteConcurrencyViolationMessage" CssClass="Warning" EnableViewState="False" Visible="False" Text="The record you attempted to delete has been modified or deleted by another user since you visited the page. Your delete was cancelled to allow you to review the other user's changes and determine if you want to continue deleting this record."></asp:Label> 
        
        <asp:DataList ID="Products" runat="server" DataKeyField="ProductID" DataSourceID="ProductsDataSource">
            <ItemTemplate>                
                <h4><asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>'>
                </asp:Label></h4>
                Price: 
                <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice", "{0:C}") %>'></asp:Label>
                <br /><br />
                <asp:Button runat="server" ID="EditButton" Text="Edit" CommandName="Edit" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="DeleteButton" Text="Delete" CommandName="Delete" />
                <br /><br />
            </ItemTemplate>
            <EditItemTemplate>
                Product: <asp:TextBox runat="server" ID="ProductName" Text='<%# Eval("ProductName") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ProductName"
                    ErrorMessage="You must provide the product's name.">*</asp:RequiredFieldValidator><br />
                Price: $<asp:TextBox runat="server" ID="UnitPrice" Text='<%# Eval("UnitPrice", "{0:N2}") %>' Columns="8" />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="UnitPrice"
                    ErrorMessage="The product's price must be a valid currency value greater than or equal to zero. Do not include the currency symbol."
                    Operator="GreaterThanEqual" Type="Currency" ValueToCompare="0">*</asp:CompareValidator><br /><br />
                <asp:Button runat="server" ID="UpdateButton" Text="Update" CommandName="Update" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="CancelButton" Text="Cancel" CommandName="Cancel" CausesValidation="False" />
                <br /><br />
            </EditItemTemplate>
        </asp:DataList><asp:ObjectDataSource ID="ProductsDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetProducts" TypeName="ProductsBLL"></asp:ObjectDataSource>
    </p>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" />

</asp:Content>

