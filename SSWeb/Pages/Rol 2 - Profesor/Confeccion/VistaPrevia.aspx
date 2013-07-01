<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="VistaPrevia.aspx.vb" Inherits="Pages_Rol_2___Profesor_Confeccion_VistaPrevia" title="Vista previa de encuesta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <%--Ingresamos ToolkitScriptManager para los controles de ajax--%>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    
    <%--Inicia el div principal de la página--%>
    <div id="Principal" style="height: 565px">
        <%--Div con el titulo de la pagina--%>
        <div id="DivTitulo" style="height: 40px; width: 691px; text-align: left; margin-left: 57px; margin-top: 29px; margin-right: 0px;">
            <div style="width: 692px; height: 28px; margin-top: 9px; margin-left: 0px;">
                <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" 
                    Font-Size="20pt" ForeColor="#000066" 
                    Text="Vista previa de la encuesta"></asp:Label>
            </div>
        </div>
        <%--Div que contiene los datos de la encuesta y las preguntas--%>
        <div id="DivDatosEncuesta" style="border-left: thin dotted #00B000; border-right: thin dotted #00B000; border-top: thin solid #00B000; border-bottom: thin solid #00B000; height: 494px; width: 870px; background-color: #B9CDDA; text-align: left; margin-left: 54px; margin-top: 0px; border-color: #95DBB8;">           
            <%--Div con el nombre y el propósito de la encuesta--%>
            <div style="border-left: thin dotted #00B000; border-right: thin dotted #00B000; border-top: thin solid #00B000; border-bottom: thin solid #00B000; float: left; height: 139px; width: 870px; background-color: #B9CDDA; text-align: left; margin-left: 0px; margin-top: 0px; border-color: #95DBB8;">
                <div id="datosEncuesta" style="height: 136px; width: 649px; float:left; margin-left: 62px; margin-top: 0px;">
                    <%--Campo para el nombre de la encuesta--%>
                    <h4 style="width: 252px; height: 18px; margin-left: 0px; margin-top: 12px; margin-bottom: 0px">
                        Nombre de la encuesta:
                    </h4>
                    <div style="height: 33px; width: 634px;">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblNombre" runat="server" Font-Names="arial" Font-Size="12pt"></asp:Label>
                    </div>
                    <h4 style="width: 127px; margin-bottom: 0px; margin-top: 0px; height: 20px;">Propósito:</h4>
                    <div style="width: 636px; height: 36px;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblProposito" runat="server" Font-Names="arial" Font-Size="12pt"></asp:Label>
                    </div>
                </div>
                <%--Imagen para responder encuesta--%>
                <div id="Imagen" style="float:right; height: 135px; width: 142px; margin-right: 0px;">
                    <asp:Image ID="Image2" runat="server" Height="123px" ImageUrl="~/imagenes/Encuesta.png" Width="119px" style="margin-top: 0px; margin-left: 7px;" />
                </div>
            </div>  
         
            <%--Div con el TabContainer de Ajax, aqui mostramos las preguntas--%>
            <div style="width: 554px; float:left; height: 278px; margin-top: 20px; margin-left: 102px;">
                <ajaxToolkit:TabContainer ID="ContenedorPreguntas" runat="server" ActiveTabIndex="0" Height="250px" Width="600px" Font-Size="14pt" 
                ForeColor="#003300" Font-Bold="False" Font-Italic="False" Font-Names="Arial" ScrollBars="Vertical">
                </ajaxToolkit:TabContainer>
            </div>
            
            <%--Div con los botones de "Finalizar" y "Cancelar"--%>
            <div style="float:right; width: 149px; height: 276px; margin-left: 0px; margin-top: 22px;">
                 <%--Botón "Finalizar"--%>
                <br />
                <%--Botón "Cancelar"--%>
                <asp:Button ID="btnCancelar" runat="server" Height="25px" 
                     style="margin-top: 88px" Text="Regresar" Width="120px" />
            </div>
            
            <%--Div que contiene el Label para mostrar los errores al usuario--%>
            </div>
    </div>
</asp:Content>

