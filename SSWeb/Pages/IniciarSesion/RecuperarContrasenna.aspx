<%@ Page Language="VB" MasterPageFile="~/Pages/IniciarSesion/IniciarSesion.master" AutoEventWireup="false" CodeFile="RecuperarContrasenna.aspx.vb" Inherits="Pages_IniciarSesion_RecuperarContrasenna" title="Recuperar contraseña" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoIniciarSesion" Runat="Server">
    
    <%--Inicia el div principal de la página--%>
    <div id="Principal" style="height:634px; text-align:center;">
        
        <%--Titulo de la página--%>
        <div id="DivTitulo" 
            
            style="float:left; height: 52px; width: 301px; text-align: left; margin-left: 99px; margin-top: 20px; margin-right: 0px;">
            <div style="width: 551px; height: 32px; margin-top: 0px; margin-left: 0px;">
                <asp:Label ID="lblRecuperar" runat="server" Enabled="False" Font-Names="Arial" 
                    Font-Size="20pt" ForeColor="#000066" Text="Recuperar contraseña"></asp:Label>
            </div>
        </div>
        
        <%--Div que contiene el botón "Regresar"--%>
        <div id="DivBotonRegresar" 
            
            style=" float:right; width: 69px; margin-right: 132px; margin-top: 28px; margin-left: 0px;">
       </div>
        
        <%--Div que contiene todos los datos  para recuperar la contraseña--%>
        <div id="SubPrincipal" 
            style="float:left; height: 492px; width: 981px; margin-top: 4px;">
            <%--Div que contiene la descripción para el módulo de recuperar contraseña--%>
            <div id="DivDescripcionModulo" style="border-left: thin none #00B000; border-right: thin none #00B000; border-top: thin solid #00B000; border-bottom: thin solid #00B000; float:left; height: 135px; width: 796px; background-color: #E3FFD7; text-align: left; margin-left: 98px; margin-top: 2px;">           
                 <div style="height: 93px; width: 87px; float:left; margin-left: 20px; margin-top: 18px;">
                     <asp:Image ID="Image2" runat="server" Height="87px" ImageUrl="~/imagenes/!.png" Width="75px" style="margin-top: 3px; margin-left: 7px;" />
                 </div>
                 <div id="Parrafo" style="float:right; height: 139px; width: 669px; margin-right: 0px;">
                    <p style="height: 58px; margin-top: 12px; margin-bottom: 0px;">
                        Para recuperar la contraseña el sistema le solicitará que 
                        introduzca el nombre de usuario y correo electrónico.
                    </p>
                    <p style="height: 58px; margin-top: 1px;">
                        El sistema le enviará automaticamente la nueva contraseña al buzón de su correo 
                        electrónico.
                    </p>
                 </div>
            </div>
            
            <%--Div que contiene los datos para recuperar la contraseña--%>
            <div id="DatosModulo" 
                style="border-left: thin none #66E0FF; border-right: thin none #66E0FF; border-top: thin solid #66E0FF; border-bottom: thin solid #66E0FF; float:left; height: 240px; width: 796px; margin-top: 30px; background-color: #D9F8FF; text-align: left; margin-left: 99px;">
                <div id="contenedorDatosParaRecuperar" style="float:left; height: 199px; width: 295px; margin-left: 0px;">
                    <div id="datosParaRecuperar" style="width: 214px; height: 149px; margin-left: 63px; margin-top: 44px; margin-bottom: 1px">
                        <%--Campo para el nombre de usuario--%>
                        <asp:Label ID="lblNombre" runat="server" Font-Size="12pt" Text="Nombre de usuario"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtNombre" runat="server" Width="208px"></asp:TextBox>
                        <br />
                        <br />
                        <%--Campo para el correo electrónico--%>
                        <asp:Label ID="lblCorreo" runat="server" Font-Size="12pt" Text="Correo electrónico"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCorreo" runat="server" Width="206px"></asp:TextBox>
                        <br />
                        <br />
                        <%--Campo para el botón "Recuperar"--%>
                        <asp:Button ID="btnRecuperar" runat="server" style="margin-left: 42px" 
                            Text="Recuperar" Width="120px" Height="25px" />
                    </div>
                </div>
                
                <%--Div que contiene la imagen del candado y Fecha--%>
                <div style="float:right; height: 199px; width: 496px;">
                    <%--Div imagen flecha verde--%>
                    <%--Div imagen candado--%>
                    <div style="float:right; width: 386px; height: 146px; margin-right: 22px; margin-top: 26px;">
                         <div style="height: 93px; width: 87px; float:left; margin-left: 20px; margin-top: 30px;">
                             <asp:Image ID="Image1" runat="server" Height="90px" ImageUrl="~/imagenes/encrypted.png" Width="84px" style="margin-top: 3px" />
                         </div>
                         <div style="float:right; width: 251px; height: 79px; margin-top: 35px;">
                            <p>¡Seguro, fácil y rápido recupera su contraseña con Survey System!</p>
                         </div>
                    </div>
                </div>
                
                <%--Div que contiene el Label donde se le mostrar los mensajes de error al usuario--%>
                <div style="float:left; width: 595px; height: 23px; margin-left: 59px; margin-top: 7px;">
                    <asp:Label ID="lblMensajeRecuperar" runat="server" Font-Size="12pt" ForeColor="Red"></asp:Label>
                </div> 
                 <%--Div que contiene el botón "Regresar"--%>
        <div id="Div1" 
            
                    style=" float:right; width: 146px; margin-right: 84px; margin-top: 28px; margin-left: 0px;">
            <asp:Button ID="btnRegresar" runat="server" Height="25px" Text="Regresar" 
                ToolTip="Regresar." Width="120px" 
                style="margin-top: 26px; margin-left: 27px;"/>
        </div>
            </div>
        </div>
    </div>
</asp:Content>
