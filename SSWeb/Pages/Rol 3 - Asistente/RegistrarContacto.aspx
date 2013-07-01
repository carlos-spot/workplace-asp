<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 3 - Asistente/PrincipalAsistente.master" AutoEventWireup="false" CodeFile="RegistrarContacto.aspx.vb" Inherits="Pages_Rol_3___Asistente_RegistrarContacto" title="Registrar contacto" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">


 <div id="registrarContactoContent">
            <div id="Contenedor titulo" style="height: 128px;">
            <div style="text-align: center">
            .<br />.<br />
        <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" 
          Font-Size="20pt" ForeColor="#000066" 
                    Text="Registrar contacto" 
          style="text-align: center"></asp:Label>
            </div>
             
        
        <div id ="informacion"><p style="width: 609px; padding-left:200px; height: 45px;">Ingresa todos los datos requeridos para registrar el contacto, este aparecer&aacute; en la lista de contactos disponibles.</p></div>
            </div>
            <div id="campos" 
                
                        
                style =" width:631px; margin-bottom: 0px; padding-left :350px; text-align:left; height: 378px;">
               <div id= "id">
               
                       <h3 style="margin-right:10px; font-size:11pt; font-weight:normal">Nombre<asp:TextBox 
                               ID="txtNombre" runat="server" 
                               style="margin-left: 118px" MaxLength="30"></asp:TextBox></h3>
                        
                 
                </div>
                        <div id= "nombre">
                            <h3 style="font-size:11pt; font-weight:normal">
                                Primer apellido<asp:TextBox ID="txtPrimerAp" runat="server" 
                                    style="margin-left: 74px" MaxLength="30"></asp:TextBox></h3>
                        </div>
                        <div id= "primerAp">
                            <h3 style="font-size:11pt;font-weight:normal">
                                Segundo apellido<asp:TextBox ID="txtSegundoAp" runat="server" 
                                    style="margin-left: 59px" MaxLength="30"></asp:TextBox></h3>
                        </div>
                        <div id= "segundoap">
                            <h3 style ="font-size:11pt;font-weight:normal">
                                E-mail<asp:TextBox ID="txtEmail" runat="server" style="margin-left: 129px" 
                                    MaxLength="30"></asp:TextBox></h3>
                        </div>
                        <div id= "Div2">
                            <h3 style="font-size:11pt; font-weight:normal">
                                Teléfono 
                                <asp:TextBox ID="txtTelefono" runat="server" 
                                    style="margin-bottom: 0px; margin-left: 111px;" MaxLength="15"></asp:TextBox>
                            </h3>
                        </div>
                        <div id= "empresaDiv">
                            <h3 style="font-size:11pt;font-weight:normal">
                                Empresa<asp:DropDownList ID="cmbxEmpresa" runat="server" 
                                    style="margin-left: 110px" Width="157px">
                                </asp:DropDownList>
                                      </h3>
                </div>
                <div id="botonaceptar" style=" padding-left: 65px">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Height="25px" 
                        Width="120px" />
  
                &nbsp;&nbsp;&nbsp;<asp:Button ID="Cancelar" runat="server" Text="Regresar" 
                        Height="25px" Width="120px" />
                </div>
                <div id="error">
                   <h5 style =" color:Red; height: 19px; width: 549px; font-weight:normal"> <asp:Label ID="lblException" 
                           runat="server" Text="Label" Font-Size="11pt"></asp:Label></h5>
                </div>
            
            </div>
             
             
        </div>
</asp:Content>

