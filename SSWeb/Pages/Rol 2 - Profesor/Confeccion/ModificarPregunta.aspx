<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="ModificarPregunta.aspx.vb" Inherits="Pages_Rol_2___Profesor_ModificarPregunta" title="Modificar pregunta" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
   <div>    
        <br />
        <div style="height: 67px">
       <h2 style="text-align: center">Gestión de encuesta:
        <asp:Label ID="lblEncuesta" runat="server" Text="Encuesta" Font-Bold="False" 
               Font-Size="13pt"></asp:Label>
        </h2>
    <p>Modificar una pregunta y sus opciones</p>
    <%--
    <div style="text-align: center">       
       <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>       
    </div>--%>
    <br />
    <%--Contenedor principal--%>
    </div>
        <%--selección --%>
        <div style="height: 134px; border: medium dotted #74B7DE; background-color: #D4D4D4; width: 410px; margin-left: 282px; text-align: left;">
            <div id="datosPregunta" 
                style="height: 47px; width: 279px; text-align: left; margin-left: 62px; margin-top: 12px">
                    <asp:Label ID="lblTipoPregunta" runat="server" Text="Tipo de pregunta:" 
                Font-Size="11pt"></asp:Label>
                    <br />
            <asp:DropDownList ID="cbxTipoPregunta" runat="server" 
            Height="27px" Width="275px" style="margin-left: 0px">
            
            <asp:ListItem Enabled="False">--Seleccione--</asp:ListItem>
            </asp:DropDownList>
            </div>
        <div style="text-align: left; width: 277px; margin-left: 63px; height: 53px; margin-top: 7px;">      
            <asp:Label ID="lblTexto" runat="server" Text="Texto:" Font-Size="11pt" 
                style="text-align: center"></asp:Label>
            <br />
            <asp:TextBox ID="txtTextoPregunta" runat="server"
            Height="36px" Width="278px" style="margin-left: 0px" TextMode="MultiLine" 
                Font-Names="arial" Font-Size="9pt"></asp:TextBox>
       </div>
        </div>
        <div style="text-align: center">     
            <asp:Label ID="lblError" runat="server" Text="Error" ForeColor="#FF3300" 
            Visible="False" Font-Size="11pt"></asp:Label>
            <br />
        </div>
        <div style="text-align: center">
          <asp:Button ID="btnAgregarPregunta" runat="server" Text="Guardar cambios" 
              Height="25px" Width="120px" />
        </div>
        <%--contenedor del grid--%>
        <br />
        <div style="text-align: center; width: 532px; margin-left: 321px;">
        <cc1:Grid ID="gvOpciones" runat="server" Height="200px" ShowFooter="False" 
                AllowSorting="False">
            <LocalizationSettings NoRecordsText="No hay opciones registradas" />
        </cc1:Grid>
        </div>
        <%--label de la pregunta--%>
        <div style="text-align: center"> 
           <asp:Label ID="lblError1" runat="server" Text="Error" 
            ForeColor="#FF3300"  Visible="False" Font-Size="11pt"></asp:Label>       
        </div>
        <%--Botones de gestión de la opcion--%>
        <div style="text-align: center; height: 91px;">
        
            <asp:Button ID="btnAgregarOpcion" runat="server" Text="Agregar opción" 
                Height="25px" style="margin-left: 19px" Width="120px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar opción" 
                Height="25px" Width="120px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnModificar" runat="server" Text="Modificar opción" 
                Height="25px" style="margin-top: 0px" Width="120px" />
        
        &nbsp;<br />
            <br />
            <asp:Button ID="btnIrCuestionario" runat="server" Text="Regresar" Width="120px" 
                Height="25px" style="margin-left: 813px" />
        </div>      
        <br />
        <br />
   </div>
</asp:Content>

