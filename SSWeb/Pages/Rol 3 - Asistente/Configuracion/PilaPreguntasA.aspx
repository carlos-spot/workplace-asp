<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 3 - Asistente/PrincipalAsistente.master" AutoEventWireup="false" CodeFile="PilaPreguntasA.aspx.vb" Inherits="Pages_Rol_3___Asistente_Configuracion_PilaPreguntasA" title="Pila de preguntas" %>
<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <br />
    <%--Div con el titulo de la pagina--%>
        <div id="DivTitulo" 
            
        style="height: 40px; width: 437px; text-align: left; margin-left: 365px; margin-top: 0px; margin-right: 0px;">
            <div style="width: 427px; height: 28px; margin-top: 9px; margin-left: 0px;">
                <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" Font-Size="20pt" ForeColor="#000066" 
                    Text="Pila de pregunta"></asp:Label>
            </div>
        </div>
    <p>En este módulo, se realizan las tareas del mantenimiento de preguntas a la pila 
                de preguntas.</p>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div id="divprincipal">
        <div id="pool"
            
            style="width: 679px; float:left; height: 384px; margin-top: 49px; margin-left: 28px;">
            
            <cc1:Grid ID="poolpreguntas" runat="server" AllowSorting="False" 
                ShowFooter="False" AllowAddingRecords="False" 
                AllowMultiRecordSelection="False" Height="370px" PageSize="0">
                <ScrollingSettings ScrollHeight="300px" />
                <LocalizationSettings NoRecordsText="No se encontraron preguntas registradas." />
            </cc1:Grid>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" 
                style="text-align: right" Font-Size="11pt"></asp:Label>
        </div> 
        <div id="menu" 
            
            style="width: 153px; height: 349px; float:right; margin-left: 0px; margin-top: 47px;">
            <asp:Button ID="btnAgregar" runat="server" style="margin-top: 34px" 
                Text="Agregar" Width="120px" Height="25px" />
            <asp:Button ID="btnModificar" runat="server" style="margin-top: 50px" 
                Text="Modificar" Width="120px" Height="25px" />
            <asp:Button ID="btnEliminar" runat="server" style="margin-top: 48px; margin-right: 0px;" 
                Text="Eliminar" Width="120px" Height="25px" />
        </div>
        <div >
                <ajaxToolkit:ModalPopupExtender 
                    ID="ModalPopudExtender" 
                    runat="server" 
                    TargetControlID="btnEliminar" 
                    PopupControlID="PNL" 
                    DropShadow="true" 
                    OkControlID="ButtonOk" 
                    CancelControlID="ButtonCancel" 
                    BackgroundCssClass="modalBackgroud">
                </ajaxToolkit:ModalPopupExtender>
                <ajaxToolkit:ModalPopupExtender 
                    ID="ModalPopupExtender1" 
                    runat="server" 
                    TargetControlID="btnModificar" 
                    PopupControlID="PanelModificar" 
                    DropShadow="true" 
                    OkControlID="ButtonOk" 
                    CancelControlID="ButtonCancel2" 
                    BackgroundCssClass="modalBackgroud">
                </ajaxToolkit:ModalPopupExtender>
                 <asp:Panel ID="PNL" runat="server" Height="70px" Width="387px" style="  background-color:White; border-width:2px; border-color:Black; border-style:solid; padding:20px;" 
                    BorderColor="#00FF99" BorderStyle="Dashed" BorderWidth="100px">
                    <asp:Label ID="lblMensajeConfirm" runat="server" Font-Size="11pt"  Text="¿Está seguro que elimiar esta pregunta?"></asp:Label>
                    <br /><br />
                    <div style="text-align:right; width:288px;">
                        <asp:Button ID="ButtonOk" runat="server" Text="OK" OnClientClick="llamarMetodoDelServer('eliminar')" style="margin-left: 0px"  Width="79px" />
                        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                            style="margin-left: 22px" Width="73px" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelModificar" runat="server" Height="70px" Width="407px" style="  background-color:White; border-width:2px; border-color:Black; border-style:solid; padding:20px;" 
                    BorderColor="#00FF99" BorderStyle="Dashed" BorderWidth="100px">
                    <asp:Label ID="Label1" runat="server" Font-Size="11pt"  Text="¿Está seguro que modificar esta pregunta?"></asp:Label>
                    <br /><br />
                    <div style="text-align:right; width:288px;">
                        <asp:Button ID="ButtonOk2" runat="server" Text="OK" OnClientClick="llamarMetodoDelServer('modificar')" style="margin-left: 0px"  Width="79px" />
                        <asp:Button ID="ButtonCancel2" runat="server" Text="Cancel" style="margin-left: 22px" Width="73px" />
                    </div>
                </asp:Panel>
           </div>
    </div>
</asp:Content>

