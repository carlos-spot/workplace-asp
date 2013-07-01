<%@ Page Title="" Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="GestionArchivos.aspx.vb" Inherits="pages_Rol_2___Profesor_GestionArchivos" %>
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
            
            style="float:left; width: 694px; height: 272px; margin-top: 0px; margin-left: 113px;">
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Size="11pt"></asp:Label><br/>
            <cc1:Grid ID="grnetEncuestas" runat="server" AllowAddingRecords="False" 
                AllowMultiRecordSelection="False" AllowSorting="False" ShowFooter="False" 
                Height="250px" >
                <ScrollingSettings ScrollHeight="400px" />
                <LocalizationSettings NoRecordsText="No hay encuestas finalizadas en el sistema" />
            </cc1:Grid>
        </div><br/><br/>
        <div id="Cargador" style="text-align: left; margin-top: 0px; height: 213px;"><br/>
        <div style="width: 304px; height: 175px; float:left; border: medium dotted #74B7DE; background-color: #D4D4D4; width: 404px; margin-left: 73px; text-align: center; margin-right: 0px;">
                    <h2 style="color: #000000">Carga de archivos</h2>
            <asp:Label ID="lblRetro" runat="server" ForeColor="Red" Font-Size="10pt"></asp:Label><br/>
            <asp:FileUpload ID="fuArchivo" runat="server" style="margin-top: 11px" Height="30px" 
                        Width="370px"/>
                    <br />
                    <br />
            <asp:Button ID="btnSubir" runat="server" Text="Subir Archivo" 
                        style="margin-top: 8px; margin-left: 0px; margin-right: 0px;" Height="25px" 
                        Width="120px" />  
        </div>
            <div id="menu" 
                
                
                
                
                style="width: 304px; height: 175px; border: medium dotted #74B7DE; float:right; background-color: #D4D4D4; width: 399px; margin-left: 6px; text-align: center; margin-right: 77px;">
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

