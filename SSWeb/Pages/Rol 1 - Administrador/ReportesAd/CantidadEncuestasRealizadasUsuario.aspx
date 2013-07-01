<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 1 - Administrador/PrincipalAdministrador.master" AutoEventWireup="false" CodeFile="CantidadEncuestasRealizadasUsuario.aspx.vb" Inherits="Reporte_CantidadEncuestasRealizadasUsuario" title="Reporte Cantidad encuestas analizadas por un usuario" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <div id= "contenedorPrincipalCrystal" style =" height:500px; padding-top:0px">

        <CR:CrystalReportSource ID="CrystalReportAnalisisSource" runat="server">
            <Report FileName="~/Reportes/CantidadAnalisisUsuario.rpt">
                <Parameters>
                    <CR:ControlParameter ControlID="" ConvertEmptyStringToNull="False" 
                        DefaultValue="6" Name="idAnalista" PropertyName="" ReportName="" />
                </Parameters>
            </Report>
        </CR:CrystalReportSource>

        <a href="CantidadEncuestasRealizadasUsuario.aspx">
        </a><CR:CrystalReportViewer ID="CrystalReportAnalisisViewer" runat="server" 
        AutoDataBind="true" ReportSourceID="CrystalReportAnalisisSource" />

</div>
<div id="bton" style =" text-align:right ">
    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" />
</div>

</asp:Content>

