<%@ Page Language="VB" MasterPageFile="~/Pages/Portal/PrincipalPortal.master" AutoEventWireup="false" CodeFile="ComparacionEncuestasPO.aspx.vb" Inherits="Pages_Rol_1___Administrador_Reportes_ComparacionEncuestas" title="Reporte comparativo" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenedorPortal" Runat="Server">
    <%--Inicia el div principal de la página--%>
    <div id="DivPrincipal" style="height: 603px">
        <div id="SubPrincipal" style="width: 813px; margin-left: 55px">
            <%--Div con el titulo de la pagina--%>
            <div id="DivTitulo" 
                style="height: 40px; width: 691px; text-align: left; margin-left: 58px; margin-top: 29px; margin-right: 0px;">
                <div style="width: 692px; height: 28px; margin-top: 9px; margin-left: 0px; text-align: center;">
                    <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" 
                        Font-Size="20pt" ForeColor="#000066" 
                        Text="Reporte comparativo de dos encuestas"></asp:Label>
                <asp:ListBox ID="lbCodigosPeriodos" runat="server" Height="21px" Width="17px" 
                        Visible="False">
                </asp:ListBox>
                <asp:ListBox ID="lbCodigosTemas" runat="server" Height="21px" Width="17px" 
                        Visible="False">
                </asp:ListBox>
                </div>
            </div>
            
            <%--Campo para seleccionar el periodo de la encuesta--%>
            <div id="DivPeriodo" 
                style=" margin: 4px auto 0px 58px; height: 39px; width: 689px;">
                <div id="DivSubPeriodo" 
                    
                    style="float:left; width: 681px; height: 38px; margin-left: 0px; margin-top: 0px; text-align: left;">
                    <asp:Label ID="lblTexto" runat="server" Font-Size="11pt"  
                        Text="Para poder realizar el reporte se necesitan dos o más encuestas finalizadas de un mismo periodo."></asp:Label>
                    <br />
                    <asp:Label ID="lblPeriodo" runat="server" Font-Size="11pt"  Text="Periodo:" 
                        Font-Bold="True" Font-Names="Arial"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlPeriodos" runat="server" Height="20px" 
                        Width="220px">
                        
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblTema" runat="server" Font-Size="11pt"  Text="Tema:" 
                        Font-Bold="True" Font-Names="Arial"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlTemas" runat="server" Height="20px" Width="220px" 
                        AutoPostBack="True">
                        
                    </asp:DropDownList>
                </div>
            </div>
            
            <%--Campo para seleccionar la primera encuesta--%>
            <div id="Div1Encuesta" 
                style=" margin: 4px auto 0px 58px; height: 191px; width: 690px;">
                <div id="SubDiv1Encuesta" 
                    style="float:left; width: 689px; height: 189px; margin-left: 0px; margin-top: 7px; text-align: left;">
                    <asp:Label ID="lblPrimeraEncuesta" runat="server" Font-Size="11pt"  
                        Text="Seleccione la primera encuesta:" Font-Bold="True"></asp:Label>
                    <br />
                    <div id="Grid1Encuesta" style="height: 179px; width: 679px">
                        <cc1:Grid ID="gvPrimeraEncuesta" runat="server" 
                            AllowMultiRecordSelection="False" AllowPageSizeSelection="False" 
                            AllowSorting="False" Height="170px" PageSize="0" ShowFooter="False" 
                            ShowMultiPageGroupsInfo="False" style="text-align: left" Width="750px">
                             <scrollingsettings scrollheight="170px" />
                             <localizationsettings norecordstext="No se encontraron encuestas para este periodo" />
                        </cc1:Grid>
                    </div>
                </div>
            </div>
             <%--Campo del boton comparara--%>
            <div id="DivComparar" 
                style=" margin: 4px auto 0px 58px; height: 31px; width: 688px; text-align: right;">
                <div id="SubDivComparar" 
                    style="float:left; width: 682px; height: 1px; margin-left: 0px; margin-top: 7px; text-align: right;">
                    <asp:Button ID="btnComparar" runat="server" Text="Comparar encuesta" 
                        Height="25px" style="margin-left: 0px; text-align: center;" Width="130px" 
                        Enabled="False" />
                </div>
            </div>
            
            <%--Campo para seleccionar la segunda encuesta--%>
            <div id="Div2Encuesta" 
                style=" margin: 4px 0px 0px 58px; height: 178px; width: 690px;">
                <div id="SubDiv2Encuesta" style="float:left; width: 689px; height: 196px; margin-left: 0px; margin-top: 7px; text-align: left;">
                    <asp:Label ID="lblSegundaEncuesta" runat="server" Font-Size="11pt"  
                        Text="Seleccione la segunda encuesta:" Font-Bold="True"></asp:Label>
                    <br />
                    <div id="Grid2Encuesta" style="height: 175px; width: 679px">
                        <cc1:Grid ID="gvSegundaEncuesta" runat="server" 
                            AllowMultiRecordSelection="False" AllowPageSizeSelection="False" 
                            AllowSorting="False" Height="170px" PageSize="0" ShowFooter="False" 
                            ShowMultiPageGroupsInfo="False" style="text-align: left" Width="750px">
                             <scrollingsettings scrollheight="170px" />
                             <localizationsettings norecordstext="No se encontraron encuestas para este periodo" />
                        </cc1:Grid>
                    </div>
                </div>
            </div>
            
            <%--Campo del boton generar--%>
            <div id="DivBtnGenerar" 
                
                style=" margin: 4px auto 0px 58px; height: 38px; width: 688px; text-align: right;">
                <div id="SubDivBtnGenerar" 
                    
                    
                    style="float:left; width: 682px; height: 25px; margin-left: 0px; margin-top: 7px; text-align: right;">
                    <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar reporte" 
                        Height="25px" style="margin-left: 0px; text-align: center;" Width="120px" 
                        Enabled="False" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

