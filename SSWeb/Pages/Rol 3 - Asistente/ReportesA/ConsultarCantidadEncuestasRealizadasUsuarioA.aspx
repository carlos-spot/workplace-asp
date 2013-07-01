<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 3 - Asistente/PrincipalAsistente.master" AutoEventWireup="false" CodeFile="ConsultarCantidadEncuestasRealizadasUsuarioA.aspx.vb" Inherits="Reporte_ConsultarCantidadEncuestasRealizadasUsuario" title="Cantidad de encuestas analizadas por un usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <div id= "PrincipalContenedor" style ="height: 500px">
    <div id= "Div1" style ="height: 4px">
             </div>
                <%--Div con el titulo de la pagina--%>
            <div id="DivTitulo" 
                
            style="height: 40px; width: 848px; text-align: left; margin-left: 58px; margin-top: 29px; margin-right: 0px;">
                <div style="width: 839px; height: 28px; margin-top: 9px; margin-left: 0px;">
                    <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" 
                        Font-Size="20pt" ForeColor="#000066" 
                        Text="Generar reporte de cantidad de encuestas analizadas por un usuario"></asp:Label>
                <asp:ListBox ID="ListBox1" runat="server" Height="16px" Width="50px" 
                        Visible="False">
                </asp:ListBox>
                </div>
            </div>
            
        <div id="descripcion" 
            style ="height: 51px; text-align:left; margin-left: 82px; width: 729px;">
        <p>Aquí puedes generar el reporte de la cantidad de encuestas que ha analizado un 
            usuario, solo debes seleccionar el usuario que deseas conocer la información y 
            dar click en consultar.</p>
        </div>
       <div id="combos" style ="height: 71px; text-align:left; margin-top: 37px;" >
        <div style="width: 220px; margin-left: 385px" >
        <asp:Label ID="lblUsuario" runat="server" Font-Size="11pt"  Text="Seleccione el usuario:" 
                        Font-Bold="True" Font-Names="Arial"></asp:Label></div>
        
            <asp:DropDownList ID="ddlUsuarios" runat="server" Height="20px" ToolTip="Temas" 
                Width="220px" style="margin-left: 384px">
            </asp:DropDownList>
            <br />
          
        </div>
        <div id="btnAceptar" style ="height: 30px; text-align:center; padding-top:30px" >
            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" Width="76px" />
        
        </div>
        <div id="lblError" style ="height: 100px; text-align:center; padding-top:10px" >
            <asp:Label ID="lblError" runat="server" Text="Label" Font-Size="12pt" ForeColor="Red"></asp:Label>
        &nbsp;<asp:ListBox ID="lbCodigosUsuarios" runat="server" Height="16px" Visible="False" 
                Width="16px"></asp:ListBox>
        </div>
    
    </div>
</asp:Content>

