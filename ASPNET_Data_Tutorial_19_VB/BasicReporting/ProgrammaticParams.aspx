<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ProgrammaticParams.aspx.vb" Inherits="BasicReporting_ProgrammaticParams" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>
        Employee Anniversaries This Month</h3>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeID"
            DataSourceID="ObjectDataSource1" EnableViewState="False">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="First" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last" SortExpression="LastName" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="HireDate" HeaderText="Hired" SortExpression="HireDate" DataFormatString="{0:d}" HtmlEncode="False" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetEmployeesByHiredDateMonth" TypeName="EmployeesBLL">
            <SelectParameters>
                <asp:Parameter Name="month" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

