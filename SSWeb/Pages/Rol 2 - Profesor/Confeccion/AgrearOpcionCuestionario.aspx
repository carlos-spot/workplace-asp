<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="AgrearOpcionCuestionario.aspx.vb" Inherits="Pages_Rol_2___Profesor_AgrearOpcionCuestionario" title="Agregar opción a la pregunta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
<div>
    <br />
    <%--Tìtulo y descripción--%>
     <%--Div con el titulo de la pagina--%>
        <div id="DivTitulo" 
            
        style="height: 40px; width: 437px; text-align: left; margin-left: 365px; margin-top: 0px; margin-right: 0px;">
            <div style="width: 427px; height: 28px; margin-top: 9px; margin-left: 0px;">
                <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" Font-Size="20pt" ForeColor="#000066" 
                    Text="Gestión de encuesta"></asp:Label>
            </div>
        </div>
    <p style="width: 869px; margin-left: 56px; text-align: center" >Agregar una opción a la pregunta. 
        Seleccione si la opción es un producto o si desea ingresar una opción 
        personalizada.</p>
    <%--Selección del tipo de opción--%>
    <div style="text-align: center">  
        <asp:RadioButtonList ID="rblSeleccionar" runat="server" 
            style="text-align: left; margin-left: 416px" Font-Size="11pt">
            <asp:ListItem Value="seleccionarProducto">Seleccionar Producto</asp:ListItem>
            <asp:ListItem Selected="True" Value="ingresarTexto">Ingresar texto</asp:ListItem>
        </asp:RadioButtonList>
   </div>
   <%--Boton de elegir la opción dada--%>
   <div>
        <br />
        <asp:Button ID="btnSiguiente" runat="server" 
            style="margin-left: 435px" Text="Seleccionar" Height="25px" 
            Width="120px" />
        <br />
        <br />
    </div>
    <%--Ingreso de los datos--%>
    <div style="text-align: center">
         &nbsp;<asp:Label ID="LblProducto" runat="server" Text="Producto:" 
             Visible="False" Font-Size="11pt"></asp:Label>&nbsp;
         <asp:DropDownList 
             ID="cbxProducto" runat="server" 
         Height="20px" Width="220px" Visible="False">
        </asp:DropDownList>
        <br />
        <br />
    </div>
    <%--Ingreso de texto--%>
    <div style="text-align: center">
        &nbsp;
        <asp:Label ID="LblTexto" runat="server" Text="Texto:" Visible="False" 
            Font-Size="11pt"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTextoOpcion" runat="server" Height="20px" 
            Width="220px" Visible="False" style="margin-left: 3px"></asp:TextBox>
        <br />
        <br />
    </div>
   <%--Label y botones--%>
    <div style="text-align: center">
        <asp:Label ID="lblError" runat="server" Text="Error" ForeColor="#FF3300" 
            Visible="False" Font-Size="11pt"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnIrPregunta" runat="server" Text="Guardar" Width="120px" 
            Visible="False" style="margin-left: 0px" Height="25px" />
        <br />
        <asp:Button ID="btnAtras" runat="server" style="margin-left: 821px" Text="Regresar" 
            Width="120px" Height="25px" />
   </div>
        <br />
</div>
</asp:Content>

