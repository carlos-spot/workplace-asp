<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 3 - Asistente/PrincipalAsistente.master" AutoEventWireup="false" CodeFile="HomeTemaA.aspx.vb" Inherits="Pages_Rol_3___Asistente_HomeTemaA" title="Mantenimiento de tema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <div id="Contenedor" style="width: 979px; font-size: 16px; text-align:justify; padding-top: 10px; height: 557px; ">
        
        <div id="Parrafo" style="height: 450px; float:left; width: 642px; text-align: left; margin-left: 85px; margin-top: 17px;">
            <div id="Titulo" 
                style="height: 35px; width: 622px; text-align: center; margin-left: 0px; margin-top: 32px;">
                <asp:Label ID="lblMantenimiento" runat="server" Enabled="False" Font-Names="Arial" Font-Size="20pt" ForeColor="#000066" 
                    Text="Mantenimiento de temas"></asp:Label>
            </div>
            <p style="font-size:20px; text-align:center; width:620px; height: 69px; line-height: 25px; margin-bottom: 0px;" >
                El mantenimiento de tema consiste en la funcionalidades de: registrar, modificar, 
                eliminar y consultar un determinado tema.
            </p>            
            <p style="font-size:20px; text-align:center; width:620px; height: 64px; line-height: 25px; margin-bottom: 0px;">
                En este modulo podra organizar todo lo que tenga que ver a los temas. 
                Un tema esta presente en los siguientes conseptos:
            </p>
            <ol style="font-size:20px; text-align:left; width:199px; height: 89px; line-height: 25px; margin-top: 5px; margin-bottom: 0px; margin-left: 225px;">
                <li>Una encuesta.</li>
                <li>Una pregunta.</li>
                <li>Un producto.</li>
            </ol>
        </div>
        <div style="height: 87px; float:right; width: 170px; text-align: left; margin-top: 187px; margin-right: 72px; margin-left: 0px;">
            <div style="width: 149px; margin-top: 9px; text-align: center; margin-left: 17px;">
            <br />
                <asp:Button ID="btnConfigurar" runat="server" Height="25px" 
                    Text="Configurar temas" Width="120px" />
            </div>
        </div>
    </div>
</asp:Content>
