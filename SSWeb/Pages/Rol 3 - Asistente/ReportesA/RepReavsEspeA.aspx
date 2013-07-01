<%@ Page Title="" Language="VB" MasterPageFile="~/Pages/Rol 3 - Asistente/PrincipalAsistente.master" AutoEventWireup="false" CodeFile="RepReavsEspeA.aspx.vb" Inherits="pages_Rol_2___Profesor_Analisis_ReportesPantallas_RepReavsEspe" %>
<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
       <div id="g">
        <div id="subg">
            <div>
                <asp:Label ID="Label1" runat="server" Text="."></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Text="."></asp:Label>
            </div>
            <div id="intro" 
                style="width: 805px; text-align: center; margin-left: 47px; margin-top: 0px;">
                <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" Font-Size="20pt" ForeColor="#000066" Text="Reporte de respuestas reales vs respuestas esperadas"></asp:Label>
                <p>Este reporte genera una comparación de la cantidad de las respuestas esperadas 
                    contra las reales de los contactos a los que fue dirigida la encuesta.</p> 
            </div>
            <div id="botonRep" 
                
                style="height: 1px; width: 339px; margin-left: 0px; margin-right: 0px; margin-top: 0px;">
            <asp:Button ID="btnVer" runat="server" Text="Ver" Height="25px" 
                    style="margin-left: 788px; margin-top: 104px;" Width="120px" />
            </div> 
            <div id="listaEncuestas" 
                style="width: 630px; margin-left: 96px; margin-top: 1px; height: 249px;" ;>   
                <cc1:Grid ID="grnetEncuestas" runat="server" AllowMultiRecordSelection="False" 
                AllowSorting="False" Height="250px" ShowFooter="False" PageSize="0">
                <ScrollingSettings ScrollHeight="250px" />
                <LocalizationSettings NoRecordsText="No existen encuestas finalizadas" />
                </cc1:Grid>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Size="11pt"></asp:Label>
            </div> 
            <div id="reporte" style="height: 220px; margin-top: 16px;";>
                <asp:Panel ID="pnlReporte" runat="server" BorderStyle="None" Height="200px" 
                    ScrollBars="Auto">    
                    <CR:CrystalReportSource ID="crs01" runat="server">
                        <Report FileName="~/Reportes/RealesvsEsperadas.rpt" >
                            <Parameters>
                            <CR:ControlParameter ControlID="" ConvertEmptyStringToNull="False" 
                                DefaultValue="0" Name="idEncuesta" PropertyName="" ReportName="" />
                        </Parameters>
                        </Report>
                    </CR:CrystalReportSource>
                    <CR:CrystalReportViewer ID="crv01" runat="server" 
                            AutoDataBind="true" ReportSourceID="crs01" 
                            DisplayGroupTree="False" />
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

