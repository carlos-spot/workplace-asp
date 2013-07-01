<%@ Page Title="" Language="VB" MasterPageFile="../PrincipalProfesor.master" AutoEventWireup="false" CodeFile="Analisis.aspx.vb" Inherits="pages_Rol_2___Profesor_Analisis" %>
<%@ Register TagPrefix="obout" Namespace="Obout.Grid" Assembly="obout_Grid_NET" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <br />
  <div style="text-align: center; height: 35px; margin-top: 20px;">
  <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" 
          Font-Size="20pt" ForeColor="#000066" 
                    Text="Módulo para la tabulación de encuestas" 
          style="text-align: center"></asp:Label>           
  </div>
       <p>
                Este módulo tiene las funcionalidades necesarias para el satisfactorio análisis de las encuestas.
        </p>
    <script src="../../../js/crearTabla.js" type="text/javascript"></script>
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
            <div id="menu" style="width: 749px; height: 50px; margin-left: 132px; margin-top: 0px; text-align: center;">
                <div id="botonUno" style="width: 160px; float:left; margin-left:110px">
                    <asp:Button ID="btnFinalizarEnc" runat="server" Height="25px" Width="120px" 
                        Text="Finalizar encuesta" />
                </div>
                
                <div id="botonDos" style="width: 170px; float:left; margin-left:24px">
                    <asp:Button ID="btnTabAbiertas" runat="server" Height="25px" Width="170px" 
                        Text="Tabular preguntas abiertas" Enabled="true"/>
                </div>
                
                <div id="botonTres" style="width: 160px; float:left; margin-left:27px">
                    <asp:Button ID="bTabular" runat="server" Height="25px" Width="120px" 
                        Text="Ver resultados"/>
                </div>
                
            </div>
        </div> 
    <br/>    
</asp:Content>

