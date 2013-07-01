
<%@ Page Language="VB" Title="Reporte porcentual de respuestas tabuladas" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="ReportePorcentualRespTabuladasP.aspx.vb" Inherits="Pages_Rol_2___Profesor_Confeccion_pruebareporte" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
   <%--Capa del contentenedor principal--%>
    <div id="Principal" style="height: 599px; width: 971px; text-align: left;">
    
    <div style="width: 845px; margin-left: 89px; margin-top: 43px;">
            <%--Títulos y descripción de la funcionalidad--%>
            <div id="DivTitulo" 
                
                style="height: 40px; width: 597px; text-align: left; margin-left: 128px; margin-top: 29px; margin-right: 0px;">
                <div style="width: 570px; height: 28px; margin-top: 9px; margin-left: 0px;">
                    <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" 
                        Font-Size="20pt" ForeColor="#000066" 
                        Text="Reporte porcentual de respuestas tabuladas"></asp:Label>
                </div>
            </div>
                
            <p style=" margin-left:0px; text-align: center; width: 843px;">Seleccione una 
                encuesta para visualizar su respectivo gráfico con la información de las 
                respuestas tabuladas</p>
            
            <%--Area de búsqueda de enucuestas--%>
         <div id="buscarEncuestas" 
                
                style=" width: 679px; margin-left: 116px; height: 42px; margin-bottom: 0px;">
    
            <asp:Label ID="lblCriterio" runat="server" Font-Size="11pt" 
                Text="Buscar encuesta por nombre:"></asp:Label>
            <asp:TextBox ID="txtCriterio" runat="server" style="margin-left: 6px" 
                 Height="20px" Width="220px"></asp:TextBox>
            
             &nbsp;<asp:Button ID="btnBuscar" runat="server" Height="25px" 
                 style="margin-left: 10px" Text="Buscar" Width="120px" />
            
             <br />
             <br />
         </div>
            <%--Capa donde se ubica el grid que muestras los resultados--%>
       
         <div id="gridEncuestas" style="width: 822px; margin-left: 3px; text-align: left; height: 272px; margin-top: 0px;">
         
            <cc1:Grid ID="gvEncuestas" runat="server" AllowMultiRecordSelection="False" 
                 AllowPageSizeSelection="False" AllowSorting="False" PageSize="0" 
                 ShowFooter="False" ShowMultiPageGroupsInfo="False" Height="250px" 
                 style="text-align: center" Width="500px">
                 <ScrollingSettings ScrollHeight="240px" />
                 <LocalizationSettings NoRecordsText="No se encontraron encuestas tabuladas" />
            </cc1:Grid>
            </div>
                <div ="botonReporte" style="text-align: center">
                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Font-Size="11pt"></asp:Label>
                        <br />
                        <br />
                    <asp:Button ID="btnReporte" runat="server" Text="Generar reporte" Height="25px" 
                        Width="120px" />                 
                </div>
       </div>
    </div>
</asp:Content>
