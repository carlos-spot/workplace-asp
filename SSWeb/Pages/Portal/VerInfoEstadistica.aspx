<%@ Page Language="VB" MasterPageFile="~/Pages/Portal/PrincipalPortal.master" AutoEventWireup="false" CodeFile="VerInfoEstadistica.aspx.vb" Inherits="Pages_Rol_1___Administrador_VerInfoEstadistica" title="Ver resultados de encuesta" %>
<%@ Register TagPrefix="obout" Namespace="Obout.Grid" Assembly="obout_Grid_NET" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenedorPortal" Runat="Server">
    <br />
  <div style="text-align: center; height: 35px; margin-top: 20px;">
  <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" 
          Font-Size="20pt" ForeColor="#000066" 
                    Text="Módulo para ver los resultados de encuestas" 
          style="text-align: center"></asp:Label>           
  </div>
       <p>
                Este módulo tiene las funcionalidades necesarias para el satisfactorio análisis de las encuestas finalizadas.
        </p>
    <script src="../../js/crearTabla.js" type="text/javascript"></script>
    <br/>
        
        <div id="Contenedor" 
        style="margin:0px auto 0px 1px; height: 454px; width: 966px;" >

            <div id="Principal" 
                style="width: 750px; height: 343px; margin-top: 9px; margin-left: 130px;">
                <cc1:Grid ID="gvEncuesta" runat="server" AllowMultiRecordSelection="False" 
                    AllowPageSizeSelection="False" AllowSorting="False" Height="300px" PageSize="0" 
                    ShowFooter="False" ShowMultiPageGroupsInfo="False" style="text-align: left" 
                    Width="750px">
                    <scrollingsettings scrollheight="300px" />
                    <localizationsettings norecordstext="No se encontraron encuestas para este periodo" />
                </cc1:Grid>
                <br/>
                <div style="text-align: center">
                    <asp:Label ID="lblError" runat="server" style="text-align: right" ForeColor="Red" Font-Size="11pt"></asp:Label>
                </div>
            </div>  
            <div id="menu" 
                
                style="width: 749px; height: 50px; margin-left: 132px; margin-top: 0px; text-align: center;">
                <asp:Button ID="bTabular" runat="server" Text="Ver resultados" Enabled="true" 
                    style="margin-top: 4px" Width="120px" Height="25px" 
                    UseSubmitBehavior="False" />
                <br/>
                <br />
            </div>
        </div> 
    <br/>    
</asp:Content>

