<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="CantidadEncuestasPorTemaDadoPeriodoP.aspx.vb" Inherits="Reporte_CantidadEncuestasPorTemaDadoPeriodo" title="Cantidad de encuestas de un tema" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
<div id= "contenedorPrincipalCrystal" style =" height:500px; padding-top:0px">

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
    AutoDataBind="true" ReportSourceID="CrystalReportSource1" 
        style="text-align: left" />
<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
    <Report FileName="~/Reportes/CantidadEncuestasPorTemaDadoPeriodo.rpt">
        <Parameters>
            <CR:ControlParameter ControlID="" ConvertEmptyStringToNull="False" 
                DefaultValue="" Name="pcodigoPeriodo" PropertyName="" ReportName="" />
            <CR:ControlParameter ControlID="" ConvertEmptyStringToNull="False" 
                DefaultValue="" Name="pcodigoTema" PropertyName="" ReportName="" />
        </Parameters>
    </Report>
</CR:CrystalReportSource>
</div>
<div id="bton" style =" text-align:right ">
    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" />
</div>
</asp:Content>

