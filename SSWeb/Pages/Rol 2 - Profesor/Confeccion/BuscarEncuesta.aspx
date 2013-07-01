<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="BuscarEncuesta.aspx.vb" Inherits="Pages_Rol_2___Profesor_BuscarEncuesta" title="Buscar encuesta" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <%--Capa del contentenedor principal--%>
    <div id="Principal" style="height: 599px; width: 971px; text-align: left;">
    
    <div style="width: 845px; margin-left: 89px; margin-top: 43px;">
            <%--Div con el titulo de la pagina--%>
        <div id="DivTitulo" 
            
        
                style="height: 40px; text-align: left; margin-left: 292px; margin-top: 0px; margin-right: 0px;">
            <div style="width: 427px; height: 28px; margin-top: 9px; margin-left: 0px;">
                <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" Font-Size="20pt" ForeColor="#000066" 
                    Text="Gestión de encuesta"></asp:Label>
            </div>
        </div>
        <p>Selección de una encuesta previamente registrada</p>
            
            <%--Area de búsqueda de enucuestas--%>
         <div style="width: 616px; margin-left: 152px; height: 39px; margin-bottom: 0px;">
    
            <asp:Label ID="lblCriterio" runat="server" Font-Size="11pt" 
                Text="Buscar encuesta por nombre:"></asp:Label>
            <asp:TextBox ID="txtCriterio" runat="server" style="margin-left: 6px" 
                 Height="20px" Width="220px"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar " 
                ToolTip="Buscar una encuesta" Height="25px" style="margin-left: 14px" 
                Width="120px" />
            
         </div>
            <%--Capa donde se ubica el grid que muestras los resultados--%>
         <div style="width: 841px; margin-left: 3px; text-align: left; height: 360px;">
         
            <cc1:Grid ID="gvEncuestas" runat="server" AllowMultiRecordSelection="False" 
                 AllowPageSizeSelection="False" AllowSorting="False" PageSize="0" 
                 ShowFooter="False" ShowMultiPageGroupsInfo="False" Height="250px" 
                 style="text-align: center" Width="750px">
                 <ScrollingSettings ScrollHeight="240px" />
                 <LocalizationSettings NoRecordsText="No se encontraron encuestas para confección" />
             </cc1:Grid>
         
             <%-- Capa de botones y labels--%>
              <div style="height: 70px; margin-left: 4px; margin-top: 12px; width: 835px; text-align: center;">
            
                <asp:Label ID="lblError" runat="server" Text="Error" ForeColor="#FF3300" 
                Visible="False" Font-Size="11pt"></asp:Label>
                <br />
                <asp:Button ID="btnCrearCuestionario" runat="server"
                Text="Configuración de un cuestionario" 
                style="margin-left: 0px; margin-top: 13px;" 
                ToolTip="Configuración de un cuestionario" Width="241px" Height="30px" />
                <br />
                
              </div>
                 <br />
                 <br />
        </div>  
    </div>
    </div>
</asp:Content>

