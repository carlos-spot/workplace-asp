<%@ Page Language="VB" MasterPageFile="~/Pages/Portal/PrincipalPortal.master" AutoEventWireup="false" CodeFile="ValidarClaveAcceso.aspx.vb" Inherits="Pages_Portal_ValidarClaveAcceso" title="Responder encuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenedorPortal" Runat="Server">
  <%--Inicia el Div Principal--%>
  <div id="Principal">
        <%--Tituloo de la página--%>
        <div id="Titulo" style="height: 20px; width: 619px; float:left; margin-left: 17px; margin-top: 74px; font-size: 16pt; font-weight: 700;">
            ¿Cómo puedo responder una encuesta de Suvey System?
        </div>
        
        <%--Div que tiene los datos del usuario: El correo electronico y la clave de acceso--%>
        <div id="contenedorDatosParaRecuperar"  style=" float:right; border-left: thin none #66E0FF; border-right: thin none #66E0FF; border-top: thin solid #66E0FF; border-bottom: thin solid #66E0FF; float:left; height: 240px; width: 796px; margin-top: 44px; background-color: #D9F8FF; height: 236px; float:right; width: 293px; text-align: left; margin-left: 5px; margin-right: 35px; margin-top: 119px;">
            <%--Div dentro del div "contenedorDatosParaRecupera"--%>
            <div id="datosParaRecuperar"  style="width: 214px; height: 171px; margin-left: 44px; margin-top: 44px; margin-bottom: 1px">
                <%--Label y TexBox para el correo electrónico--%>
                <asp:Label ID="lblCorreoContacto" runat="server" Font-Size="12pt" Text="Correo electrónico:"></asp:Label>
                <br />
                <asp:TextBox ID="txtContacto" runat="server" Width="220px" Height="20px"></asp:TextBox>
                <br />
                <br />
                <%--Label y TexBox para la clave de acceso--%>
                <asp:Label ID="lblClave" runat="server" Font-Size="12pt" Text="Clave de acceso:"></asp:Label>
                <br />
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" 
                    AutoCompleteType="Disabled" Width="220px" Height="20px"></asp:TextBox>
                <br />
                <br />
                <%--Boton Ingresar--%>
                <asp:Button ID="btnIngresar" runat="server" Height="25px" Text="Ingresar" 
                    ToolTip="Ingresar mi nombre de usuario y contraseña." Width="120px" 
                    style="margin-top: 4px; margin-left: 44px;"/>
            </div>
        </div>
        
        <%--Div que contiene el parrrafo y la imagen--%>
        <div id="Parrafo" style=" float:left; height: 245px; width: 550px; text-align: left; margin-left: 54px; margin-top: 21px;">
            <%--Div que contiene la flecha verde de imagen--%>
            <div style="width: 65px; height: 1px; margin-left: 9px; margin-right: 0px; margin-top: 0px; margin-bottom: 0px;">
            </div>
            <p style="font-size:20px; text-align:center; width:431px; height: 229px; line-height: 25px; margin-left: 24px;" >
                Survey System presenta el módulo para responder 
                encuesta, este módulo facilita de una forma muy interactiva el proceso de 
                recolección de datos. Para acceder a ella ingrese la clave de acceso que se le 
                envió a su correo personal, despues ingrese su correo electrónico para verificar 
                su cuenta.
            </p>
        </div>
        
        <%--Div que contiene el mensaje de errror que se le muestra al usuario--%>
        <div style="float:left; width: 333px; text-align: center; margin-left: 622px; margin-top: 32px; height: 47px;">
            <asp:Label ID="lblMensaje" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>

