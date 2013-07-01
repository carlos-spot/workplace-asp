<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="VistaReporteComparacionP.aspx.vb" Inherits="Pages_Rol_1___Administrador_Reportes_VistaReporteComparacion" title="Reporte comparativo" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <div id ="DivPrincipal" style="height: 604px">
        <div id="SubDivPrincipal" style="height: 514px; width: 844px; margin-left: 43px; margin-top: 28px; text-align: left;">
                <h3>
                    Reporte comparativo de dos encuestas</h3>
            <CR:CrystalReportSource ID="crsComparacion" runat="server">
                <Report FileName="~/Reportes/ReporteComparativo.rpt" >
                    <Parameters>
                        <CR:ControlParameter ControlID="" ConvertEmptyStringToNull="False" DefaultValue="1" Name="codEncuesta1" PropertyName="" ReportName="" />
                        <CR:ControlParameter ControlID="" ConvertEmptyStringToNull="False" DefaultValue="1" Name="codEncuesta2" PropertyName="" ReportName="" />
                    </Parameters>
                </Report>
            </CR:CrystalReportSource>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                    AutoDataBind="true" ReportSourceID="crsComparacion" 
                    DisplayGroupTree="False" />
        </div>
        <div style="text-align: right">
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" Height="25px" 
                style="margin-right: 50px" Width="120px" />
        </div>
    </div>
</asp:Content>

