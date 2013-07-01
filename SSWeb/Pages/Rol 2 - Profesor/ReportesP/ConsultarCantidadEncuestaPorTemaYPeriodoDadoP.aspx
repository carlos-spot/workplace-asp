<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="ConsultarCantidadEncuestaPorTemaYPeriodoDadoP.aspx.vb" Inherits="Reporte_ConsultarCantidadEncuestaPorTemaYPeriodoDado" title="Cantidad de encuestas de un tema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
       <div id= "PrincipalContenedor" style ="height: 500px">
    <div id= "Div1" style ="height: 7px">
             </div>
             
        <%--Div con el titulo de la pagina--%>
            <div id="DivTitulo" 
                
            style="height: 40px; width: 848px; text-align: left; margin-left: 58px; margin-top: 29px; margin-right: 0px;">
                <div style="width: 839px; height: 28px; margin-top: 9px; margin-left: 0px;">
                    <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" 
                        Font-Size="20pt" ForeColor="#000066" 
                        Text="Generar reporte de cantidad de encuestas por tema dado un periodo"></asp:Label>
                <asp:ListBox ID="ListBox1" runat="server" Height="16px" Width="50px" 
                        Visible="False">
                </asp:ListBox>
                </div>
            </div>
            
        <div id="descripcion" 
            style ="height: 51px; text-align:left; margin-left: 142px; width: 699px;">
            <p>Aqu&iacute; puedes generar el reporte de la cantidad de encuestas  que se han realizado, solo debes ingresar los criterios de la lista de temas y de peri&oacute;do.</p>
        </div>
        <div id="combos" style ="height: 182px; text-align:left; margin-top: 36px;" >
        <div style="width: 220px; margin-left: 376px" >
            <asp:Label ID="lblPeriodo" runat="server" Font-Size="11pt"  Text="Seleccione el tema:" 
                        Font-Bold="True" Font-Names="Arial"></asp:Label>
        </div>
        
            <asp:DropDownList ID="ddlTemas" runat="server" Height="20px" ToolTip="Temas" 
                Width="220px" style="margin-left: 374px">
            </asp:DropDownList>
            <br />
            <br />
            <div style="width: 214px; margin-left: 376px">
            <asp:Label ID="Label1" runat="server" Font-Size="11pt"  Text="Seleccione el periodo:" 
                        Font-Bold="True" Font-Names="Arial"></asp:Label>
            </div>
        <asp:DropDownList ID="ddlPeriodos" runat="server" Height="20px" ToolTip="Periódos" 
                Width="220px" style="margin-left: 373px">
            </asp:DropDownList>
            <br />
            <br />
        </div>
        <div id="btnAceptar" style ="height: 30px; text-align:center; padding-top:30px" >
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" Width="120px" 
                Height="25px" />
        
        </div>
        <div style ="height: 100px; text-align:center; padding-top:10px" >
            <asp:Label ID="lblError" runat="server" Text="Label" Font-Size="12pt" ForeColor="Red"></asp:Label>
        &nbsp;<asp:ListBox ID="lbCodigosTemas" runat="server" Height="16px" Visible="False" 
                Width="16px"></asp:ListBox>
            <asp:ListBox ID="lbCodigosPeriodos" runat="server" Height="16px" 
                Visible="False" Width="16px"></asp:ListBox>
        </div>
    
    </div>
</asp:Content>

