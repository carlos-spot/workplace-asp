<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="FormView.aspx.vb" Inherits="CustomFormatting_FormView" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Creating a Fluid Display with the FormView</h2>
    <p>&nbsp;</p>
    <p>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" AllowPaging="True" EnableViewState="False">
            <ItemTemplate>
                <hr />
                <h3><%# Eval("ProductName") %></h3>
                <table border="0">
                    <tr>
                        <td class="ProductPropertyLabel">Category:</td>
                        <td class="ProductPropertyValue"><%# Eval("CategoryName") %></td>
                        <td class="ProductPropertyLabel">Supplier:</td>
                        <td class="ProductPropertyValue"><%# Eval("SupplierName")%></td>
                    </tr>
                    <tr>
                        <td class="ProductPropertyLabel">Price:</td>
                        <td class="ProductPropertyValue"><%# Eval("UnitPrice", "{0:C}") %></td>
                        <td class="ProductPropertyLabel">Units In Stock:</td>
                        <td class="ProductPropertyValue"><%# Eval("UnitsInStock")%></td>
                    </tr>
                    <tr>
                        <td class="ProductPropertyLabel">Units On Order:</td>
                        <td class="ProductPropertyValue"><%# Eval("UnitsOnOrder") %></td>
                        <td class="ProductPropertyLabel">Reorder Level:</td>
                        <td class="ProductPropertyValue"><%# Eval("ReorderLevel")%></td>
                    </tr>
                    <tr>
                        <td class="ProductPropertyLabel">Qty/Unit</td>
                        <td class="ProductPropertyValue"><%# Eval("QuantityPerUnit") %></td>
                        <td class="ProductPropertyLabel">Discontinued:</td>
                        <td class="ProductPropertyValue">
                            <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" Checked='<%# Eval("Discontinued") %>' />
                        </td>
                    </tr>
                </table>
                <hr />
            </ItemTemplate>
        </asp:FormView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="DeleteProduct"
            InsertMethod="AddProduct" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProducts"
            TypeName="ProductsBLL" UpdateMethod="UpdateProduct">
            <DeleteParameters>
                <asp:Parameter Name="productID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="productName" Type="String" />
                <asp:Parameter Name="supplierID" Type="Int32" />
                <asp:Parameter Name="categoryID" Type="Int32" />
                <asp:Parameter Name="quantityPerUnit" Type="String" />
                <asp:Parameter Name="unitPrice" Type="Decimal" />
                <asp:Parameter Name="unitsInStock" Type="Int16" />
                <asp:Parameter Name="unitsOnOrder" Type="Int16" />
                <asp:Parameter Name="reorderLevel" Type="Int16" />
                <asp:Parameter Name="discontinued" Type="Boolean" />
                <asp:Parameter Name="productID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="productName" Type="String" />
                <asp:Parameter Name="supplierID" Type="Int32" />
                <asp:Parameter Name="categoryID" Type="Int32" />
                <asp:Parameter Name="quantityPerUnit" Type="String" />
                <asp:Parameter Name="unitPrice" Type="Decimal" />
                <asp:Parameter Name="unitsInStock" Type="Int16" />
                <asp:Parameter Name="unitsOnOrder" Type="Int16" />
                <asp:Parameter Name="reorderLevel" Type="Int16" />
                <asp:Parameter Name="discontinued" Type="Boolean" />
            </InsertParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

