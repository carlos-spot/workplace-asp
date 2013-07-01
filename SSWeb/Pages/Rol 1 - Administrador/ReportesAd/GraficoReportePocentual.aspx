<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 1 - Administrador/PrincipalAdministrador.master" AutoEventWireup="false" CodeFile="GraficoReportePocentual.aspx.vb" Inherits="Pages_Rol_2___Profesor_Confeccion_GraficoReportePocentual" title="Gráfico de porcentaje de respuestas tabuladas" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <br />
    <div>
        <h2 style="text-align: center; height: 1px;">
            <asp:Label ID="lblTitulo" runat="server" Text="titulo"></asp:Label>
        </h2>
    </div>
        <div id="reporte" 
            
    style="height: 190px; margin-top: 23px; width: 778px; margin-left: 93px; margin-right: 0px;">
            <CR:CrystalReportSource ID="crs1" runat="server">
                <Report FileName="~/Reportes/rptRespuestasTabuladasGrafico.rpt" >
                   <Parameters>
                        <CR:ControlParameter ControlID="" ConvertEmptyStringToNull="False" DefaultValue="0" Name="codEncuesta" PropertyName="" ReportName="" />
                    </Parameters>
                </Report>
            </CR:CrystalReportSource>
                <CR:CrystalReportViewer ID="crv1" runat="server" 
                    AutoDataBind="true" ReportSourceID="crs1" 
                    DisplayGroupTree="False" DisplayToolbar="False" />
        </div>
        <div style="text-align: right; margin-top: 284px">
        
                 <asp:Button ID="btnAtras" runat="server" Text="Regresar" style="margin-left: 0px" 
                Height="30px" Width="91px" />
        
        </div>
</asp:Content>

