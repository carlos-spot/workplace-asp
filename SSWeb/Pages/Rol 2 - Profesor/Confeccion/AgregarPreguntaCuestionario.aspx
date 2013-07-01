<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="AgregarPreguntaCuestionario.aspx.vb" Inherits="Pages_Rol_2___Profesor_AgregarPreguntaCuestionario" title="Agregar nueva pregunta" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <div>
           <div>
             <br />
            <br />
            <h2 style="height: 40px; width: 973px; margin-left: 4px; text-align: center; margin-top: 0px;">Crear nueva pregunta 
             de encuesta:
             <asp:Label ID="lblEncuesta" runat="server" Text="Encuesta"></asp:Label>
            </h2>
            <p>Creación de una nueva pregunta para agragarla al cuestionario</p>
        </div>
        <asp:Panel ID="PanelRegistro" runat="server" 
            Height="153px" style="margin-left: 222px" Width="619px">
            <div style="height: 135px; border: medium dotted #74B7DE; background-color: #D4D4D4; width: 400px; margin-left: 65px; text-align: left;">
                <div 
                    style="text-align: left; width: 333px; margin-left: 36px; margin-top: 7px">
                    <asp:Label ID="LblTipo" runat="server" Text="Tipo de pregunta:" 
                        Font-Size= "11pt" Font-Names="Arial"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbxTipoPregunta" runat="server" 
                        Height="20px" Width="316px" style="margin-left: 0px">
                        <asp:ListItem Enabled="False">--Seleccione--</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
                
                <div style="width: 333px; margin-left: 36px; height: 78px; text-align: left; margin-top: 6px;">
                    <asp:Label ID="lblTexto" runat="server" Font-Size="11pt" 
                        Text="Texto personalizado:"></asp:Label>
                         <br />
                    <asp:TextBox ID="txtTextoPregunta" runat="server" Height="49px" 
                        style="margin-left: 0px" TextMode="MultiLine" Width="315px" 
                        Font-Names="Arial" Font-Size="11pt"></asp:TextBox>
                    <div style="position: relative; top: -73px; left: 425px; width: 167px; height: 91px;">
                        <asp:Button ID="btnAgregarPregunta" runat="server" Height="25px" 
                            style="margin-left: 0px; text-align: center; margin-bottom: 37px; margin-top: 3px;" 
                            Text="Agregar opción" Width="120px" />
                    </div>
                </div>
            </div>
        </asp:Panel>
        <div>
            <%--Configuración de la pregunta--%><br />
            <div style="width: 970px; margin-left: 3px; text-align: center;">
                <asp:Label ID="lblError" runat="server" Text="Error" ForeColor="#FF3300" 
                 Visible="False" Font-Size="11pt"></asp:Label>
            </div>
    &nbsp;  <div style="width: 520px; margin-left: 289px; text-align: center; height: 135px;">
                    <cc1:Grid ID="gvOpciones" runat="server" AllowAddingRecords="False" 
                        ShowFooter="False" Width="400px" AllowMultiRecordSelection="False" 
                        EnableTypeValidation="False" PageSize="0" AllowColumnResizing="False" 
                        FolderExports="" Height="150px">
                        <ScrollingSettings ScrollHeight="400px" />
                        <LocalizationSettings NoRecordsText="No hay opciones registradas" />
            </cc1:Grid>
            </div>
            <br />
            <div style="width: 968px; margin-left: 3px; text-align: center;">
                    <asp:Label ID="lblError1" runat="server" Text="Error" 
                ForeColor="#FF3300" Visible="False" Font-Size="11pt"></asp:Label>
            </div>
            
            <div style="width: 968px; margin-left: 4px; margin-top: 0px;">
             <asp:Button ID="btnAgregarOpcion" runat="server" Text="Agregar nueva opción" 
                    Width="150px" Height="25px" 
                    style="text-align: center; margin-left: 246px" />
             <asp:Button ID="btnModificar" runat="server" Text="Modificar opción" 
                    Width="150px" Height="25px" 
                    style="text-align: center; margin-left: 10px" />
             <asp:Button ID="btnEliminar" runat="server" Text="Eliminar opción" 
                    Width="150px" Height="25px" style="margin-left: 10px" />
            </div>
            <br />
            <div style="width: 972px; margin-left: 1px">
                 <asp:Button ID="btnIrCuestionario" runat="server" Text="Regresar" CssClass="" 
                     Width="150px" Height="25px" 
                     style="margin-left: 778px; text-align: center; margin-top: 17px;" />
            </div>
        </div> 
    </div>
</asp:Content>

