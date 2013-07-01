<%@ Page Title="" Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="InfoEstadistica.aspx.vb" Inherits="pages_Rol_2___Profesor_InfoEstadistica" %>
    
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <br />
    <br />
    <div id="Principal" style="height: 596px">

  <div style="text-align: center">
  <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" 
          Font-Size="20pt" ForeColor="#000066" 
                    Text="Información estadística de encuestas" 
          style="text-align: center"></asp:Label>           
  </div>
       <p>
                Este módulo le ofrece la funcionalidad donde usted puede conocer la información estadística de las encuestas. Tales como moda, mediana, y percentiles.
        </p>

        <div id="listaEncuestas" style="float:left">
            <cc1:Grid ID="grnetEncuestas" runat="server" AllowAddingRecords="False" 
                AllowMultiRecordSelection="False" AllowPageSizeSelection="False" 
                AllowPaging="False" NumberOfPagesShownInFooter="0" PageSize="0" 
                ShowFooter="False" Height="220px">
                <GroupingSettings AllowChanges="False" />
                <LocalizationSettings NoRecordsText="No hay encuestas finalizadas." />
            </cc1:Grid>
            <asp:Label ID="lblError" runat="server" Font-Size="10pt" ForeColor="Red"></asp:Label>
        </div>
        <div id="botoncillo" 
            style="float:right; width: 179px; height: 179px; margin-top: 22px;">
            <asp:Button ID="btnVerInfo" runat="server" Text="Ver Estadísticas" 
                style="margin-top: 73px" Height="25px" Width="120px" />
        </div>
        
        <div id="Panel">
            <asp:Panel ID="PanelDatos" runat="server" Height="173px" 
            HorizontalAlign="Right" ScrollBars="Vertical" style="text-align: left; margin-left: 70px;" 
            Width="677px" BorderColor="Black" BorderStyle="Double">
        </asp:Panel>
        </div>
        
    </div>
    <style type="text/css">
        .Label
        {
          margin-left:19px;
        }
        #Panel
        {
            margin-top: 2px;
        }
        #listaEncuestas
        {
            height: 239px;
            width: 686px;
            margin-left: 71px;
            margin-top: 21px;
        }
    </style>
</asp:Content>

