<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 3 - Asistente/PrincipalAsistente.master" AutoEventWireup="True" CodeFile="AgregarContactos.aspx.vb" Inherits="Pages_Rol_3___Asistente_AgregarContactos" title="Invitar Contactos" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">

 <div id="ContenedorPrincipal" style ="width:1000px; height: 595px;">
                    <div id="titulo" style=" width:1000px; height:35px">
                         <h1 style=" margin:0px 0">&nbsp;</h1>
                    </div>
                
                <!----contenedor de bonotes-->
                    <div id= "ContenedorBotones" style=" width:1000px; height: 45px;">
                       <div style =" width: 455px; margin-left: 263px;" >
                          
                        <asp:Button ID="btnClonacionContactos" runat="server" 
                           Text="Clonar contacto de encuesta" Height="25px" Width="200px" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnRegContacto" runat="server" Height="25px" 
                            Text="Registrar Contacto" Width="200px" />
                            </div>
                    </div>
                    
                    <!--contenedor grid encuestas--->
                  
                        <div id="encuesta" style="padding-top:5px">
                        
                        
                        <div id="DivContentInformacionLbls" 
            
                                
                                
                                style=" border-left: thin none #7DD780; border-right: thin none #7DD780; border-top: thin ridge #7DD780; border-bottom: thin ridge #7DD780; height:76px; margin-top:5px; margin-bottom:14px; width: 718px; margin-left: 133px;">
                      
                     <div id="ContentLeftLbl" style ="height:70px; width: 291px; float:left; padding-left:35px; margin-left: 28px;">
                         <b>Encuesta #</b> <asp:Label ID="lblIdEncuesta" runat="server" Text="Error Excepciones"></asp:Label><br />
                     <b>Nombre encuesta:</b><asp:Label ID="lblNombreEncuesta" runat="server" Text="Error Excepciones"></asp:Label><br />
                    <b>Fecha de inicio: </b><asp:Label ID="lblInicio" runat="server" Text="Error Excepciones"></asp:Label><br />
                    <b>Fecha de fin: </b><asp:Label ID="lblFin" runat="server" Text="Error Excepciones"></asp:Label>
                    
                     </div>
                     <div id="ContentRigLbl" 
                                
                                style ="height:70px; width: 258px; float:left; padding-left:100px; margin-left: 0px;">
                      <b>Poblaci&oacute;n: </b><asp:Label ID="lblPoblacion" runat="server" Text="Error Excepciones"></asp:Label><br />
                     <b>Muestra: </b><asp:Label ID="lblMuestra" runat="server" Text="Error Excepciones"></asp:Label><br />
                    <b>Margen: </b> <asp:Label ID="lblMargen" runat="server" Text="Error Excepciones"></asp:Label><br />
                    <b>Tema: </b><asp:Label ID="lblTema" runat="server" Text="Error Excepciones"></asp:Label>
                    
                     </div>
                 </div>
                
                </div><!----fin div grid-->
                <div id="textoDescripcion" style ="width:813px; height: 81px;">
                                <p style="text-align: center; margin-left:182px; width: 636px;">Seleccione los contactos de la tabla de contactos disponibles y agreguelos a la 
                        tabla de invitados.<br />
                                    También tiene la posibilidad de invitar personas que ya hayan participado con 
                                    anterioridad en una encuesta ingresando a la clonación de contactos de 
                        encuesta.</p>
                            <div id="jhjh" 
                                    style="height: 191px; width: 132px; margin-left: 840px; margin-top: 3px;">
                           <asp:Button ID="btnInvitar" runat="server" Height="26px" Text="Invitar" 
                      Width="101px" ToolTip="Enviar la invitación a participar en la encuesta" 
                                    style="margin-top: 59px" />
                      <br/><asp:Button ID="btnEnviarEnlace" runat="server" Height="25px" Text="Enviar enlace" 
                      Width="102px" ToolTip="Enviar el enlace y la contrasena a un contacto" 
                                    style="margin-top: 9px" />
                             <br />
               
                  <asp:Button ID="btnBorrar" runat="server" Height="25px" Text="Remover" 
                      Width="100px" style="margin-top: 10px" />
                        </div>
                        
                </div><!---fin texto descripcion---->
                    <div id="contenedorGrids" style=" width:823px; height:256px; margin-left:140px"> <!--contenedor texto-titulos grid--->
                        <div id="ContenedorIsq"  style=" width:301px; float:left;height:226px; " >
                            <div id="titloIzquierdoGrid" style=" width:296px; height:30px;">
                                <h2 style="padding-left:15px;">Lista de contactos disponibles</h2>
                            </div>
                            <div id="IzquierdoGrid" style=" width:300px; height:192px; " ><!---gridIzquierdo-->
                                <cc1:Grid ID="gContactos" runat="server" AllowPageSizeSelection="False" 
                                    AllowPaging="False" Height="230px" ShowFooter="False" Width="300px" 
                                    PageSize="0">
                                    <scrollingsettings scrollheight="230px" />
                                </cc1:Grid>
                            
                            </div>
                        </div><!-Contenedor botones medio-->
                        <div id="contenedorMedio"  
                            
                            style=" width:88px; float:left;height:126px; padding-top:100px; text-align:center">
                            <asp:Button ID="btnInvitarContacto" runat="server" Text="Agregar" 
                Height="25px" style =" vertical-align : middle" Width="80px"  />  
               
                            <br />
                            <asp:Label ID="lblException" runat="server" Text="Exception"></asp:Label>
                        </div>
                        <div id="ContenedorDerecho"  style=" width:432px; float:left;height:223px;"><!---gridDerecho-->
                             <div id="tituloDerechoGrid" style=" width:293px; height:30px;">
                                 <h2 style="padding-left:15px;">Lista de contactos invitados</h2>
                            </div>
                            <div id="DerechoGrid" style=" width:300px; height:195px; float:left;">
                                <cc1:Grid ID="gContactosInvitados" runat="server" AllowAddingRecords="False" 
                                    AllowPageSizeSelection="False" AllowPaging="False" AllowSorting="False" 
                                    Height="230px" PageSize="0" Width="300px" ShowFooter="False">
                                </cc1:Grid>
                         
                            </div>
                        
                    </div>
                        </div>
                         
                <!--fin texto-titulos grid--->
                   
                                <br />
                                <br />
                                <div id="div" style="height: 25px; text-align: right;">
                                  <asp:Button ID="btnAtras" runat="server" Text="Regresar" Width="120px" 
                            Height="25px" style="margin-right: 75px" />  
                                <div style="height: 19px; width: 318px; float: left; margin-left: 112px;">
                                    <asp:Label ID="lblInformacin" runat="server" Text="Label" Font-Size="11pt"></asp:Label>
                                    </div>
                             
                    </div>
                                <br />
                            
              </div>
        
        <!--- contenedor titulos y bontones-->
         
             
</asp:Content>

