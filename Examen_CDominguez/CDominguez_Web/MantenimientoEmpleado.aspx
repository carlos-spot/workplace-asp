<%--
MantenimientoEmpleado.aspx
Creada por: Carlos Dominguez Lara
Fecha de Creación: 25 de Noviembre del 2010
Fecha de Modificación: 25 de Noviembre del 2010
--%>

<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MantenimientoEmpleado.aspx.vb" Inherits="MantenimientoEmpleado" %>
<%--Hacemos las referencias para los dll que ingresamos--%>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Mantenimiento de empleado</title>
    <link href="CDominguezEstilo.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function llamarMetodoDelServer(pmetodo) {
            __doPostBack(pmetodo, "");
        }
    </script> 
</head>
<body>
    <form id="form1" runat="server">
        <%--Ingresamos el ScripManager para ajax--%>
        <ajaxtoolkit:toolkitscriptmanager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
        
        <%--Comienza el div principal--%>
        <div id="Principal" >
            <div id="Header">
                <h1 style="margin-top: 9px">Mantenimiento de empleado</h1>
            </div>
            <div id="derechaDiv1" style="float:right; height: 41px; width: 137px; margin-left: 0px; margin-top: 0px;"></div>
            <%--Div izquierdo que contiene el encabezado "Registrar un empleado"--%>
            <div id="divEncabezadoRegistrar" 
                style="float:left; height: 39px; width: 820px; margin-top: 2px;">
                <div id="DivPrincipalCabezera" 
                    style="height: 29px; width: 593px; text-align: center; margin-left: 178px; margin-top: 7px;">
                    <asp:Label ID="lblMantenimiento" runat="server" Font-Size="11pt"  Text="Registrar un empleado" style="font-weight: 700; font-size: 15pt"></asp:Label>
                    <%--ListBox donde guardaremos los codigo de los departamentos que se seleccionen--%>
                    <asp:ListBox ID="lbDepartamentos" runat="server" Height="26px" Width="48px" Visible="False"></asp:ListBox>
                </div>
            </div>
            
            <%--Div derecho que tiene los botones de guardar y Limpiar--%>
            <div id="DivDerechoBotones" style="float:right; height: 290px; width: 137px;">
                <%--Boton que guarda los registros de los nuevos empleados--%>
                <asp:Button ID="btnGuardarReg" runat="server" Text="Guardar" Width="100px" 
                    Height="39px" style="margin-left: 1px; margin-top: 32px;" TabIndex="8"/>
                <%--Boton que guarda las modificaciones a los empleados--%> 
                <asp:Button ID="btnGuardarMod" runat="server" Text="Guardar" Width="100px" Visible="False" Height="39px" style="margin-left: 0px; margin-top: 26px;"/>
                <%--Boton que limpia los datos de las cajas de texto--%>
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="100px" Height="39px" style="margin-left: 0px; margin-top: 25px;"  />
            </div>
            
            <%--Div izquierdo que contiene un div con los datos de los empleados--%>
            <div id="DivIzquierdoDatos" style="float:left; height: 293px; width: 822px;">
                <div id="DivDatosEmpleado" 
                    
                    style="height: 263px; border: medium dotted #74B7DE; background-color: #D4D4D4; width: 649px; margin-left: 147px; text-align: center;">
                    <%--Nombre del empleado--%>
                    <div id="DivNombre" style="float:left; margin: 4px auto 0px 0px; height: 47px; width: 320px;" >
                        <div id="subDivNombre" style="float:left; width: 257px; height: 38px; margin-left: 32px; margin-top: 7px; text-align: left;">
                            <asp:Label ID="lblNombre" runat="server" Font-Size="11pt" Text="Nombre:"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtNombre" runat="server" Height="22px" Width="230px" 
                                MaxLength="50" TabIndex="1"></asp:TextBox>
                        </div>
                    </div>
                    
                    <%--Identificación del empleado--%>
                    <div id="DivIdentificacion" style="float:right; margin: 4px auto 0px 0px; height: 47px; width: 320px;" >
                        <div id="subDivIdentificacion" style="float:left; width: 257px; height: 38px; margin-left: 32px; margin-top: 7px; text-align: left;">
                            <asp:Label ID="lblIdientificacion" runat="server" Font-Size="11pt" Text="Identificacion:"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtIdentificacion" runat="server" Height="22px" Width="230px" 
                                MaxLength="50" TabIndex="4"></asp:TextBox>
                        </div>
                    </div>
                    
                    <%--Apellidos del empleado--%>
                    <div id="DivApellidos" style="float:left; width: 320px; height: 47px; margin-left: 0px; margin-top: 7px; text-align: left;">
                        <div id="subDivApellidos" style="float:left; width: 247px; height: 40px; margin-left: 34px; margin-top: 7px; text-align: left;">
                            <asp:Label ID="lblApellidos" runat="server" Font-Size="11pt" Text="Apellidos:"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtApellidos" runat="server" Height="22px" Width="230px" 
                                MaxLength="50" TabIndex="2"></asp:TextBox>
                        </div>
                    </div>
                    
                    <%--Departamento del empleado--%>
                    <div id="DivDepartamentos"  style="float:right; width: 320px; height: 47px; margin-left: 0px; margin-top: 7px; text-align: left;">
                        <div id="subDivDepartamento" style="float:left; width: 247px; height: 40px; margin-left: 34px; margin-top: 7px; text-align: left;">
                            <asp:Label ID="lblDepartamento" runat="server" Font-Size="11pt" Text="Departamento:"></asp:Label>
                            <br />
                            <asp:DropDownList ID="ddlDepartamentos" runat="server" Height="20px" 
                                Width="230px" TabIndex="5">
                            </asp:DropDownList>
                        </div>
                    </div>
                
                    <%--Direccion del empleado--%>
                    <div id="DivDireccion" 
                        
                        
                        style="float:left; width: 311px; height: 98px; margin-left: 0px; margin-top: 7px; text-align: left;">
                        <div id="subDivDireccion" 
                            style="float:left; width: 247px; height: 80px; margin-left: 34px; margin-top: 7px; text-align: left;">
                            <asp:Label ID="lblDireccion" runat="server" Font-Size="11pt" Text="Dirección:"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtDireccion" runat="server" Height="75px" Width="230px" 
                                MaxLength="50" TabIndex="3"></asp:TextBox>
                        </div>
                    </div>
                
                    <%--Puesto del empleado--%>
                    <div id="DivPuesto" style="float:right; width: 320px; height: 47px; margin-left: 0px; margin-top: 7px; text-align: left;">
                        <div id="subDivPuesto" style="float:left; width: 247px; height: 40px; margin-left: 34px; margin-top: 7px; text-align: left;">
                            <asp:Label ID="lblPuesto" runat="server" Font-Size="11pt" Text="Puesto:"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtPuesto" runat="server" Height="22px" Width="230px" 
                                MaxLength="50" TabIndex="6"></asp:TextBox>
                        </div>
                    </div>
                    
                    <%--Telefono del empleado--%>  
                    <div id="DivTelefono" 
                        
                        
                        style="float:right; height: 62px; margin-left: 0px; margin-top: 7px; text-align: left; width: 317px;">
                        <div id="subDivTelefono" 
                            style="float:left; width: 247px; height: 40px; margin-left: 34px; margin-top: 7px; text-align: left; margin-right: 0px;">
                            <asp:Label ID="lblTelefono" runat="server" Font-Size="11pt" Text="Teléfono:"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtTelefono" runat="server" Height="22px" Width="230px" 
                                MaxLength="50" TabIndex="7"></asp:TextBox>
                        </div>
                    </div>       
                
                    <div style="float:left; width: 311px; height: 1px;"></div>  
                   
                    <%--Label con el que se le mostraran los errores al usuario--%>
                    <div id="DivMensajeRegistrar" style="float:right; margin: 0px auto 0px 0px; height: 22px; width: 632px;">
                        <div id="subDivMensajeRegistrar" style="float:inherit; width: 607px; height: 18px; margin-left: 0px; margin-top: 0px;">
                           <asp:Label ID="lblMensajeRegistrar" runat="server" Font-Size="11pt" ForeColor="#FF3300"></asp:Label>
                        </div>
                    </div>
            </div>
            </div>
            
            <div id="derechaDiv3"  
                
                
                style="float:right; height: 51px; width: 135px; margin-left: 0px; margin-top: 19px;"></div>
            
            <%--Div izquierdo que donde se ingresa el criterio de busqueda--%>
            <div id="DivBuscar" 
                style="float:left; height: 51px; width: 821px; margin-top: 16px;">
                <div id="subDivBuscar" 
                    style=" float:left; margin: 2px auto 0px 0px; background-color:Transparent; height: 50px; width: 803px;" >
                <div id="DivLblBuscar" style="float:left; height: 39px; width: 487px; margin-left: 143px;">
                    <asp:Label ID="lblCriterio" runat="server" Font-Size="11pt" Text="Ingrese el criterio de busqueda:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtCriterio" runat="server" Height="25px" Width="205px" style="margin-left: 0px; margin-top: 0px;"></asp:TextBox>
                </div>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100px" style="margin-left: 0px" Height="39px" />
            </div>
            </div>
            
            <div id="derechaDiv4" style="float:right; height: 18px; width: 135px;"></div>
            
            <%--Label con el que se le mostraran los errores al usuario en la busqueda--%>
            <div id="DivLblMensajeBusqueda" 
                style="float:left; height: 21px; width: 819px; text-align: center;">
                <asp:Label ID="lblMensajeBuscar" runat="server" Font-Size="11pt" ForeColor="#FF3300" Visible="False"></asp:Label>
            </div>
            
            <%--Div derecho que tiene los botones de Modificar y Eliminar--%>
            <div id="DivModificarEliminar" 
                style="float:right; height: 194px; width: 137px;">
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="100px" style="margin-left: 0px; margin-top: 33px" Height="39px" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Width="99px" style="margin-left: 0px; margin-top: 25px" Height="36px" />
            </div>
            
            <%--Div izquierdo que contiene el Grind donde mostramos los datos--%>
            <div id="DivTabla" 
                style="float:left; height: 198px; width: 793px; text-align: left;">
                <div id="subDivTabla" 
                    
                    style="background-color:Transparent; height: 193px; text-align: center; margin-left: 269px; width: 552px; margin-top: 0px;">
                <cc1:Grid ID="tablaGrind" runat="server" AllowPageSizeSelection="False" PageSize="0" 
                    ShowFooter="False" ShowMultiPageGroupsInfo="False" AllowSorting="False" 
                    AllowMultiRecordSelection="False">
                    <ScrollingSettings ScrollHeight="240px" />
                    <LocalizationSettings NoRecordsText="No se encontraron temas registrados." />
                </cc1:Grid>
           </div>
            </div>
            
            <%--Div izquierdo que contiene los paneles de confirmacion para eliminar y modificar un empleado--%>
            <div id="divPanelDeConfirmacion" 
                style="float:right; height: 23px; width: 789px;">
                <ajaxtoolkit:modalpopupextender 
                    ID="ModalPopudExtender" 
                    runat="server" 
                    TargetControlID="btnEliminar" 
                    PopupControlID="PNL" 
                    DropShadow="true" 
                    OkControlID="ButtonOk" 
                    CancelControlID="ButtonCancel" 
                    BackgroundCssClass="modalBackgroud">
                </ajaxtoolkit:modalpopupextender>
                <ajaxtoolkit:modalpopupextender 
                    ID="ModalPopupExtender1" 
                    runat="server" 
                    TargetControlID="btnGuardarMod" 
                    PopupControlID="PanelModificar" 
                    DropShadow="true" 
                    OkControlID="ButtonOk" 
                    CancelControlID="ButtonCancel2" 
                    BackgroundCssClass="modalBackgroud">
                </ajaxtoolkit:modalpopupextender>
                <asp:Panel ID="PNL" runat="server" Height="70px" Width="387px" style=" display:none; background-color:White; border-width:2px; border-color:Black; border-style:solid; padding:20px;" 
                    BorderColor="#00FF99" BorderStyle="Dashed" BorderWidth="100px">
                    <asp:Label ID="lblMensajeConfirm" runat="server" Font-Size="11pt"  Text="¿Estas seguro de que deseas elimiar este empleado?"></asp:Label>
                    <br /><br />
                    <div style="text-align:right; width:288px;">
                        <asp:Button ID="ButtonOk" runat="server" Text="OK" OnClientClick="llamarMetodoDelServer('eliminar')" style="margin-left: 0px"  Width="79px" />
                        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" 
                            style="margin-left: 22px" Width="73px" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelModificar" runat="server" Height="70px" Width="407px" style="display:none; background-color:White; border-width:2px; border-color:Black; border-style:solid; padding:20px;" 
                    BorderColor="#00FF99" BorderStyle="Dashed" BorderWidth="100px">
                    <asp:Label ID="Label1" runat="server" Font-Size="11pt"  Text="¿Estas seguro de que deseas modificar este empleado?"></asp:Label>
                    <br /><br />
                    <div style="text-align:right; width:288px;">
                        <asp:Button ID="ButtonOk2" runat="server" Text="OK" OnClientClick="llamarMetodoDelServer('modificar')" style="margin-left: 0px"  Width="79px" />
                        <asp:Button ID="ButtonCancel2" runat="server" Text="Cancel" style="margin-left: 22px" Width="73px" />
                    </div>
                </asp:Panel>
            </div>
            <div id="derechoDiv6" style="float:left; height: 27px; width: 160px;"></div>
            
        </div>
    </form>
</body>
</html>
