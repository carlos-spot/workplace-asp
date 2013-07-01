<%@ Page Title="" Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="TabulacionAbiertas.aspx.vb" Inherits="pages_Rol_2___Profesor_Analisis_TabulacionAbiertas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
     <%--Div con el titulo de la pagina--%>
        <br />.
        <div id="DivTitulo" 
            
        
         style="height: 40px; width: 469px; text-align: left; margin-left: 231px; margin-right: 0px;">
            <div style="width: 427px; height: 28px; margin-top: 9px; margin-left: 0px;">
                <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" Font-Size="20pt" ForeColor="#000066" 
                    Text="Tabulación de preguntas abiertas"></asp:Label>
            </div>
        </div>
<p>Este módulo le permite realizar la tabulación de las preguntas abiertas de una encuesta para todos sus ejemplares.</p>
<ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <%--Inicia el div principal de la página--%>
    <div id="Principal" style="height: 397px; margin-top: 0px;">
        <%--Div con el titulo de la pagina--%>
        <div id="DivDatosEncuesta" 
            
            style="border-left: thin dotted #00B000; border-right: thin dotted #00B000; border-top: thin solid #00B000; border-bottom: thin solid #00B000; height: 382px; width: 870px; background-color: #B9CDDA; text-align: left; margin-left: 54px; margin-top: 0px; border-color: #95DBB8; ">           
            <%--Div con el nombre y el propósito de la encuesta--%>
            <div style="border-left: thin dotted #00B000; border-right: thin dotted #00B000; border-top: thin solid #00B000; border-bottom: thin solid #00B000; float: left; height: 143px; width: 870px; background-color: #B9CDDA; text-align: left; margin-left: 0px; margin-top: 18px; border-color: #66CC99; " >
               <div id="datosEncuesta" style="height: 136px; width: 649px; float:left; margin-left: 62px; margin-top: 0px;">
                    <%--Campo para el nombre de la encuesta--%>
                        <asp:Label ID="lblNombreEnc" runat="server" Text="Nombre de la encuesta:   " 
                        Font-Bold="True" Font-Size="15pt" ForeColor="Black"></asp:Label>
                        <asp:Label ID="lblNombre" runat="server" Font-Names="arial" Font-Size="12pt"></asp:Label>
                        <asp:ListBox ID="codPreguntas" runat="server" Height="21px" Visible="False" 
                            Width="26px"></asp:ListBox>
                    <%--Campo para el propósito de la encuesta--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<h4 style="width: 295px; margin-bottom: 0px; margin-top: 22px;">Preguntas de la 
                        encuesta:</h4>
                    <div style="width: 636px; height: 36px; margin-top: 0px;">
                        <asp:DropDownList ID="ddlPreguntas" runat="server" Height="20px" Width="500px" 
                            AutoPostBack="True" style="margin-top: 3px">
                        </asp:DropDownList>
                    </div>
                </div>
                <%--Imagen para responder encuesta--%>
                <div id="Imagen" style="float:right; height: 135px; width: 142px; margin-right: 0px;">
                    <asp:Image ID="Image2" runat="server" Height="123px" ImageUrl="~/imagenes/Encuesta.png" Width="119px" style="margin-top: 0px; margin-left: 7px;" />
                </div>
            </div>  
         
            <%--Div con el TabContainer de Ajax, aqui mostramos las preguntas--%>
            <div style="width: 486px; float:left; height: 192px; margin-top: 0px; margin-left: 58px;">
                <asp:Panel ID="Panel1" runat="server" Height="172px" Width="510px" 
                    style="margin-top: 0px">
                    <br />
                    <asp:TextBox ID="txtRespuesta" runat="server" Height="83px" Width="458px" 
                        TextMode="MultiLine" Enabled="False"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblValor" runat="server" Font-Size="12pt" Text="Asignar valor"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlOpciones" runat="server" Height="20px" Width="220px" 
                        style="margin-top: 4px">
                    </asp:DropDownList>
                </asp:Panel>
            </div>
            
            <%--Div con los botones de "Finalizar" y "Cancelar"--%>
            <div style="float:right; width: 304px; height: 189px; margin-left: 0px; ">
                 <%--Botón "Finalizar"--%>
                                 
                <div id="boton" 
                     style="float:left; margin-left: 29px; margin-top: 0px; height: 147px; width: 147px;">
                    <asp:Label ID="lblCont" runat="server" Font-Size="Large" Text="Label"></asp:Label>
                    <br />
                <asp:Button ID="btnFinalizar" runat="server" Height="25px" 
                     style="margin-top: 36px; margin-left: 0px;" Text="Siguiente --&gt;" 
                     Width="120px" Enabled="False" />
                </div>
                <br />
                 <br />
                 <br />
                 <br />
                 <br/>
                </div>
            
            <%--Div que contiene el Label para mostrar los errores al usuario--%>
            <div style=" float:left; width: 268px; height: 22px; margin-left: 61px; margin-top: 0px;">
                 <asp:Label ID="lblMensajeError" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label>
            </div>
            <br />
            <br />
        </div>
        <%--Div que contiene el control "ModalPopupExtender" de ajax, para mostrar los mensajes de confirmación--%>
        </div>
</asp:Content>

