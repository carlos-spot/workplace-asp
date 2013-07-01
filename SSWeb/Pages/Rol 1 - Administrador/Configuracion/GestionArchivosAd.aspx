<%@ Page Title="" Language="VB" MasterPageFile="~/Pages/Rol 1 - Administrador/PrincipalAdministrador.master" AutoEventWireup="false" CodeFile="GestionArchivosAd.aspx.vb" Inherits="Pages_Rol_1___Administrador_Configuracion_GestionArchivosAd" %>
<%@ Register TagPrefix="obout" Namespace="Obout.Grid" Assembly="obout_Grid_NET" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
         <br />
        <div style="text-align: center; height: 35px; margin-top: 20px;">
        <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" 
        Font-Size="20pt" ForeColor="#000066" 
        Text="Gestión de archivos" 
        style="text-align: center"></asp:Label>           
        </div>
        <p>
        En este modulo podrá realizar la gestión de sus archivos, carga y descarga de 
        archivos al portal.
        </p>
        
        <div id="0" 
            
             style="float:left; width: 694px; height: 279px; margin-top: 0px; margin-left: 96px;">
            <cc1:Grid ID="gvEncuesta" runat="server" AllowMultiRecordSelection="False" 
                    AllowPageSizeSelection="False" AllowSorting="False" Height="250px" PageSize="0" 
                    ShowFooter="False" ShowMultiPageGroupsInfo="False" style="text-align: left" 
                    Width="750px">
                    <scrollingsettings scrollheight="250px" />
                    <localizationsettings norecordstext="No se encontraron encuestas para este periodo" />
                </cc1:Grid>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Size="11pt"></asp:Label>
        </div><br/><br/>
        <div id="Cargador" style="text-align: left; margin-top: 0px; height: 213px;"><br/>
            <div id="menu" 
                
                
                
                
                
                style="width: 304px; height: 175px; border: medium dotted #74B7DE; float:right; background-color: #D4D4D4; width: 510px; margin-left: 33px; text-align: center; margin-right: 241px;">
            <h2>Descarga de archivos</h2>
                <asp:Label ID="lblRetro1" runat="server" ForeColor="Red" Font-Size="10pt"></asp:Label><br />
            <asp:Button ID="pdf" runat="server" Text="Descargar PDF" 
                style="margin-top: 15px" Height="25px" Width="120px"/>
            <br />
            <br />
            <asp:Button ID="doc" runat="server" Text="Descargar DOC" style="margin-top: 0px" 
                    Width="120px" Height="25px" />
            </div>
        </div>
    
</asp:Content>

