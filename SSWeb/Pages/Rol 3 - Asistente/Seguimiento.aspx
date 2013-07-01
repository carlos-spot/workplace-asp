<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 3 - Asistente/PrincipalAsistente.master" AutoEventWireup="True" CodeFile="Seguimiento.aspx.vb" Inherits="Pages_Rol_3___Asistente_Seguimiento" title="Seguimiento" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">

    <div id="contenedorSeguimiento" >
        <div style="width: 714px; height: 148px; margin-left: 129px; text-align: center;">
        .<br />.<br />
        <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" 
          Font-Size="20pt" ForeColor="#000066" 
                    Text="Encuestas en proceso de seguimiento" 
          style="text-align: center"></asp:Label>  
        <p>En este módulo podrá dar seguimiento a una encuesta ya sea invitando contactos, 
            modificar los parametros de una encuesta para realizar prórroga o modificar la 
            muestra.</p>
            
        </div>
        
        <div style="width: 414px; margin-left: 305px">
        <asp:Button ID="btnInvitarContactos" runat="server" Text="Invitar contactos"  
                Height="25px" Width="170px" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnModificarEncuesta" runat="server" Text="Modificar parámetros" 
                Height="25px" Width="170px" />
        &nbsp;&nbsp;&nbsp;
                
        </div>
        
        <br />
       
        <div style="width: 530px; margin-left: 79px; height: 221px;">
            <cc1:Grid ID="gvEncuestas" runat="server" AllowAddingRecords="False" 
                AllowMultiRecordSelection="False" AllowPageSizeSelection="False" 
                AllowSorting="False" PageSize="0" Height="300px" ShowFooter="False">
                <ScrollingSettings ScrollHeight="300px" />
            </cc1:Grid>
        </div>
                
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div style="width: 962px; margin-left: 3px; text-align:center"><asp:Label ID="lblError" runat="server" Text="lblError" Font-Size="12pt" ForeColor="Red"></asp:Label></div>
       <div id="" style="text-align: right">
           <asp:Button ID="Volver" runat="server" Text="Regresar" Width="120px" 
               Height="25px" style="margin-right: 46px" />
        </div>
    </div>
</asp:Content>

