<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MantenimientoPersona.aspx.cs" Inherits="MantenimientoPersona" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
        <%--Definicion del SQLDataSource para listar los datos de la tabla TPersona y poder eliminarlas --%>
        <%--Se puede poner el ConnectionString de las siguientes:
             - ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" NOTA:(Solo si se definio en el Web.config)
             - connectionString="Data Source=localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=zxcv123!A"--%>
        <asp:SqlDataSource ID="TPersonaDataSource" runat="server" ConnectionString="Data Source=localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=zxcv123!A"
            SelectCommand="SELECT [IDPersona], [Nombre], [Apellido1], [Apellido2], [Genero], [Casado] FROM [TPersona]"
            DeleteCommand="DELETE FROM TPersona WHERE IDPersona = @IDPersona">
            <DeleteParameters>
                <asp:Parameter Name="IDPersona" />
            </DeleteParameters>
        </asp:SqlDataSource>
        <%--Grid que lista todos  los datos de la tabla TPersona y muestra un boton de borrar--%>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="IDPersona" DataSourceID="TPersonaDataSource" EnableViewState="False">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="IDPersona" HeaderText="IDPersona" InsertVisible="False" ReadOnly="True" SortExpression="IDPersona" />
                <asp:BoundField DataField="Apellido1" HeaderText="Apellido 1" SortExpression="Apellido1" />
                <asp:BoundField DataField="Apellido2" HeaderText="Apellido 2" SortExpression="Apellido2" />
                <asp:BoundField DataField="Genero" HeaderText="Genero" SortExpression="Genero" />
                <asp:BoundField DataField="Casado" HeaderText="Casado" SortExpression="Casado" />
                <%-- Para Columnas que se tenga que mostrar con el formato de dinero $17.00
                    <asp:BoundField DataField="Dinero" DataFormatString="{0:c}" HeaderText="Dinero" HtmlEncode="False" SortExpression="Dinero" />--%>
            </Columns>
        </asp:GridView>
    </p>
    <p>
        
        <%--Definicion del SQLDataSource que va a tener el DetailsView 'ManageTPersonaDataSource' para Agregar y Actualizar --%>
        <%--IMPORTANTE: LA COLUMNA IDPERSONA TIENE QUE SER IDENTITY!!!! PARA QUE SIRVA EL INSERT --%>
        <asp:SqlDataSource ID="ManageTPersonaDataSource" runat="server" 
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            DeleteCommand="DELETE FROM [TPersona] WHERE [IDPersona] = @IDPersona" 
            InsertCommand="INSERT INTO [TPersona] ([Nombre],[Apellido1], [Apellido2], [Genero], [Casado])VALUES (@Nombre, @Apellido1, @Apellido2, @Genero, @Casado)"
            SelectCommand="SELECT [IDPersona],[Nombre],[Apellido1], [Apellido2], [Genero], [Casado] FROM [TPersona]"
            UpdateCommand="UPDATE [TPersona] 
                           SET [Nombre] = @Nombre,
                               [Apellido1] = @Apellido1,
                               [Apellido2] = @Apellido2, 
                               [Genero] = @Genero, 
                               [Casado] = @Casado 
                           WHERE [IDPersona] = @IDPersona">
            <DeleteParameters>
                <asp:Parameter Name="IDPersona" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="IDPersona" Type="Int32" />
                <asp:Parameter Name="Nombre" Type="String" />
                <asp:Parameter Name="Apellido1" Type="String" />
                <asp:Parameter Name="Apellido2" Type="String" />
                <asp:Parameter Name="Genero" Type="String" />
                <asp:Parameter Name="Casado" Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Nombre" Type="String" />
                <asp:Parameter Name="Apellido1" Type="String" />
                <asp:Parameter Name="Apellido2" Type="String" />
                <asp:Parameter Name="Genero" Type="String" />
                <asp:Parameter Name="Casado" Type="Boolean" />
            </InsertParameters>
        </asp:SqlDataSource>

        <%--DetailsView que muestra la informacion de un Persona una a la vez y permite actualizar y registrar una nueva--%>
        <asp:DetailsView ID="ManageTPersona" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="IDPersona" DataSourceID="ManageTPersonaDataSource" EnableViewState="False">
            <Fields>
                <asp:BoundField DataField="IDPersona" HeaderText="IDPersona" InsertVisible="False" ReadOnly="True" SortExpression="IDPersona" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido1" HeaderText="Apellido1" SortExpression="Apellido1" />
                <asp:BoundField DataField="Apellido2" HeaderText="Apellido2" SortExpression="Apellido2" />
                <asp:BoundField DataField="Genero" HeaderText="Genero" SortExpression="Genero" />
                <asp:CheckBoxField DataField="Casado" HeaderText="Casado" SortExpression="Casado" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
    </p>
    </div>
    </form>
</body>
</html>
