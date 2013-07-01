<%@ Page Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="UserLevelAccess.aspx.vb" Inherits="EditDeleteDataList_UserLevelAccess" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Limiting Access Based on the User</h2>
    <p>
        You are logged on as:
        <asp:DropDownList ID="LoggedOnAs" runat="server" AppendDataBoundItems="True" DataSourceID="LoggedOnAsDataSource"
            DataTextField="LastName" DataValueField="EmployeeID" AutoPostBack="True">
            <asp:ListItem Value="-1">Anonymous Visitor</asp:ListItem>
        </asp:DropDownList><asp:ObjectDataSource ID="LoggedOnAsDataSource" runat="server"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetEmployees" TypeName="EmployeesBLL">
        </asp:ObjectDataSource>
    </p>
    <p>
        <asp:DataList ID="Employees" runat="server" DataKeyField="EmployeeID" DataSourceID="EmployeesDataSource">
            <ItemTemplate>
                <h4>
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>'></asp:Label>                
                </h4>
                
                Title:
                <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>'></asp:Label><br />
                Hire Date:
                <asp:Label ID="HireDateLabel" runat="server" Text='<%# Eval("HireDate", "{0:d}") %>'></asp:Label><br />
                <br /><br />
                <asp:Button runat="server" ID="EditButton" CommandName="Edit" Text="Edit" />
                <br /><br />
            </ItemTemplate>
            
            <EditItemTemplate>
                First Name: <asp:TextBox runat="server" ID="FirstName" Text='<%# Eval("FirstName") %>' Columns="10" MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName"
                    ErrorMessage="You must provide the employee's first name.">*</asp:RequiredFieldValidator><br />
                Last Name: <asp:TextBox runat="server" ID="LastName" Text='<%# Eval("LastName") %>' Columns="20" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastName"
                    ErrorMessage="You must provide the employee's last name.">*</asp:RequiredFieldValidator><br />
                Title: <asp:TextBox runat="server" ID="Title" Text='<%# Eval("Title") %>' Columns="30" MaxLength="30"></asp:TextBox><br />
                Hire Date: <asp:TextBox runat="server" ID="HireDate" Text='<%# Eval("HireDate", "{0:d}") %>' Columns="15"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="HireDate"
                    ErrorMessage="The hire date must be a valid date value." Operator="DataTypeCheck"
                    Type="Date">*</asp:CompareValidator>
                <br /><br />
                <asp:Button ID="UpdateButton" runat="server" Text="Update" CommandName="Update" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="CancelButton" runat="server" Text="Cancel" CausesValidation="False" CommandName="Cancel" />
                
            </EditItemTemplate>
        </asp:DataList>

        <asp:ObjectDataSource ID="EmployeesDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetEmployees" TypeName="EmployeesBLL"></asp:ObjectDataSource>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" />
    </p>
</asp:Content>

