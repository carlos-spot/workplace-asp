<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 3 - Asistente/PrincipalAsistente.master" AutoEventWireup="false" CodeFile="ModificarEncuesta.aspx.vb" Inherits="Pages_Rol_3___Asistente_ModificarEncuesta" title="Modificar parametros" %>

<%@ Register assembly="obout_Calendar2_Net" namespace="OboutInc.Calendar2" tagprefix="obout" %>

<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">

 <div id = "contenedorSeguimiento">
    
    
        <h2 style="margin-top:20px ; text-align:center">Modificar par<em>á</em>metros de encuesta</h2> 
       <div id="DivContentInformacionLbls"  style=" border-left: thin none #7DD780; border-right: thin none #7DD780; border-top: thin ridge #7DD780; border-bottom: thin ridge #7DD780; height:76px; margin-top:5px; margin-bottom:14px; width: 718px; margin-left: 133px;">
                      
                     <div id="ContentLeftLbl" style ="height:70px; width: 291px; float:left; padding-left:35px; margin-left: 28px;">
                         <b>Encuesta #</b> <asp:Label ID="lblIdEncuesta" runat="server" Text="Error Excepciones"></asp:Label><br />
                     <b>Nombre encuesta:</b><asp:Label ID="lblNombreEncuesta" runat="server" Text="Error Excepciones"></asp:Label><br />
                    <b>Fecha de inicio: </b><asp:Label ID="lblInicio" runat="server" Text="Error Excepciones"></asp:Label><br />
                    <b>Fecha de fin: </b><asp:Label ID="lblFin" runat="server" Text="Error Excepciones"></asp:Label>
                    
                     </div>
                     <div id="ContentRigLbl" 
                                
                                style ="height:70px; width: 258px; float:left; padding-left:100px; margin-left: 0px;">
                      <b>Poblaci&oacute;n: </b><asp:Label ID="lblPoblacion" runat="server" Text="Error Excepciones"></asp:Label><br />
                     <b>Muestra: </b><asp:Label ID="lblMuestra" runat="server" Text="Error Excepciones"></asp:Label><br />
                    <b>Margen: </b> <asp:Label ID="lblMargen" runat="server" Text="Error Excepciones"></asp:Label><br />
                    <b>Tema: </b><asp:Label ID="lblTema" runat="server" Text="Error Excepciones"></asp:Label>
                    
                     </div>
                 </div>
  </div>
                        
         <p>Para modificar la encuesta debes dar click en una de las siguientes opciones</p>
    <div id="botones" style="width: 423px; margin-left: 285px; clear:both">
    <asp:Button ID="btnModificarMuestra" runat="server" Text="Modificar muestra" 
            Height="25px" Width="120px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnRealizarProrroga" runat="server" Text="Realizar prórroga" 
            Height="25px" Width="120px" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAtras" runat="server" Text="Regresar" Height="25px" 
            Width="120px" />
        <br />
    <br /></div>
                
        <div id="Contentmodificadores" style="text-align: left">
            <div id="modificadores" 
                
                
                style=" width:377px; padding-left:300px; text-align:center; margin-top: 0px;">
        
            
            <asp:Label ID="lblInformacion" runat="server" Text="Error Excepciones" 
                    Font-Size="11pt"></asp:Label>
                
            
    &nbsp;<asp:Panel ID="pModificarMuestra" runat="server" Height="120px" Width="369px">
        
        <h4>Modificar Muestra</h4>
    <br />
    <asp:TextBox ID="txtMuestra" runat="server" Columns="5" MaxLength="5" Width="64px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar Cambios" Height="25px" 
                        Width="120px" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancelar" runat="server" Height="25px" Text="Cancelar" Width="120px" />
    <br />
    <br />
    <asp:Label ID="lblError" runat="server" Text="Error" ForeColor="Red"></asp:Label>
</asp:Panel>
   
    
       <asp:Panel ID="pprorroga" runat="server" Height="289px" Width="372px">
        <h4>Seleccionar la fecha de la prorroga</h4><br />
        <obout:Calendar ID="calendario" runat="server">
        </obout:Calendar>
        <br />
        <br />
        <asp:Button ID="btnGuardarProrroga" runat="server" Text="Guardar cambios" 
               Height="25px" Width="120px" />
           &nbsp;&nbsp;&nbsp;
           <asp:Button ID="btnCancelar0" runat="server" Height="25px" Text="Cancelar" 
               Width="120px" />
           <br />
           <asp:Label ID="lblErrorProrroga" runat="server" ForeColor="Red" Text="Error" 
               Font-Size="11pt"></asp:Label>
        <br />
        <br />
        <br />
    </asp:Panel>
    <p>
        &nbsp;</p>
        </div>
        </div>
</asp:Content>

