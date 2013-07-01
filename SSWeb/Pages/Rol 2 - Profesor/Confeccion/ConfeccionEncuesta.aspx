<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="ConfeccionEncuesta.aspx.vb" Inherits="Pages_Rol_2___Profesor_ConfeccionEncuesta" title="Confecci&oacute;n de cuestionario" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>
<%@ Register assembly="obout_Interface" namespace="Obout.Interface" tagprefix="cc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <br />
    <br />
    <div style="height: 568px; margin-right: 47px;">
        <h2 style="height: 31px; width: 606px; margin-left: 230px; margin-top: 0px;">Confecci&oacute;n de cuestionario:
            <asp:Label ID="lblTitulo" runat="server" Text="Encuesta" Visible="False" 
                Font-Bold="False" Font-Size="12pt"></asp:Label>
                                 </h2>
        <p>Editar opciones, crear, modificar y eliminar preguntas en el cuestionario</p>
    <div style="height: 463px">
        
    <div style="height: 44px; width: 930px; margin-left: 3px; text-align: center;">
        
        <asp:Button ID="btnAgregarPreguntaPila" runat="server"
            Text="Agregar pregunta de pila" Width="190px" Height="25px" 
            style="margin-left: 10px" />
        
        <asp:Button ID="btnClonarEncuesta" runat="server" 
            Text="Clonar preguntas" Width="190px" Height="25px" 
            style="margin-left: 10px" />
    
        <asp:Button ID="btnVistaPrevia" runat="server" 
            Text="Vista previa" Width="190px" Height="25px" 
            style="margin-left: 10px" />
    
    </div>  
    <br />
    <%--Div que contiene los datos del tema--%>
    <div id="DivPreguntas"  
            
            style="border-left: medium dotted #339933; border-right: medium dotted #339933; border-top: medium double #339933; border-bottom: medium double #339933; height: 330px; width: 870px; text-align: left; margin-left: 54px; margin-top: 0px; ">           
                <%--Campo para el nombre del tema--%>
                      
     <div style=" float:left; width: 503px; margin-left: 35px; height: 274px; margin-top: 7px;">
        <cc1:Grid ID="gvPreguntas" runat="server" AllowAddingRecords="False" 
            AllowMultiRecordSelection="False" AllowSorting="False" ShowFooter="False" 
            Width="300px" Height="280px">
            <LocalizationSettings NoRecordsText="No hay preguntas registradas" />
        </cc1:Grid>
    </div>
     <div style="width: 182px; float:right; margin-left: 0px; height: 283px; margin-right: 42px;">
            <br />

            <br />
        
            <asp:Button ID="btnAgregarPregunta" runat="server" 
          Text="Agregar pregunta" Width="174px" Height="25px" style="margin-top: 14px" />

            <asp:Button ID="btnModificar" runat="server" Text="Modificar pregunta" 
                 style="margin-left: 0px; margin-top: 21px;" Height="25px" 
                Width="175px" />       
             <br />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar pregunta" 
                 Height="25px" Width="175px" 
                style="margin-left: 0px; margin-top: 18px;" />
        
        </div>
                     <div style="width: 535px; margin-left: 3px; float: left; text-align: center;">
                         <asp:Label ID="lblError" runat="server" Text="Label" Font-Size="11pt" 
                             ForeColor="Red" style="text-align: center"></asp:Label>  
                     </div>
                     <br />
                     <br />
                     <br />
                     
        <%--Div que muestra los errores al usuario--%>
                </div>
                     <br />
                       <div style="width: 927px; margin-left: 3px; height: 44px; text-align: center;">
                        <asp:Button ID="btnNotificacion" runat="server" 
                            Text="Finalizar confección" Height="25px" Width="175px" 
                               style="margin-left: 10px" />
                       <asp:Button ID="btnGuardarCuestionario" runat="server" 
                            Text="Salir de confección" Height="25px" style="margin-left: 36px" 
                               Width="175px" 
                               
                               ToolTip="Salir a pantalla principal, los datos fuero actuales están almacenados" />
                 </div>
    
                <asp:Panel ID="PanelModificar" runat="server" Height="70px" Width="407px" style="display:none; background-color:White; border-width:2px; border-color:Black; border-style:solid; padding:20px;" 
                    BorderColor="#00FF99" BorderStyle="Dashed" BorderWidth="100px">
                    <asp:Label ID="Label5" runat="server" Font-Size="11pt"  Text="¿Estas seguro de que deseas modificar este tema?"></asp:Label>
                    <br /><br />
                    <div style="text-align:right; width:288px;">
                        <asp:Button ID="ButtonOk2" runat="server" Text="OK" OnClientClick="llamarMetodoDelServer('modificar')" style="margin-left: 0px"  Width="79px" />
                        <asp:Button ID="ButtonCancel2" runat="server" Text="Cancel" style="margin-left: 22px" Width="73px" />
                    </div>
                </asp:Panel>
           </div>
        </div>
</asp:Content>

