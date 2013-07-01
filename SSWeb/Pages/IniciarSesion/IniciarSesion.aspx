<%@ Page Language="VB" AutoEventWireup="false" CodeFile="IniciarSesion.aspx.vb" Inherits="IniciarSesion" title="Iniciar sesión" MasterPageFile="IniciarSesion.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoIniciarSesion" Runat="Server">
    <%--Inicia el div Principal de la página--%>
    <div id="Principal" style="width: 972px; font-size: 16px; text-align:justify; padding-top: 10px; height: 446px; background-color: #FBFFFD; margin-left: 28px; margin-top: 0px;">
        <%--Titulo de la página--%>
        <div id="Titulo" style="height: 71px; width: 545px; float:left; margin-left: 55px; margin-top: 74px;">
            <h2 style="width: 300px; height: 26px; margin-left: 113px">
            ¿Qué es Survey System?
            </h2>
        </div>
        
        <%--Div que contiene los datos de usuario: Nombre de usuario, contreseña--%>
        <div id="contenedorDatosUsuario" style="border-left: thin none #66E0FF; border-right: thin none #66E0FF; border-top: thin solid #66E0FF; border-bottom: thin solid #66E0FF; float:left; height: 240px; width: 796px; margin-top: 44px; background-color: #D9F8FF; height: 250px; float:right; width: 293px; text-align: left; margin-left: 5px; margin-right: 35px; margin-top: 91px;">
            <%--Div con el Nombre de usuario, contreseña, y el botón ingresar--%>
            <div id="datosUsuario" style="width: 214px; height: 171px; margin-left: 44px; margin-top: 44px; margin-bottom: 1px">
                <%--Label y TexBox para el nombre de usuario--%>
                <asp:Label ID="lblUsuario" runat="server" Font-Size="12pt" Text="Nombre de usuario:"></asp:Label>
                <br />
                <asp:TextBox ID="txtUsuario" runat="server" Width="208px"></asp:TextBox>
                <br />
                <br />
                <%--Label y TexBox para la contraseña--%>
                <asp:Label ID="lblContrasenna" runat="server" Font-Size="12pt" Text="Contraseña:"></asp:Label>
                <br />
                <asp:TextBox ID="txtContrasenna" runat="server" TextMode="Password" AutoCompleteType="Disabled" Width="203px"></asp:TextBox>
                <br />
                <br />
                <%--Botón ingresar--%>
                <asp:Button ID="btnIngresar" runat="server" Height="25px" 
                    Text="Ingresar" ToolTip="Ingresar mi nombre de usuario y contraseña." 
                    Width="120px" style="margin-top: 4px; margin-left: 44px;"/>
            </div>
                
            <%--HyperLink para recuperar la contraseña--%>
            <div id="recuperarContrasenna" style=" margin-left: 40px; width: 251px; margin-top: 8px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="13pt" Font-Underline="True" 
                        NavigateUrl="~/Pages/IniciarSesion/RecuperarContrasenna.aspx">
                        ¿Ha olvidado su contraseña?
                    </asp:HyperLink>
                </div>
        </div>
        
        <%--Div con el párrafo de la página--%>
        <div id="Parrafo" style="height: 245px; width: 550px; text-align: center; margin-left: 54px;">
            <p style="font-size:20px; text-align:center; width:535px; height: 229px; line-height: 25px;" >
                Survey System es un sistema amigable diseñado para el modelado, captura y análisis 
                de la información de encuestas.

                Los procesos de Survey System son automáticos y amigables, logrará 
                recortar los tiempos de ejecución del estudio y el procesamiento manual en cada una 
                de sus etapas.
            </p>
        </div>
        
        <%--Div con el Label para mostrar los mensajes al usuario--%>
        <div style="float:left; width: 325px; text-align: center; margin-left: 638px;">
            <asp:Label ID="lblMensaje" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label>
        </div>
        
        <%--Div que contiene la imagen y Hiperlink para regresar al portal--%>
        <div style="margin-left: 709px; margin-top: 161px; font-size: 15px; height: 45px; width: 208px;">
            <asp:HyperLink ID="RegresarPortal" runat="server" Font-Bold="False" Font-Italic="False" Font-Size="13pt" Font-Underline="True" 
                NavigateUrl="~/index.aspx">Regresar al portal
            </asp:HyperLink>
            <a href="~/index.aspx">
                <asp:Image ID="Image2" runat="server" Height="38px" ImageAlign="Middle" ImageUrl="~/imagenes/atras.jpg" Width="36px" />
            </a>
        </div>
    </div>
    <%--Termina el div Principal--%>
</asp:Content>