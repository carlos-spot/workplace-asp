<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="MantenimientoProductoP.aspx.vb" Inherits="Pages_Rol_2___Profesor_MantenimientoProductoP" title="Mantenimiento de productos" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>
<%@ Register assembly="obout_Interface" namespace="Obout.Interface" tagprefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
     <%--Ingresamos ToolkitScriptManager para los controles de ajax--%>
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    
    <%--Inicia el div principal de la página--%>
    <div id="Principal " style="background-color:Transparent; width: 983px; height: 556px; margin-left: 0px; margin-right: auto; margin-top: 0px;" >
        <div id="derechaDiv1" style="float:right; height: 39px; width: 139px; margin-left: 0px; margin-top: 25px;"></div>
        <%--Div con el titulo de la pagina--%>
        <div id="izquierdaDiv1" style="float:left; height: 39px; width: 837px; margin-top: 25px;">
            <div id="DivPrincipalCabezera" style="height: 29px; width: 593px; text-align: center; margin-left: 141px; margin-top: 7px;">
                <asp:Label ID="lblMantenimiento" runat="server" Enabled="False" Font-Names="Arial" Font-Size="20pt" ForeColor="#000066" 
                    Text="Registrar productos"></asp:Label>
                <%--Ocultamos un ListBox para guardas los codigos de los temas--%>
                <asp:ListBox ID="lbCodigosTemas" runat="server" Height="26px" Width="48px" Visible="False">
                </asp:ListBox>
            </div>
        </div>
        
        <%--Div con los botones de "Guardar al registrar", "Guardar al modificar", "Limpiar los datos"--%>
        <div id="DivBotones" style="float:right; height: 148px; width: 137px;">
            <asp:Button ID="btnGuardarReg" runat="server" Text="Guardar" Width="120px" 
                Height="25px" style="margin-left: 1px; margin-top: 32px;"/>
            <asp:Button ID="btnGuardarMod" runat="server" Text="Guardar" Width="120px" 
                Visible="False" Height="25px" style="margin-left: 0px; margin-top: 26px;"/>
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="120px" 
                Height="25px" style="margin-left: 0px; margin-top: 25px;"  />
        </div>
        
        <%--Div que contiene los datos del producto--%>
        <div id="DivDatos" style="float:left; height: 151px; width: 837px;">
            <div id="DivDatosProducto" style="height: 137px; border: medium dotted #74B7DE; background-color: #D4D4D4; width: 717px; margin-left: 79px; text-align: center;">
                <%--Campo para el nombre del producto--%>
                <div id="DivNombreProducto" style="float:left; margin: 4px auto 0px 0px; height: 51px; width: 346px;" >
                <div id="DivSubNombreProducto" style="float:left; width: 257px; height: 47px; margin-left: 72px; margin-top: 7px; text-align: left;">
                    <asp:Label ID="lblNombre" runat="server" Font-Size="11pt" Text="Nombre para el nuevo producto:"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" Height="20px" Width="255px" 
                        MaxLength="50"></asp:TextBox>
                </div>
            </div>
            
                <%--Campo para la marca del producto--%>
                <div id="DivMarca" style="float:right; margin: 4px auto 0px 0px; height: 51px; width: 346px;">
                <div id="DivSubMarca" style="float:left; width: 265px; height: 48px; margin-left: 0px; margin-top: 7px; text-align: left;">
                    <asp:Label ID="lblNombre0" runat="server" Font-Size="11pt"  Text="Marca:"></asp:Label>
                    <asp:TextBox ID="txtMarca" runat="server" Height="20px" Width="255px" 
                        style="margin-left: 0px" MaxLength="50"></asp:TextBox>
                </div>
            </div>
            
                <%--Campo para el fabricante del producto--%>
                <div id="DivFabricante" style="float:left; margin: 4px auto 0px 0px; height: 56px; width: 346px;" >
                <div id="DivSubFabricante" style="float:left; width: 247px; height: 47px; margin-left: 73px; margin-top: 7px; text-align: left;">
                    <asp:Label ID="Label3" runat="server" Font-Size="11pt" Text="Fabricante:"></asp:Label>
                    <asp:TextBox ID="txtFabricante" runat="server" Height="20px" Width="255px" 
                        MaxLength="50"></asp:TextBox>
                </div>
            </div>
            
                <%--Campo para seleccionar el tema del producto--%>
                <div id="DivTema" style="float:right; margin: 4px auto 0px 0px; height: 56px; width: 346px;">
                <div id="DivSubTema" style="float:left; width: 263px; height: 48px; margin-left: 0px; margin-top: 7px; text-align: left;">
                    <asp:Label ID="Label4" runat="server" Font-Size="11pt"  Text="Tema:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlTemas" runat="server" Height="20px" Width="255px">
                    </asp:DropDownList>
                </div>
            </div>
            
                <%--Div que muestra los errores al usuario--%>
                <div id="DivMensajeError" style="float:right; margin: 0px auto 0px 0px; height: 22px; width: 716px;">
                <div id="Div3" style="float:inherit; width: 686px; height: 18px; margin-left: 0px; margin-top: 0px;">
                   <asp:Label ID="lblMensajeRegistrar" runat="server" Font-Size="11pt" ForeColor="#FF3300"></asp:Label>
                </div>
            </div>
            </div>
        </div>
        <div id="derechaDiv3" style="float:right; height: 36px; width: 106px; margin-left: 0px;"></div>
        
        <%--Div que contiene el campo para buscar los productos--%>
        <div id="DivBuscar" style="float:left; height: 51px; width: 870px;">
            <div id="subDivBuscar" style=" float:left; margin: 2px auto 0px 0px; background-color:Transparent; height: 50px; width: 832px;" >
                <div id="DivLblBuscar" style="float:left; height: 39px; width: 487px; margin-left: 143px;">
                    <asp:Label ID="lblCriterio" runat="server" Font-Size="11pt" Text="Ingrese el criterio de busqueda:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtCriterio" runat="server" Height="25px" Width="205px" 
                        style="margin-left: 0px; margin-top: 0px;" 
                        ToolTip="Criterios válidos: nombre, marca, fabricante y tema."></asp:TextBox>
                </div>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="120px" 
                    style="margin-left: 0px" Height="25px" />
            </div>
        </div>
        
        <div id="derechaDiv4" style="float:right; height: 32px; width: 104px;"></div>
        <%--Div que contiene el mensaje de busqueda que se le mostrara al usuario--%>
        <div id="divMensajeBusqueda" style="float:left; height: 21px; width: 868px; text-align: center;">
            <asp:Label ID="lblMensajeBuscar" runat="server" Font-Size="11pt" ForeColor="#FF3300" Visible="False"></asp:Label>
        </div>
        
        <%--Div que contiene los botones de "Modificar" y "Eliminar"--%>
        <div id="DivBotonesModificarEliminar" style="float:right; height: 197px; width: 137px;">
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="120px" 
                style="margin-left: 0px; margin-top: 33px" Height="25px" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Width="120px" 
                style="margin-left: 0px; margin-top: 25px" Height="25px" />
        </div>
        
        <%--Div que contiene la tabla donde mostraremos los datos de los productos--%>
        <div id="DivTablaGrind" style="float:left; height: 198px; width: 839px;">
            <div id="SubDivTablaGrind" 
                style="background-color:Transparent; height: 193px; text-align: center; margin-left: 98px; width: 724px; margin-top: 0px;">
                <cc1:Grid ID="tablaGrind" runat="server" AllowPageSizeSelection="False" PageSize="0" 
                    ShowFooter="False" ShowMultiPageGroupsInfo="False" AllowSorting="False" 
                    AllowMultiRecordSelection="False" Height="240px">
                    <ScrollingSettings ScrollHeight="240px" />
                    <LocalizationSettings NoRecordsText="No se encontraron temas registrados." />
                </cc1:Grid>
           </div>
        </div>
        
        <%--Div que contiene el control "ModalPopupExtender" de ajax, para mostrar los mensajes de confirmación--%>
        <div id="DivConfirmaciones" style="float:left; height: 31px; width: 840px;">
           <div style="display:run-in;">
                <ajaxToolkit:ModalPopupExtender 
                    ID="ModalPopudExtender" 
                    runat="server" 
                    TargetControlID="btnEliminar" 
                    PopupControlID="PNL" 
                    DropShadow="true" 
                    OkControlID="ButtonOk" 
                    CancelControlID="ButtonCancel" 
                    BackgroundCssClass="modalBackgroud">
                </ajaxToolkit:ModalPopupExtender>
                <ajaxToolkit:ModalPopupExtender 
                    ID="ModalPopupExtender1" 
                    runat="server" 
                    TargetControlID="btnGuardarMod" 
                    PopupControlID="PanelModificar" 
                    DropShadow="true" 
                    OkControlID="ButtonOk" 
                    CancelControlID="ButtonCancel2" 
                    BackgroundCssClass="modalBackgroud">
                </ajaxToolkit:ModalPopupExtender>
                <%--Panel que se mostrara cuando se precione el botón "Eliminar"--%>
                <asp:Panel ID="PNL" runat="server" Height="70px" Width="387px" style=" display:none; background-color:White; border-width:2px; border-color:Black; border-style:solid; padding:20px;" 
                    BorderColor="#00FF99" BorderStyle="Dashed" BorderWidth="100px">
                    <asp:Label ID="lblMensajeConfirm" runat="server" Font-Size="11pt"  Text="¿Estas seguro de que deseas elimiar este producto?"></asp:Label>
                    <br /><br />
                    <div style="text-align:right; width:288px;">
                        <asp:Button ID="ButtonOk" runat="server" Text="OK" OnClientClick="llamarMetodoDelServer('eliminar')" style="margin-left: 0px"  Width="79px" />
                        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" style="margin-left: 22px" Width="73px" />
                    </div>
                </asp:Panel>
                <%--Panel que se mostrara cuando se preciones el botón "Modificar"--%>
                <asp:Panel ID="PanelModificar" runat="server" Height="70px" Width="407px" style="display:none; background-color:White; border-width:2px; border-color:Black; border-style:solid; padding:20px;" 
                    BorderColor="#00FF99" BorderStyle="Dashed" BorderWidth="100px">
                    <asp:Label ID="Label1" runat="server" Font-Size="11pt"  Text="¿Estas seguro de que deseas modificar este producto?"></asp:Label>
                    <br /><br />
                    <div style="text-align:right; width:288px;">
                        <asp:Button ID="ButtonOk2" runat="server" Text="OK" OnClientClick="llamarMetodoDelServer('modificar')" style="margin-left: 0px"  Width="79px" />
                        <asp:Button ID="ButtonCancel2" runat="server" Text="Cancel" style="margin-left: 22px" Width="73px" />
                    </div>
                </asp:Panel>
           </div>
        </div>
        <div id="derechoDiv6" style="float:right; height: 33px; width: 134px;"></div>
     </div>
</asp:Content>

