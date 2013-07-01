<%@ Page Title="" Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="GestionPreguntas.aspx.vb" Inherits="pages_Rol_2___Profesor_RegistrarPregunta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
       <div id="ff">
    
    <div id="principal" 
            style="width: 636px; margin-left: 0px; margin-top: 0px; height: 560px;">
        
        <%--Div con el titulo de la pagina--%>
        <div id="DivTitulo" 
            style="height: 40px; width: 437px; text-align: left; margin-left: 54px; margin-top: 29px; margin-right: 0px;">
            <div style="width: 427px; height: 28px; margin-top: 9px; margin-left: 0px;">
                <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" Font-Size="20pt" ForeColor="#000066" 
                    Text="Pila de pregunta"></asp:Label>
            </div>
        </div>
        <h4>
        <asp:Label ID="lblMod" runat="server"></asp:Label>
        </h4>
        <br />
        <div id="peq" style="font-size: small">
            <asp:Label ID="lblTipoP" runat="server" Text="Tipo de pregunta" 
                Font-Size="11pt"></asp:Label>
            <asp:DropDownList ID="cbxTipoPregunta" runat="server"
                Height="21px" Width="239px" style="margin-left: 14px">
                <asp:ListItem Enabled="False">--Seleccione--</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lblTema" runat="server" Text="Tema" Font-Size="11pt"></asp:Label>
            <asp:DropDownList ID="cbxTemas" runat="server"
                Height="21px" Width="243px" style="margin-left: 85px">
                <asp:ListItem Enabled="False">--RegresarRegresarRegresarSeleccione--</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />

            <asp:Label ID="lblTexto" runat="server" Text="Texto" Font-Size="11pt"></asp:Label>
            <asp:TextBox ID="txtTexto" runat="server" style="margin-left: 10px" 
                Height="69px" Width="320px" TextMode="MultiLine" Font-Names="Arial" 
                Font-Size="11pt"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Size="11pt"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" 
                Width="120px" Height="25px" style="margin-left: 71px" />
            <asp:Button ID="btnCancelar" runat="server" Text="Limpiar" 
                style="margin-left: 23px" Height="25px" Width="120px" />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" Height="26px" 
                style="margin-right: 32px; margin-left: 517px; margin-top: 45px;" 
                Width="87px" />
            <br />
        </div>
        </div>

</div>
</asp:Content>