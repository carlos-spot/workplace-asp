<%@ Page Title="" Language="VB" MasterPageFile="~/Pages/Rol 3 - Asistente/PrincipalAsistente.master" AutoEventWireup="false" CodeFile="GestionArchivosAs.aspx.vb" Inherits="Pages_Rol_3___Asistente_GestionArchivosAs" %>
<%@ Register TagPrefix="obout" Namespace="Obout.Grid" Assembly="obout_Grid_NET" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
   <div id="Principal" style="height: 600px; margin-top: 0px">
        <br />
        <div id="Titulo" style="text-align: center; height: 32px; margin-top: 16px;">
            <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" Font-Size="20pt" ForeColor="#000066" 
            Text="Gestión de archivos" style="text-align: center"></asp:Label>           
        </div>
        <div id="Parrafo">
            <p>En este modulo podrá&nbsp; descargar el archivo PDF de cualquier encuesta 
                finalizada.
            </p>
        </div>
        <div id="0" 
            style="float:left; width: 750px; height: 279px; margin-top: 0px; margin-left: 98px;">
            <div style="text-align: center">
                <cc1:Grid ID="gvEncuesta" runat="server" AllowMultiRecordSelection="False" 
                    AllowPageSizeSelection="False" AllowSorting="False" Height="250px" PageSize="0" 
                    ShowFooter="False" ShowMultiPageGroupsInfo="False" style="text-align: left" 
                    Width="750px">
                    <scrollingsettings scrollheight="250px" />
                    <localizationsettings norecordstext="No se encontraron encuestas para este periodo" />
                </cc1:Grid>
            </div>
            <div style="text-align: center">
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Size="11pt"></asp:Label>
            </div>
        </div><br/><br/>
        <div id="Cargador" style="text-align: left; margin-top: 0px; height: 213px;"><br/>
            <div id="menu" 
                
                
                style="width: 304px; height: 156px; border: medium dotted #74B7DE; float:right; background-color: #D4D4D4; width: 437px; margin-left: 6px; text-align: center; margin-right: 302px;">
            <h2>&nbsp;</h2>
                <h2>Descarga de archivos</h2>
                <asp:Label ID="lblRetro1" runat="server" ForeColor="Red" Font-Size="10pt"></asp:Label><br />
            <asp:Button ID="pdf" runat="server" Text="Descargar PDF" 
                style="margin-top: 15px" Height="25px" Width="120px"/>
            <br />
            <br />
            </div>
        </div>
    </div>
</asp:Content>