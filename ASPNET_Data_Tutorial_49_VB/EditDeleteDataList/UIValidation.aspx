<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="UIValidation.aspx.vb" Inherits="EditDeleteDataList_UIValidation" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Adding Validation Controls to the DataList's Editing Interface</h2>
    <p>
        <asp:Label ID="ExceptionDetails" runat="server" EnableViewState="False" CssClass="Warning"></asp:Label>
    </p>
    <p>
        <asp:DataList ID="Products" runat="server" DataKeyField="ProductID" DataSourceID="ProductsDataSource" RepeatColumns="2" OnEditCommand="Products_EditCommand">
            <ItemTemplate>
                <h5><asp:Label runat="server" ID="ProductNameLabel" Text='<%# Eval("ProductName") %>'></asp:Label></h5>
                Price: <asp:Label runat="server" ID="Label1" Text='<%# Eval("UnitPrice", "{0:C}") %>'></asp:Label>
                <br />
                <asp:Button runat="server" id="EditProduct" CommandName="Edit" Text="Edit" />
                <br />
                <br />
            </ItemTemplate>
            <EditItemTemplate>
                Product name:
                <asp:TextBox ID="ProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ProductName"
                    ErrorMessage="You must provide the product's name">*</asp:RequiredFieldValidator><br />
                Price:
                $<asp:TextBox ID="UnitPrice" runat="server" Text='<%# Eval("UnitPrice", "{0:n2}") %>'></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="UnitPrice"
                    ErrorMessage="The price must be greater than or equal to zero and cannot include the currency symbol"
                    Operator="GreaterThanEqual" Type="Currency" ValueToCompare="0">*</asp:CompareValidator><br />
                <br />
                <asp:Button ID="UpdateProduct" runat="server" CommandName="Update" Text="Update" />&nbsp;<asp:Button
                    ID="CancelUpdate" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="False" />

            </EditItemTemplate>
        </asp:DataList>
        
        <asp:ObjectDataSource ID="ProductsDataSource" runat="server"
            SelectMethod="GetProducts" TypeName="ProductsBLL" OldValuesParameterFormatString="original_{0}">
        </asp:ObjectDataSource>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" />
    </p>
</asp:Content>

